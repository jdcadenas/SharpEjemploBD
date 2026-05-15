/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 15/5/2026
 * Hora: 10:42 a. m.
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
			this.btnVerPregunta = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvModulos
			// 
			this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvModulos.Location = new System.Drawing.Point(140, 64);
			this.dgvModulos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvModulos.Name = "dgvModulos";
			this.dgvModulos.ReadOnly = true;
			this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvModulos.Size = new System.Drawing.Size(668, 233);
			this.dgvModulos.TabIndex = 1;
			// 
			// btnVerPregunta
			// 
			this.btnVerPregunta.Location = new System.Drawing.Point(356, 346);
			this.btnVerPregunta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnVerPregunta.Name = "btnVerPregunta";
			this.btnVerPregunta.Size = new System.Drawing.Size(259, 62);
			this.btnVerPregunta.TabIndex = 2;
			this.btnVerPregunta.Text = "Ver pregunta";
			this.btnVerPregunta.UseVisualStyleBackColor = true;
			this.btnVerPregunta.Click += new System.EventHandler(this.BtnVerPreguntaClick);
			// 
			// GestionModulos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(921, 457);
			this.Controls.Add(this.btnVerPregunta);
			this.Controls.Add(this.dgvModulos);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "GestionModulos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GestionModulos";
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btnVerPregunta;
		private System.Windows.Forms.DataGridView dgvModulos;
	}
}
