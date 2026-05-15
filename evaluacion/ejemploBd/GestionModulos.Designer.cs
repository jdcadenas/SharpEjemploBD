namespace ejemploBd
{
	partial class GestionModulos
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dgvModulos;
		private System.Windows.Forms.TextBox txtNombreEs;
		private System.Windows.Forms.TextBox txtNombreEn;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionModulos));
			this.dgvModulos = new System.Windows.Forms.DataGridView();
			this.txtNombreEs = new System.Windows.Forms.TextBox();
			this.txtNombreEn = new System.Windows.Forms.TextBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BtnVerPreguntas = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvModulos
			// 
			this.dgvModulos.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvModulos.Location = new System.Drawing.Point(25, 29);
			this.dgvModulos.Name = "dgvModulos";
			this.dgvModulos.Size = new System.Drawing.Size(439, 234);
			this.dgvModulos.TabIndex = 0;
			// 
			// txtNombreEs
			// 
			this.txtNombreEs.Location = new System.Drawing.Point(164, 296);
			this.txtNombreEs.Name = "txtNombreEs";
			this.txtNombreEs.Size = new System.Drawing.Size(262, 20);
			this.txtNombreEs.TabIndex = 1;
			// 
			// txtNombreEn
			// 
			this.txtNombreEn.Location = new System.Drawing.Point(164, 357);
			this.txtNombreEn.Name = "txtNombreEn";
			this.txtNombreEn.Size = new System.Drawing.Size(262, 20);
			this.txtNombreEn.TabIndex = 2;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(452, 354);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(75, 23);
			this.btnGuardar.TabIndex = 3;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.BtnGuardarClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(44, 299);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nombre (ES):";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(44, 354);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Name (EN):";
			// 
			// BtnVerPreguntas
			// 
			this.BtnVerPreguntas.Location = new System.Drawing.Point(452, 299);
			this.BtnVerPreguntas.Name = "BtnVerPreguntas";
			this.BtnVerPreguntas.Size = new System.Drawing.Size(75, 23);
			this.BtnVerPreguntas.TabIndex = 4;
			this.BtnVerPreguntas.Text = "ver";
			this.BtnVerPreguntas.UseVisualStyleBackColor = true;
			this.BtnVerPreguntas.Click += new System.EventHandler(this.BtnVerPreguntasClick);
			// 
			// GestionModulos
			// 
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(712, 464);
			this.Controls.Add(this.BtnVerPreguntas);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.txtNombreEn);
			this.Controls.Add(this.txtNombreEs);
			this.Controls.Add(this.dgvModulos);
			this.Name = "GestionModulos";
			this.Text = "Gestión de Módulos Bilingües";
			((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button BtnVerPreguntas;
	}
}
