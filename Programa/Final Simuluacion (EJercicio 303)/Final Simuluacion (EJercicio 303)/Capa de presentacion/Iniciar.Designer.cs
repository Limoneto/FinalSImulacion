namespace Final_Simuluacion__EJercicio_303_.Capa_de_presentacion
{
    partial class Iniciar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInicar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInicar
            // 
            this.btnInicar.Location = new System.Drawing.Point(298, 97);
            this.btnInicar.Name = "btnInicar";
            this.btnInicar.Size = new System.Drawing.Size(111, 42);
            this.btnInicar.TabIndex = 0;
            this.btnInicar.Text = "Iniciar";
            this.btnInicar.UseVisualStyleBackColor = true;
            this.btnInicar.Click += new System.EventHandler(this.btnInicar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(72, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "El siguiente final esta hecho por Juan Manuel Casella | legajo: 78139";
            // 
            // Iniciar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInicar);
            this.Name = "Iniciar";
            this.Text = "Iniciar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInicar;
        private System.Windows.Forms.Label label1;
    }
}