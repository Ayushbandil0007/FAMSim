using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    public partial class GenerateCustomSurface : Form
    {
        const double convFact = Math.PI / 180;
        int numberOfRows = 3;
        private SelectWorkpieceProfileForm preForm;
        List<double> xValues = new List<double>();
        List<double> zValues = new List<double>();
        double xMax;
        double delX = 0.01;
        double zMin;
        double zMax;

        public GenerateCustomSurface(SelectWorkpieceProfileForm preForm)
        {
            this.preForm = preForm;
            InitializeComponent();
            initializeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNewTextbox();
            numberOfRows++;
        }

        private void initializeData()
        {
            textboxno1.Enabled = false;
            textboxno1.Text = "0";
            textboxno2.Text = "15";
            textboxno3.Text = "0";

            textboxno4.Text = textboxno2.Text;
            textboxno4.Enabled = false;
            textboxno5.Text = "15.01";
            textboxno6.Text = "89.943";

            textboxno7.Text = textboxno5.Text;
            textboxno7.Enabled = false;
            textboxno8.Text = "30";
            textboxno9.Text = "-45";

            //hide labels and textboxes
            for (int i = 10; i < 31; i++)
            {
                TextBox textBox = (TextBox)Controls.Find(string.Format("textboxno{0}", i), false).FirstOrDefault();
                if (textBox != null)
                {
                    textBox.Hide();
                    if (i % 3 == 1)
                    {
                        textBox.Enabled = false;
                    }
                    if (i % 3 == 0)
                    {
                        textBox.Text = "0";
                    }
                }

                Label label = (Label)Controls.Find(string.Format("label_{0}", i), false).FirstOrDefault();
                if (label != null) 
                    label.Hide();

            }
            xMax = 30;
            calculateYvalues(xMax);
            updateGraph();
        }

        private void addNewTextbox()
        {
            for (int i = 0; i < 3; i++)
            {
                int numberofTexBox = numberOfRows * 3 + i + 1;
                TextBox textBox = (TextBox)Controls.Find(string.Format("textboxno{0}", numberofTexBox), false).FirstOrDefault();
                if (textBox != null)
                    textBox.Show();
                Label label = (Label)Controls.Find(string.Format("label_{0}", numberofTexBox), false).FirstOrDefault();
                if (label != null)
                    label.Show();
            }
        }

        private void changeValue(object sender, EventArgs e)
        {
            TextBox textBoxChanged = sender as TextBox;
            int index=0;
            string value="";
            for (int i = 1; i < 30; i++)
            {
                TextBox textBox = (TextBox)Controls.Find(string.Format("textboxno{0}", i), false).FirstOrDefault();
                if (textBox == textBoxChanged)
                {
                    index = i;
                    value = textBox.Text.ToString();
                    break;
                }
            }

            TextBox textBoxToChange = (TextBox)Controls.Find(string.Format("textboxno{0}", index+2), false).FirstOrDefault();
            textBoxToChange.Text = value;
        }

        private void updateGraph()
        {
            // Clear Chart
            this.display.Series.Clear();
            this.display.Legends.Clear();
            this.display.ChartAreas.Clear();
            this.display.Titles.Clear();

            this.ChartAreas("Surface  Profile (in mm)");
            //this.ChartTitle("Torque in Tool Coordinate System");

            var series1 = new Series
            {
                Color = Color.Black,
                BorderWidth = 3,
                IsVisibleInLegend = true,
                //IsXValueIndexed = true,
                ChartType = SeriesChartType.Line,
            };
            var series2 = new Series
            {
                Color = Color.Gray,
                BorderWidth = 1,
                IsVisibleInLegend = true,
                //IsXValueIndexed = true,
                ChartType = SeriesChartType.StepLine,
            };
            var series3 = new Series
            {
                Color = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80))))),
                BorderWidth = 1,
                IsVisibleInLegend = true,
                //IsXValueIndexed = true,
                ChartType = SeriesChartType.Point,
            };
            
            double zDepth = 100; // in mm   // it is the depth which we want to show in graph // otherwise useless
            
            for (int i = 0; i < xValues.Count(); i++)
            {
                series1.Points.AddXY(i * this.delX, zValues[i]);
                // adding surface below borders
                for (int j = 0; j < 2; j++)
                {
                    series2.Points.AddXY(i * this.delX, zMin - zDepth + (zValues[i] - zMin + zDepth) * j);
                }
            }

            // adding this series so graph doesnot autosize

            double xStep = 0.2;
            double R = FunctionWise.R;
            double spacingFactor=R/10;
            for (int i = 0; i < 18*spacingFactor; i++)
            {
                series3.Points.AddXY(R * Math.Sin(i * convFact * 5 / spacingFactor), (R - R * Math.Cos(i * convFact * 5 / spacingFactor)));
            }
            for (int i = 0; i < 20; i++)
            {
                series3.Points.AddXY(R, R + i);
            }
            
            display.Series.Add(series3);
            display.Series.Add(series2);
            display.Series.Add(series1);
            this.display.Invalidate();
        }

        private void ChartTitle(string title)
        {
            var titles1 = new Title
            {
                Name = title,
                Text = title + " Data",
                Visible = true,
            };
            this.display.Titles.Add(titles1);
        }

        private void ChartAreas(string title)
        {
            var axisX = new Axis
            {
                Minimum = 0,
                Maximum = Math.Max(xMax+5,40),
                //Interval = 50,//xInterval/delX,
                Title = "Distance in mm"
            };

            var axisY = new Axis
            {
                Minimum = Math.Min(zMin - 5, -20),
                Maximum = Math.Max(zMax + 5, 20),
                Interval = 10,
                Title = title,
            };

            var chartArea1 = new ChartArea
            {
                AxisX = axisX,
                AxisY = axisY,
            };

            this.display.ChartAreas.Add(chartArea1);
        }

        private void calculateYvalues(double xMax)
        {
            //clearing previous data
            xValues.Clear();
            zValues.Clear();
            xValues.Add(0);
            zValues.Add(0);
            int numberOfValues = 1;
            double delY;
            {   
                for (int i = 0; i < 10; i++)
                {
                    TextBox tillX = (TextBox)Controls.Find(string.Format("textboxno{0}", 3 * i + 2), false).FirstOrDefault();
                    TextBox angle = (TextBox)Controls.Find(string.Format("textboxno{0}", 3 * i + 3), false).FirstOrDefault();
                    while (xValues[xValues.Count - 1]+delX <= double.Parse(tillX.Text))
                    {
                        if ((numberOfValues + 1) * delX < xMax) // if next value is not less than x max then 
                        {
                            delY = delX * Math.Tan(double.Parse(angle.Text) * convFact);
                            xValues.Add(xValues[numberOfValues - 1] + delX);
                            zValues.Add(zValues[numberOfValues - 1] + delY);
                            numberOfValues++;
                        }
                        else
                        {
                            updateZminAndMax();
                            return;
                        }
                    }
                }
            }
        }

        private bool checkForDouble(TextBox data)
        {
            try
            {
                if (data.Text.Length!= 0)
                {
                    double value = Convert.ToDouble(data.Text);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Data is inconsistent, values are not real number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool dataValidation()
        {
            for (int i=1; i <= 30; i++)
            {
                TextBox tempTextBox = (TextBox)Controls.Find(string.Format("textboxno{0}", i), false).FirstOrDefault();
                if (!checkForDouble(tempTextBox)) { return false; }
            }
            for (int i = 1; i < 10; i++)
            {
                TextBox tempTextBox1 = (TextBox)Controls.Find(string.Format("textboxno{0}", 3 * i - 1), false).FirstOrDefault();
                TextBox tempTextBox2 = (TextBox)Controls.Find(string.Format("textboxno{0}", 3 * i + 2), false).FirstOrDefault();
                if (tempTextBox2.Text.Length != 0)
                {
                    if (double.Parse(tempTextBox2.Text)< double.Parse(tempTextBox1.Text))
                    {
                        MessageBox.Show("Data is inconsistent, value of piecewise linear function should be defined in increasing value of x ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        { return false; }
                    }
                }
            }
            return true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataValidation())
            {
                xMax = 0;
                for (int i = 1; i < 11; i++)
                {
                    TextBox textbox = (TextBox)Controls.Find(string.Format("textboxno{0}", 3 * i - 1), false).FirstOrDefault();
                    if (textbox.Text.Length > 0)
                    {
                        if (double.Parse(textbox.Text) > this.xMax) { xMax = double.Parse(textbox.Text); }
                    }
                }
                calculateYvalues(this.xMax);
                updateGraph();
            }
        }
        
        private void updateZminAndMax()
        {
            zMin = 0;
            for (int i = 0; i < zValues.Count; i++)
            {
                if (zValues[i] < zMin)
                {
                    this.zMin = zValues[i];
                }
                if (zValues[i] > zMin)
                {
                    zMax = zValues[i];
                }
            }
            
        }

        private void GenerateCustomSurfaceNextButton_Click(object sender, EventArgs e)
        {
            //FunctionWise.isSurfaceUserDefined = true;
            FunctionWise.initializeCustomSurfaceCoodinates(xValues,zValues);
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(preForm, null, SurfaceType.customSurface);
            toolInitialPositionForm.Show();
            this.preForm.Hide();
            this.Hide();
            this.Close();
        }
    }
}
