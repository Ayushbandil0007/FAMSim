using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class PleaseWaitForm : Form
    {
        public PleaseWaitForm()
        {
            InitializeComponent();
            OKbutton.Hide();
        }
        public void initializeText(string display)
        {
            finalLabel.Text = display;
            Update();
        }
        public void setMaxValue(int value)
        {
            progressBar1.Maximum = value;
        }
        public void uptateStatusBar(int value)
        {
            progressBar1.Value = value;
            //progressBar1.Update();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                progressBar1.Hide();
                OKbutton.Show();
                label1.Text = "Successfully Exported Data to Excel";
                finalLabel.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
