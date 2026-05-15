/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 15/05/2026
 * Hora: 11:25
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
			this.btnPreguntas = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvModulos
			// 
			this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvModulos.Location = new System.Drawing.Point(37, 34);
			this.dgvModulos.Name = "dgvModulos";
			this.dgvModulos.Size = new System.Drawing.Size(450, 219);
			this.dgvModulos.TabIndex = 0;
			// 
			// btnPreguntas
			// 
			this.btnPreguntas.Location = new System.Drawing.Point(378, 297);
			this.btnPreguntas.Name = "btnPreguntas";
			this.btnPreguntas.Size = new System.Drawing.Size(97, 50);
			this.btnPreguntas.TabIndex = 1;
			this.btnPreguntas.Text = "Preguntas";
			this.btnPreguntas.UseVisualStyleBackColor = true;
			this.btnPreguntas.Click += new System.EventHandler(this.BtnPreguntasClick);
			// 
			// GestionModulos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 395);
			this.Controls.Add(this.btnPreguntas);
			this.Controls.Add(this.dgvModulos);
			this.Name = "GestionModulos";
			this.Text = "GestionModulos";
			this.Load += new System.EventHandler(this.GestionModulos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnPreguntas;
		private System.Windows.Forms.DataGridView dgvModulos;
	}
}
