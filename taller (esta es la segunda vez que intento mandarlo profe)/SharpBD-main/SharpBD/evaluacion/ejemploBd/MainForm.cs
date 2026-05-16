/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 2:53 p. m.
 */
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
		// ESTA PARTE FUNCIONA: Úsala como guía para completar el resto del sistema
		private string cadenaConexion =  "Server=localhost;Database=taller-luben-angel;Uid=root;Pwd=;";
		private int ID = -1;
		
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
					string consulta = "SELECT ID, Name, Password, Rol from User";
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
			ID = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["ID"].Value);

			if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand("DELETE FROM User WHERE ID= @ID", conexion))
				{
					cmd.Parameters.AddWithValue("@ID", ID);
					conexion.Open();      
					cmd.ExecuteNonQuery(); 
				}
				CargarUsuarios();
			}
		}
		
		void BtnAcualizarUsuarioClick(object sender, EventArgs e)
		{
			DataGridViewRow fila = dgvUsuarios.SelectedRows[0];
			int id = Convert.ToInt32(fila.Cells["ID"].Value);
			string nombre = fila.Cells["Name"].Value.ToString();
			string clave = fila.Cells["Password"].Value.ToString();
			int rol = Convert.ToInt32(fila.Cells["Rol"].Value);

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
			// EXAMEN: Abrir el formulario de Gestión de Módulos
			GestionModulos frm = new GestionModulos();
			frm.ShowDialog();
		}
	}
}
