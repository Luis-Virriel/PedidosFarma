namespace PedidosFarma
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            codigo = new TextBox();
            label1 = new Label();
            listado = new ListView();
            agregar = new Button();
            lblpedidos = new Label();
            copiar = new Button();
            SuspendLayout();
            // 
            // codigo
            // 
            codigo.Location = new Point(99, 57);
            codigo.Name = "codigo";
            codigo.Size = new Size(176, 23);
            codigo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 29);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "Medicamento";
            // 
            // listado
            // 
            listado.Location = new Point(480, 29);
            listado.Name = "listado";
            listado.Size = new Size(298, 378);
            listado.TabIndex = 2;
            listado.UseCompatibleStateImageBehavior = false;
            listado.View = View.Details;
            // 
            // agregar
            // 
            agregar.Location = new Point(149, 97);
            agregar.Name = "agregar";
            agregar.Size = new Size(75, 23);
            agregar.TabIndex = 3;
            agregar.Text = "Agregar";
            agregar.UseVisualStyleBackColor = true;
            // 
            // lblpedidos
            // 
            lblpedidos.AutoSize = true;
            lblpedidos.Location = new Point(647, 410);
            lblpedidos.Name = "lblpedidos";
            lblpedidos.Size = new Size(131, 15);
            lblpedidos.TabIndex = 4;
            lblpedidos.Text = "Medicamentos pedidos";
            // 
            // copiar
            // 
            copiar.Location = new Point(480, 413);
            copiar.Name = "copiar";
            copiar.Size = new Size(75, 23);
            copiar.TabIndex = 5;
            copiar.Text = "Copiar";
            copiar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(copiar);
            Controls.Add(lblpedidos);
            Controls.Add(agregar);
            Controls.Add(listado);
            Controls.Add(label1);
            Controls.Add(codigo);
            Name = "Form1";
            Text = "PedidosFarma";
            ResumeLayout(false);
            PerformLayout();
        }

        public TextBox codigo;
        public Label label1;
        public ListView listado;
        public Button agregar;
        public Label lblpedidos;
        private Button copiar;
    }
}