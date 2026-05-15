# Evaluación de Laboratorio: Flujo Bilingüe (10%)

**IUJO - Algorítmica y Programación**

### Datos de la Pareja

* **Nombre 1:** Marlys Flores
* **Nombre 2:** Rebeca Granoble

---

### 1. El Flujo de Trabajo en Parejas

1. **Estudiante A:** Hace el **Fork** del repositorio a su cuenta y añade al **Estudiante B** como colaborador (en *Settings > Collaborators*).
2. **Ambos:** Clonan el repositorio del Estudiante A en sus computadoras.
3. **Sincronización:** Deben ejecutar `git pull` antes de empezar a escribir código para recibir lo que su compañero haya subido y evitar conflictos.
4. **Regla de oro:** No trabajen en el mismo archivo al mismo tiempo. Si el Estudiante A está en `GestionModulos.cs`, el Estudiante B debe estar en la Base de Datos o en `GestionPreguntas.cs`.

---

### INSTRUCCIONES

> ⚠️ **IMPORTANTE:** El repositorio tiene dos carpetas con nombres similares.
> * **Guía de Referencia:** Utilice la carpeta `ejemploBd` que está en la **raíz** del repositorio para consultar código funcional.
> * **Carpeta de Examen:** Realice todos sus cambios exclusivamente dentro de la carpeta `evaluacion/ejemploBd`. Abra el archivo `.sln` ubicado dentro de esta última.

Su examen consiste en completar la **Gestión de Módulos y Preguntas** dentro de la carpeta `evaluacion`.

---

### FASE 1: Base de Datos (Módulos)

1. **Tablas:** Asegúrese de tener creadas las tablas `modulo` y `pregunta` (ver scripts en `README.md`).
2. **Datos:** Inserte manualmente en phpMyAdmin los 4 módulos: *Architecture, Anthropology, Calculus, Sports*.
3. **Análisis de Integridad:** En el script SQL, la relación tiene la instrucción `ON DELETE CASCADE`. ¿Qué sucede con las preguntas asociadas si eliminamos un módulo de la tabla `modulo`?

* *R:* Si se elimina un registro en la tabla modulo, el motor de la base de datos eliminará automáticamente todos los registros de la tabla pregunta que tengan el id_modulo correspondiente. Esto garantiza que no queden "registros huérfanos" (preguntas que apunten a un módulo que ya no existe).

4. **Tipos de Datos:** ¿Por qué es obligatorio que el campo `id_modulo` (en `pregunta`) tenga el mismo tipo de dato que el `id` (en `modulo`) para que la relación funcione?

* *R:*Es obligatorio porque ambos campos forman un vínculo de integridad referencial. Para que el motor de la base de datos pueda comparar los valores y validar la clave foránea
---

### FASE 2: Gestión de Módulos (Incompleto)

1. **Conexión:** En `GestionModulos.cs`, la instancia de conexión debe configurarse. **Tome como referencia el MainForm.cs del ejemplo.**
2. **Consulta SQL:** Complete el `SELECT` en `CargarModulos` para mostrar `id`, `nombre_es` y `nombre_en`.
3. **Carga:** Programe la línea que usa el `adaptador` para llenar el `DataTable` y mostrar los datos en la grilla.

---

### FASE 3: Paso de Parámetros (El Reto)

1. **Del Padre al Hijo:** En `GestionModulos.cs`, al hacer clic en el botón para ver preguntas, debe capturar el `id` del módulo seleccionado en el DataGridView.
2. **El Constructor:** En `GestionPreguntas.cs`, complete el constructor para que reciba ese `id` y lo asigne a la variable interna de la clase.
3. **El Filtro:** En la consulta SQL de la ventana de preguntas, use el `id` recibido (cláusula `WHERE`) para que **solo** se muestren las preguntas del módulo seleccionado.

---

### FASE 4: Preguntas Teóricas

1. **Lógica:** Si al abrir la ventana de preguntas estas aparecen vacías para todos los módulos (pero no hay errores de código), ¿qué objeto revisaría primero: la `Conexion` o la consulta `SQL`? Justifique.
* *R:* Revisaria la consulta SQL


2. **Encapsulamiento:** ¿Cuál es la ventaja de recibir el ID mediante el **Constructor** y guardarlo en una variable `private`, en lugar de simplemente declarar una variable `public` que cualquiera pueda modificar?
* *R:* La ventaja principal es la integridad de los datos y la seguridad.



---

### ENTREGA (Pull Request)

Para finalizar la evaluación, el **Estudiante A** (el dueño del Fork) debe realizar el **Pull Request** hacia el repositorio original del profesor.

### Resumen de comandos sugeridos

> **Guía rápida de consola para el Laboratorio:**
> 1. `git add .`
> 2. `git commit -m "Solución Laboratorio - Apellido1 y Apellido2"`
> 3. `git push origin evaluacion-lab`
> 
> 

**⚠️ IMPORTANTE:** No intente subir las carpetas `bin` ni `obj`. El archivo `.gitignore` ya está configurado para mantener el repositorio limpio.

---
XDDD



FASE 1: Base de Datos (Módulos)
3. Análisis de Integridad: ¿Qué sucede con las preguntas asociadas si eliminamos un módulo?

R: 
4. Tipos de Datos: ¿Por qué es obligatorio que id_modulo coincida en tipo con id?

R: 
FASE 4: Preguntas Teóricas
1. Lógica: Si las preguntas aparecen vacías pero no hay errores, ¿qué revisaría primero?

R: Revisaría la consulta SQL.

Justificación: Si no hay errores de código (excepciones), significa que la Conexion se estableció con éxito y el comando se ejecutó. El hecho de que la grilla esté vacía sugiere un error de lógica en el filtro (cláusula WHERE), donde probablemente el ID enviado no coincide con ningún registro en la base de datos o la condición del SELECT es demasiado restrictiva.

2. Encapsulamiento: Ventaja de recibir el ID mediante el Constructor y guardarlo en private.

R: 
Tips adicionales para tu código (FASE 2 y 3)
Para asegurar que tu código funcione al primer intento, recuerda estos fragmentos clave:

En CargarModulos:

C#
// Consulta SQL sugerida
string query = "SELECT id, nombre_es, nombre_en FROM modulo";
// Para llenar el DataTable
adaptador.Fill(dt);
dgvModulos.DataSource = dt;
En el Constructor de GestionPreguntas.cs:

C#
    private int idModuloRecibido;

    public GestionPreguntas(int idSeleccionado)
    {
        InitializeComponent();
        this.idModuloRecibido = idSeleccionado;
        // Luego usas this.idModuloRecibido en tu WHERE del SELECT
    }
    ```




¡Mucho éxito con el **Pull Request**! Recuerden que el trabajo en equipo es clave: mantengan la comunicación para no pisar el código del otro.

El vie, 15 de may de 2026, 11:07 a. m., teamo quakiris <teamoquakiris@gmail.com> escribió:
# Evaluación de Laboratorio: Flujo Bilingüe (10%)

**IUJO - Algorítmica y Programación**

### Datos de la Pareja

* **Nombre 1:** ________________________________________
* **Nombre 2:** ________________________________________

---

### 1. El Flujo de Trabajo en Parejas

1. **Estudiante A:** Hace el **Fork** del repositorio a su cuenta y añade al **Estudiante B** como colaborador (en *Settings > Collaborators*).
2. **Ambos:** Clonan el repositorio del Estudiante A en sus computadoras.
3. **Sincronización:** Deben ejecutar `git pull` antes de empezar a escribir código para recibir lo que su compañero haya subido y evitar conflictos.
4. **Regla de oro:** No trabajen en el mismo archivo al mismo tiempo. Si el Estudiante A está en `GestionModulos.cs`, el Estudiante B debe estar en la Base de Datos o en `GestionPreguntas.cs`.

---

### INSTRUCCIONES

> ⚠️ **IMPORTANTE:** El repositorio tiene dos carpetas con nombres similares.
> * **Guía de Referencia:** Utilice la carpeta `ejemploBd` que está en la **raíz** del repositorio para consultar código funcional.
> * **Carpeta de Examen:** Realice todos sus cambios exclusivamente dentro de la carpeta `evaluacion/ejemploBd`. Abra el archivo `.sln` ubicado dentro de esta última.

Su examen consiste en completar la **Gestión de Módulos y Preguntas** dentro de la carpeta `evaluacion`.

---

### FASE 1: Base de Datos (Módulos)

1. **Tablas:** Asegúrese de tener creadas las tablas `modulo` y `pregunta` (ver scripts en `README.md`).
2. **Datos:** Inserte manualmente en phpMyAdmin los 4 módulos: *Architecture, Anthropology, Calculus, Sports*.
3. **Análisis de Integridad:** En el script SQL, la relación tiene la instrucción `ON DELETE CASCADE`. ¿Qué sucede con las preguntas asociadas si eliminamos un módulo de la tabla `modulo`?
* *R:* ________________________________________________


4. **Tipos de Datos:** ¿Por qué es obligatorio que el campo `id_modulo` (en `pregunta`) tenga el mismo tipo de dato que el `id` (en `modulo`) para que la relación funcione?
* *R:* ________________________________________________



---

### FASE 2: Gestión de Módulos (Incompleto)

1. **Conexión:** En `GestionModulos.cs`, la instancia de conexión debe configurarse. **Tome como referencia el MainForm.cs del ejemplo.**
2. **Consulta SQL:** Complete el `SELECT` en `CargarModulos` para mostrar `id`, `nombre_es` y `nombre_en`.
3. **Carga:** Programe la línea que usa el `adaptador` para llenar el `DataTable` y mostrar los datos en la grilla.

---

### FASE 3: Paso de Parámetros (El Reto)

1. **Del Padre al Hijo:** En `GestionModulos.cs`, al hacer clic en el botón para ver preguntas, debe capturar el `id` del módulo seleccionado en el DataGridView.
2. **El Constructor:** En `GestionPreguntas.cs`, complete el constructor para que reciba ese `id` y lo asigne a la variable interna de la clase.
3. **El Filtro:** En la consulta SQL de la ventana de preguntas, use el `id` recibido (cláusula `WHERE`) para que **solo** se muestren las preguntas del módulo seleccionado.

---

### FASE 4: Preguntas Teóricas

1. **Lógica:** Si al abrir la ventana de preguntas estas aparecen vacías para todos los módulos (pero no hay errores de código), ¿qué objeto revisaría primero: la `Conexion` o la consulta `SQL`? Justifique.
* *R:* ________________________________________________


2. **Encapsulamiento:** ¿Cuál es la ventaja de recibir el ID mediante el **Constructor** y guardarlo en una variable `private`, en lugar de simplemente declarar una variable `public` que cualquiera pueda modificar?
* *R:* ________________________________________________



---

### ENTREGA (Pull Request)

Para finalizar la evaluación, el **Estudiante A** (el dueño del Fork) debe realizar el **Pull Request** hacia el repositorio original del profesor.

### Resumen de comandos sugeridos

> **Guía rápida de consola para el Laboratorio:**
> 1. `git add .`
> 2. `git commit -m "Solución Laboratorio - Apellido1 y Apellido2"`
> 3. `git push origin evaluacion-lab`
>
>

**⚠️ IMPORTANTE:** No intente subir las carpetas `bin` ni `obj`. El archivo `.gitignore` ya está configurad