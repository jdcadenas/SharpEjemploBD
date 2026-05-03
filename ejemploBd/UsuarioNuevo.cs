/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 6:41 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	/// <summary>
	/// Description of UsuarioNuevo.
	/// </summary>
	public partial class UsuarioNuevo : Form
	{
		//crea una cadena de conexión
		private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		
		
		public UsuarioNuevo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNombre.Text))
			{
				MessageBox.Show("Escriba nombre para el usuario.");
				return;
			}
			if (string.IsNullOrWhiteSpace(txtClave.Text))
			{
				MessageBox.Show("Escriba clave para el usuario.");
				return;
			}
			if (cmbRol.SelectedItem == null)
			{
				MessageBox.Show("Seleccione un rol.");
				return;
			}
			string consulta = "INSERT INTO usuario (nombre, clave, rol) VALUES (@nombre, @clave,@rol)";
			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
				{
					
					cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
					cmd.Parameters.AddWithValue("@clave", txtClave.Text);
					cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString());
					conexion.Open();
					cmd.ExecuteNonQuery();
				}
				MessageBox.Show("Usuario agregada correctamente.");
				this.DialogResult = DialogResult.OK;   // Para que el padre sepa que se agregó
				this.Close();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error al agregar: {0}", ex.Message));
			}
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
