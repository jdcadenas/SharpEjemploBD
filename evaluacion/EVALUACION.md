# Evaluación de Laboratorio: Flujo Bilingüe (10%)
**IUJO - Algorítmica y Programación**

### Datos de la Pareja
*   **Nombre 1:** ________________________________________
*   **Nombre 2:** ________________________________________

---

### INSTRUCCIONES
Utilice el módulo de **Gestión de Usuarios** como guía. Este módulo funciona correctamente y tiene el código completo. Su examen consiste en completar la **Gestión de Módulos y Preguntas**.

---

### FASE 1: Base de Datos (Módulos)
1.  **Tablas:** Asegúrese de tener creadas las tablas `modulo` y `pregunta` (ver scripts en `README.md`).
2.  **Datos:** Inserte manualmente en phpMyAdmin los 4 módulos (Architecture, Anthropology, Calculus, Sports).
3.  **Pregunta:** ¿Cuál es la Primary Key de la tabla `pregunta` y cuál es su Foreign Key hacia `modulo`?
    *   *R:* ________________________________________________

---

### FASE 2: Gestión de Módulos (Incompleto)
1.  **Conexión:** En `GestionModulos.cs`, la cadena de conexión está vacía. **Búsquela en MainForm.cs y cópiela.**
2.  **Consulta SQL:** Complete el SELECT en `CargarModulos` para mostrar `id`, `nombre_es` y `nombre_en`.
3.  **Carga:** Falta la línea que usa el `adaptador` para llenar el `DataTable`.

---

### FASE 3: Paso de Parámetros (El Reto)
1.  **Del Padre al Hijo:** En `GestionModulos.cs`, al hacer clic en el botón para ver preguntas, debe capturar el `id` y el `nombre` del módulo seleccionado.
2.  **El Constructor:** En `GestionPreguntas.cs`, complete el constructor para que reciba esos datos y los asigne a las variables internas.
3.  **El Filtro:** En la consulta SQL de preguntas, use el `id` recibido para que **solo** se muestren las preguntas del módulo seleccionado.

---

### FASE 4: Preguntas Teóricas
1.  **Lógica:** Si al abrir la ventana de preguntas estas aparecen vacías para todos los módulos, ¿qué objeto revisaría primero: la `Conexion`, el `Adaptador` o la consulta `SQL`?
2.  **Parámetros:** ¿Por qué usamos un **Constructor con parámetros** para pasar el ID del módulo en lugar de crear una nueva conexión?

---

### ENTREGA
Suba su carpeta `evaluacion` a GitHub y envíe el enlace.
