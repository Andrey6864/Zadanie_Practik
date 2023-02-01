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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDataSet.___The_supplier_". При необходимости она может быть перемещена или удалена.
            this.___The_supplier_TableAdapter.Fill(this.sTUDataSet.___The_supplier_);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDataSet.__Point_of_issue_". При необходимости она может быть перемещена или удалена.
            this._Point_of_issue_TableAdapter.Fill(this.sTUDataSet.@__Point_of_issue_);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
