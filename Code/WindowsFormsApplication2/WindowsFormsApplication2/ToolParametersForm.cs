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
    public partial class ToolParametersForm : Form
    {
        const double convFact= Math.PI / 180;
        private SelectToolForm prevForm;
        private SelectWorkpieceProfileForm nextForm;
        private ToolType toolType;

        public ToolParametersForm(SelectToolForm prevForm, SelectWorkpieceProfileForm nextForm, ToolType tooltype)
        {
            Top = prevForm.Top;
            Left = prevForm.Left;
            this.prevForm = prevForm;
            this.nextForm = nextForm;
            this.toolType = tooltype;
            InitializeComponent();
            setTextBoxes();
        }

        private void setTextBoxes()
        {
            constHelix.Checked = true;
            noOfFlutes.Text = "2";
            rakeAngle.Text = "0";
            helixAngle.Text = "30";
            switch (toolType)
            {
                case ToolType.cylindricalEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.Cylindrical;
                    d.Text = "20";
                    r.Text = "0";
                    r.Enabled = false;
                    r_r.Text = "10";                //D/2
                    r_r.Enabled = false;
                    r_z.Text = "0";
                    r_z.Enabled = false;
                    alpha.Text = "0";
                    beta.Text = "0";
                    alpha.Enabled = false;
                    beta.Enabled = false;
                    h.Text = "20";
                    break;
                case ToolType.ballEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.Ball2;
                    r_r.Text = "0";
                    alpha.Text = "0";
                    beta.Text = "0";
                    r_r.Enabled = false;
                    alpha.Enabled = false;
                    beta.Enabled = false;
                    r.Enabled = false;
                    r_z.Enabled = false;
                    d.Text = "20";
                    h.Text = "20";
                    break;
                case ToolType.bullNoseEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.BullNosePara;
                    d.Text = "20";
                    r.Text = "5";
                    r.Enabled = false;
                    r_r.Text = "5";                //D/4
                    r_r.Enabled = false;
                    r_z.Text = "5";
                    r_z.Enabled = false;
                    alpha.Text = "0";
                    beta.Text = "0";
                    alpha.Enabled = false;
                    beta.Enabled = false;
                    h.Text = "20";
                    break;
                case ToolType.taperEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.TaperPara;
                    d.Text = "20";
                    r.Text = "0";
                    r.Enabled = false;
                    r_r.Text = "10";                
                    r_r.Enabled = false;
                    r_z.Text = "0";
                    r_z.Enabled = false;
                    alpha.Text = "0";
                    beta.Text = "20";
                    alpha.Enabled = false;
                    h.Text = "20";
                    break;
                case ToolType.taperBallEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.TaperBallPara2;
                    d.Text = "30";
                    r.Text = "20";
                    r_r.Text = "0";
                    r_r.Enabled = false;
                    r_z.Text = "20";
                    r_z.Enabled = false;
                    alpha.Text = "0";
                    beta.Text = "10";
                    alpha.Enabled = false;
                    h.Text = "20";
                    break;
                case ToolType.generalEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.GeneralPara;
                    d.Text = "35";
                    r.Text = "20";
                    r_r.Text = "2";
                    r_z.Text = "18";
                    alpha.Text = "7";
                    beta.Text = "15";
                    h.Text = "20";
                    break;
                case ToolType.coneEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.ConePara;
                    r.Text = "0";
                    r.Enabled = false;
                    alpha.Text = "25";
                    r_r.Text = "10";
                    r_r.Enabled = false;
                    r_z.Enabled = false;
                    beta.Text = "20";
                    h.Text = "20";
                    d.Text = "20";
                    break;
                case ToolType.roundedEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.RoundedPara;
                    d.Text = "20";
                    r.Text = "10";
                    r_r.Text = "0";
                    r_r.Enabled = false;
                    r_z.Text = "8";
                    alpha.Text = "0";
                    beta.Text = "0";
                    alpha.Enabled = false;
                    beta.Enabled = false;
                    h.Text = "20";
                    break;
                case ToolType.invertedConeEndMill:
                    pictureBox1.BackgroundImage = Properties.Resources.InvertedPara;
                    d.Text = "40";
                    r.Text = "20";
                    r_r.Text = "1";
                    r_z.Text = "18";
                    alpha.Text = "10";
                    beta.Text = "-7";
                    h.Text = "20";
                    break;
                default:
                    break;
            }
        }

        private bool checkForDouble(TextBox data)
        {
            try
            {
                double value = Convert.ToDouble(data.Text);
                if (!((data == alpha) || (data == beta)))
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
                MessageBox.Show(" value of "+data.Name +" is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool checkForInt(TextBox data)
        {
            try
            {
                int value = Convert.ToInt16(data.Text);
                if (value <= 0)
                {
                    MessageBox.Show(" value of " + data.Name + " is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
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
            if (!checkForDouble(d)) { return false; }
            if (!checkForDouble(r)) { return false; }
            if (!checkForDouble(r_r)) { return false; }
            if (!checkForDouble(r_z)) { return false; }
            if (!checkForDouble(alpha)) { return false; }   //can take negative values
            if (!checkForDouble(beta)) { return false; }    //can take negative values
            if (!checkForDouble(h)) { return false; }
            if (!checkForDouble(rakeAngle)) { return false; }
            if (!checkForDouble(helixAngle)) { return false; }
            if (!checkForInt(noOfFlutes)) { return false; }
            double R = double.Parse(r.Text);
            double Rr = double.Parse(r_r.Text);
            double Rz = double.Parse(r_z.Text);
            double Alpha = double.Parse(alpha.Text) * convFact;
            double Beta = double.Parse(beta.Text) * convFact;
            double D = double.Parse(d.Text);
            double u = D / 2 * (1-Math.Tan(Alpha)* Math.Tan(Beta));
            double Nz = ((Rr - u) * Math.Tan(Beta) + Rz - Math.Sqrt((R * R - Rz * Rz) * Math.Tan(Beta) * Math.Tan(Beta) + 2 * Rz * (Rr - u) * Math.Tan(Beta) - (Rr - u) * (Rr - u) + R * R)) / (Math.Tan(Beta) * Math.Tan(Beta) + 1);
            double LowestR = (Rz - Rr * Math.Tan(Alpha)) / Math.Sqrt(Math.Tan(Alpha) * Math.Tan(Alpha) + 1);
            LowestR = Math.Round(LowestR, 2); // Rounding ot off

            if (Math.Round(Rz,4)  < Math.Round(Rr * Math.Tan(Alpha), 4))
            {
                MessageBox.Show(" Rz cannot be less Rr*tan(alpha) = " + Math.Round(Rr * Math.Tan(Alpha), 2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (R < LowestR)
            {
                MessageBox.Show(" R cannot be less = " + LowestR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (((R * R - Rr * Rr) * Math.Tan(Alpha) * Math.Tan(Alpha) + 2 * Rz * Rr * Math.Tan(Alpha) - Rz * Rz + R * R) < 0)
            {
                MessageBox.Show(" Inconsistent data, tool profile is physically not possible", "Error type 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            double insideStuff2 = ((R * R - Rz * Rz) * Math.Tan(Beta) * Math.Tan(Beta) + 2 * Rz * (Rr - u) * Math.Tan(Beta) - (Rr - u) * (Rr - u) + R * R);
            if ( insideStuff2 < 0)
            {
                MessageBox.Show(" Inconsistent data, tool profile is physically not possible", "Error type 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (double.Parse(h.Text) < Nz)
            {
                MessageBox.Show(" Value of h is not acceptable, h can not be less than axial offset of point M i.e. "+Nz, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void toolParameterNextButton_Click(object sender, EventArgs e)
        {
            if (dataValidation())
            {
                if (this.nextForm == null)
                {
                    SelectWorkpieceProfileForm selectSurfaceForm = new SelectWorkpieceProfileForm(this);
                    selectSurfaceForm.Show();
                    this.nextForm = selectSurfaceForm;
                }
                else
                {
                    this.nextForm.Show();
                }
                this.Hide();
                FunctionWise.initializeToolGeometryParametresForGeneralMillingTool(double.Parse(d.Text), double.Parse(r.Text), double.Parse(r_r.Text), double.Parse(r_z.Text), double.Parse(alpha.Text), double.Parse(beta.Text), double.Parse(h.Text), double.Parse(helixAngle.Text), double.Parse(rakeAngle.Text), int.Parse(noOfFlutes.Text), toolType, constHelix.Checked);
                //FunctionWise.toolParametersInitialization(double.Parse(d.Text), double.Parse(h.Text), double.Parse(helixAngle.Text), double.Parse(rakeAngle.Text), int.Parse(noOfFlutes.Text));
            }

        }

        private void toolParameterBackButton_Click(object sender, EventArgs e)
        {
            this.prevForm.Show();
            this.Hide();
        }

        private void d_TextChanged(object sender, EventArgs e)
        {
            if (!checkForDouble(d)) return;
            switch (toolType)
            {
                case ToolType.cylindricalEndMill:
                    if (d.Text.Length > 0)
                    {
                        r_r.Text = (double.Parse(d.Text) / 2).ToString();
                    }
                    if (d.Text.Length == 0)
                    {
                        r_r.Text = " ";
                    }
                    break;
                case ToolType.ballEndMill:
                    if (d.Text.Length > 0)
                    {
                        r_z.Text = (double.Parse(d.Text) / 2).ToString();
                        r.Text = (double.Parse(d.Text) / 2).ToString();
                    }
                    if (d.Text.Length == 0)
                    {
                        r_z.Text = " ";
                        r.Text = " ";
                    }
                    break;
                case ToolType.bullNoseEndMill:
                    if (d.Text.Length > 0)
                    {
                        r_z.Text = (double.Parse(d.Text) / 4).ToString();
                        r.Text = (double.Parse(d.Text) / 4).ToString();
                        r_r.Text = (double.Parse(d.Text) / 4).ToString();
                    }
                    if (d.Text.Length == 0)
                    {
                        r_z.Text = " ";
                        r.Text = " ";
                        r_r.Text = "";
                    }
                    break;
                case ToolType.taperEndMill:
                    if (d.Text.Length > 0)
                    {
                        r_r.Text = (double.Parse(d.Text) / 2).ToString();
                    }
                    if (d.Text.Length == 0)
                    {
                        r_r.Text = " ";
                    }
                    break;
                case ToolType.taperBallEndMill:
                    break;
                case ToolType.generalEndMill:
                    break;
                case ToolType.coneEndMill:
                    if (d.Text.Length > 0)
                    {
                        r_r.Text = (double.Parse(d.Text) / 2).ToString();
                        r_z.Text = (double.Parse(d.Text) / 2 * Math.Tan(double.Parse(alpha.Text) * convFact)).ToString();
                    }
                    if (d.Text.Length == 0)
                    {
                        r_r.Text = " ";
                        r_z.Text = " ";
                    }
                    break;
                case ToolType.roundedEndMill:
                    break;
                case ToolType.invertedConeEndMill:
                    break;
                default:
                    break;
            }
        }

        private void ToolParametersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void r_TextChanged(object sender, EventArgs e)
        {
            if (!checkForDouble(r)) return;
            if (toolType == ToolType.taperBallEndMill)
            {
                if (r.Text.Length > 0)
                {
                    r_z.Text = double.Parse(r.Text).ToString();
                }
                if (d.Text.Length == 0)
                {
                    r_z.Text = "";
                }
            }
        }

        private void displayToolProfile_Click(object sender, EventArgs e)
        {
            if (dataValidation())
            {
                FunctionWise.isDisplayProfile = true;
                FunctionWise.initializeToolGeometryParametresForGeneralMillingTool(double.Parse(d.Text), double.Parse(r.Text), double.Parse(r_r.Text), double.Parse(r_z.Text), double.Parse(alpha.Text), double.Parse(beta.Text), double.Parse(h.Text), double.Parse(helixAngle.Text), double.Parse(rakeAngle.Text), int.Parse(noOfFlutes.Text), toolType, constHelix.Checked);
                double del_z = 0.1;
                double del_phi = 5; // degrees
                FunctionWise.machiningParametersInitialization(1, 0, 1, del_z, del_phi);
                FunctionWise.descritizationOfMultipleTool();
            }
        }
    }
}
