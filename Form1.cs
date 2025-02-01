using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;

namespace PedidosFarma
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> listaMedicamentos = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            string rutaArchivo = Path.Combine(Application.StartupPath, "Archivos", "Planilla.xlsx");
            CargarMedicamentosDesdeExcel(rutaArchivo); // Usar la ruta correcta
            agregar.Click += Agregar_Click; // Asociar evento al botón Agregar.
            copiar.Click += CopiarMedicamentos_Click; // Asociar evento al botón Copiar
        }

        private void CargarMedicamentosDesdeExcel(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show($"El archivo '{rutaArchivo}' no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new FileInfo(rutaArchivo)))
                {
                    var hoja = package.Workbook.Worksheets[0]; // Primera hoja
                    int filas = hoja.Dimension.Rows;

                    // Limpiar lista antes de cargar nuevos datos
                    listaMedicamentos.Clear();

                    for (int i = 2; i <= filas; i++) // Comienza desde la fila 2 (salta el encabezado)
                    {
                        string codigo = hoja.Cells[i, 1].Text.Trim(); // Columna 1: Código
                        string nombre = hoja.Cells[i, 2].Text.Trim(); // Columna 2: Nombre

                        // Depuración: Verificar qué código y nombre se están leyendo
                        Console.WriteLine($"Leyendo - Fila: {i}, Código: '{codigo}', Nombre: '{nombre}'");

                        // Guardamos el medicamento en el diccionario
                        if (!string.IsNullOrEmpty(codigo) && !string.IsNullOrEmpty(nombre))
                        {
                            listaMedicamentos[codigo] = nombre;
                        }
                    }
                }

                MessageBox.Show("Medicamentos cargados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar medicamentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = codigo.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                MessageBox.Show("Por favor, ingrese un código de medicamento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            Console.WriteLine($"Buscando el código: {codigoIngresado}");

            if (listaMedicamentos.TryGetValue(codigoIngresado, out string nombreMedicamento))
            {
                ListViewItem item = new ListViewItem(codigoIngresado);
                item.SubItems.Add(nombreMedicamento);
                listado.Items.Add(item);
                codigo.Clear();
            }
            else
            {
                MessageBox.Show("El código ingresado no se encuentra en la lista de medicamentos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopiarMedicamentos_Click(object sender, EventArgs e)
        {

            try
            {
               
                StringBuilder sb = new StringBuilder();

                
                foreach (ListViewItem item in listado.Items)
                {
                    // Concatenar solo el nombre del medicamento (columna B)
                    sb.AppendLine(item.SubItems[1].Text); // SubItems[1] es el nombre del medicamento
                }

                
                Clipboard.SetText(sb.ToString());

                
                MessageBox.Show("Los nombres de los medicamentos han sido copiados al portapapeles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No tienes ningún medicamento cargado aún.");
                
            }
            
            
        }
    }
}