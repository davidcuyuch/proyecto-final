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
    public partial class menu_de_venta : Form
    {
        List<clientes> cliente = new List<clientes>();
        List<producexistente> existente = new List<producexistente>();
        List<totalventas> totales = new List<totalventas>();
        List<factura> fact = new List<factura>();
        public menu_de_venta(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            label16.Text=nombre;
        }
        string nombre;
        double dat;
        double lb1;
        double da;
        string variable1;
        string va2;
        double total = 0;
        string var1;
        string var2;
        string var3;
        string var4;
        string var5;
        private void button1_Click(object sender, EventArgs e)
        {
         string cargar = "compradores.txt";
         FileStream temporal = new FileStream(cargar, FileMode.Open, FileAccess.Read);
         StreamReader lector = new StreamReader(temporal);
         string dato = textBox1.Text;
          while (lector.Peek() > -1)
          {
          clientes client = new clientes();
          client.Nombre = lector.ReadLine();
          client.Nit = lector.ReadLine();
          cliente.Add(client);
          }
           lector.Close();
            for(int x=0; x<cliente.Count; x++)
            {
                 if(dato==cliente[x].Nit)
                 {
                    var2 = cliente[x].Nombre;
                    var3 = cliente[x].Nit;
                    listBox1.Items.Add(cliente[x].Nombre);
                    listBox1.Items.Add(cliente[x].Nit);
                    label11.Text = cliente[x].Nit;
                 }
            }
            if (label11.Text==dato)
            {
                listBox2.Items.Add( label11.Text);
            }
            else
            {
                for (int y = 0; y < cliente.Count; y++)
                {
                    var1 = cliente[y].Nit;
                }
                if (dato !=var1)
                {
                    string nomb = textBox2.Text;
                    string datos = textBox1.Text;
                    FileStream temp = new FileStream(cargar, FileMode.Append, FileAccess.Write);
                    StreamWriter scritor = new StreamWriter(temp);
                    scritor.WriteLine(nomb);
                    scritor.WriteLine(datos);
                    scritor.Close();
                    listBox1.Items.Add(nomb);
                    listBox1.Items.Add(datos);
                }
            }
         textBox1.Text = "";
         textBox2.Text = "";
         textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string producto = comboBox1.Text;
            string cantidad = textBoxcant.Text;
            string mesvari = textBox3.Text;
            string mes = mesvari + ".txt";
            FileStream temp = new FileStream(mes, FileMode.Append, FileAccess.Write);
            StreamWriter scritor = new StreamWriter(temp);
            scritor.WriteLine(producto);
            scritor.WriteLine(cantidad);
            //apartar codigo
            string contra = comboBox1.Text;
            string cant = textBoxcant.Text;
            string cargar = "productos tienda.txt";
            FileStream temporal = new FileStream(cargar, FileMode.Open, FileAccess.Read);
            StreamReader lector = new StreamReader(temporal);
            string dato = comboBox1.Text;
            while (lector.Peek() > -1)
            {
                producexistente client = new producexistente();
                client.Nombre = lector.ReadLine();
                client.Cantidad = lector.ReadLine();
                client.Precio = lector.ReadLine();
                existente.Add(client);
            }
            lector.Close();
            for (int x = 0; x < existente.Count; x++)
            {
                var5=existente[x].Cantidad;
                if (dato == existente[x].Nombre)
                {
                    variable1 = existente[x].Precio;
                }
            }
            if(cant>var5)
            dat = Convert.ToDouble(textBoxcant.Text);
            lb1 = Convert.ToDouble(variable1);
            da = dat * lb1;
            va2=textBoxefectivo.Text = da.ToString();
            scritor.WriteLine(da);
            scritor.Close();
            string re = "listemporal.txt";
            FileStream tep = new FileStream(re, FileMode.Append, FileAccess.Write);
            StreamWriter skritor = new StreamWriter(tep);
            skritor.WriteLine(da);
            skritor.Close();
            listBox3.Items.Add(producto); listBox3.Items.Add(da);
            string factura = "listado de facturas.txt";
            FileStream recivir = new FileStream(factura, FileMode.Append, FileAccess.Write);
            StreamWriter scribiendo = new StreamWriter(recivir);
            scribiendo.WriteLine(mes);
            scribiendo.WriteLine(nombre);
            scribiendo.WriteLine(var2);
            scribiendo.WriteLine(var3);
            scribiendo.WriteLine(producto);
            scribiendo.WriteLine(cantidad);
            scribiendo.WriteLine(da);
            scribiendo.Close();
            comboBox1.Text = "";
            textBoxcant.Text = "";
            textBoxefectivo.Text = "";
        }
        private void menu_de_venta_Load(object sender, EventArgs e)
        {
            string prod = "productos tienda.txt";
            FileStream temp = new FileStream(prod, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(temp);
            while(leer.Peek()>-1)
            {
                producexistente estado = new producexistente();
                estado.Nombre = leer.ReadLine();
                estado.Precio = leer.ReadLine();
                estado.Cantidad = leer.ReadLine();
                existente.Add(estado);
            }
            for (int x = 0; x < existente.Count; x++)
            {
                comboBox1.Items.Add(existente[x].Nombre);
            }
            leer.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string temp = "listado de facturas.txt";
            FileStream tempo = new FileStream(temp, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(tempo);
            while(leer.Peek()>-1)
            {
              factura pro = new factura();
              pro.Mes = leer.ReadLine();
              pro.Vendedor = leer.ReadLine();
              pro.Cliente = leer.ReadLine();
              pro.Nit = leer.ReadLine();
              pro.Nombreprod = leer.ReadLine();
              pro.Cntidad = leer.ReadLine();
              pro.Precio = leer.ReadLine();
              fact.Add(pro);
            }
            leer.Close();
            for (int x = 0; x <fact.Count; x++)
            {
                var4 = fact[x].Precio;
            }
            total = total + Convert.ToDouble(var4);
            va2 = textBoxefectivo.Text = total.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string contra = comboBox1.Text;
            string cargar = "productos tienda.txt";
            FileStream temporal = new FileStream(cargar, FileMode.Open, FileAccess.Read);
            StreamReader lector = new StreamReader(temporal);
            string dato = comboBox1.Text;
            while (lector.Peek() > -1)
            {
                producexistente client = new producexistente();
                client.Nombre = lector.ReadLine();
                client.Precio = lector.ReadLine();
                existente.Add(client);
            }
            lector.Close();
            for (int x = 0; x < existente.Count; x++)
            {
                if (dato == existente[x].Nombre)
                {
                    variable1 = existente[x].Precio;
                }
            }
              dat =Convert.ToDouble(textBoxcant.Text);
              lb1 = Convert.ToDouble(variable1);
              da = dat*lb1;
            textBoxefectivo.Text = da.ToString();
        }
    }
}