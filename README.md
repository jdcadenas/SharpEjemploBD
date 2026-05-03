# EjemploBD con SharpDevelop y Mysql 

## 1 Script SQL para crear la base de datos y la tabla
```Mysql
--
-- Base de datos: `peducativa`
--
CREATE DATABASE IF NOT EXISTS `peducativa` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `peducativa`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL,
  `rol` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
```

## 2 Configurar ShaarpDevelop
### 2.1 4.1. Instalar el conector MySQL para .NET
Descarga `MySql.Data.dll`desde [https://github.com/jdcadenas/SharpEjemploBD/tree/main/LIB_CONEXION/MySql.Data.dll](https://github.com/jdcadenas/SharpEjemploBD/tree/main/LIB_CONEXION/MySql.Data.dll)

### 4.2. Crear el proyecto en SharpDevelop
- Abre SharpDevelop → `File` → `New` → `Solution` → `C#` → `Windows Forms Application`  
- Nombre: `ejemploBD`  
- Haz clic en `Create`.

### 4.3. Agregar referencia a `MySql.Data.dll`
- En el `Solution Explorer`, haz clic derecho en `References` → `Add Reference`  
- Pestaña `.NET Assembly Browser` → `Browse`  
- Busca el archivo `MySql.Data.dll` en la carpeta del conector y selecciónalo.  
- Haz clic en `OK`. Verás que `MySql.Data` aparece bajo `References`.

### 4.4. Agregar los espacios de nombres
Abre `MainForm.cs` y, al inicio, junto a los `using` existentes, escribe:

```csharp
using MySql.Data.MySqlClient;
using System.Data;
```

## Curso: Algorítmica y Programación – Instituto Universitario Jesús Obrero
## Herramientas: SharpDevelop 4.4, XAMPP, phpMyAdmin, MySQL Connector/NET 6.9.8

---

## 1. ¿Qué es un CRUD?

CRUD son las cuatro operaciones básicas sobre datos:

- **Create** (Crear / Insertar)
- **Read** (Leer / Consultar)
- **Update** (Actualizar / Modificar)
- **Delete** (Eliminar / Borrar)

Ejemplo:  Puedes agregar un usuario (Create), ver todas (Read), editar  y borrar (Delete).

---

## 2. Entidad elegida: `tareas`

Para que el aprendizaje sea rápido y claro, usaremos una tabla con **solo 3 columnas**:

| Campo        | Tipo         | Descripción                          |
|--------------|--------------|--------------------------------------|
| `id`         | INT          | Número único, automático (llave primaria) |
| `usuario`| VARCHAR(200) | Texto de la tarea                    |
| `clave`| VARCHAR(200) | Texto de la tarea                    |
| `rol` | int      | 0 = administrador, 1 = jugador        |


No hay relaciones con otras tablas. Es totalmente independiente.

---

## 3. Script SQL para crear la base de datos y la tabla

Abre phpMyAdmin (http://localhost/phpmyadmin), crea una base de datos llamada `plataforma_educativa` (si no existe) y ejecuta el siguiente SQL:

```sql
-- Crear la tabla tareas
CREATE TABLE tareas (
    id INT PRIMARY KEY AUTO_INCREMENT,
    descripcion VARCHAR(200) NOT NULL,
    completada BOOLEAN DEFAULT 0
);

-- Insertar algunas tareas de ejemplo
INSERT INTO tareas (descripcion, completada) VALUES
('Comprar leche', 0),
('Estudiar C#', 0),
('Hacer ejercicio', 1);
```

**Explicación:**  
- `AUTO_INCREMENT` hace que el `id` se genere solo.  
- Los datos de ejemplo permiten probar la aplicación inmediatamente.

---

## 4. Configuración de SharpDevelop

### 4.1. Descarga el conector MySQL para .NET

### 4.2. Crear el proyecto en SharpDevelop
- Abre SharpDevelop → `File` → `New` → `Solution` → `C#` → `Windows Forms Application`  
- Nombre: `ejemploBD`  
- Haz clic en `Create`.

### 4.3. Agregar referencia a `MySql.Data.dll`
- En el `Solution Explorer`, haz clic derecho en `References` → `Add Reference`  
- Pestaña `.NET Assembly Browser` → `Browse`  
- Busca el archivo `MySql.Data.dll` en la carpeta del conector y selecciónalo.  
- Haz clic en `OK`. Verás que `MySql.Data` aparece bajo `References`.

### 4.4. Agregar los espacios de nombres
Abre `Form1.cs` y, al inicio, junto a los `using` existentes, escribe:

```csharp
using MySql.Data.MySqlClient;
using System.Data;
```

---

## 5. Diseño del formulario (interfaz)

Agrega los siguientes controles desde la `Toolbox`:

| Control        | Nombre          | Propiedades importantes                     |
|----------------|-----------------|---------------------------------------------|
| `DataGridView` | `dgvTareas`     | `SelectionMode = FullRowSelect`            |
| `TextBox`      | `txtDescripcion`| -                                           |
| `CheckBox`     | `chkCompletada` | `Text = "Completada"`                      |
| `Button`       | `btnAgregar`    | `Text = "Agregar"`                         |
| `Button`       | `btnActualizar` | `Text = "Actualizar"`                      |
| `Button`       | `btnEliminar`   | `Text = "Eliminar"`                        |
| `Button`       | `btnLimpiar`    | `Text = "Limpiar"`                         |
| `Label`        | `lblEstado`     | `Text = "Listo"`                           |

**Distribución sugerida:**  
- `dgvTareas` ocupa la parte superior.  
- Debajo, un `GroupBox` con título "Datos de la tarea" que contiene `txtDescripcion` y `chkCompletada`.  
- Botones a la derecha o debajo del GroupBox.  
- `lblEstado` en la parte inferior.

---

## 6. Código completo de Form1.cs

**Nota importante:** SharpDevelop no soporta interpolación de cadenas (`$"..."`). Usamos `string.Format`.

Copia y pega todo el siguiente código en `Form1.cs` (reemplaza el existente):

```csharp
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_Tareas
{
    public partial class Form1 : Form
    {
        // Cadena de conexión (cambia la contraseña si la tienes)
        private string connectionString = "Server=localhost;Database=plataforma_educativa;Uid=root;Pwd=;";
        private int tareaIdSeleccionada = -1;

        public Form1()
        {
            InitializeComponent();
            CargarTareas();
        }

        // 1. Cargar todas las tareas en el DataGridView
        private void CargarTareas()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    string consulta = "SELECT id, descripcion, completada FROM tareas";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvTareas.DataSource = tabla;

                    // Mejorar la vista de la columna "completada"
                    if (dgvTareas.Columns.Contains("completada"))
                        dgvTareas.Columns["completada"].HeaderText = "¿Completada? (0=Pendiente, 1=Lista)";

                    lblEstado.Text = string.Format("Tareas cargadas: {0}", tabla.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al cargar: {0}", ex.Message));
            }
        }

        // 2. Evento: al hacer clic en una fila, mostrar sus datos en los campos
        private void dgvTareas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvTareas.SelectedRows[0];
                tareaIdSeleccionada = Convert.ToInt32(fila.Cells["id"].Value);
                txtDescripcion.Text = fila.Cells["descripcion"].Value.ToString();
                chkCompletada.Checked = Convert.ToBoolean(fila.Cells["completada"].Value);
                lblEstado.Text = string.Format("Editando tarea ID {0}", tareaIdSeleccionada);
            }
        }

        // 3. Agregar una nueva tarea
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Escriba una descripción para la tarea.");
                return;
            }

            string consulta = "INSERT INTO tareas (descripcion, completada) VALUES (@desc, @comp)";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@comp", chkCompletada.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Tarea agregada correctamente.");
                LimpiarCampos();
                CargarTareas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al agregar: {0}", ex.Message));
            }
        }

        // 4. Actualizar la tarea seleccionada
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (tareaIdSeleccionada == -1)
            {
                MessageBox.Show("Primero seleccione una tarea de la lista.");
                return;
            }

            string consulta = "UPDATE tareas SET descripcion=@desc, completada=@comp WHERE id=@id";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@comp", chkCompletada.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", tareaIdSeleccionada);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Tarea actualizada.");
                LimpiarCampos();
                CargarTareas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al actualizar: {0}", ex.Message));
            }
        }

        // 5. Eliminar la tarea seleccionada
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tareaIdSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una tarea para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta tarea?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(connectionString))
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM tareas WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                        cmd.Parameters.AddWithValue("@id", tareaIdSeleccionada);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Tarea eliminada.");
                    LimpiarCampos();
                    CargarTareas();
                    tareaIdSeleccionada = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error al eliminar: {0}", ex.Message));
                }
            }
        }

        // 6. Limpiar todos los campos manualmente
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Método auxiliar para limpiar campos y resetear selección
        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            chkCompletada.Checked = false;
            tareaIdSeleccionada = -1;
            lblEstado.Text = "Campos limpios. Puede agregar una nueva tarea.";
        }
    }
}
```

---

## 7. Diagrama de flujo del CRUD

```
[Inicio]
   │
   ▼
[CargarTareas()] ────→ [Mostrar DataGridView]
   │
   ▼
[Esperar acción del usuario]
   │
   ├──► [Agregar] ──► [Validar] ──► [INSERT] ──► [Limpiar] ──► [Recargar]
   │
   ├──► [Seleccionar fila] ──► [Mostrar datos en campos]
   │
   ├──► [Actualizar] ──► [Validar selección] ──► [UPDATE] ──► [Limpiar] ──► [Recargar]
   │
   ├──► [Eliminar] ──► [Confirmar] ──► [DELETE] ──► [Limpiar] ──► [Recargar]
   │
   └──► [Limpiar] ──► [Vaciar campos]
   │
   ▼
[Fin]
```

---

## 8. Explicación paso a paso para el profesor (guión de clase)

### 8.1. Crear la base de datos (5 min)
*“Abran XAMPP, inicien MySQL, vayan a phpMyAdmin, crean la base de datos y ejecutan el script SQL que les di.”*

### 8.2. Configurar SharpDevelop (10 min)
*“Nuevo proyecto, agregamos la referencia a la DLL de MySQL, importamos los espacios de nombre.”*

### 8.3. Diseñar el formulario (10 min)
*“Arrastren los controles como ven en la tabla. Nombren cada uno exactamente como está escrito.”*

### 8.4. Escribir el código – Cargar tareas (10 min)
*“El método `CargarTareas` se conecta, hace un `SELECT` y llena el DataGridView. Observen el uso de `string.Format` en lugar de `$"..."`.”*

### 8.5. Seleccionar fila (5 min)
*“El evento `SelectionChanged` captura la fila que el usuario hace clic. Guardamos el `id` y mostramos la descripción y el estado en los controles.”*

### 8.6. Agregar, Actualizar, Eliminar (15 min)
*“Cada botón ejecuta una consulta SQL con parámetros. Siempre limpiamos los campos después y recargamos la grilla.”*

### 8.7. Probar (10 min)
*“Ejecuten (F5). Agreguen una tarea, márquenla como completada, actualícenla, elimínenla. Todo debe funcionar.”*
