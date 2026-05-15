using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionPreguntas : Form
    {
        // EXAMEN PASO 5.1: Esta cadena debe estar vacía. Cópiala de MainForm.cs
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
        private int _idModulo = -1;

        // EXAMEN PASO 5.2: El constructor debe recibir el ID y el Nombre del módulo
        public GestionPreguntas(int idModulo, string nombreModulo)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            // //
            InitializeComponent();
            this._idModulo = idModulo;
            this.Text = "Preguntas de: " + nombreModulo;
            CargarPreguntas();
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
                MessageBox.Show(string.Format("No se pudo realizar conexion por : {0}",ex.Message));
            }
        }

        void BtnAgregarUsuarioClick(object sender, EventArgs e)
        {
            UsuarioNuevo frmnuevo = new UsuarioNuevo();
            
            if (frmnuevo.ShowDialog() == DialogResult.OK) // para mantener estructura
            {
                CargarUsuarios();
            }
        }

        private void CargarPreguntas()
        {
            try {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                    // EXAMEN PASO 6: Filtrar las preguntas por el ID del módulo recibido (_idModulo)
                    string sql = "SELECT * FROM pregunta WHERE id_modulo = " + _idModulo;
                    
                    conexion.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexion);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dgvPreguntas.DataSource = dt;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}