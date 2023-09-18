using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Entidades
{
    internal class Clientes
    {
        private int codCliente;
        private string apellido;
        private string nombre;

        public Clientes(int codCliente, string apellido, string nombre)
        {
            this.codCliente = codCliente;
            this.apellido = apellido;
            this.nombre = nombre;
        }

        public Clientes()
        {
            codCliente = 0;
            apellido = String.Empty;
            nombre = String.Empty;
        }

        public int CodCliente { get => codCliente; set => codCliente = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre}";
        }
    }
}
