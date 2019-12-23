//------------------------------------------------------------------
// Please read the attached license document before using this class
//------------------------------------------------------------------

// window class for testing 3d chart using WPF
// version 0.1

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System;
using System.Collections;
using System.Threading;
//using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

namespace WPFChart3D
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // transform class object for rotate the 3d model
        public WPFChart3D.TransformMatrix m_transformMatrix = new WPFChart3D.TransformMatrix();

        // ***************************** 3d chart ***************************
        private WPFChart3D.Chart3D m_3dChart;       // data for 3d chart
        public int m_nChartModelIndex = -1;         // model index in the Viewport3d
        //public int m_nSurfaceChartGridNo = 100;     // surface chart grid no. in each axis
        //public int m_nScatterPlotDataNo = 5000;     // total data number of the scatter plot

        // ***************************** selection rect ***************************
        ViewportRect m_selectRect = new ViewportRect();
        public int m_nRectModelIndex = -1;
        Matrix3D totalMatrixInitial = new Matrix3D();
        int distance = 0;

        public Window1()
        {
            InitializeComponent();
            
            // selection rect
            m_selectRect.SetRect(new Point(-0.5, -0.5), new Point(-0.5, -0.5));
            WPFChart3D.Model3D model3d = new WPFChart3D.Model3D();
            ArrayList meshs = m_selectRect.GetMeshes();
            totalMatrixInitial = this.m_transformMatrix.m_totalMatrix;
        }

        int Kp;
        int Lp;
        int numberOfFlutes;

        public void initializeToolParameteres(int KpNew, int LpNew, int Nf)
        {
            Kp = KpNew;
            Lp = LpNew;
            numberOfFlutes = Nf;
        }

        public void TestSimpleScatterPlot(double[,] coordinates, int numberOfPointsInCuttingRegion)
        {
            distance++;
            mygrid.UpdateLayout();
            int nDotNo = coordinates.GetLength(0);
            // 1. set the scatter plot size
            m_3dChart = new ScatterChart3D();
            m_3dChart.SetDataNo(nDotNo);
            
            // 2. set the properties of each dot
            Random randomObject = new Random();
            int nDataRange = 40;
            for (int i = 0; i < nDotNo; i++)
            {
                ScatterPlotItem plotItem = new ScatterPlotItem();
                
                plotItem.x = (float)coordinates[i, 0];
                plotItem.y = (float)coordinates[i, 1];
                plotItem.z = (float)coordinates[i, 2];
                
                if (numberOfFlutes == 0)
                {
                    label.Content = "Distance travelled by tool = " + distance +" mm.";
                    if (i < numberOfPointsInCuttingRegion)
                    {
                        plotItem.w = 0.25f;
                        plotItem.h = 0.10f;
                        plotItem.shape = (int)Chart3D.SHAPE.BAR;
                        plotItem.color = Color.FromArgb(200, (byte)(160), (byte)(5), (byte)(5));
                    }
                    else
                    {
                        plotItem.w = 0.05f;
                        plotItem.h = 0.1f;
                        plotItem.shape = (int)Chart3D.SHAPE.BAR;
                        plotItem.color = Color.FromArgb(200, (byte)(160), (byte)(160), (byte)(160));
                    }
                }
                else
                {
                    label.Content=("");
                    if (((int)(i / Lp)) % (Kp / numberOfFlutes) == 0)
                    {
                        int n = (int)(((int)(i / Lp)) / (Kp / numberOfFlutes));
                        plotItem.w = 0.8f;
                        plotItem.h = 0.20f;
                        plotItem.shape = (int)Chart3D.SHAPE.PYRAMID;
                        //plotItem.color = Color.FromArgb(200, (byte)(80), (byte)(80), (byte)(60));
                        plotItem.color = Color.FromArgb(1, (byte)(60 + 20 * n), (byte)(60 + 20 * n), (byte)(30 + 40 * n));
                    }
                    else
                    {
                        plotItem.w = 0.2f;
                        plotItem.h = 0.10f;
                        plotItem.shape = (int)Chart3D.SHAPE.BAR;
                        plotItem.color = Color.FromArgb(1, (byte)(160), (byte)(160), (byte)(160));
                    }
                }
                ((ScatterChart3D)m_3dChart).SetVertex(i, plotItem);

            }
            // 3. set axes
            m_3dChart.GetDataRange();
            m_3dChart.SetAxes();

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = ((ScatterChart3D)m_3dChart).GetMeshes();

            // 5. display vertex no and triangle no.
            UpdateModelSizeInfo(meshs);

            // 6. show 3D scatter plot in Viewport3d
            WPFChart3D.Model3D model3d = new WPFChart3D.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);

            // 7. set projection matrix
            float viewRange = (float)nDataRange;
            m_transformMatrix.CalculateProjectionMatrix(0, viewRange, 0, viewRange, 0, viewRange, 0.5);
            TransformChart();
            mainViewport.UpdateLayout();
        }

        public void OnViewportMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);
            if (args.ChangedButton == MouseButton.Left)         // rotate or drag 3d model
            {
                m_transformMatrix.OnLBtnDown(pt);
            }
            else if (args.ChangedButton == MouseButton.Right)   // select rect
            {
                m_selectRect.OnMouseDown(pt, mainViewport, m_nRectModelIndex);
            }
        }

        public void OnViewportMouseMove(object sender, System.Windows.Input.MouseEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);

            if (args.LeftButton == MouseButtonState.Pressed)                // rotate or drag 3d model
            {
                m_transformMatrix.OnMouseMove(pt, mainViewport);

                TransformChart();
            }
            else if (args.RightButton == MouseButtonState.Pressed)          // select rect
            {
                m_selectRect.OnMouseMove(pt, mainViewport, m_nRectModelIndex);
            }
            else
            {
                /*
                String s1;
                Point pt2 = m_transformMatrix.VertexToScreenPt(new Point3D(0.5, 0.5, 0.3), mainViewport);
                s1 = string.Format("Screen:({0:d},{1:d}), Predicated: ({2:d}, H:{3:d})", 
                    (int)pt.X, (int)pt.Y, (int)pt2.X, (int)pt2.Y);
                this.statusPane.Text = s1;
                */
            }
        }

        public void OnViewportMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);
            if (args.ChangedButton == MouseButton.Left)
            {
                m_transformMatrix.OnLBtnUp();
            }
            else if (args.ChangedButton == MouseButton.Right)
            {
                if (m_nChartModelIndex == -1) return;
                // 1. get the mesh structure related to the selection rect
                MeshGeometry3D meshGeometry = Model3D.GetGeometry(mainViewport, m_nChartModelIndex);
                if (meshGeometry == null) return;
              
                // 2. set selection in 3d chart
                m_3dChart.Select(m_selectRect, m_transformMatrix, mainViewport);

                // 3. update selection display
                m_3dChart.HighlightSelection(meshGeometry, Color.FromRgb(200, 200, 200));
            }
        }

        // zoom in 3d display
        public void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs args)
        {
            m_transformMatrix.OnKeyDown(args);
            TransformChart();
        }

         private void UpdateModelSizeInfo(ArrayList meshs)
        {
            if (meshs == null)
            {
                MessageBox.Show("No points to display");
                return;
            }
            int nMeshNo = meshs.Count;
            int nChartVertNo = 0;
            int nChartTriangelNo = 0;
            for (int i = 0; i < nMeshNo; i++)
            {
                nChartVertNo += ((Mesh3D)meshs[i]).GetVertexNo();
                nChartTriangelNo += ((Mesh3D)meshs[i]).GetTriangleNo();
            }
        }

        // this function is used to rotate, drag and zoom the 3d chart
        public void TransformChart()
        {
            if (m_nChartModelIndex == -1) return;
            ModelVisual3D visual3d = (ModelVisual3D)(this.mainViewport.Children[m_nChartModelIndex]);
            if (visual3d.Content == null) return;
            Transform3DGroup group1 = visual3d.Content.Transform as Transform3DGroup;
            group1.Children.Clear();
            group1.Children.Add(new MatrixTransform3D(m_transformMatrix.m_totalMatrix));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //string  s=    this.mainViewport.Camera.GetValue(ProjectionCamera.LookDirectionProperty).ToString();
            // string t = this.mainViewport.Camera.GetValue(ProjectionCamera.PositionProperty).ToString();
            // string u = this.mainViewport.Camera.GetValue(ProjectionCamera.FarPlaneDistanceProperty).ToString();
            // string v = this.mainViewport.Camera.GetValue(ProjectionCamera.NearPlaneDistanceProperty).ToString();
            // string w = this.mainViewport.Camera.GetValue(ProjectionCamera.UpDirectionProperty).ToString();

            //string s = this.mainViewport.Camera.GetValue(OrthographicCamera.LookDirectionProperty).ToString();
            //string t = this.mainViewport.Camera.GetValue(OrthographicCamera.PositionProperty).ToString();
            //string u = this.mainViewport.Camera.GetValue(OrthographicCamera.FarPlaneDistanceProperty).ToString();
            //string v = this.mainViewport.Camera.GetValue(OrthographicCamera.NearPlaneDistanceProperty).ToString();
            //string w = this.mainViewport.Camera.GetValue(OrthographicCamera.UpDirectionProperty).ToString();

            //string s = this.mainViewport.Camera.GetValue(PerspectiveCamera.LookDirectionProperty).ToString();
            //string t = this.mainViewport.Camera.GetValue(PerspectiveCamera.PositionProperty).ToString();
            //string u = this.mainViewport.Camera.GetValue(PerspectiveCamera.FarPlaneDistanceProperty).ToString();
            //string v = this.mainViewport.Camera.GetValue(PerspectiveCamera.NearPlaneDistanceProperty).ToString();
            //string w = this.mainViewport.Camera.GetValue(PerspectiveCamera.UpDirectionProperty).ToString();

            //this.mainViewport.Camera.SetValue(PerspectiveCamera.LookDirectionProperty, this.mainViewport.Camera.GetValue(PerspectiveCamera.LookDirectionProperty));
            //this.m_transformMatrix.m_totalMatrix = totalMatrixInitial;
            //this.TransformChart();
            mainViewport.Camera.SetValue(ProjectionCamera.UpDirectionProperty, new Vector3D(1, 0, 1));
            mainViewport.Camera.SetValue(ProjectionCamera.LookDirectionProperty, new Vector3D(1, 0, 1));
            //string cameraLookDir = this.camera.LookDirection.ToString();

            //string Y= this.canvasOn3D.GetValue(OrthographicCamera.LookDirectionProperty).ToString();
            //this.mainViewport.BringIntoView(m_selectRect)            //string y= this.mainViewport.Camera.GetValue(OrthographicCamera.)
            //MessageBox.Show("canvas camera 3d" + this.canvasOn3D.GetValue(Viewport3DVisual.CameraProperty));
            //MessageBox.Show("canvas view port"+this.canvasOn3D.GetValue(Viewport3DVisual.ViewportProperty));
            //MessageBox.Show("Look direction"+s+", Position "+t+", Far Plane"+u+", Near plane"+v+", Up direction"+w + ", lOOK direction" + Y);
            //MessageBox.Show("Look direction" + s + ", Position " + t + ", Far Plane" + u + ", Near plane" + v + ", Up direction" + w );

            //MessageBox.Show("cameralookdir " + cameraLookDir);
        }
    }
}
