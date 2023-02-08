using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_Practik
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDataSet.tovar". При необходимости она может быть перемещена или удалена.
            this.tovarTableAdapter.Fill(this.sTUDataSet.tovar);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDataSet.___The_supplier_". При необходимости она может быть перемещена или удалена.
            this.___The_supplier_TableAdapter.Fill(this.sTUDataSet.___The_supplier_);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 af = new Form4();
            af.Owner = this;
            af.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 af = new Form5();
            af.Owner = this;
            af.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 af = new Form6();
            af.Owner = this;
            af.Show();
        }
    }
}
