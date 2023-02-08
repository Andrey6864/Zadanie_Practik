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
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static System.Windows.Forms.AxHost;
using System.Data.OleDb;


namespace Zadanie_Practik
{
    public partial class Form8 : Form
    {

        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        DataTable table = new DataTable();
        SqlDataAdapter z;
        DataSet gSMDataSet = new DataSet();


        string connectionString = @"Data Source=WIN-4CAAR61UG4L;Initial Catalog=STU;Integrated Security=True";
        string sql = "SELECT * FROM Orders";



        public Form8()
        {
            InitializeComponent();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;

        
        }

        

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.sTUDataSet.Orders);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                dataGridView2.CurrentCell = null;
                dataGridView2.Rows[i].Visible = false;
                for (int c = 0; c < dataGridView2.Columns.Count; c++)
                {
                    if (dataGridView2[c, i].Value.ToString() == textBox1.Text)
                    {
                        dataGridView2.Rows[i].Visible = true;
                        break;
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void FrmExport_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon;
            string conString = null;
            string sqlQuery = null;

            conString = "Data Source=WIN-4CAAR61UG4L;Initial Catalog=STU;Integrated Security=True;";
            sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            sqlQuery = "SELECT * FROM tblOrders";
            SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
            DataTable dtData = new DataTable();
            dscmd.Fill(dtData);
            dataGridView2.DataSource = dtData;
        }


        private void печатьToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Записать данные на диск не представлялось возможным." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Данные успешно экспортированы !!!", "Инфо");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет Записи для Экспорта !!!", "Инфо");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {

                    int delet = dataGridView2.SelectedCells[0].RowIndex;
                    dataGridView2.Rows.RemoveAt(delet);
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить запись, т.к. она не выбана");
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                sTUDataSetBindingSource.EndEdit();
                ordersTableAdapter.Update(sTUDataSet.Orders);
                MessageBox.Show("Изменения сохранены !", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Изменения не сохранены !", "Внимание !", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }


        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("Orders", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@[Order list]", SqlDbType.NVarChar, 255, "Order list"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Number", SqlDbType.Float, 0, "Number"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@[_Order date]", SqlDbType.Date, 0, "_Order date"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Delivery date", SqlDbType.Date, 0, "Delivery date"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@[Point of issue]", SqlDbType.Float, 0, "Point of issue"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@[Full name of the client]", SqlDbType.NVarChar, 255, "Full name of the client"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@[Code to receive]", SqlDbType.Float, 0, "Code to receive"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@[Order status]", SqlDbType.NVarChar, 255, "Order status"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@IDOrders", SqlDbType.Float, 0, "IDOrders");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
            }
        }
    }
}
