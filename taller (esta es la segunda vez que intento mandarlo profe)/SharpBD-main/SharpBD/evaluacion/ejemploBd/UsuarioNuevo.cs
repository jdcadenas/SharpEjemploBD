/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 6:41 p. m.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class UsuarioNuevo : Form
	{
		// ESTA PARTE FUNCIONA: Úsala como guía para completar el resto del sistema
		private string cadenaConexion = "Server=localhost;Database=taller-luben-angel;Uid=root;Pwd=;";
		private bool _esEdicion = false;
		private int _ID = -1;
		
		public UsuarioNuevo()
		{
			InitializeComponent();
		}
		
		public UsuarioNuevo(int ID,string Name, string Password, int Rol)
		{
			InitializeComponent();
			txtNombre.Text =  Name;
			txtClave.Text = Password;
			cmbRol.SelectedIndex = Rol;
			_ID = ID;
			_esEdicion = true;
			this.Text = "Editar Usuario";
			btnGuardar.Text = "Actualizar";
		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtClave.Text) || cmbRol.SelectedIndex == -1)
			{
				MessageBox.Show("Complete todos los campos.");
				return;
			}
			
			int idrol = (int)cmbRol.SelectedIndex;
			string consulta = _esEdicion ? 
				"UPDATE User SET Name=@Name, Password=@Password, Rol=@Rol WHERE ID=@ID" : 
				"INSERT INTO User (Name, Password, Rol) VALUES (@Name, @Password, @Rol)";		
			
			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
				{
					cmd.Parameters.AddWithValue("@Name", txtNombre.Text.Trim());
					cmd.Parameters.AddWithValue("@Password", txtClave.Text);
					cmd.Parameters.AddWithValue("@Rol", idrol);
					if (_esEdicion) cmd.Parameters.AddWithValue("@Id", _ID);
					
					conexion.Open();
					cmd.ExecuteNonQuery(); // ESTA LÍNEA ES CLAVE: Ejecuta la acción en la BD
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
