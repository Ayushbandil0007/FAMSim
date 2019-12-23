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
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

   
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value <= 20)
                this.Opacity = progressBar1.Value * 0.05;            
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                //Hide();
            }
        }
    }
}
