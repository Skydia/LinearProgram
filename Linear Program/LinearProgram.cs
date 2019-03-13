using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Linear_Program
{
    public partial class LinearProgram : Form
    {
        public LinearProgram()
        {
            InitializeComponent();
        }

        private void LinearProgram_Load(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = "" + trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = "" + trackBar2.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {         
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = trackBar2.Value + 4;
            dataGridView1.RowCount = trackBar1.Value + 1;

            int i = 1;
            while (i <= dataGridView1.ColumnCount - 4)
            {
                dataGridView1.Columns[i].Name = "X" + i;
                i++;
            }
            dataGridView1.Columns[i+1].Name = "RHS";
            dataGridView1.Columns[i+2].Name = "Equation Form";

            if (radioButton1.Checked)
            {
                dataGridView1.Rows[0].Cells[0].Value = "Maximum";
            }
            else if (radioButton2.Checked)
            {
                dataGridView1.Rows[0].Cells[0].Value = "Minimum";
            }

            
            i = 1;
            while (i <= dataGridView1.ColumnCount - 4)
            {
                dataGridView1.Rows[0].Cells[i].Value = 0;
                i++;
            }
            int j = 1;
            while(j <= dataGridView1.RowCount - 1)
            {
                i = 1;
                dataGridView1.Rows[j].Cells[0].Value="Constraint "+j;
                while (i <= dataGridView1.ColumnCount - 4)
                {      
                    dataGridView1.Rows[j].Cells[i].Value = 0;
                    i++;
                }
                dataGridView1.Rows[j].Cells[i].Value = "<=";
                dataGridView1.Rows[j].Cells[i+1].Value = 0;
                dataGridView1.Rows[j].Cells[i+2].Value = "<="+0;
                j++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.ColumnCount = trackBar2.Value + 4;
            dataGridView2.RowCount = trackBar1.Value + 1;

            int i = 1;
            while (i <= dataGridView2.ColumnCount - 4)
            {
                dataGridView2.Columns[i].Name = "X" + i;
                i++;
            }
            dataGridView2.Columns[i + 1].Name = "RHS";
            dataGridView2.Columns[i + 2].Name = "Equation Form";

            if (radioButton1.Checked)
            {
                dataGridView2.Rows[0].Cells[0].Value = "Maximum";
            }
            else if (radioButton2.Checked)
            {
                dataGridView2.Rows[0].Cells[0].Value = "Minimum";
            }


            i = 1;
            while (i <= dataGridView2.ColumnCount - 4)
            {
                dataGridView2.Rows[0].Cells[i].Value = 0;
                i++;
            }
            int j = 1;
            while (j <= dataGridView2.RowCount - 1)
            {
                i = 1;
                dataGridView2.Rows[j].Cells[0].Value = "Constraint " + j;
                while (i <= dataGridView2.ColumnCount - 4)
                {
                    dataGridView2.Rows[j].Cells[i].Value = 0;
                    i++;
                }
                dataGridView2.Rows[j].Cells[i].Value = "<=";
                dataGridView2.Rows[j].Cells[i + 1].Value = 0;
                dataGridView2.Rows[j].Cells[i + 2].Value = "<=" + 0;
                j++;
            }

            //////////////////Proses Hitung//////////////////
            j = 1;
            decimal minColumnsValue = 99999;
            int minColumns=0;

            //////////////////Cari Kolom//////////////////
            while (j <= dataGridView2.ColumnCount - 4)
            {
                decimal tempMinColumns = Convert.ToDecimal(dataGridView1.Rows[0].Cells[j].Value);
                if (tempMinColumns < minColumnsValue)
                {
                    minColumns = j;
                    minColumnsValue = Convert.ToDecimal(dataGridView1.Rows[0].Cells[j].Value);
                }
                j++;
            }

            //////////////////Cari Baris//////////////////
            j = 0;
            decimal minRatioValue = 99999;
            decimal minRows = 0;
            decimal ratio;
            while ( j <= dataGridView2.RowCount - 1)
            {
                if (Convert.ToDecimal(dataGridView1.Rows[j].Cells[minColumns].Value) == 0){
                }
                else if (Convert.ToDecimal(dataGridView1.Rows[j].Cells[dataGridView1.ColumnCount - 2].Value) != 0){
                    ratio = Convert.ToDecimal(dataGridView1.Rows[j].Cells[dataGridView1.ColumnCount - 2].Value) / Convert.ToDecimal(dataGridView1.Rows[j].Cells[minColumns].Value);
                    if (ratio < minRatioValue)
                    {
                        minRows = j;
                        minRatioValue = ratio;
                    }
                }
                j++;
            }
            /*
            i = 1;
            j = 0;
            // pivot row[minRows].columns[minColumns]
            //////////////////Set nilai pada baris dengan rasio terkecil//////////////////
            while (j <= dataGridView2.RowCount - 1)
            {
                dataGridView2.Rows[minRows].Cells[j].Value = Convert.ToDecimal(dataGridView2.Rows[minRows].Cells[j].Value) / Convert.ToDecimal(dataGridView2.Rows[minRows].Cells[minColumns].Value);
            }
            j = 0;
            //////////////////Gauss//////////////////
            /*while (j <= dataGridView2.RowCount - 1)
            {
                while(i <= dataGridView2.ColumnCount - 4)
                {
                    decimal perkalian = 
                    dataGridView2.Rows[i].Cells[j].Value = Convert.ToDecimal(dataGridView2.Rows[i].Cells[j])


                }
                if (j == minRows - 1)
                    j = j + 2;
                else
                    j++;
            }*/


        }
    }
}
