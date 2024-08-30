using System; // Importa el espacio de nombres que contiene clases fundamentales del .NET Framework.
using System.Collections.Generic; // Importa clases para trabajar con colecciones genéricas.
using System.Linq; // Importa LINQ para realizar consultas sobre colecciones de datos.
using System.Text; // Importa clases para manipular texto y cadenas de caracteres.
using System.Threading.Tasks; // Importa clases para la programación asincrónica basada en tareas.

namespace DatosLayer // Define el espacio de nombres que agrupa las clases relacionadas con la capa de datos.
{
    public class Customers // Define la clase Customers que representa la entidad "Clientes" en la base de datos.
    {
        // Propiedades de la clase Customers que corresponden a las columnas de la tabla Customers en la base de datos.
        public string CustomerID { get; set; } // Identificador único del cliente.
        public string CompanyName { get; set; } // Nombre de la empresa del cliente.
        public string ContactName { get; set; } // Nombre de la persona de contacto del cliente.
        public string ContactTitle { get; set; } // Título del contacto del cliente.
        public string Address { get; set; } // Dirección física del cliente.
        public string City { get; set; } // Ciudad donde se ubica el cliente.
        public string Region { get; set; } // Región o estado del cliente (si aplica).
        public string PostalCode { get; set; } // Código postal del cliente.
        public string Country { get; set; } // País del cliente.
        public string Phone { get; set; } // Número de teléfono del cliente.
        public string Fax { get; set; } // Número de fax del cliente (si aplica).
    }
}
