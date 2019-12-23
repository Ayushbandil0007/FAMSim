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
    public partial class ToolInitialPositionForm : Form
    {
        private SelectWorkpieceProfileForm prevForm;
        private TaskSelectionForm nextForm;
        private SurfaceType surface;
        public ToolInitialPositionForm(SelectWorkpieceProfileForm prevForm,TaskSelectionForm nextForm, SurfaceType surface)
        {
            this.prevForm = prevForm;
            this.nextForm = nextForm;
            this.surface = surface;
            Top = prevForm.Top;
            Left = prevForm.Left;
            InitializeComponent();
            initializeTextBoxes();
            //BackgroundImage = Properties.Resources.stepthrough;
            //imagePanel.BackgroundImage = global::WindowsFormsApplication2.Properties.Resources.samplePlain;
            //this.imagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void initializeTextBoxes()
        {
            verticalFeed.Text = "0";
            horizonatalFeed.Text = "100";
            rpm.Text="500";
            //Lp.Text = "100";
            //Kp.Text = "72";
            del_phi.Text = "5";
            del_z.Text = "0.1";
            Kp.Text = ((int)(Math.Round((360 / double.Parse(del_phi.Text))))).ToString();
            Lp.Text = ((int)(Math.Round(FunctionWise.h / double.Parse(del_z.Text)))).ToString();
            depth.Text = "5";
            switch (surface)
            {
                case SurfaceType.planer:
                    alpha.Hide();
                    beta.Hide();
                    xMargin.Hide();
                    yMargin.Hide();
                    stepSize.Hide();
                    alpha.Text = "0";
                    beta.Text = "0";
                    xMargin.Text = "0";
                    yMargin.Text = "0";
                    stepSize.Text = "0";
                    xLabel.Hide();
                    yLabel.Hide();
                    alphaLabel.Hide();
                    betaLabel.Hide();
                    stepSizeLabel.Hide();
                    picturePanel.BackgroundImage = Properties.Resources.PlanePara;
                    break;
                case SurfaceType.corner:
                    //alpha.Hide();
                    //beta.Hide();
                    //xMargin.Hide();
                    //yMargin.Hide();
                    stepSize.Hide();
                    alpha.Text = "30";
                    beta.Text = "30";
                    xMargin.Text = "10";
                    yMargin.Text = "5";
                    stepSize.Text = "5";
                    //xLabel.Hide();
                    //yLabel.Hide();
                    //alphaLabel.Hide();
                    //betaLabel.Hide();
                    stepSizeLabel.Hide();
                    picturePanel.BackgroundImage= Properties.Resources.CornerPara3;
                    //xMargin.Top = xMargin.Top + 30;
                    //xLabel.Top = xLabel.Top + 30;
                    //stepSize.Top = stepSize.Top - 60;
                    //stepSizeLabel.Top = stepSizeLabel.Top - 60;
                    break;
                case SurfaceType.customSurface:
                    alpha.Hide();
                    beta.Hide();
                    xMargin.Hide();
                    //yMargin.Hide();
                    stepSize.Hide();
                    alpha.Text = "0";
                    beta.Text = "0";
                    xMargin.Text = "0";
                    yMargin.Text = "5";
                    stepSize.Text = "0";
                    xLabel.Hide();
                    //yLabel.Hide();
                    alphaLabel.Hide();
                    betaLabel.Hide();
                    stepSizeLabel.Hide();
                    picturePanel.BackgroundImage = Properties.Resources.CustomPara;
                    yMargin.Top = yMargin.Top + 60;
                    yLabel.Top = yLabel.Top + 60;
                    break;
                case SurfaceType.edgeThrough:
                    alpha.Hide();
                    //beta.Hide();
                    xMargin.Hide();
                    //yMargin.Hide();
                    stepSize.Hide();
                    alpha.Text = "0";
                    beta.Text = "30";
                    xMargin.Text = "0";
                    yMargin.Text = "5";
                    stepSize.Text = "0";
                    xLabel.Hide();
                    //yLabel.Hide();
                    alphaLabel.Hide();
                    //betaLabel.Hide();
                    stepSizeLabel.Hide();
                    picturePanel.BackgroundImage = Properties.Resources.EdgePara;
                    yMargin.Top = yMargin.Top + 30;
                    yLabel.Top = yLabel.Top + 30;
                    break;
                case SurfaceType.slopeCutting:
                    alpha.Hide();
                    //beta.Hide();
                    xMargin.Hide();
                    //yMargin.Hide();
                    stepSize.Hide();
                    alpha.Text = "0";
                    beta.Text = "30";
                    xMargin.Text = "0";
                    yMargin.Text = "5";
                    stepSize.Text = "0";
                    xLabel.Hide();
                    //yLabel.Hide();
                    alphaLabel.Hide();
                    //betaLabel.Hide();
                    stepSizeLabel.Hide();
                    picturePanel.BackgroundImage = Properties.Resources.SlopeCuttingPara;
                    yMargin.Top = yMargin.Top + 30;
                    yLabel.Top = yLabel.Top + 30;
                    break;
                case SurfaceType.slopeInsert:
                    //alpha.Hide();
                    beta.Hide();
                    //xMargin.Hide();
                    yMargin.Hide();
                    stepSize.Hide();
                    alpha.Text = "30";
                    beta.Text = "0";
                    xMargin.Text = "10";
                    yMargin.Text = "0";
                    stepSize.Text = "0";
                    //xLabel.Hide();
                    yLabel.Hide();
                    //alphaLabel.Hide();
                    betaLabel.Hide();
                    stepSizeLabel.Hide();
                    picturePanel.BackgroundImage = Properties.Resources.SlopeThroughPara;
                    xMargin.Top = xMargin.Top + 60;
                    xLabel.Top = xLabel.Top + 60;
                    alpha.Top = xMargin.Top + 30;
                    alphaLabel.Top = xLabel.Top + 30;
                    break;
                case SurfaceType.step:
                    alpha.Hide();
                    beta.Hide();
                    //xMargin.Hide();
                    yMargin.Hide();
                    //stepSize.Hide();
                    alpha.Text = "0";
                    beta.Text = "0";
                    xMargin.Text = "10";
                    yMargin.Text = "0";
                    stepSize.Text = "5";
                    //xLabel.Hide();
                    yLabel.Hide();
                    alphaLabel.Hide();
                    betaLabel.Hide();
                    //stepSizeLabel.Hide();
                    picturePanel.BackgroundImage = Properties.Resources.StepPara;
                    xMargin.Top = xMargin.Top + 60;
                    xLabel.Top = xLabel.Top + 60;
                    stepSize.Top = stepSize.Top - 30;
                    stepSizeLabel.Top = stepSizeLabel.Top - 30;
                    break;
                default:
                break;
            }
        }
        private void ToolInitialPositionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool checkForDouble(TextBox data)
        {
            try
            {
                double value = Convert.ToDouble(data.Text);
                if ((data == verticalFeed)|| (data == horizonatalFeed) || (data == rpm) || (data == del_z) || (data == del_phi)|| (data == Lp)|| (data == Kp))
                {
                    if (value < 0)
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
            if (!checkForDouble(verticalFeed)) { return false; } //cannot take negative values
            if (!checkForDouble(horizonatalFeed)) { return false; } 
            if (!checkForDouble(rpm)) { return false; } //cannot take negative values
            if (!checkForDouble(depth)) { return false; } 

            if (!checkForDouble(del_z)) { return false; } //cannot take negative values
            if (!checkForDouble(del_phi)) { return false; } //cannot take negative values
            if (!checkForDouble(Kp)) { return false; }
            if (!checkForDouble(Lp)) { return false; }

            if (!checkForDouble(xMargin)) { return false; } 
            if (!checkForDouble(yMargin)) { return false; }
            if (!checkForDouble(alpha)) { return false; }
            if (!checkForDouble(beta)) { return false; }
            if (!checkForDouble(stepSize)) { return false; }
            return true;
        }

        private void toolInitialPositionNext_Click_1(object sender, EventArgs e)
        {
            if (dataValidation())
            {
                FunctionWise.machiningParametersInitialization(double.Parse(verticalFeed.Text), double.Parse(horizonatalFeed.Text), double.Parse(rpm.Text), double.Parse(del_z.Text), double.Parse(del_phi.Text));
                FunctionWise.initializationSurfaceParameters(double.Parse(depth.Text), double.Parse(xMargin.Text), double.Parse(yMargin.Text), double.Parse(alpha.Text), double.Parse(beta.Text), double.Parse(stepSize.Text), surface);
                TaskSelectionForm.initializeRPMandFeed(double.Parse(rpm.Text), Math.Sqrt(Math.Pow(double.Parse(verticalFeed.Text), 2) + Math.Pow(double.Parse(horizonatalFeed.Text), 2)));
                TaskSelectionForm taskSelectionForm = new TaskSelectionForm(this);
                taskSelectionForm.Show();
                this.nextForm = taskSelectionForm;
                //TaskSelectionForm.rpm = double.Parse(rpm.Text);
                //TaskSelectionForm.feedRate = Math.Sqrt(Math.Pow(double.Parse(verticalFeed.Text),2)+ Math.Pow(double.Parse(horizonatalFeed.Text), 2));
                this.Hide();
                //FunctionWise.MainOfLogic();
            }
        }
        
        private void toolInitialPositionBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.prevForm.Show();
        }

        private void verticalFeed_TextChanged(object sender, EventArgs e)
        {
            if (verticalFeed.Text != "0" && (FunctionWise.toolType==ToolType.cylindricalEndMill|| FunctionWise.toolType == ToolType.bullNoseEndMill || FunctionWise.toolType == ToolType.taperEndMill || FunctionWise.toolType == ToolType.roundedEndMill))
            {
                MessageBox.Show(FunctionWise.toolType+" tool is recommended to have zero vertical feed", "Warning");
            }
        }

        private void Lp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (Lp.Text.Length > 0)
            {
                if (checkForDouble(Lp))
                {
                    del_z.Text = (Lp.Text == "0"|| Lp.Text == "0.") ? "Not defined" : (Math.Round(FunctionWise.h / double.Parse(Lp.Text), 4)).ToString();
                }
            }
            if (Lp.Text.Length == 0)
            {
                del_z.Text = "";
            }
        }

        private void del_z_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (del_z.Text.Length > 0)
            {
                if (checkForDouble(del_z))
                {
                    Lp.Text = (del_z.Text == "0"|| del_z.Text == "0.") ? "Not defined" : ((int)(Math.Round(FunctionWise.h / double.Parse(del_z.Text)))).ToString();
                }
            }
            if (del_z.Text.Length == 0)
            {
                Lp.Text = "";
            }
        }

        private void Kp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (Kp.Text.Length > 0)
            {
                if (checkForDouble(Kp))
                {
                    del_phi.Text = (Kp.Text=="0"|| Kp.Text == "0.") ?"Not defined":(Math.Round(360 / double.Parse(Kp.Text), 4)).ToString();
                }
            }
            if (Kp.Text.Length == 0)
            {
                del_phi.Text = "";
            }
        }

        private void del_phi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            if (del_phi.Text.Length > 0)
            {
                if (checkForDouble(del_phi))
                {
                    Kp.Text = (del_phi.Text == "0"|| del_phi.Text == "0.") ?"Not defined":((int)(Math.Round((360 / double.Parse(del_phi.Text))))).ToString();
                }
            }
            else { Kp.Text = ""; }
        }
    }
}
