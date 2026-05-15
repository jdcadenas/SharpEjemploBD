using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionModulos : Form
    {
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;"; 

        public GestionModulos()
        {
            InitializeComponent();
            
            // ===============================================================
            // CREACIÓN Y CONFIGURACIÓN DEL BOTÓN "VER PREGUNTAS" POR CÓDIGO
            // ===============================================================
            Button btnVerPreguntas = new Button();
            btnVerPreguntas.Text = "Ver Preguntas";
            btnVerPreguntas.Size = new Size(130, 35); // Ancho y Alto del botón
            
            // Ubicación en el formulario (X=180, Y=220). 
            // Puedes cambiar estos números si se encima con tus cuadros de texto o tabla.
            btnVerPreguntas.Location = new Point(180, 220); 
            
            // Vinculamos el clic del botón con tu método existente
            btnVerPreguntas.Click += new EventHandler(BtnVerPreguntasClick);
            
            // Agregamos el botón a los controles del formulario para que sea visible
            this.Controls.Add(btnVerPreguntas);
            // ===============================================================

            CargarModulos();
        }

        private void CargarModulos()
        {
            try {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                    string consulta = "SELECT id, nombre_es, nombre_en FROM modulo";
                    
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    
                    adaptador.Fill(tabla);
                    dgvModulos.DataSource = tabla;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        void BtnVerPreguntasClick(object sender, EventArgs e)
        {
            // Modificado: Si no hay fila seleccionada, avisa al usuario en vez de cerrarse silenciosamente
            if (dgvModulos.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Por favor, seleccione una materia de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idModulo = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["id"].Value);
            string nombreMod = dgvModulos.SelectedRows[0].Cells["nombre_es"].Value.ToString();

            GestionPreguntas frm = new GestionPreguntas(idModulo, nombreMod);
            frm.ShowDialog();
        }

        void BtnGuardarClick(object sender, EventArgs e)
        {
            string nombre_es = txtNombreEs.Text;
            string nombre_en = txtNombreEn.Text;
            
            if(string.IsNullOrWhiteSpace(nombre_es) || string.IsNullOrWhiteSpace(nombre_en))
            {
                MessageBox.Show("Todos los campos deben estar rellenos", "Error");
                return;
            }
            
            string sqlInsert = "INSERT INTO modulo (nombre_es, nombre_en) VALUES (@name_es, @name_en)";
            
            using (MySqlConnection con = new MySqlConnection(cadenaConexion))
            {
                con.Open();
                
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@name_es", nombre_es);
                cmd.Parameters.AddWithValue("@name_en", nombre_en);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modulo agregado con exito", "Exito");
                
                txtNombreEn.Clear();
                txtNombreEs.Clear();
                
                CargarModulos();
            }
        }
    }
}
