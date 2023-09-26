using Facturacion_Problema_1_2.Datos.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Problema_1_2.Factory
{
    public abstract class FabricarServicio
    {
        public abstract IServicio CrearServicio();
    }
}
