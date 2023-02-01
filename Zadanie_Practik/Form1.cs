using System;
using formpos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zadanie_Practik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 af = new Form10();
            af.Owner = this;
            af.Show();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 af = new Form2();
            af.Owner = this;
            af.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=WIN-4CAAR61UG4L;Initial Catalog=STU;Integrated Security=True;");
                con.Open();
                string str = "insert into Users(Login,Password) values ('" + textBox1.Text + "','" + textBox2.Text +  "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Пользователь зарегистрирован!!!");
                
            }
        }
    }
}
