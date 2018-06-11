using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final
{
    class factura
    {
        string mes;
        string vendedor;
        string cliente;
        string nit;
        string nombreprod;
        string cntidad;
        string precio;

        public string Mes { get => mes; set => mes = value; }
        public string Vendedor { get => vendedor; set => vendedor = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Nombreprod { get => nombreprod; set => nombreprod = value; }
        public string Cntidad { get => cntidad; set => cntidad = value; }
        public string Precio { get => precio; set => precio = value; }
    }
}
