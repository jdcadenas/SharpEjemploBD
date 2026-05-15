using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class GestionPreguntas : Form
{
    // PASO 5.1: Cadena de conexión (debe coincidir con MainForm)
    private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;"; 
    private int _idModulo;

    // PASO 5.2: Constructor corregido para recibir los parámetros
    public GestionPreguntas(int idModulo, string nombreModulo)
    {
        InitializeComponent();
        
        // Asignamos el ID a la variable global para usarla en CargarPreguntas
        this._idModulo = idModulo;
        
        // Personalizamos el título del formulario para saber qué estamos viendo
        this.Text = "Preguntas del módulo: " + nombreModulo;
        
        CargarPreguntas();
    }

    private void CargarPreguntas()
    {
        try {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                // PASO 6: Filtrar preguntas usando parámetros (Seguridad contra SQL Injection)
                string sql = "SELECT * FROM pregunta WHERE id_modulo = @idModulo";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idModulo", _idModulo); 
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvPreguntas.DataSource = dt;
            }
        } catch (Exception ex) {
            MessageBox.Show("Error al cargar preguntas: " + ex.Message);
        }
    }
	}
}
