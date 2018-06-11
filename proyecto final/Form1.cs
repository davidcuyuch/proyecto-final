using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace proyecto_final
{
    public partial class Form1 : Form
    {
        List<empleados> empleado = new List<empleados>();
        List<productovendido> ventas = new List<productovendido>();
        List<productovendido> ventasord = new List<productovendido>();
        List<string> nombres = new List<string>();
        string v1;
        string nombre;
        int v2;
        double dat2=0;
        double suma=0;
        public Form1()
        {
            InitializeComponent();
            textBoxcontraseña.PasswordChar = '*';
            textBoxcontraseña.MaxLength = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cargar = "empleados.txt";
            FileStream temporal = new FileStream(cargar, FileMode.Open, FileAccess.Read);
            StreamReader lector = new StreamReader(temporal);
            string contra = textBoxcontraseña.Text;
            while(lector.Peek()>-1)
            {
                empleados empl = new empleados();
                empl.Nombre = lector.ReadLine();
                empl.Contraseña = lector.ReadLine();
                empleado.Add(empl);
            }
            for(int x=0; x<empleado.Count; x++)
            {
                nombre = empleado[x].Nombre;
                v1 = empleado[x].Contraseña;
                if (contra == v1)
                {
                    menu_de_venta menu = new menu_de_venta(nombre);
                    menu.Show();
                }
            }
            lector.Close();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listado_de_ventas list = new listado_de_ventas();
            list.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string cargar = "productos vendidos.txt";
            FileStream temp = new FileStream(cargar, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(temp);
            while(leer.Peek()>-1)
            {
                productovendido venta = new productovendido();
                venta.Nombre = leer.ReadLine();
                venta.Cantidad = leer.ReadLine();
                ventas.Add(venta);
            }
            ventasord= ventas.OrderByDescending(n => n.Nombre).ToList();
            leer.Close();
            for (int x = 0; x < ventasord.Count-1; x++)
            {
                if (ventasord[x].Nombre == ventasord[x + 1].Nombre)
                {
                    v2 = Convert.ToInt16(ventasord[x].Cantidad) + v2 ; 
                }
                else
                {
                    v2 += Convert.ToInt16(ventasord[x].Cantidad);
                    dat2 = Convert.ToDouble(v2);
                    suma = suma + dat2;
                    listBox1.Text = suma.ToString();
                    listBox1.Items.Add(ventasord[x].Nombre);
                    listBox1.Items.Add(suma);
                    suma = 0;
                    v2 = 0;
                }
            }
        }
    }
}

