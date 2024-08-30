using System; // Importa el espacio de nombres que contiene clases fundamentales del .NET Framework.
using System.Collections.Generic; // Importa clases para trabajar con colecciones genéricas.
using System.Linq; // Importa LINQ para realizar consultas sobre colecciones de datos.
using System.Text; // Importa clases para manipular texto y cadenas de caracteres.
using System.Threading.Tasks; // Importa clases para la programación asincrónica basada en tareas.
using System.Configuration; // Importa clases para manejar configuraciones, como cadenas de conexión en archivos de configuración.
using System.Xml.Linq; // Importa clases para trabajar con XML, aunque no se usa en este código.
using System.Data.SqlClient; // Importa clases necesarias para interactuar con SQL Server.
using System.Runtime.CompilerServices; // Importa clases para trabajar con compilación y atributos de metadatos, aunque no se usa directamente en este código.

namespace DatosLayer // Define el espacio de nombres que agrupa las clases relacionadas con la capa de datos.
{
    public class DataBase // Clase que gestiona la configuración y conexión a la base de datos.
    {
        // Propiedad estática que obtiene la cadena de conexión a la base de datos.
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión desde el archivo de configuración (app.config o web.config).
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Crea un objeto SqlConnectionStringBuilder para manipular fácilmente la cadena de conexión.
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Establece el nombre de la aplicación si ha sido configurado externamente; si no, utiliza el nombre predeterminado.
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el tiempo de espera de la conexión si ha sido configurado externamente; si no, utiliza el tiempo de espera predeterminado.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                return conexionBuilder.ToString(); // Devuelve la cadena de conexión completa como una cadena.
            }
        }

        // Propiedad estática para configurar o recuperar el tiempo de espera de la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para configurar o recuperar el nombre de la aplicación.
        public static string ApplicationName { get; set; }

        // Método estático que crea y abre una conexión a SQL Server usando la cadena de conexión configurada.
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conexion = new SqlConnection(ConnectionString); // Crea una nueva conexión con la cadena de conexión configurada.
            conexion.Open(); // Abre la conexión a la base de datos.
            return conexion; // Devuelve la conexión abierta.
        }
    }
}
