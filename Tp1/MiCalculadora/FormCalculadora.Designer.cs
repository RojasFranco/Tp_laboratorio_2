namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxOperacion = new System.Windows.Forms.ComboBox();
            this.textSegundoNumero = new System.Windows.Forms.TextBox();
            this.textPrimerNumero = new System.Windows.Forms.TextBox();
            this.buttonOperar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonConvertABinario = new System.Windows.Forms.Button();
            this.buttonConvertADecimal = new System.Windows.Forms.Button();
            this.labelMostrarResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxOperacion
            // 
            this.comboBoxOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOperacion.FormattingEnabled = true;
            this.comboBoxOperacion.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.comboBoxOperacion.Location = new System.Drawing.Point(195, 47);
            this.comboBoxOperacion.Name = "comboBoxOperacion";
            this.comboBoxOperacion.Size = new System.Drawing.Size(117, 37);
            this.comboBoxOperacion.TabIndex = 1;
            // 
            // textSegundoNumero
            // 
            this.textSegundoNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSegundoNumero.Location = new System.Drawing.Point(368, 49);
            this.textSegundoNumero.Name = "textSegundoNumero";
            this.textSegundoNumero.Size = new System.Drawing.Size(115, 35);
            this.textSegundoNumero.TabIndex = 2;
            // 
            // textPrimerNumero
            // 
            this.textPrimerNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrimerNumero.Location = new System.Drawing.Point(12, 47);
            this.textPrimerNumero.Name = "textPrimerNumero";
            this.textPrimerNumero.Size = new System.Drawing.Size(115, 35);
            this.textPrimerNumero.TabIndex = 0;
            // 
            // buttonOperar
            // 
            this.buttonOperar.Location = new System.Drawing.Point(12, 132);
            this.buttonOperar.Name = "buttonOperar";
            this.buttonOperar.Size = new System.Drawing.Size(141, 40);
            this.buttonOperar.TabIndex = 3;
            this.buttonOperar.Text = "Operar";
            this.buttonOperar.UseVisualStyleBackColor = true;
            this.buttonOperar.Click += new System.EventHandler(this.ButtonOperar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(181, 132);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(143, 40);
            this.buttonLimpiar.TabIndex = 4;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(347, 132);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(136, 40);
            this.buttonCerrar.TabIndex = 5;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.ButtonCerrar_Click);
            // 
            // buttonConvertABinario
            // 
            this.buttonConvertABinario.Location = new System.Drawing.Point(12, 194);
            this.buttonConvertABinario.Name = "buttonConvertABinario";
            this.buttonConvertABinario.Size = new System.Drawing.Size(214, 40);
            this.buttonConvertABinario.TabIndex = 6;
            this.buttonConvertABinario.Text = "Convertir a binario";
            this.buttonConvertABinario.UseVisualStyleBackColor = true;
            this.buttonConvertABinario.Click += new System.EventHandler(this.ButtonConvertABinario_Click);
            // 
            // buttonConvertADecimal
            // 
            this.buttonConvertADecimal.Location = new System.Drawing.Point(268, 194);
            this.buttonConvertADecimal.Name = "buttonConvertADecimal";
            this.buttonConvertADecimal.Size = new System.Drawing.Size(215, 40);
            this.buttonConvertADecimal.TabIndex = 7;
            this.buttonConvertADecimal.Text = "Convertir a decimal";
            this.buttonConvertADecimal.UseVisualStyleBackColor = true;
            this.buttonConvertADecimal.Click += new System.EventHandler(this.ButtonConvertADecimal_Click);
            // 
            // labelMostrarResultado
            // 
            this.labelMostrarResultado.AutoSize = true;
            this.labelMostrarResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarResultado.Location = new System.Drawing.Point(347, 9);
            this.labelMostrarResultado.MinimumSize = new System.Drawing.Size(132, 20);
            this.labelMostrarResultado.Name = "labelMostrarResultado";
            this.labelMostrarResultado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelMostrarResultado.Size = new System.Drawing.Size(132, 20);
            this.labelMostrarResultado.TabIndex = 8;
            this.labelMostrarResultado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 246);
            this.Controls.Add(this.labelMostrarResultado);
            this.Controls.Add(this.buttonConvertADecimal);
            this.Controls.Add(this.buttonConvertABinario);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonOperar);
            this.Controls.Add(this.textPrimerNumero);
            this.Controls.Add(this.textSegundoNumero);
            this.Controls.Add(this.comboBoxOperacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Franco Rojas del curso 2°C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOperacion;
        private System.Windows.Forms.TextBox textSegundoNumero;
        private System.Windows.Forms.TextBox textPrimerNumero;
        private System.Windows.Forms.Button buttonOperar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonConvertABinario;
        private System.Windows.Forms.Button buttonConvertADecimal;
        private System.Windows.Forms.Label labelMostrarResultado;
    }
}

