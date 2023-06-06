using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet dataSetProfesores;
        SqlDataAdapter dataAdapterProfesores;
        private int pos;
        private int maxRegistros;

        private void mostrarRegistro( int pos)
        {
            DataRow dRegistro;

            dRegistro= dataSetProfesores.Tables["Profesores"].Rows[pos];

            textBox1.Text = dRegistro[0].ToString();
            textBox2.Text = dRegistro[1].ToString();
            textBox3.Text = dRegistro[2].ToString();
            textBox4.Text = dRegistro[3].ToString();
            textBox5.Text = dRegistro[4].ToString();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Paco\\Downloads\\Instituto (1).mdf\";Integrated Security=True;Connect Timeout=30";

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            dataSetProfesores = new DataSet();

            string cadenaSQL = "SELECT * From Profesores";

            dataAdapterProfesores = new SqlDataAdapter(cadenaSQL,conexion);

            dataAdapterProfesores.Fill(dataSetProfesores, "Profesores");

            pos = 0;
            mostrarRegistro(pos);
            maxRegistros = dataSetProfesores.Tables["Profesores"].Rows.Count;
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos = 0;
            mostrarRegistro(pos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos--;
            mostrarRegistro(pos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pos++;
            mostrarRegistro(pos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos = maxRegistros - 1;
            mostrarRegistro(pos);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            


        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRow dRegistro = dataSetProfesores.Tables["Profesores"].NewRow();
            dRegistro[0] = textBox1.Text;
            dRegistro[1] = textBox2.Text;
            dRegistro[2] = textBox3.Text;
            dRegistro[3] = textBox4.Text;
            dRegistro[4] = textBox5.Text;
            dataSetProfesores.Tables["Profesores"].Rows.Add(dRegistro);
            SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapterProfesores);
            dataAdapterProfesores.Update(dataSetProfesores, "Profesores");
            maxRegistros++;
            pos = maxRegistros - 1;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataRow dRegistro = dataSetProfesores.Tables["Profesores"].Rows[pos];
            dRegistro[0] = textBox1.Text;
            dRegistro[1] = textBox2.Text;
            dRegistro[2] = textBox3.Text;
            dRegistro[3] = textBox4.Text;
            dRegistro[4] = textBox5.Text;
            SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapterProfesores);
            dataAdapterProfesores.Update(dataSetProfesores, "Profesores");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            dataSetProfesores.Tables["Profesores"].Rows[pos].Delete();
           
            maxRegistros--;
        
            pos = 0;
            mostrarRegistro(pos);

            SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapterProfesores);
            dataAdapterProfesores.Update(dataSetProfesores, "Profesores");

        }
    }
}
