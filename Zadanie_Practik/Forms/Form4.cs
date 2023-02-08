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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDataSet.ManuFacturer". При необходимости она может быть перемещена или удалена.
            this.manuFacturerTableAdapter.Fill(this.sTUDataSet.ManuFacturer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
