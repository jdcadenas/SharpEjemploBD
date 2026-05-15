/*
 * Creado por SharpDevelop.
 * Usuario: usuario1
 * Fecha: 15/5/2026
 * Hora: 11:19 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ejemploBd
{
	partial class GestionModulos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvModulos = new System.Windows.Forms.DataGridView();
			this.btnVerPreguntas = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvModulos
			// 
			this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvModulos.Location = new System.Drawing.Point(32, 23);
			this.dgvModulos.Name = "dgvModulos";
			this.dgvModulos.Size = new System.Drawing.Size(435, 198);
			this.dgvModulos.TabIndex = 0;
			// 
			// btnVerPreguntas
			// 
			this.btnVerPreguntas.Location = new System.Drawing.Point(213, 240);
			this.btnVerPreguntas.Name = "btnVerPreguntas";
			this.btnVerPreguntas.Size = new System.Drawing.Size(75, 23);
			this.btnVerPreguntas.TabIndex = 1;
			this.btnVerPreguntas.Text = "Preguntas";
			this.btnVerPreguntas.UseVisualStyleBackColor = true;
			this.btnVerPreguntas.Click += new System.EventHandler(this.BtnVerPreguntasClick);
			// 
			// GestionModulos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 289);
			this.Controls.Add(this.btnVerPreguntas);
			this.Controls.Add(this.dgvModulos);
			this.Name = "GestionModulos";
			this.Text = "GestionModulos";
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnVerPreguntas;
		private System.Windows.Forms.DataGridView dgvModulos;
	}
}
