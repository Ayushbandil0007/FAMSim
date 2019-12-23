using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using WPFChart3D;

namespace WindowsFormsApplication2
{
    public enum ToolType
    {
        cylindricalEndMill,
        ballEndMill,
        bullNoseEndMill,
        taperEndMill,
        taperBallEndMill,
        generalEndMill,
        coneEndMill,
        roundedEndMill,
        invertedConeEndMill,
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new SelectToolForm());
        }
    }

    public class FunctionWise
    {
        //
        // VARIABLE DECLARATION
        // 
        // convertion factor from degree to radians
        const double convFact = Math.PI / 180;

        // Tool geometric parameters
        public static ToolType toolType; 
        static double D;
        public static double R;
        static double Rr;
        static double Rz;
        static double alpha;
        static double beta;
        public static double h;
        static double helixAngle;                // helix angle 
        static double rakeAngle;                          // Rake angle (in radians) 
        static int Nf;                                  // number of cutting edges
        static bool isConstantHelix;

        // Tool geometry Offset Parameters
        static double Mr;
        static double Mz;
        static double Nz;
        static double Nr;
        static double u;
        static double zone0Length;

        //Machining process parameters
        public static double[] feedVector = new double[3];     // in mm/min    // y component should always be zero, since the feed direction is only defined in the direction 
                                                        //of propogation of machine
        static double feedAngle;
        static double feed_rate;               // mm / min
        static double rpm;                           // rev / min
        static double feedPerRevolution;                 // feed since h is mm / rev or uncut chip thickness
        static double depthCorrected;                        // Depth of cut (in mm)
        static double c_depth;
        static double St;                         // feed per tooth
        static double leadAngle;
        static double tiltAngle;
        static double slopeinCNplane;
        static double stepOver;
        static bool stepOverEnabled;
        static double surfaceRoughness;

        // Lp and Kp (# of divisions)
        static int Lp;
        public static double del_z;
        public static double del_phi;            
        static int Kp;       // # of axial divisions

        // Material specific constants
        const double tau_s = 613;                          // in MPA

        // Tool descretization parameters 
        static double[] radius;
        static double[] kappa;
        static double[] phi;
        static double[] shi;
        static double[,] phi_2;
        static double[,] xx_tcs;
        static double[,] yy_tcs;
        static double[,] zz_tcs;
        static double[,] xx_fcn;
        static double[,] yy_fcn;
        static double[,] zz_fcn;
        static double[,] tcsCoordinates;
        static List<double[]> toolAndSurfacePoints;
        static int numberOfPointsOnTool;
        //static double distanceTravelledByToolForSimulation;
        //static System.Windows.Forms.Timer timer;

        //static double[,,] relatvVectr; // relative vector of any point on surface w.r.t. centre in FCN
        static double[] centreInFCNwrtToolOrigin = new double[3];
        // double[] centreCoordinates = new double[3]; // In real life coordinates 0--> x, 1--> y, 2--> z
        static double[] toolBaseCoordinates = new double[3];

        // Torque in TCS
        static double[] torqueInTCS;

        // Declaring the values of friction coefficient and shear angle which are material properties
        static Dictionary<string, double> matPro;
        static double phi_c;             // matPro ~ Material Properties
        static double beta_a;

        // Calculation of cutting force coefficients
        static double Kte;
        static double Kre;
        static double Kae;
        static double[] cutF;
        static double Ktc;
        static double Krc;
        static double Kac;
        static List<double[]> profile;
        public static bool isDisplayProfile;
        public static string locationOfExport;

        // other variables 
        static bool isTvariable;  // If lead and tilt are variable then T matrix will be variable 
        //public static bool isSurfaceUserDefined=false;
        public static bool isExportExcelSheet;
        static List<double> xValuesFromUserDefinedSurface;
        static List<double> zValuesFromUserDefinedSurface;
        static int StatusNumberOfPointsExportedToExcel;
        static PleaseWaitForm display; 
        static double time;
        static Window1 cuttingZoneSimulation;
        static Timer timer;
        static int distanceTravelled;
        static double timeForSimulation;

        //Surface Parameters
        static double xMargin;
        static double yMargin;
        static double zStep;
        static double alphaSurface;
        static double betaSurface;
        public static SurfaceType surfaceType;
        //static Window1 surfaceplotwindow;

        // VARIABLE INITIALIZATION FUCNTIONS

        public static void machiningParametersInitialization(double verticalFeedNew, double horizontalFeedNew, double rpmNew, double del_zNew, double del_phiNew)
        {
            //Machining process parameters
            feedVector = new double[3] { horizontalFeedNew, 0, -verticalFeedNew };     // in mm/min    // y component should always be zero, since the feed direction is only defined in the direction 
                                                                                       //of propogation of machine
            feedAngle = Math.Atan(-feedVector[2] / feedVector[0]);
            feed_rate = vectorMagnitude(feedVector);               // mm / min
            rpm = rpmNew;                           // rev / min
            feedPerRevolution = feed_rate / rpm;                 // feed since h is mm / rev or uncut chip thickness
            St = feedPerRevolution / Nf;                         // feed per tooth

            // Lp and Kp (# of divisions)
            
            del_z = del_zNew;
            Lp = (int)(h/del_z);
            del_phi = del_phiNew * convFact;               // in radians
            Kp = (int)(2 * Math.PI / del_phi);       // # of axial divisions

            // Surface and tool initial condition parameter initialization
            centreInFCNwrtToolOrigin = new double[3] { 0, 0, R };
            //centreCoordinates = new double[3] { 0, 0, 0 };      // In real life coordinates 0--> x, 1--> y, 2--> z

            // Declaring the values of friction coefficient and shear angle which are material properties
            matPro = ocm_Ti(St, rakeAngle, tau_s);
            phi_c = matPro["phi_c"];             // matPro ~ Material Properties
            beta_a = matPro["beta_a"];

            // Calculation of cutting force coefficients
            Kte = 24;
            Kre = 43;
            Kae = 0;
            cutF = ccm_Ti(rakeAngle, phi_c, beta_a, tau_s, helixAngle);
            Ktc = cutF[0];
            Krc = cutF[1];
            Kac = cutF[2];
            profile = new List<double[]>();
            toolAndSurfacePoints = new List<double[]>();

            // other variables 
            isTvariable = false;  // If lead and tilt are variable then T matrix will be variable 
            time = 0;

            // Tool decretization parameters 
            kappa = new double[Lp];
            phi = new double[Kp];
            shi = new double[Lp];
            phi_2 = new double[Lp, Kp];
            xx_tcs = new double[Lp, Kp];
            yy_tcs = new double[Lp, Kp];
            zz_tcs = new double[Lp, Kp];
            xx_fcn = new double[Lp, Kp];
            yy_fcn = new double[Lp, Kp];
            zz_fcn = new double[Lp, Kp];
            //relatvVectr = new double[Lp, Kp, 3]; // relative vector of any point on surface w.r.t. centre in FCN
        }

        public static void initializeCustomSurfaceCoodinates(List<double> xValues, List<double> zValues)
        {
            xValuesFromUserDefinedSurface = xValues;
            zValuesFromUserDefinedSurface = zValues;
        }

        public static void initializeLeadAndTilt(double lead, double tilt)
        {
            leadAngle = lead;
            tiltAngle = tilt;
            slopeinCNplane = Math.Tan(Math.PI/2+tiltAngle*convFact);
        }

        public static void initializeStepOver(bool stepOverEnabledNew, double stepOverNew)
        {
            stepOverEnabled = stepOverEnabledNew;
            stepOver = stepOverNew;
        }

        public static void initializationSurfaceParameters(double depth,double xValueNew, double yValueNew, double alphaSurfaceNew, double betaSurfaceNew, double zStepNew, SurfaceType surfaceTypeNew)
        {
            // incoming values are in mm and degrees
            c_depth = depth;
            xMargin = xValueNew;
            yMargin = yValueNew;
            alphaSurface = alphaSurfaceNew * convFact;
            betaSurface = betaSurfaceNew * convFact;
            zStep = zStepNew;
            surfaceType = surfaceTypeNew;
        }

        public static void initializeToolGeometryParametresForGeneralMillingTool(double DNew, double RNew, double RrNew, double RzNew, double alphaNew, double betaNew, double hNew, double hel_aNew, double alpha_rNew, int NfNew, ToolType toolNew, bool IsConstHelixNew)
        {
            D = DNew;
            R = RNew;
            Rr = RrNew;
            Rz = RzNew;
            alpha = alphaNew * convFact;
            beta = betaNew * convFact;
            h = hNew;
            helixAngle = hel_aNew * convFact;                          // Helix angle(in radians)
            rakeAngle = alpha_rNew * convFact;                  // Rake angle (in radians) 
            Nf = NfNew;                                       // number of cutting edges
            toolType = toolNew;
            isConstantHelix = IsConstHelixNew;
        }

        //// MACHINING PARAMETRES DEFINING FUNCTIONS
        // Transformation matrix TCS----> FCN  
        static double[,] T()
        {
            double[,] T = new double[3, 3] { {  Math.Cos(lead())                   , 0                 ,   Math.Sin(lead())},
                                             {  Math.Sin(tilt()) * Math.Sin(lead()), Math.Cos(tilt())  , - Math.Sin(tilt()) * Math.Cos(lead()) },
                                             {- Math.Cos(tilt()) * Math.Sin(lead()), Math.Sin(tilt())  ,   Math.Cos(tilt()) * Math.Cos(lead()) } };
            return T;
        }

        // Functions of lead and tilt angles are written so that in case in future if we want lead and tilt as a function of time
        // and we can change it dynamically without changing the entire model; currently constant lead and tilts are used
        static double lead()
        {
            return leadAngle * convFact; // in radians
        }

        static double tilt()
        {
            return tiltAngle * convFact; // in radians 
        }

        //static double r_z(int j)
        //{
        //    return Math.Sqrt(Math.Pow(R, 2) - Math.Pow((R - z_ms(j)), 2));
        //}

        static double z_ms(int j)
        {
            //return j * h / (Lp - 1);
            return j * del_z *Lp/(Lp-1);
            //return j * del_z * 100 / 99;
        }

        // FORCE CALCULATING FORCES FUCNTIONS (MAIN)
        static double[] forcesInFCN(double theta)
        {
            theta = theta * convFact;
            int i = (int)Math.Round(theta / del_phi);
            double[] F_fcn = matMultiply(T(), forcesInTCS(i));
            return F_fcn;
        }

        static double[] forcesInTCS(int i)
        {
            // Calculation of of forces and torques
            double[] F_tcs = new double[3];
            torqueInTCS[i] = 0; // to delete previous value if more than one rotation
            for (int k = 0; k < Nf; k++)
            {
                int j = (int)((i + k * Kp / Nf) % Kp);
                //Console.WriteLine("for i = {0}, j's are {1}",i,j);
                // j is to keep the phase difference when there are more than 1 flute 
                // round is used because in calculations the value is converted into
                // double, which is not accepted to be an index
                double[,] dF_tcs_arrays = dF_tcs(j);
                for (int row = 0; row < Lp; row++)
                {
                    F_tcs[0] = F_tcs[0] + dF_tcs_arrays[row, 0];
                    F_tcs[1] = F_tcs[1] + dF_tcs_arrays[row, 1];
                    F_tcs[2] = F_tcs[2] + dF_tcs_arrays[row, 2];
                    torqueInTCS[i] = torqueInTCS[i] + dF_tcs_arrays[row, 3];
                    //Console.WriteLine("for i = {0}, j's are {1} and F_tcs are {2}, {3}, {4}", i, j, F_tcs[0], F_tcs[1], F_tcs[2]);
                }
            }
            return F_tcs;
        }

        static double correctDepthDuetoRotationOfTool()
        {
            double Zmin = 0;
            for (int i = 0; i < Kp; i++)                            //loop for radial incremental angles.
            {
                for (int j = 0; j < Lp; j++)
                {
                    if (Zmin > zz_fcn[j, i]) Zmin = zz_fcn[j, i];
                }
            }
            return c_depth + Zmin;
        }

        static double[,] dF_tcs(int i)
        {
            double[] dF_t_lcs = new double[Lp];
            double[] dF_r_lcs = new double[Lp];
            double[] dF_a_lcs = new double[Lp];
            double[] dTorque_tcs = new double[Lp];
            double[] dFx_tcs = new double[Lp];
            double[] dFy_tcs = new double[Lp];
            double[] dFz_tcs = new double[Lp];
            double[,] toReturn = new double[Lp, 4];

            for (int j = 0; j < Lp; j++)
            {
                //double kappa = Math.Asin(r_z(j) / R);  //// axial immersion angle-"Angle between the cutter axis and normal of helical cutting edge at particular point"
                // defining normal vector for any point in TCS
                double[] normalVector = new double[3] { Math.Sin(kappa[j]) * Math.Sin(phi_2[j, i]), Math.Sin(kappa[j]) * Math.Cos(phi_2[j, i]), -Math.Cos(kappa[j]) };

                //CosValue is the value of cosine of vector joining the point [j, i] to R vector in FCN to the feedVector
                //double cosValue = cosOfAngleBtwVectors(getRelatvVectr(j, i), feedVector);
                double cosValue = cosOfAngleBtwVectors(matMultiply(T(), normalVector), feedVector);

                //// Now we need to find out the region which is actually in contact with workpiece and fascilititating the cutting 
                // this can be done by doing two types of sorting processes 
                // 1) to remove the points above cutting depth 
                // 2) to remove the points opposite to the feed direction

                //// Finding the region below the actual depth of cut

                // Feed check: only the points pointing towards feed contributes in cutting, checked by positive value of cosValue
                if ((Math.Round(cosValue, 8) > 0) && (cuttingZoneCheck(j, i)))
                {
                    //profile.Add(new double[3] { xx_fcn[j, i], yy_fcn[j, i], zz_fcn[j, i] });
                    //Console.WriteLine(xx_fcn[j, i] + " " + yy_fcn[j, i] + " " + zz_fcn[j, i]);
                    double chipWidth = (kappa[j] != 0) ? del_z / Math.Sin(kappa[j]) : 0;
                    double chipLength = (j > 0) ? vectorMagnitude(new double[3] { xx_tcs[j, i] - xx_tcs[j - 1, i], yy_tcs[j, i] - yy_tcs[j - 1, i], zz_tcs[j, i] - zz_tcs[j - 1, i] }) : 0;
                    double chipThickness = St * cosValue; //St *  (Math.Sin(kappa) * Math.Sin(phi_2[j, i]) * Math.Cos(feedAngle) + Math.Cos(kappa) * Math.Sin(feedAngle));
                    //St * cosValue;
                    // Calculation of elemental forces and torques

                    //Console.WriteLine("Points that are in cutting zone are ");
                    //Console.Write("index ({0}, {1}) ");
                    dF_t_lcs[j] = Kte * chipLength + Ktc * chipWidth * chipThickness;
                    dF_r_lcs[j] = Kre * chipLength + Krc * chipWidth * chipThickness;
                    dF_a_lcs[j] = Kae * chipLength + Kac * chipWidth * chipThickness;
                    toReturn[j, 3] = dF_t_lcs[j] * radius[j]; // 4th column is torque
                    
                    // A matrix is used to transform from Local Coordinate system to Tool Coordinate system
                    double[,] A = new double[3, 3] { { - Math.Sin(kappa[j]) * Math.Sin(phi_2[j, i]), - Math.Cos(phi_2[j, i]), - Math.Cos(kappa[j]) * Math.Sin(phi_2[j, i])},
                                                 { - Math.Sin(kappa[j]) * Math.Cos(phi_2[j, i]),   Math.Sin(phi_2[j, i]), - Math.Cos(kappa[j]) * Math.Cos(phi_2[j, i])},
                                                 {   Math.Cos(kappa[j])                        ,   0                    , - Math.Sin(kappa[j])                        }};

                    double[] dF_xyz_tcs = matMultiply(A, new double[3] { dF_t_lcs[j], dF_r_lcs[j], dF_a_lcs[j] }); //Surface points in FCN Coordinate system
                    toReturn[j, 0] = dF_xyz_tcs[0]; // dFx
                    toReturn[j, 1] = dF_xyz_tcs[1]; // dFy
                    toReturn[j, 2] = dF_xyz_tcs[2]; // dFz
                    //Console.WriteLine("Forces are {" + toReturn[j, 0] + " "+ toReturn[j, 1] + " " + toReturn[j, 2]+"}");
                }
            }
            return toReturn;
        }

        // FORCE CALCULATING FORCES FUCNTIONS (SUB)

        public static void descritizationOfBallEndTool()
        {
            centreInFCNwrtToolOrigin = matMultiply(T(), new double[3] { 0, 0, R });

            for (int j = 0; j < Lp; j++)
            {
                shi[j] = ((Math.Tan(helixAngle)) / R) * z_ms(j);     // radial lag angle  
                kappa[j] = Math.Asin(radius[j] / R);
            }

            // Tool descreted geometry generation 
            for (int i = 0; i < Kp; i++)                            //loop for radial incremental angles.
            {
                phi[i] = i * del_phi;
                for (int j = 0; j < Lp; j++)
                {                                                   // loop for depth / axial increment
                    phi_2[j, i] = phi[i] - shi[j];                  // radial immersion angle
                    

                    // Surface points in TCS coordinate system
                    xx_tcs[j, i] = radius[j] * Math.Sin(phi_2[j, i]);
                    yy_tcs[j, i] = radius[j] * Math.Cos(phi_2[j, i]);
                    zz_tcs[j, i] = z_ms(j);

                    // Surface points in FCN coordinate system
                    double[] XYZ_fcn = matMultiply(T(), new double[3] { xx_tcs[j, i], yy_tcs[j, i], zz_tcs[j, i] }); //Surface points in FCN Coordinate system
                    xx_fcn[j, i] = XYZ_fcn[0];
                    yy_fcn[j, i] = XYZ_fcn[1];
                    zz_fcn[j, i] = XYZ_fcn[2];

                    // relativeVector is vector joining centre of sphere and the point
                    //relatvVectr[j, i, 0] = xx_fcn[j, i] - centreInFCNwrtToolOrigin[0];
                    //relatvVectr[j, i, 1] = yy_fcn[j, i] - centreInFCNwrtToolOrigin[1];
                    //relatvVectr[j, i, 2] = zz_fcn[j, i] - centreInFCNwrtToolOrigin[2];
                    // NOTE: relativeVector needs to be updated if T matrix is variable 
                }
            }
            depthCorrected= correctDepthDuetoRotationOfTool(); //Temp
            System.Windows.Forms.MessageBox.Show(" Corrected depth is  "+depthCorrected, "Number of points", MessageBoxButtons.OK, MessageBoxIcon.Error);
            toolBaseCoordinates = new double[3] { 0, 0, -depthCorrected };
        }

        static bool cuttingZoneCheck(int j, int i)
        {
            //any point should be in cutting region i.e. where material exists
            double[] ptCoordinate = new double[3];

            ptCoordinate[0] = toolBaseCoordinates[0] + xx_fcn[j, i]; //Temp
            ptCoordinate[1] = toolBaseCoordinates[1] + yy_fcn[j, i];
            ptCoordinate[2] = toolBaseCoordinates[2] + zz_fcn[j, i];

            //ptCoordinate[0] = centreCoordinates[0] + getRelatvVectr(j, i)[0];
            //ptCoordinate[1] = centreCoordinates[1] + getRelatvVectr(j, i)[1];
            //ptCoordinate[2] = centreCoordinates[2] + getRelatvVectr(j, i)[2];

            // Checking if the point has already been removed by the previous cut
            if (stepOverEnabled)
            {
                if (!isPointPresentAfterPreviousCut(j, i)) { return false; }
            }

            // Checking for surface constraints
            switch (surfaceType)
            {
                case SurfaceType.planer:
                    return (ptCoordinate[2] <= 0);
                case SurfaceType.slopeInsert:
                    return (ptCoordinate[0] <= xMargin) ? (ptCoordinate[2] < 0) : (ptCoordinate[2] < (ptCoordinate[0] - xMargin) * Math.Tan(alphaSurface));
                case SurfaceType.slopeCutting:
                    return (ptCoordinate[1] <= yMargin) ? (ptCoordinate[2] < 0) : (ptCoordinate[2] < (ptCoordinate[1] - yMargin) * Math.Tan(betaSurface));
                case SurfaceType.edgeThrough:
                    return (ptCoordinate[1] <= yMargin) ? false : (ptCoordinate[2] < (ptCoordinate[1] - yMargin) * Math.Tan(betaSurface));
                case SurfaceType.step:
                    return (ptCoordinate[0] <= xMargin) ? (ptCoordinate[2] < 0) : (ptCoordinate[2] < zStep);
                case SurfaceType.corner:
                    return ((ptCoordinate[0] <= xMargin) ? (ptCoordinate[2] < 0) : (ptCoordinate[2] < (ptCoordinate[0] - xMargin) * Math.Tan(alphaSurface))) || ((ptCoordinate[1] <= yMargin) ? (ptCoordinate[2] < 0) : (ptCoordinate[2] < (ptCoordinate[1] - yMargin) * Math.Tan(betaSurface)));
                case SurfaceType.customSurface:
                    // Getting corresponding x value 
                    int index = 0;
                    while (ptCoordinate[0] >= xValuesFromUserDefinedSurface[index])
                    {
                        index++;
                        if (index == xValuesFromUserDefinedSurface.Count) { return false; }
                    }
                    return (ptCoordinate[1] <= yMargin) ? false: (ptCoordinate[2] <= zValuesFromUserDefinedSurface[index]);
                default:
                    return true;
            }
        }

        static void updateToolBaseCoordinates(double atTime)
        {
            //centreCoordinates[0] = feedVector[0] * atTime;
            //centreCoordinates[1] = feedVector[1] * atTime;
            //centreCoordinates[2] = feedVector[2] * atTime;

            toolBaseCoordinates[0] = feedVector[0] * atTime;
            toolBaseCoordinates[1] = feedVector[1] * atTime;
            toolBaseCoordinates[2] = -depthCorrected + feedVector[2] * atTime;
        }


        static bool isPointPresentAfterPreviousCut(int j, int i)
        {
            double d1= (slopeinCNplane >= 16000000)? yy_fcn[j, i] + stepOver: Math.Abs((zz_fcn[j, i] - slopeinCNplane * (yy_fcn[j, i] + stepOver)) / Math.Sqrt(1 + slopeinCNplane * slopeinCNplane));
            double d2 = vectorMagnitude(new double[3] { 0, yy_fcn[j, i] + stepOver, zz_fcn[j, i] });
            double d3 = Math.Sqrt(d2 * d2 - d1 * d1);
            if (d3 >= h) return false;
            if (zz_fcn[j, i] >= (stepOver + yy_fcn[j, i]) * Math.Tan(tilt()))
            {
                if (d1 <= radius[(int)(d3 / del_z)]) return false;
            }
            return true;
        }

        // MATERIAL PROPERTIES FUNCTIONS FOR TITANIUM
        static Dictionary<string, double> ocm_Ti(double feedPerRotation, double alpha_r, double tau_s)
        {
            // For Mechanics of cutting with helical ball-end mills,fundamental cutting parameters as
            // yield shear stress, average friction coefficient on the rake face and shear angle are measured
            // from a set of orthogonal cutting tests at various cutting speeds and feeds(Lee / Altintas)

            //Inputs:
            // h: Feed in mm / rev or uncut chip thickness in OCM model
            // alpha_r: Rake angle
            // tau_s: Shearing stress (in MPA)

            // Outputs:
            // phi_c: Shear angle
            // beta_a: Friction angle

            // Note: The relations are oly valid for undertaking Titanium alloy and
            // other material may exhibit other relations
            double cf = 180 / Math.PI;                // from radians to degrees
            alpha_r = alpha_r * cf;
            double r_0 = 1.755 - 0.028 * alpha_r;
            double a = 0.331 - 0.0082 * alpha_r;
            double rc = r_0 * Math.Pow(feedPerRotation, a);
            double phi_c = (Math.Atan((rc * Math.Cos(alpha_r / cf)) / (1 - rc * Math.Sin(alpha_r / cf)))); // Shear angle
            Dictionary<string, double> outputList = new Dictionary<string, double>();

            // Friction angle(measure in degree)
            outputList.Add("beta_a", (19.1 + 0.29 * (alpha_r)) / cf); //returning value in radians;

            // Shear Angle
            outputList.Add("phi_c", phi_c);
            return outputList;
        }

        static double[] ccm_Ti(double alpha_r, double phi_c, double beta_a, double tau_s, double i)
        {
            //// This function is used to calculate the cutting force coefficients in
            // the local coordinate system using results obtained from oblique cutting model
            // Assumptions in the model: Normal rake angle=Orthogonal rake angle,
            // Normal shear angle=Orthogonal shear angle, Oblique angle = Chip flow angle
            // Friction angle and shear stress are same in both orthogonal and obique cutting
            //for given speed,chip load and tool wp pair

            // Input parameters:
            // alpha_r: Rake angle
            // phi_c: Shear angle
            // beta_a: Friction angle
            // tau_s: Shearing stress (in MPA)

            // Output parameters:
            // Ktc: tagential direction cutting force coefficient
            // Kac: axial direction cutting force coefficient
            // Krc: radial direction cutting force coefficient

            // Calculation 
            double n_c = i; // Chip flow angle is approximated to local inclination angle
            double alpha_n = alpha_r;
            double phi_n = phi_c;
            double beta_n = beta_a;

            double c = Math.Sqrt(Math.Pow(Math.Cos(phi_n + beta_n - alpha_n), 2) + Math.Pow(Math.Tan(n_c) * Math.Sin(beta_n), 2));

            //cutF[0] = Ktc, cutF[1] = Krc, cutF[2] = Kac
            double[] cutF = new double[3];
            cutF[0] = (tau_s / (Math.Sin(phi_n))) * ((Math.Cos(beta_n - alpha_n) + (Math.Tan(i) * Math.Tan(n_c) * Math.Sin(beta_n))) / c);
            cutF[1] = (tau_s / (Math.Sin(phi_n) * Math.Cos(i))) * ((Math.Sin(beta_n - alpha_n)) / c);
            cutF[2] = (tau_s / (Math.Sin(phi_n))) * (((Math.Cos(beta_n - alpha_n) * (Math.Tan(i)) - (Math.Tan(n_c) * Math.Sin(beta_n)))) / c);

            return cutF;
        }

        // GENERAL USE FUNCTIONS 
        //static double[] getRelatvVectr(int j, int i)
        //{
        //    double[] toReturn = new double[3];
        //    if (!isTvariable)
        //    {
        //        toReturn[0] = relatvVectr[j, i, 0];
        //        toReturn[1] = relatvVectr[j, i, 1];
        //        toReturn[2] = relatvVectr[j, i, 2];
        //    }
        //    else
        //    {
        //        // else update the relative vector for the required point 
        //        centreInFCNwrtToolOrigin = matMultiply(T(), new double[3] { 0, 0, R }); // to get current centre in FCN according to current tilt and lead
        //        // relativeVector is vector joining centre of sphere and the point
        //        toReturn[0] = xx_fcn[j, i] - centreInFCNwrtToolOrigin[0];
        //        toReturn[0] = yy_fcn[j, i] - centreInFCNwrtToolOrigin[1];
        //        toReturn[0] = zz_fcn[j, i] - centreInFCNwrtToolOrigin[2];
        //    }
        //    return toReturn;
        //}

        static double dotProduct(double[] A, double[] B)
        {
            return A[0] * B[0] + A[1] * B[1] + A[2] * B[2];
        }

        static void exportExcel(double[,] toPrint, string name)
        {
            display = new PleaseWaitForm();
            display.setMaxValue(toPrint.GetLength(0));
            display.initializeText("Exporting Data with " + toPrint.GetLength(0) + " point...");
            display.Show();
            //name = "C:\\Users\\Ayush Bandil\\" + name + ".xls"; 
            
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            for (int i = 0; i < toPrint.GetLength(0); i++)
            {
                for (int j = 0; j < toPrint.GetLength(1); j++)
                {
                    worksheet.Cells[i + 1, j + 1] = toPrint[i, j];
                    StatusNumberOfPointsExportedToExcel++;
                }
                display.uptateStatusBar(i+1);
            }
            try
            {
                workbook.SaveAs(locationOfExport);
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show(" Cannot replace, file already open ", "Number of points", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            excel.Quit();
            workbook = null;
            excel = null;

            //Console.WriteLine("Successfully exported {0}", name);
        }

        static double cosOfAngleBtwVectors(double[] A, double[] B)
        {
            double cosValue = dotProduct(A, B) / (vectorMagnitude(A) * vectorMagnitude(B));
            return cosValue;
        }

        static double vectorMagnitude(double[] A)
        {
            return Math.Sqrt(Math.Pow(A[0], 2) + Math.Pow(A[1], 2) + Math.Pow(A[2], 2));
        }

        // For multiplication of 3x3 and 3x1 matrix 
        static double[] matMultiply(double[,] A, double[] B)
        {
            double[] C = new double[3];
            C[0] = A[0, 0] * B[0] + A[0, 1] * B[1] + A[0, 2] * B[2];
            C[1] = A[1, 0] * B[0] + A[1, 1] * B[1] + A[1, 2] * B[2];
            C[2] = A[2, 0] * B[0] + A[2, 1] * B[1] + A[2, 2] * B[2];
            return C;
        }

        static double[,] listToArray(List<double[]> A)
        {
            double[,] B = new double[A.Count, 3];
            for (int i = 0; i < A.Count; i++)
            {
                B[i, 0] = A[i][0];
                B[i, 1] = A[i][1];
                B[i, 2] = A[i][2];
            }
            return B;
        }

        // FUNCTIONS GETTING CALL FROM TASK SELECTION FORM 
        public static void plotGraphs(double timeMax)
        {
            //descritizationOfBallEndTool();
            descritizationOfMultipleTool();
            //MessageBox.Show(" Height of tool base is "+toolBaseHeightFromZmin(), "Number of points", MessageBoxButtons.OK, MessageBoxIcon.Error);

            double theta = 0;
            // time is in minutes                    //in mm,  distance we want tool to travel along feed
            double numberOfRevolutions = rpm * timeMax;
            int numberOfTimeIterations = (int)(numberOfRevolutions * 2 * Math.PI / del_phi);
            double[,] FCN_complete_data = new double[numberOfTimeIterations, 4];
            torqueInTCS = new double[numberOfTimeIterations];
            for (int i = 0; i < numberOfTimeIterations; i++)
            {
                time = i * del_phi / (rpm * 2 * Math.PI);
                theta = (del_phi / convFact) * i;
                double[] forcesFCN = forcesInFCN(theta);
                FCN_complete_data[i, 0] = forcesFCN[0];
                FCN_complete_data[i, 1] = forcesFCN[1];
                FCN_complete_data[i, 2] = forcesFCN[2];
                FCN_complete_data[i, 3] = torqueInTCS[i];
                updateToolBaseCoordinates(time);
            }
            //time = timeMax;
            // Calling graphicalOutForm for Graphs
            GraphicalOutputForm plotTorque = new GraphicalOutputForm(torqueInTCS);
            plotTorque.Show();

            GraphicalOutputForm plotForces = new GraphicalOutputForm(FCN_complete_data);
            plotForces.Show();

            if (isExportExcelSheet)
            {
                string fileName = ("Winform FCN for lead " + lead() / convFact + ", tilt " + tilt() / convFact + ", feeddirection {" + feedVector[0] + " " + feedVector[1] + " " + feedVector[2] + "}, Lp " + Lp + " and feed " + feed_rate);
                exportExcel(FCN_complete_data, fileName);
            }
        }

        public static double getFmax(double atTime)
        {
            double FmaxTCS = double.MinValue;
            updateToolBaseCoordinates(atTime);
            // initialize torque in TCS though it is of no use in this context, since forceInTCS calculates tourque as well, has to be initialized
            torqueInTCS = new double[Kp];
            for (int i = 0; i < Kp; i++)
            {
                double[] forcesTCS = forcesInTCS(i);
                if (FmaxTCS < Math.Sqrt(Math.Pow(forcesTCS[0], 2) + Math.Pow(forcesTCS[1], 2))) { FmaxTCS = Math.Sqrt(Math.Pow(forcesTCS[0], 2) + Math.Pow(forcesTCS[1], 2)); }
            }
            return FmaxTCS;
        }

        public static void getCuttingZone(double atTime)
        {
            profile.Clear(); // in case this is called multiple times without closing the window
            //descritizationOfBallEndTool();
            updateToolBaseCoordinates(atTime);
            for (int i = 0; i < Kp; i++)
            {
                for (int j = 0; j < Lp; j++)
                {
                    //double kappa = Math.Asin(r_z(j) / R);  //// axial immersion angle-"Angle between the cutter axis and normal of helical cutting edge at particular point"
                                                           // defining normal vector for any point in TCS
                    double[] normalVector = new double[3] { Math.Sin(kappa[j]) * Math.Sin(phi_2[j, i]), Math.Sin(kappa[j]) * Math.Cos(phi_2[j, i]), -Math.Cos(kappa[j]) };

                    //CosValue is the value of cosine of vector joining the point [j, i] to R vector in FCN to the feedVector
                    //double cosValue = cosOfAngleBtwVectors(getRelatvVectr(j, i), feedVector);
                    double cosValue = cosOfAngleBtwVectors(matMultiply(T(), normalVector), feedVector);

                    // Feed check: only the points pointing towards feed contributes in cutting, checked by positive value of cosValue
                    if ((Math.Round(cosValue, 8) > 0) && (cuttingZoneCheck(j, i))) 
                    {
                        profile.Add(new double[3] { xx_fcn[j, i], yy_fcn[j, i], zz_fcn[j, i] });
                    }
                }
            }
            if (isExportExcelSheet)
            {
                exportExcel(listToArray(profile), "");
            }
        }

        public static void simulateEngagementRegion(double tillTime)
        {
            timeForSimulation = tillTime;
            descritizationOfMultipleTool();
            cuttingZoneSimulation = new Window1();
            cuttingZoneSimulation.Show();
            timer = new Timer();
            timer.Start();
            timer.Interval = 100;
            timer.Tick += new System.EventHandler(simulateCuttingForNextStep);
            timer.Start();
            distanceTravelled = 0;
            getCuttingZone(tillTime);
        }

        static void simulateCuttingForNextStep(object sender, EventArgs e)
        {
            timer.Interval = 100000;
            profile.Clear();
            updateToolBaseCoordinates(distanceTravelled / feed_rate);
            for (int i = 0; i < Kp; i++)
            {
                    for (int j = 0; j < Lp; j++)
                    {
                        //double kappa = Math.Asin(r_z(j) / R);  //// axial immersion angle-"Angle between the cutter axis and normal of helical cutting edge at particular point"
                        // defining normal vector for any point in TCS
                        double[] normalVector = new double[3] { Math.Sin(kappa[j]) * Math.Sin(phi_2[j, i]), Math.Sin(kappa[j]) * Math.Cos(phi_2[j, i]), -Math.Cos(kappa[j]) };

                        //CosValue is the value of cosine of vector joining the point [j, i] to R vector in FCN to the feedVector
                        //double cosValue = cosOfAngleBtwVectors(getRelatvVectr(j, i), feedVector);
                        double cosValue = cosOfAngleBtwVectors(matMultiply(T(), normalVector), feedVector);

                        // Feed check: only the points pointing towards feed contributes in cutting, checked by positive value of cosValue
                        if ((Math.Round(cosValue, 8) > 0) && (cuttingZoneCheck(j, i)))
                        {
                            profile.Add(new double[3] { xx_fcn[j, i], yy_fcn[j, i], zz_fcn[j, i] });
                        }
                    }
                }

                int numberOfPointsInCuttingZone = profile.Count;
                // Adding points which are not in the cutting region 
                for (int i = 0; i < Kp; i++)
                {
                    for (int j = 0; j < Lp; j++)
                    {
                        double[] normalVector = new double[3] { Math.Sin(kappa[j]) * Math.Sin(phi_2[j, i]), Math.Sin(kappa[j]) * Math.Cos(phi_2[j, i]), -Math.Cos(kappa[j]) };
                        double cosValue = cosOfAngleBtwVectors(matMultiply(T(), normalVector), feedVector);
                        // Adding points which do not lie in the cutting region 
                        // Feed check: only the points pointing towards feed contributes in cutting, checked by positive value of cosValue
                        if (!((Math.Round(cosValue, 8) > 0) && (cuttingZoneCheck(j, i))))
                        {
                            profile.Add(new double[3] { xx_fcn[j, i], yy_fcn[j, i], zz_fcn[j, i] });
                        }
                    }
                }
            cuttingZoneSimulation.TestSimpleScatterPlot(listToArray(profile), numberOfPointsInCuttingZone);
            distanceTravelled++;
            if (distanceTravelled >= timeForSimulation*feed_rate) timer.Stop();
            timer.Interval = 400;
        }

        static void initializeOffsetParameters()
        {
            Mr = (Rz * Math.Tan(alpha) + Rr + Math.Sqrt((R * R - Rr * Rr) * Math.Tan(alpha) * Math.Tan(alpha) + 2 * Rz * Rr * Math.Tan(alpha) - Rz * Rz + R * R)) / (Math.Tan(alpha) * Math.Tan(alpha) + 1);
            Mz = Mr * Math.Tan(alpha);
            u = D * (1 - Math.Tan(alpha) * Math.Tan(beta)) / 2;
            Nz = ((Rr - u) * Math.Tan(beta) + Rz - Math.Sqrt((R * R - Rz * Rz) * Math.Tan(beta) * Math.Tan(beta) + 2 * Rz * (Rr - u) * Math.Tan(beta) - (Rr - u) * (Rr - u) + R * R)) / (Math.Tan(beta) * Math.Tan(beta) + 1);
            Nr = u + Nz * Math.Tan(beta);
            //double andarKaMaal = (R * R - Rr * Rr) * Math.Tan(alpha) * Math.Tan(alpha) + 2 * Rz * Rr * Math.Tan(alpha) - Rz * Rz + R * R;

            // zone 0 is added to the model to take care of the bottommost part of the tool, this will add to the forces will there is lead or tilt, also the case when feed is not horizontal
            zone0Length = (Mz == 0 && Mr != 0) ? Mr : 0;
        }

        public static double getSurfaceRoughness()
        {
            if (stepOver <= 2 * R * Math.Cos(tilt())) return R - Math.Sqrt(R * R - stepOver * stepOver / 4);
            else return R - Math.Sqrt(R * R - Math.Pow((R - stepOver * Math.Cos(tilt())), 2)) * Math.Cos(tilt()) - (R - stepOver * Math.Cos(tilt())) * Math.Sin(Math.Abs(tilt()));
        }

        static void initializeRadiusKappaShi()
        {
            int zone1Points;
            int zone2Points;
            int zone3Points;

            zone1Points = (int)(Math.Round(Mz / del_z));
            zone2Points = (int)(Math.Round(Nz / del_z)) - zone1Points;
            zone3Points = (int)(Math.Round(h / del_z)) - zone1Points - zone2Points;
            //MessageBox.Show(" Number of points in zone 1 = " + zone1Points + ", in zone 2 = " + zone2Points + ", in zone 3 = " + zone3Points, "Number of points", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Console.WriteLine("Number of points in zone 1 = {0}, in zone 2 = {1} and in zone 3 = {2}", zone1Points, zone2Points, zone3Points);
            Lp = zone1Points + zone2Points + zone3Points;

            radius = new double[Lp];
            kappa = new double[Lp];
            shi = new double[Lp];
            double shi1s = 0;
            double shi1e = 0;
            double shiae;
            double shias;
            double shi2s;

            for (int j = 0; j < Lp; j++)
            {
                radius[j] = (j < zone1Points) ? z_ms(j) / Math.Tan(alpha) : (j < zone1Points + zone2Points) ? Rr + Math.Sqrt(R * R - Math.Pow((Rz - z_ms(j)), 2)) : u + z_ms(j) * Math.Tan(beta);
                kappa[j] = (j < zone1Points) ? alpha : (j < zone1Points + zone2Points) ? Math.Asin((radius[j] - Rr) / R) : Math.PI / 2 - beta;
            }

            // if zone OM is missing then shi1e will be 0 as already defined otherwise will be changed 
            if (Mz != 0)
            {
                shi1s = Math.Log(Mr / 20) * Math.Tan(helixAngle) / Math.Cos(alpha);
                shi1e = Math.Log(Mr) * Math.Tan(helixAngle) / Math.Cos(alpha) - shi1s;
                for (int j = 1; j < zone1Points; j++)
                {
                    shi[j] = Math.Log(z_ms(j) / Math.Tan(alpha)) * Math.Tan(helixAngle) / Math.Cos(alpha) - shi1s;
                }
            }

            // if zone 2 is missing shiae = shi1e else shiae will be changed as...
            if (R == 0) // or if Mr=Nr or Mz=Mz 
            {
                shiae = shi1e;
            }
            else
            {
                shias = (R + Mz - Rz) * Math.Tan(helixAngle) / R;
                shiae = (R + Nz - Rz) * Math.Tan(helixAngle) / R - shias + shi1e;
                for (int j = zone1Points; j < zone1Points + zone2Points; j++)
                {
                    shi[j] = (R + z_ms(j) - Rz) * Math.Tan(helixAngle) / R - shias + shi1e;
                }
            }

            // Calculation for zone 3
            // There are 2 cases in Taper zone i) Constant helix ii) Constant lead
            //isConstantHelix = true;
            if (isConstantHelix)
            {
                if (beta != 0)
                {
                    shi2s = Math.Log(Nr) * Math.Tan(helixAngle) / Math.Sin(beta);
                    for (int j = zone1Points + zone2Points; j < zone1Points + zone2Points + zone3Points; j++)
                    {
                        shi[j] = Math.Log(Nr - (Nz - z_ms(j)) * Math.Tan(beta)) * Math.Tan(helixAngle) / Math.Sin(beta) - shi2s + shiae;
                    }
                }
                else
                {
                    shi2s = 0;
                    for (int j = zone1Points + zone2Points; j < zone1Points + zone2Points + zone3Points; j++)
                    {
                        shi[j] = (z_ms(j) - Nz) * Math.Tan(helixAngle) / Nr - shi2s + shiae;
                    }
                }
            }
            else // case of constant lead 
            {
                double lead = 100;
                double nominalHelix = Math.Atan((2 * Math.PI * Nr) / (lead * Math.Cos(beta)));
                for (int j = zone1Points + zone2Points; j < zone1Points + zone2Points + zone3Points; j++)
                {
                    shi[j] = (z_ms(j) - Nz) * Math.Tan(nominalHelix) / Nr + shiae;
                }
            }
        }
        
        public static void descritizationOfMultipleTool()
        {
            //Console.WriteLine("For tool {0}, D = {1}, R = {2}, Rz = {3}, Rr = {4}, alpha = {5}, beta = {6} and h = {7}", toolType, D, R, Rz, Rr, alpha, beta, h);
            //MessageBox.Show("For tool " + toolType + ", D = " + D + ", R = " + R + ", Rz = " + Rz + ", Rr = " + Rr + ", alpha = " + alpha + ", beta = " + beta + " and h = " + h, "Values of tool parameter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // offsets declaration 
            initializeOffsetParameters();
            
            //MessageBox.Show("For tool " + toolType + ", Mr = " + Mr + ", Mz = " + Mz + ", u = " + u + ", Nr = " + Nr + ", Nz = " + Nz, "Values of offsets", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Console.WriteLine("For tool {0}, Mr = {1}, Mz = {2}, u = {3}, Nr= {4} and Nz = {5}", toolType, Mr, Mz, u, Nr, Nz);

            initializeRadiusKappaShi();

            tcsCoordinates = new double[Lp * Kp, 3];
            numberOfPointsOnTool = 0;

            for (int i = 0; i < Kp; i++)
            {
                phi[i] = i * del_phi;
                for (int j = 0; j < Lp; j++)
                {
                    phi_2[j, i] = phi[i] - shi[j];                  // radial immersion angle

                    //Surface points in TCS coordinate system
                    xx_tcs[j, i] = radius[j] * Math.Sin(phi_2[j, i]);
                    yy_tcs[j, i] = radius[j] * Math.Cos(phi_2[j, i]);
                    zz_tcs[j, i] = z_ms(j);

                    tcsCoordinates[numberOfPointsOnTool, 0] = xx_tcs[j, i];
                    tcsCoordinates[numberOfPointsOnTool, 1] = yy_tcs[j, i];
                    tcsCoordinates[numberOfPointsOnTool, 2] = zz_tcs[j, i];
                    numberOfPointsOnTool++;

                    //// Surface points in FCN coordinate system
                    double[] XYZ_fcn = matMultiply(T(), new double[3] { xx_tcs[j, i], yy_tcs[j, i], zz_tcs[j, i] }); //Surface points in FCN Coordinate system
                    xx_fcn[j, i] = XYZ_fcn[0];
                    yy_fcn[j, i] = XYZ_fcn[1];
                    zz_fcn[j, i] = XYZ_fcn[2];

                    toolAndSurfacePoints.Add(new double[3] { xx_fcn[j, i], yy_fcn[j, i], zz_fcn[j, i] });
                }
            }
            depthCorrected = correctDepthDuetoRotationOfTool();
            //MessageBox.Show(" Corrected depth for General Tool is " + depthCorrected, "Number of points", MessageBoxButtons.OK, MessageBoxIcon.Error);
            toolBaseCoordinates = new double[3] { 0, 0, -depthCorrected };

            //double[,] shiExport = new double[Lp, 2];
            //for (int j = 0; j < Lp; j++)
            //{
            //    shiExport[j, 0] = j;
            //    shiExport[j, 1] = shi[j];
            //}

            if (isDisplayProfile)
            {
                Window1 toolGeometry = new Window1();
                toolGeometry.initializeToolParameteres(Kp, Lp, Nf);
                toolGeometry.Show();
                toolGeometry.TestSimpleScatterPlot(tcsCoordinates,0);
                isDisplayProfile = false;
            }
            //exportExcel(shiExport, "shi values");
            //descritizationOfTool();
            //GraphicalOutputForm toolProfile = new GraphicalOutputForm(radius);
            //toolProfile.Show();

            //GraphicalOutputForm lagAngle = new GraphicalOutputForm(shi);
            //lagAngle.Show();
        }
    }
}