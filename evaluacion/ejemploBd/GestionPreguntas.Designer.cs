namespace ejemploBd
{
	partial class GestionPreguntas
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dgvPreguntas;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.dgvPreguntas = new System.Windows.Forms.DataGridView();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.txtNombreEs = new System.Windows.Forms.TextBox();
			this.txtNombreEn = new System.Windows.Forms.TextBox();
			this.cmbRol = new System.Windows.Forms.ComboBox();
			this.dataPreguntas = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataPreguntas)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvPreguntas
			// 
			this.dgvPreguntas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPreguntas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPreguntas.Location = new System.Drawing.Point(0, 0);
			this.dgvPreguntas.Name = "dgvPreguntas";
			this.dgvPreguntas.Size = new System.Drawing.Size(484, 310);
			this.dgvPreguntas.TabIndex = 0;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(292, 275);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(98, 23);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(12, 275);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(89, 23);
			this.btnGuardar.TabIndex = 2;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			// 
			// txtNombreEs
			// 
			this.txtNombreEs.Location = new System.Drawing.Point(63, 193);
			this.txtNombreEs.Name = "txtNombreEs";
			this.txtNombreEs.Size = new System.Drawing.Size(259, 20);
			this.txtNombreEs.TabIndex = 3;
			// 
			// txtNombreEn
			// 
			this.txtNombreEn.Location = new System.Drawing.Point(63, 235);
			this.txtNombreEn.Name = "txtNombreEn";
			this.txtNombreEn.Size = new System.Drawing.Size(259, 20);
			this.txtNombreEn.TabIndex = 4;
			// 
			// cmbRol
			// 
			this.cmbRol.FormattingEnabled = true;
			this.cmbRol.Items.AddRange(new object[] {
									"0",
									"1"});
			this.cmbRol.Location = new System.Drawing.Point(22, 32);
			this.cmbRol.Name = "cmbRol";
			this.cmbRol.Size = new System.Drawing.Size(170, 21);
			this.cmbRol.TabIndex = 5;
			// 
			// dataPreguntas
			// 
			this.dataPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataPreguntas.Location = new System.Drawing.Point(212, 12);
			this.dataPreguntas.Name = "dataPreguntas";
			this.dataPreguntas.Size = new System.Drawing.Size(260, 150);
			this.dataPreguntas.TabIndex = 6;
			// 
			// GestionPreguntas
			// 
			this.ClientSize = new System.Drawing.Size(484, 310);
			this.Controls.Add(this.dataPreguntas);
			this.Controls.Add(this.cmbRol);
			this.Controls.Add(this.txtNombreEn);
			this.Controls.Add(this.txtNombreEs);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.dgvPreguntas);
			this.Name = "GestionPreguntas";
			this.Text = "Preguntas";
			((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataPreguntas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridView dataPreguntas;
		private System.Windows.Forms.ComboBox cmbRol;
		private System.Windows.Forms.TextBox txtNombreEn;
		private System.Windows.Forms.TextBox txtNombreEs;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnCancelar;
	}
}
