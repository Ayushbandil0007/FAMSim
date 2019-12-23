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

namespace WindowsFormsApplication2
{
    public partial class TaskSelectionForm : Form
    {
        static double rpm;
        static double feedRate;
        private ToolInitialPositionForm prevForm;
        public TaskSelectionForm(ToolInitialPositionForm prevForm)
        {
            this.prevForm = prevForm;
            Top = prevForm.Top;
            Left = prevForm.Left;
            InitializeComponent();
            initializeData();
        }

        private void initializeData()
        {
            taskSimulateForces.Checked = true;
            cycles.Text = "1";
            time.Text = (double.Parse(cycles.Text) / rpm).ToString();
            distanceTravel.Text = (double.Parse(cycles.Text) / rpm * feedRate).ToString();
            lead.Text = "0";
            tilt.Text = "0";
            //time.Text = (double.Parse(cycles.Text) / rpm).ToString();
            //distanceTravel.Text = (double.Parse(cycles.Text) * feedRate / rpm).ToString();
            stepOver.Text = "5";
            firstCut.Checked = true;
            stepOver.Enabled = false;
            getSurfaceRoughnessButton.Enabled = false;
            getSurfaceRoughnessButton.Hide();
            if (FunctionWise.feedVector[2]==0)
            {
                firstCut.Enabled = true;
                followingCut.Enabled = true;
                if (FunctionWise.toolType == ToolType.ballEndMill && FunctionWise.surfaceType == SurfaceType.planer) getSurfaceRoughnessButton.Show();
            }
            else
            {
                firstCut.Enabled = false;
                followingCut.Enabled = false;
            }
        }
        public static void initializeRPMandFeed(double rpmIn, double feed)
        {
            rpm = rpmIn;
            feedRate = Math.Round(feed,4);
        }

        private bool checkForDouble(TextBox data)
        {
            try
            {
                double value = Convert.ToDouble(data.Text);
                if (value < 0)
                {
                    if ((data == time)) //||(data==stepOver)
                    {
                        MessageBox.Show(" value of " + data.Name + " is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(" value of " + data.Name + " is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool dataValidation()
        {
            if (!checkForDouble(time)) { return false; }
            if (!checkForDouble(lead)) { return false; }
            if (!checkForDouble(tilt)) { return false; }
            if (!checkForDouble(stepOver)) { return false; }
            return true;
        }

        private void taskButton_Click(object sender, EventArgs e)
        {
            if (dataValidation())
            {
                if (exportToExcel.Checked)
                {
                    saveFileDialog1.Filter = "Excel Spreadsheet|*.xls";
                    saveFileDialog1.FileName = (taskSimulateForces.Checked) ? "FCN data till time " + time.Text + " for lead " + lead.Text + " and tilt " + tilt.Text : "Cutting Zone at time " + time.Text + " for lead " + lead.Text + " and tilt " + tilt.Text;
                    saveFileDialog1.Title = "Export file at";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        FunctionWise.locationOfExport = saveFileDialog1.FileName;
                        FunctionWise.isExportExcelSheet = true;
                    }
                        
                }
                if (taskSimulateForces.Checked == true)
                {
                    FunctionWise.initializeLeadAndTilt(double.Parse(lead.Text), double.Parse(tilt.Text));
                    FunctionWise.initializeStepOver(followingCut.Checked, double.Parse(stepOver.Text));
                    FunctionWise.plotGraphs(double.Parse(time.Text));
                }
                if (taskLeadTiltAngle.Checked == true)
                {
                    FunctionWise.initializeStepOver(followingCut.Checked, double.Parse(stepOver.Text));
                    FindLeadAndTiltForm output = new FindLeadAndTiltForm(double.Parse(time.Text));
                    //output.Parent = this;
                    output.Show();
                }
                if (taskDisplayCuttingZone.Checked == true)
                {
                    FunctionWise.initializeLeadAndTilt(double.Parse(lead.Text), double.Parse(tilt.Text));
                    FunctionWise.initializeStepOver(followingCut.Checked, double.Parse(stepOver.Text));
                    FunctionWise.simulateEngagementRegion(double.Parse(time.Text));
                }
            }
        }

        private void TaskSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TaskSelectionBackButton_Click(object sender, EventArgs e)
        {
            prevForm.Show();
            this.Hide();

        }

        private void taskSimulateForces_CheckedChanged(object sender, EventArgs e)
        {
            if (taskSimulateForces.Checked == true)
            {
                exportToExcel.Enabled = true;
                //panel1.Left = 50;
                //panel1.Size = new Size(225, 148);
                //label6.Show();
                //lead.Show();
                //time.Left = 124;
                lead.Enabled = true;
                tilt.Enabled = true;
            }
        }

        private void taskLeadTiltAngle_CheckedChanged(object sender, EventArgs e)
        {
            if (taskLeadTiltAngle.Checked == true)
            {
                exportToExcel.Enabled = false;
                //panel1.Size = new Size(225, 100);
                //label6.Hide();
                //lead.Hide();
                lead.Enabled = false;
                tilt.Enabled = false;
            }
        }

        private void taskDisplayCuttingZone_CheckedChanged(object sender, EventArgs e)
        {
            if (taskDisplayCuttingZone.Checked == true)
            {
                exportToExcel.Enabled = true;
                //panel1.Size = new Size(225, 100);
                ////label6.Hide();
                //lead.Hide();
                lead.Enabled = true;
                tilt.Enabled = true;
            }

        }

        private void firstCut_CheckedChanged(object sender, EventArgs e)
        {
            if (firstCut.Checked)
            {
                stepOver.Enabled = false;
                getSurfaceRoughnessButton.Enabled = false;
            }
        }

        private void followingCut_CheckedChanged_1(object sender, EventArgs e)
        {
            if (followingCut.Checked)
            {
                stepOver.Enabled = true;
                getSurfaceRoughnessButton.Enabled = true;
            }
        }

        private void getSurfaceRoughnessButton_Click(object sender, EventArgs e)
        {
            FunctionWise.initializeLeadAndTilt(double.Parse(lead.Text), double.Parse(tilt.Text));
            FunctionWise.initializeStepOver(followingCut.Checked, double.Parse(stepOver.Text));
            if (double.IsNaN(FunctionWise.getSurfaceRoughness())) MessageBox.Show("Stepover value is too large (Stepover cannot be greater than diameter of the tool)");
            else MessageBox.Show("Surface Roughness for tilt " + tilt.Text + ", and stepover " + stepOver.Text + ", is " + Math.Round(FunctionWise.getSurfaceRoughness(), 4) + " mm");
        }

        private void lead_TextChanged(object sender, EventArgs e)
        {
            if (checkForDouble(lead))
            {
                if (double.Parse(lead.Text) < 0) MessageBox.Show("Negative value of lead angle is not recommended", "Warning");
            }
        }

        private void time_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (time.Text.Length > 0)
            {
                if (checkForDouble(time))
                {
                    distanceTravel.Text = (Math.Round(double.Parse(time.Text) * feedRate, 4)).ToString();
                    cycles.Text = (Math.Round(double.Parse(time.Text) * rpm, 4)).ToString();
                }
            }
            else
            {
                distanceTravel.Text = "";
                cycles.Text = "";
            }
        }

        private void distanceTravel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (distanceTravel.Text.Length > 0)
            {
                if (checkForDouble(distanceTravel))
                {
                    time.Text = (Math.Round(double.Parse(distanceTravel.Text) / feedRate, 4)).ToString();
                    cycles.Text = (Math.Round(double.Parse(distanceTravel.Text) / feedRate * rpm, 4)).ToString();
                }
            }
            else
            {
                time.Text = "";
                cycles.Text = "";
            }
        }

        private void cycles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (cycles.Text.Length > 0)
            {
                if (checkForDouble(cycles))
                {
                    time.Text = (Math.Round(double.Parse(cycles.Text) / rpm, 4)).ToString();
                    distanceTravel.Text = (Math.Round(double.Parse(cycles.Text) / rpm * feedRate, 4)).ToString();
                }
            }
            else
            {
                time.Text = "";
                distanceTravel.Text = "";
            }
        }
    }
}