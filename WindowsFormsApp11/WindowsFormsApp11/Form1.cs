using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private List<float> X, Y;

        private float Sumxy, Sumx2, Sumx, Sumy, Sumpr;
        private float a, b;

        private void button2_Click(object sender, EventArgs e)
        {
            X.Clear(); Y.Clear();

            dataGridView1.Columns.Clear(); dataGridView1.ColumnCount = 2;
            label1.Text = null;
        }
              private void Form1_Load(object sender, EventArgs e)
      {
            X = new List<float>();
            Y = new List<float>();

            dataGridView1.ColumnCount = 2;
            label1.Text = null;
            textBox1.Text = "0";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sumx = 0;
            Sumy = 0;
            Sumxy = 0;
            Sumx2 = 0;
                
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                X.Add((float)Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value));
                Y.Add((float)Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));

            }
            for (int i = 0; i < X.Count; i++)
            {
                Sumx += X[i];
                Sumy += Y[i];
                Sumxy += X[i] * Y[i];
                Sumx2 += X[i] * X[i];
            }
            a = (float)(X.Count * Sumxy - Sumx * Sumy) / (float)(X.Count * Sumx2 - Sumx * Sumx);
            b = (float)(Sumy - a * Sumx) / (float)X.Count;
            for (int i = 0; i < X.Count; i++)
            {
                Sumpr += ((Y[i] - (a * X[i] + b)) * (Y[i] - (a * X[i] + b)));
            }
            textBox1.Text = Convert.ToString(Sumpr);
            label1.Text = "y = " + a + "x + " + b;
        }
public Form1()
        {
            InitializeComponent();
        }


    }
}

