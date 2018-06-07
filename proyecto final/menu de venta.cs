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
        double dat; 
        double lb1; 
        double da;
        string variable1;
        string va2;
        double total=0;
        public menu_de_venta()
        {
            InitializeComponent();
        }
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
            listBox1.Items.Add(cliente[x].Nombre);
            listBox1.Items.Add(cliente[x].Nit);
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
                    if (dato != cliente[y].Nit)
                    {
                        string nomb = textBox2.Text;
                        string datos = textBox1.Text;
                        FileStream temp = new FileStream(cargar, FileMode.Append, FileAccess.Write);
                        StreamWriter scritor = new StreamWriter(temp);
                        scritor.WriteLine(datos);
                        scritor.WriteLine(nomb);
                        scritor.Close();
                    }
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
            string guardar = "productos vendidos.txt";
            FileStream temp = new FileStream(guardar, FileMode.Append, FileAccess.Write);
            StreamWriter scritor = new StreamWriter(temp);
            scritor.WriteLine(producto);
            scritor.WriteLine(cantidad);
            scritor.Close();
            //apartar codigo
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
            for (int x = 0; x < existente.Count; x++)
            {
                if (dato == existente[x].Nombre)
                {
                    variable1 = existente[x].Precio;
                }
            }
            lector.Close();
            dat = Convert.ToDouble(textBoxcant.Text);
            lb1 = Convert.ToDouble(variable1);
            da = dat * lb1;
           va2=textBoxefectivo.Text = da.ToString();
            string re = "listemporal.txt";
            FileStream tep = new FileStream(re, FileMode.Append, FileAccess.Write);
            StreamWriter skritor = new StreamWriter(tep);
            skritor.WriteLine(da);
            skritor.Close();
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
            string temp = "listemporal.txt";
            FileStream tempo = new FileStream(temp, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(tempo);
            while(leer.Peek()>-1)
            {
              totalventas pro = new totalventas();
              pro.Precios = leer.ReadLine();
              totales.Add(pro);
            }
            for(int x = 0; x <totales.Count; x++)
            {
                total = total +Convert.ToDouble(totales[x].Precios);
            }
            va2=label12.Text = total.ToString();
            leer.Close();
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
            for (int x = 0; x < existente.Count; x++)
            {
                if (dato == existente[x].Nombre)
                {
                    variable1 = existente[x].Precio;
                }
            }
            lector.Close();
              dat =Convert.ToDouble( textBoxcant.Text);
              lb1 = Convert.ToDouble(variable1);
              da = dat*lb1;
            textBoxefectivo.Text = da.ToString();
        }
    }
}