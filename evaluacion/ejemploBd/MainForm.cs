
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class MainForm : Form
	{
		private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		private int id = -1;
		
		public MainForm()
		{
			InitializeComponent();
			CargarUsuarios();
		}
		
		public void CargarUsuarios()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					string consulta = "SELECT id, nombre, clave, rol from usuario";
					conexion.Open();
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					DataTable tabla = new DataTable();
					adaptador.Fill(tabla);
					dgvUsuarios.DataSource = tabla;
					lblEstado.Text = string.Format("Cargados {0} usuarios.", tabla.Rows.Count);
				}
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Error de conexión: {0}", ex.Message));
			}
		}
		
		void BtnAgregarUsuarioClick(object sender, EventArgs e)
		{
			UsuarioNuevo frmnuevo  = new UsuarioNuevo();
			if (frmnuevo.ShowDialog() == DialogResult.OK)
			{
				CargarUsuarios();
			}
		}
		
		void BtnEliminarUsuarioClick(object sender, EventArgs e)
		{
			if (dgvUsuarios.SelectedRows.Count == 0) return;
			id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value);

			if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE id = @id", conexion))
				{
					cmd.Parameters.AddWithValue("@id", id);
					conexion.Open();      
					cmd.ExecuteNonQuery(); 
				}
				CargarUsuarios();
			}
		}
		
		void BtnAcualizarUsuarioClick(object sender, EventArgs e)
		{
			DataGridViewRow fila = dgvUsuarios.SelectedRows[0];
			int id = Convert.ToInt32(fila.Cells["id"].Value);
			string nombre = fila.Cells["nombre"].Value.ToString();
			string clave = fila.Cells["clave"].Value.ToString();
			int rol = Convert.ToInt32(fila.Cells["rol"].Value);

			using (UsuarioNuevo  frmEditar = new UsuarioNuevo(id, nombre, clave, rol))
			{
				if (frmEditar.ShowDialog() == DialogResult.OK)
				{
					CargarUsuarios();
				}
			}
		}

		void BtnGestionModulosClick(object sender, EventArgs e)
		{
			GestionModulos frm = new GestionModulos();
			frm.ShowDialog();
		}
	}
}
