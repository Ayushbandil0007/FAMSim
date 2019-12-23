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
    public partial class FindLeadAndTiltForm : Form
    {
        double time; 
        public FindLeadAndTiltForm(double atTime)
        {
            this.time = atTime;
            InitializeComponent();
            initializeTextBoxes();

        }

        public void initializeTextBoxes()
        {
            leadMax.Text = "-30";
            leadMin.Text = "-40";
            tiltMax.Text = "10";
            tiltMin.Text = "-10";
        }

        public void getBestLeadAndTilt()
        {
            button1.Hide();
            finalLabel.Hide();
            
            double FminForDifferentLeadAndTilts = double.MaxValue;
            double lBest=0;
            double tBest=0;
            int lmin = int.Parse(leadMin.Text);
            int lmax = int.Parse(leadMax.Text);
            int tmin = int.Parse(tiltMin.Text);
            int tmax = int.Parse(tiltMax.Text);
            
            progressBar1.Maximum = (int)((lmax - lmin + 1) * (tmax - tmin + 1));
            int count=0;
            for (int l = lmin; l <= lmax; l++)
            {
                for (int t = tmin; t <= tmax; t++)
                {
                    count++;
                    FunctionWise.initializeLeadAndTilt(l, t);
                    FunctionWise.descritizationOfMultipleTool(); // Not writing descritezation in getFmax Function because tool geometry is fixed 
                    dynamicLabel.Text = "Calculating Fmax for lead = " + l + " degrees and tilt = " + t + " degrees";
                    double Fmax = FunctionWise.getFmax(time);
                    maximumForceForLeadTilt.Text = "Maximum Force for the and lead and tilt = " + Math.Round(Fmax,2) + " N";
                    progressBar1.Value = count;
                    if (FminForDifferentLeadAndTilts > Fmax)
                    {
                        FminForDifferentLeadAndTilts = Fmax;
                        leadTiltForMimimumForces.Text = "Best combination till now is lead = "+l +" , tilt = "+t;
                        minForceTIllNow.Text = "Minimum value of force till now = " + Math.Round(Fmax, 2) + " N";
                        Update();
                        lBest = l;
                        tBest = t;
                    }
                    this.Update();
                }
            }
            finalLabel.Text = "Lead = " + lBest + " degrees and Tilt = " + tBest + " degrees for minimum forces" ;
            button1.Show();
            finalLabel.Show();
            dynamicLabel.Hide();
            progressBar1.Hide();
            leadTiltForMimimumForces.Hide();
            maximumForceForLeadTilt.Hide();
            minForceTIllNow.Hide();
            this.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OutputForm_Load(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            getBestLeadAndTilt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
