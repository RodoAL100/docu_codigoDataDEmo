using System; // Importa el espacio de nombres que contiene clases fundamentales del .NET Framework.
using System.Collections.Generic; // Importa clases para trabajar con colecciones genéricas como List, Dictionary, etc.
using System.ComponentModel; // Importa clases para implementar la funcionalidad de componentes y notificaciones de cambios.
using System.Data; // Importa clases para trabajar con datos y bases de datos.
using System.Drawing; // Importa clases para manejar gráficos, colores, y fuentes.
using System.Linq; // Importa LINQ para realizar consultas sobre colecciones de datos.
using System.Text; // Importa clases para manipular texto y cadenas de caracteres.
using System.Threading.Tasks; // Importa clases para la programación asincrónica basada en tareas.
using System.Windows.Forms; // Importa clases necesarias para construir aplicaciones con interfaces gráficas en Windows Forms.
using System.Data.SqlClient; // Importa clases necesarias para interactuar con SQL Server.
using DatosLayer; // Importa el espacio de nombres que contiene la capa de datos de la aplicación.
using System.Net; // Importa clases para trabajar con protocolos de red.
using System.Reflection; // Importa clases para trabajar con metadatos y reflexión, permitiendo inspeccionar tipos y sus miembros.

namespace ConexionEjemplo // Define el espacio de nombres de la aplicación, en este caso, ConexionEjemplo.
{
    public partial class Form1 : Form // Define la clase Form1 que hereda de Form, representando una ventana de la aplicación.
    {
        CustomerRepository customerRepository = new CustomerRepository();
        // Crea una instancia de CustomerRepository, que gestiona la interacción con la base de datos para la entidad "Customers".

        public Form1() // Constructor de la clase Form1.
        {
            InitializeComponent(); // Inicializa todos los controles y componentes del formulario, configurados en el diseñador.
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            var Customers = customerRepository.ObtenerTodos(); // Obtiene todos los clientes de la base de datos.
            dataGrid.DataSource = Customers; // Asigna la lista de clientes como la fuente de datos del DataGridView para mostrar los datos.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Este método está comentado, pero la idea es filtrar los clientes según lo que se ingrese en tbFiltro.
            // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Este código está comentado, pero sirve para configurar el nombre de la aplicación y el tiempo de espera de la conexión en la capa de datos.
            /*
            DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnectionTimeout = 30;

            string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conexion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text); // Busca un cliente por su ID.
            // Muestra la información del cliente en los TextBoxes correspondientes.
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Evento asociado a un clic en el label4. Actualmente no realiza ninguna acción.
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;

            var nuevoCliente = ObtenerNuevoCliente(); // Obtiene los datos del nuevo cliente desde los TextBoxes.

            // Este código está comentado, pero verifica si los campos están completos y, si lo están, inserta el nuevo cliente en la base de datos.
            /*
            if (tboxCustomerID.Text != "" || 
                tboxCompanyName.Text !="" ||
                tboxContacName.Text != "" ||
                tboxContacName.Text != "" ||
                tboxAddress.Text != "" ||
                tboxCity.Text != "")
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else {
                MessageBox.Show("Debe completar los campos por favor");
            }
            */

            // Este código, también comentado, realiza validaciones campo por campo para asegurarse de que no haya valores nulos o vacíos.
            /*
            if (nuevoCliente.CustomerID == "") {
                MessageBox.Show("El Id en el usuario debe de completarse");
                return;    
            }

            if (nuevoCliente.ContactName == "")
            {
                MessageBox.Show("El nombre de usuario debe de completarse");
                return;
            }
            
            if (nuevoCliente.ContactTitle == "")
            {
                MessageBox.Show("El contacto de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.Address == "")
            {
                MessageBox.Show("La direccion de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.City == "")
            {
                MessageBox.Show("La ciudad de usuario debe de completarse");
                return;
            }
            */

            // Verifica si alguno de los campos del cliente es nulo.
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente); // Inserta el nuevo cliente en la base de datos.
                MessageBox.Show("Guardado" + " Filas modificadas = " + resultado); // Muestra un mensaje indicando que el cliente fue guardado.
            }
            else
            {
                MessageBox.Show("Debe completar los campos por favor"); // Muestra un mensaje de error si hay campos vacíos.
            }
        }

        // Método que valida si algún campo de un objeto es nulo o está vacío.
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null); // Obtiene el valor de cada propiedad del objeto.
                if ((string)value == "")
                {
                    return true; // Si algún campo está vacío, devuelve true.
                }
            }
            return false; // Si todos los campos están completos, devuelve false.
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Evento asociado a un clic en el label5. Actualmente no realiza ninguna acción.
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            var actualizarCliente = ObtenerNuevoCliente(); // Obtiene los datos actualizados del cliente desde los TextBoxes.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente); // Actualiza el cliente en la base de datos.
            MessageBox.Show($"Filas actualizadas = {actualizadas}"); // Muestra un mensaje indicando cuántas filas fueron actualizadas.
        }

        // Método que crea una nueva instancia de Customers con los datos ingresados en los TextBoxes.
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente; // Devuelve la instancia de Customers.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int eliminadas = customerRepository.EliminarCliente(tboxCustomerID.Text); // Elimina el cliente de la base de datos basado en el CustomerID.
            MessageBox.Show("Filas eliminadas = " + eliminadas); // Muestra un mensaje indicando cuántas filas fueron eliminadas.
        }
    }
}
