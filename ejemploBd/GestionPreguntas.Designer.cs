/*
 * Creado por SharpDevelop.
 * Usuario: usuario1
 * Fecha: 15/5/2026
 * Hora: 11:36 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ejemploBd
{
	partial class GestionPreguntas
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
			this.dgvPreguntas = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvPreguntas
			// 
			this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPreguntas.Location = new System.Drawing.Point(45, 40);
			this.dgvPreguntas.Name = "dgvPreguntas";
			this.dgvPreguntas.Size = new System.Drawing.Size(388, 150);
			this.dgvPreguntas.TabIndex = 0;
			// 
			// GestionPreguntas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 261);
			this.Controls.Add(this.dgvPreguntas);
			this.Name = "GestionPreguntas";
			this.Text = "GestionPreguntas";
			((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView dgvPreguntas;
	}
}
