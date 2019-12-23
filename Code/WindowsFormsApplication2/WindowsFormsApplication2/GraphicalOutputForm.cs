using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    public partial class GraphicalOutputForm : Form
    {
        const double convFact = Math.PI / 180;
        double[,] FCNdata;
        double[] torque;
        bool forceOrTorque = false; // false for torque
        bool numberOfCyclesmoreThan2 = false; // this variable is to determine whether we are plotting for less than 2 or more than
        // 2 cycles and accordingly can change the x axis label 

        // 2 diffrent constructors for force and torque
        public GraphicalOutputForm(double[,] FCNdata)
        {
            InitializeComponent();
            this.FCNdata = FCNdata;
            this.forceOrTorque = true; // resetting to true
        }

        public GraphicalOutputForm(double[] torque)
        {
            InitializeComponent();
            this.torque = torque;
        }
        
        private void GraphicalOutputForm_Load(object sender, EventArgs e)
        {
            //System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            int numberOfPoints = forceOrTorque ? FCNdata.GetLength(0) : torque.GetLength(0);
            numberOfCyclesmoreThan2 = numberOfPoints * FunctionWise.del_phi > 4 * Math.PI;// if more than 2 cycles then true else false
            this.RunReport();
            //System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Runs the report chart data.
        /// </summary>
        private void RunReport()
        {
            // Clear Chart
            this.chart1.Series.Clear();
            this.chart1.Legends.Clear();
            this.chart1.ChartAreas.Clear();
            this.chart1.Titles.Clear();

            // Build Chart
            //this.ChartSeries(1, "y = 2x");
            //this.ChartSeries(2, "y = x^2 - 1");
            this.ForceAndTorqueGraph();
            this.chart1.Invalidate();
        }

        /// <summary>
        /// Sets up the look and style of the chart, Areas.
        /// </summary>
        /// <param name="title">Title of the chart.</param>
        private void ChartAreas(string title)
        {
            int interval= (numberOfCyclesmoreThan2)? (int)(Math.Round(360 * convFact / FunctionWise.del_phi)) : interval = (int)(Math.Round(30 * convFact / FunctionWise.del_phi));
            string xtitle = (numberOfCyclesmoreThan2) ? "Number of revolutions" : "Angle in degrees";
            var axisX = new Axis
            {
                Minimum = 1,
                Interval = interval,
                TitleForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
                Title = xtitle,
                LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
            };
            axisX.MinorTickMark.Interval = 1;
            //axisX.MinorGrid.Interval = 1;
            axisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            axisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            axisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            axisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            var axisY = new Axis
            {
                //Minimum = 0,
                //Maximum = 110,
                Title = title,
                TitleForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
                LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
            };
            axisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            axisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            axisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX = axisX,
                AxisY = axisY,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60))))),
                //BackGradientStyle = GradientStyle.TopBottom
        };
            this.chart1.ChartAreas.Add(chartArea1);
        }

        /// <summary>
        /// Sets up the look and style of the chart, Title.
        /// </summary>
        /// <param name="title">Title of the chart.</param>
        private void ChartTitle(string title)
        {
            var titles1 = new System.Windows.Forms.DataVisualization.Charting.Title
            {
                Name = title,
                Text = title + " Data",
                Visible = true,
                ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
            };
            this.chart1.Titles.Add(titles1);
        }

        /// <summary>
        /// Sets up the look and style of the chart, Legends.
        /// </summary>
        /// <param name="name">Name of the chart data.</param>
        private void ChartLegends(string name)
        {
            var legends1 = new Legend
            {
                Name = name,
            };
            this.chart1.Legends.Add(legends1);
        }

        /// <summary>
        /// Sets up the look and style of the chart, Series.
        /// </summary>
        /// <param name="data">The data type.</param>
        /// <param name="name">The name of the data.</param>
        
        public void ForceAndTorqueGraph()
        {
            double xMarking = (numberOfCyclesmoreThan2) ? FunctionWise.del_phi/(2*Math.PI) : FunctionWise.del_phi / convFact;
            if (!forceOrTorque)
            {
                Top = 50;
                Left = 50;
                this.ChartAreas("In Newton-meters");
                this.ChartTitle("Torque in Tool Coordinate System");
                var series1 = new Series
                {
                    Name = "Torque in TCS",
                    Color = System.Drawing.Color.Blue,
                    BorderWidth = 3,
                    IsVisibleInLegend = true,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line,
                };
                for (int i = 0; i < torque.GetLength(0); i++)
                {
                    //series1.Points.AddXY(xMarking * i, torque[i]); 
                    series1.Points.AddXY(xMarking * i, torque[i]); 
                }
                chart1.Series.Add(series1);
                ChartLegends("TRIAL1");
            }
            else
            {
                Top = 90;
                Left = 90;
                this.ChartAreas("In Newtons");
                this.ChartTitle("Force in Global Coordinate System");
                var series1 = new Series
                {
                    Name = "Force along X",
                    Color = System.Drawing.Color.Blue,
                    BorderWidth = 3,
                    IsVisibleInLegend = true,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line,
                };
                var series2 = new Series
                {
                    Name = "Force along Y",
                    Color = System.Drawing.Color.DarkOrange,
                    BorderWidth = 3,
                    IsVisibleInLegend = true,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line,
                };
                var series3 = new Series
                {
                    Name = "Force along Z",
                    Color = System.Drawing.Color.Gray,
                    BorderWidth = 3,
                    IsVisibleInLegend = true,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line,
                };

                for (int i = 0; i < FCNdata.GetLength(0); i++)
                {
                    series1.Points.AddXY(xMarking * i, FCNdata[i, 0]);
                    series2.Points.AddXY(xMarking * i, FCNdata[i, 1]);
                    series3.Points.AddXY(xMarking * i, FCNdata[i, 2]);
                }

                this.chart1.Series.Add(series1);
                this.chart1.Series.Add(series2);
                this.chart1.Series.Add(series3);
                ChartLegends("TRIAL2");
            }
        }
    }
}
