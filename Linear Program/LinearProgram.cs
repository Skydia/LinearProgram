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
            dataGridView1.ColumnCount = trackBar1.Value + 4;
            dataGridView1.RowCount = trackBar2.Value + 1;

            int i = 1;
            while (i <= dataGridView1.ColumnCount - 4)
            {
                dataGridView1.Columns[i].Name = "X" + i;
                i++;
            }
            dataGridView1.Columns[i+1].Name = "RHS";
            dataGridView1.Columns[i+2].Name = "Equation Form";

            /* ArrayList row = new ArrayList();
             i = 1;
             row.Add("Maximize");
             while (i <= dataGridView1.ColumnCount - 4)
             {
                 row.Add("0");
                 i++;
             }
             row.Add(" ");
             row.Add(" ");
             row.Add("Max");
             dataGridView1.Rows.Add(row.ToArray());

             int j = 2;
             while (j <= trackBar2.Value)
             {
                 i = 1;
                 row = new ArrayList();
                 row.Add("Constraint " + i);
                 while (i <= dataGridView1.ColumnCount - 4)
                 {
                     row.Add("0");
                     i++;
                 }
                 row.Add(" ");
                 row.Add(" ");
                 row.Add("Max");
                 j++;
             }*/

            dataGridView1.Rows[0].Cells[0].Value = "Maximize";
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
                dataGridView1.Rows[j].Cells[0].Value=j;
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
    }
}
