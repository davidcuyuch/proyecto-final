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
    public partial class listado_de_ventas : Form
    {
        List<mes> ms = new List<mes>();
        List<mes2> ter = new List<mes2>();
        string var1;
        string var2;
        public listado_de_ventas()
        {
            InitializeComponent();
        }
        private void listado_de_ventas_Load(object sender, EventArgs e)
        {
            string listado = "meses.txt";
            FileStream temporal = new FileStream(listado, FileMode.Open, FileAccess.Read);
            StreamReader lectro = new StreamReader(temporal);
            while(lectro.Peek()>-1)
            {
                mes tem = new mes();
                tem.Nombre = lectro.ReadLine();
                ms.Add(tem);
            }
            for(int x=0; x<ms.Count; x++)
            {
                comboBox1.Items.Add(ms[x].Nombre);
            }
            lectro.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for(int x=0; x<ms.Count; x++)
            {
                var1 = ms[x].Nombre;
            }
            if(comboBox1.Text==var1)
            {
                var2 = var1 + ".txt";
                FileStream temporal = new FileStream(var2, FileMode.Open, FileAccess.Read);
                StreamReader leer = new StreamReader(temporal);
                while (leer.Peek() > -1)
                {
                    mes2 re = new mes2();
                    re.Nombre = leer.ReadLine();
                    re.Cantidad = leer.ReadLine();
                    re.Precio = leer.ReadLine();
                    ter.Add(re);
                }
                leer.Close();
                for(int g=0; g<ter.Count; g++)
                {
                    dataGridView1.DataSource = ter[g].Nombre;
                    dataGridView1.DataSource = ter[g].Cantidad;
                    dataGridView1.DataSource = ter[g].Precio;
                    dataGridView1.Refresh();
                }
            }
        }
    }
}
