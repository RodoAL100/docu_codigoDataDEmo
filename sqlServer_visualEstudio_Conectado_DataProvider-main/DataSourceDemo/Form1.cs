using System; // Importa el espacio de nombres que contiene clases fundamentales del .NET Framework.
using System.Collections.Generic; // Importa clases para trabajar con colecciones genéricas como List, Dictionary, etc.
using System.ComponentModel; // Importa clases para implementar la funcionalidad de componentes y notificaciones de cambios.
using System.Data; // Importa clases para trabajar con datos y bases de datos.
using System.Drawing; // Importa clases para manejar gráficos, colores, y fuentes.
using System.Linq; // Importa LINQ para realizar consultas sobre colecciones de datos.
using System.Text; // Importa clases para manipular texto y cadenas de caracteres.
using System.Threading.Tasks; // Importa clases para la programación asincrónica basada en tareas.
using System.Windows.Forms; // Importa clases necesarias para construir aplicaciones con interfaces gráficas en Windows Forms.

namespace DataSourceDemo // Define un espacio de nombres llamado DataSourceDemo para organizar y evitar conflictos de nombres.
{
    public partial class Form1 : Form // Define la clase Form1 que hereda de Form, representando una ventana de la aplicación.
    {
        public Form1() // Constructor de la clase Form1.
        {
            InitializeComponent(); // Inicializa todos los controles y componentes del formulario, configurados en el diseñador.
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate(); // Valida los controles del formulario para asegurar que los datos ingresados sean correctos.
            this.customersBindingSource.EndEdit(); // Finaliza la edición actual en el BindingSource, aplicando los cambios.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Aplica todos los cambios en el DataSet a la base de datos.
        }

        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate(); // Valida los controles del formulario.
            this.customersBindingSource.EndEdit(); // Finaliza la edición en el BindingSource.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los cambios en la base de datos.
        }

        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate(); // Valida los controles del formulario.
            this.customersBindingSource.EndEdit(); // Finaliza la edición en el BindingSource.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los cambios en la base de datos.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga datos en la tabla 'Customers' del DataSet 'northwindDataSet' desde la base de datos utilizando el TableAdapter.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento que se dispara cuando se hace clic en una celda dentro del DataGridView 'customersDataGridView'.
            // Actualmente, este método está vacío y no realiza ninguna acción.
        }

        private void customersBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            // Evento que se dispara cuando el BindingNavigator 'customersBindingNavigator' necesita refrescar sus ítems.
            // Actualmente, este método está vacío y no realiza ninguna acción.
        }
    }
}
