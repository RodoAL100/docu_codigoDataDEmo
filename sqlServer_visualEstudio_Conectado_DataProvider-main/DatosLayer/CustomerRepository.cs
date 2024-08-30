using System; // Importa el espacio de nombres que contiene clases fundamentales del .NET Framework.
using System.Collections.Generic; // Importa clases para trabajar con colecciones genéricas como List, Dictionary, etc.
using System.Data.SqlClient; // Importa clases necesarias para interactuar con SQL Server.
using System.Linq; // Importa LINQ para realizar consultas sobre colecciones de datos.
using System.Text; // Importa clases para manipular texto y cadenas de caracteres.
using System.Threading.Tasks; // Importa clases para la programación asincrónica basada en tareas.

namespace DatosLayer // Define el espacio de nombres que agrupa las clases relacionadas con la capa de datos.
{
    public class CustomerRepository // Clase que maneja las operaciones de datos relacionadas con los clientes en la base de datos.
    {
        public List<Customers> ObtenerTodos()
        {
            // Método que obtiene todos los registros de la tabla Customers de la base de datos.
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectFrom = ""; // Inicializa la cadena SQL para la consulta.
                // Construye la consulta SQL para seleccionar todos los campos de la tabla Customers.
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Ejecuta la consulta y lee los resultados.
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Customers> Customers = new List<Customers>(); // Lista para almacenar los clientes obtenidos.

                    while (reader.Read()) // Itera sobre los registros obtenidos.
                    {
                        var customers = LeerDelDataReader(reader); // Mapea el registro actual al objeto Customers.
                        Customers.Add(customers); // Añade el objeto Customers a la lista.
                    }
                    return Customers; // Devuelve la lista de clientes.
                }
            }
        }

        public Customers ObtenerPorID(string id)
        {
            // Método que obtiene un cliente específico por su ID.
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectForID = ""; // Inicializa la cadena SQL para la consulta.
                // Construye la consulta SQL para seleccionar un cliente específico por su ID.
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n";
                selectForID = selectForID + $"  Where CustomerID = @customerId"; // Agrega la condición de búsqueda por CustomerID.

                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    comando.Parameters.AddWithValue("customerId", id); // Asigna el parámetro del CustomerID.

                    var reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene el resultado.
                    Customers customers = null;
                    if (reader.Read())
                    { // Si se encuentra el registro, lo mapea al objeto Customers.
                        customers = LeerDelDataReader(reader);
                    }
                    return customers; // Devuelve el objeto Customers.
                }
            }
        }

        public Customers LeerDelDataReader(SqlDataReader reader)
        {
            // Método que mapea los datos obtenidos de la base de datos a un objeto Customers.
            Customers customers = new Customers();
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];
            return customers; // Devuelve el objeto Customers mapeado.
        }

        public int InsertarCliente(Customers customer)
        {
            // Método que inserta un nuevo cliente en la base de datos.
            using (var conexion = DataBase.GetSqlConnection())
            {
                String insertInto = ""; // Inicializa la cadena SQL para la inserción.
                // Construye la consulta SQL para insertar un nuevo cliente en la tabla Customers.
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    int insertados = parametrosCliente(customer, comando); // Inserta el cliente utilizando los parámetros.
                    return insertados; // Devuelve el número de filas afectadas.
                }
            }
        }

        public int ActualizarCliente(Customers customer)
        {
            // Método que actualiza un cliente existente en la base de datos.
            using (var conexion = DataBase.GetSqlConnection())
            {
                String ActualizarCustomerPorID = ""; // Inicializa la cadena SQL para la actualización.
                // Construye la consulta SQL para actualizar un cliente específico.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID";
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    int actualizados = parametrosCliente(customer, comando); // Actualiza el cliente utilizando los parámetros.
                    return actualizados; // Devuelve el número de filas afectadas.
                }
            }
        }

        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            // Método que asigna los valores de un objeto Customers como parámetros para un comando SQL.
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactName); // Debe corregirse para usar el parámetro correcto (ContactTitle).
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);
            var insertados = comando.ExecuteNonQuery(); // Ejecuta el comando SQL.
            return insertados; // Devuelve el número de filas afectadas.
        }

        public int EliminarCliente(string id)
        {
            // Método que elimina un cliente de la base de datos por su ID.
            using (var conexion = DataBase.GetSqlConnection())
            {
                String EliminarCliente = ""; // Inicializa la cadena SQL para la eliminación.
                // Construye la consulta SQL para eliminar un cliente específico por su ID.
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n";
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID";
                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                {
                    comando.Parameters.AddWithValue("@CustomerID", id); // Asigna el parámetro del CustomerID.
                    int eliminados = comando.ExecuteNonQuery(); // Ejecuta el comando SQL de eliminación.
                    return eliminados; // Devuelve el número de filas afectadas.
                }
            }
        }
    }
}
