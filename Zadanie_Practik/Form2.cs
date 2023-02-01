using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Zadanie_Practik
{
    public partial class Form2 : Form
    {
       

        public Form2()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            WaitSomeTime();
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

      


        public async void WaitSomeTime()
        {
            await Task.Delay(5000);
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }


       

        

        private void поставщикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 af = new Form3();
            af.Owner = this;
            af.Show();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 af = new Form7();
            af.Owner = this;
            af.Show();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 af = new Form8();
            af.Owner = this;
            af.Show();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 af = new Form9();
            af.Owner = this;
            af.Show();
        }
    }
}
