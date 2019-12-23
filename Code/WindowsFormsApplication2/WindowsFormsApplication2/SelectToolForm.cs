using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WPFChart3D;

namespace WindowsFormsApplication2
{
    public partial class SelectToolForm : Form
    {
        public SelectToolForm()
        {
            Thread t = new Thread(new ThreadStart(loading));
            t.Start();
            Thread.Sleep(3000);
            t.Abort();
            InitializeComponent();
        }
        public void loading()
        {
            Application.Run(new LoadingScreen());
        }

        private void ballEndMillToolButton_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.ballEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void SelectToolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.invertedConeEndMill);
            toolParametersForm.Show();
            this.Hide();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.bullNoseEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.cylindricalEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.taperEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.taperBallEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.generalEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.coneEndMill);
            toolParametersForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ToolParametersForm toolParametersForm = new ToolParametersForm(this, null, ToolType.roundedEndMill);
            toolParametersForm.Show();
            this.Hide();
        }
    }
}
