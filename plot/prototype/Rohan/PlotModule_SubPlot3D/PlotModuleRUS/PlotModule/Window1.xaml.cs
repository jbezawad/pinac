using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Media.Media3D;
using _3DTools;

namespace PlotModule
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private PlotReceiver pr;
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            unit_test_receiver();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pr.terminate();
        }

        private void unit_test_paint()
        {
            Paint p = new Paint();
            List<double> plist = new List<double>();
            for (int i = -10; i < 10; i++)
            {
                plist.Add(i + 0.3);
            }
            double[] plist1 = new double[] { 6.4, 2.2, 6.2, 7.7, 4.0, -6.0, 8.5, 60.4, 8, 75, -4, 32 };
            double[] plist2 = new double[] { -5, -30, -5.7, -21, -35 };
            double[] plist3 = new double[] { 10, 3, 5, 10, 2 };
            double[] plist4 = new double[] { -100, 100, 5, 10, 10, 400 };

            canvas2.Visibility = Visibility.Hidden;
            canvas5.Visibility = Visibility.Hidden;
            canvas3.Visibility = Visibility.Hidden;
            canvas4.Visibility = Visibility.Hidden;
            p.plot2D(plist3);
        }

        private void unit_test_receiver()
        {
            pr = new PlotReceiver();
            pr.checklist();
            //Plot plotobj = new Plot();
            //plotobj.Command = "plot";
            //plotobj.Data = new double[,] { { 10.2, 3.59, 5.3, 10.23, 2.9 } };
            //plotobj.Dimensions = 2;
            //plotobj.ScaleMode = 1;
            //plotobj.X_Fact = 1;
            //plotobj.Y_Fact = 1;
            //plotobj.PlotTitle = "FirstPlot";
            //pr.writetolist(plotobj);

            //Plot subplotobj = new Plot();
            //subplotobj.Command = "subplot";
            //subplotobj.Data = new double[,] { { -10, -1, -2, -4, -2 } };
            //subplotobj.Dimensions = 2;
            //subplotobj.ScaleMode = 1;
            //subplotobj.X_Fact = 1;
            //subplotobj.Y_Fact = 1;
            //subplotobj.PaneNum = 2;
            //subplotobj.PlotTitle = "second plot";
            Plot subplotobj3 = new Plot();
            subplotobj3.Command = "subplot";
            subplotobj3.Data = new double[,] { { 10, 1, 20, 4, 2 } };
            subplotobj3.Dimensions = 3;
            subplotobj3.ScaleMode = 2;
            subplotobj3.X_Fact = 1;
            subplotobj3.Y_Fact = 1;
            subplotobj3.PaneNum = 3;
            subplotobj3.PlotTitle = "Third Plot";

            
            //pr.writetolist(subplotobj);

            //Plot plotobj3d = new Plot();
            //plotobj3d.Command = "plot";
            //plotobj3d.Data = new double[,] { {1,1.3,5.2,3.4,2.9},{2.4,2.3,1.5,3.4,2.5}};
            //plotobj3d.Dimensions = 3;
            //plotobj3d.ScaleMode = 1;
            //plotobj3d.Mode = 2;
            //plotobj3d.X_Fact = 1;
            //plotobj3d.Y_Fact = 1;
            //plotobj3d.PlotTitle = "First3DPlot";
            //pr.writetolist(plotobj3d);

            //Plot plotobj3d2 = new Plot();
            //plotobj3d2.Command = "plot";
            //plotobj3d2.Data = new double[,] { { 10.2,3.4,2.5,10.43,20} };
            //plotobj3d2.Dimensions = 3;
            //plotobj3d2.ScaleMode = 1;
            //plotobj3d2.Mode = 3;
            //plotobj3d2.X_Fact = 1;
            //plotobj3d2.Y_Fact = 1;
            //plotobj3d2.PlotTitle = "second3DPlot";
            //pr.writetolist(plotobj3d);

            Plot plotobj3d3 = new Plot();
            plotobj3d3.Command = "subPlot";
            plotobj3d3.Data = new double[,] { { 5, 6, 5, 10 }, { 3, 4, 7, 8 } };
            plotobj3d3.Dimensions = 3;
            plotobj3d3.Mode = 1;
            plotobj3d3.PaneNum = 2;
            plotobj3d3.PlotTitle = "first3DPlot";

            Plot plotobj3d31 = new Plot();
            plotobj3d31.Command = "subPlot";
            plotobj3d31.Data = new double[,] { { 5, 6, 5, 10 }, { 3, 4, 7, 8 } };
            plotobj3d31.Dimensions = 3;
            plotobj3d31.Mode = 1;
            plotobj3d31.PaneNum = 3;
            plotobj3d31.PlotTitle = "first3DPlot";

            Plot plotobj3d32 = new Plot();
            plotobj3d32.Command = "subPlot";
            plotobj3d32.Data = new double[,] { { 5, 6, 5, 10 }, { 3, 4, 7, 8 } };
            plotobj3d32.Dimensions = 3;
            plotobj3d32.Mode = 3;
            plotobj3d32.PaneNum = 4;
            plotobj3d32.PlotTitle = "first3DPlot";

            pr.writetolist(plotobj3d3);
            pr.writetolist(plotobj3d31);
            pr.writetolist(plotobj3d32);
            

            ////Thread.Sleep(5000);
            //Plot subplotobj4 = new Plot();
            //subplotobj4.Command = "subplot";
            //subplotobj4.Data = new double[,] { { -10, -1, -20, -4, -2 } };
            //subplotobj4.Dimensions = 2;
            //subplotobj4.ScaleMode = 1;
            //subplotobj4.X_Fact = 1;
            //subplotobj4.Y_Fact = 1;
            //subplotobj4.PaneNum = 4;
            //subplotobj4.PlotTitle = "Fourth Plot";
            //pr.writetolist(subplotobj4);
            //Plot plotobj1 = new Plot();
            //plotobj1.Command = "plot Again";
            //plotobj1.Data = new double[,] { { -10, -1, 20, 4, 2 } };
            //plotobj1.Dimensions = 2;
            //plotobj1.ScaleMode = 1;
            //plotobj1.X_Fact = 1;
            //plotobj1.Y_Fact = 1;
            //plotobj1.PaneNum = 3;
            //plotobj1.PlotTitle = "Full Plot";
            
        }
        public void test()
        {
            vector3D();
        }
            public void vector3D()
        {
            Viewport3D viewport = new Viewport3D();
            viewport.Height = 500;
            viewport.Width = 500;
            //viewport.Camera = Camera_Details();
            //viewport.Children.Add(ModelVisual3D_Details());
            viewport.ClipToBounds = true;
            Point3D[] pt = new Point3D[10];
            pt[0] = new Point3D(5, 6, 0);
            pt[1] = new Point3D(0, -2, 3);
            pt[2] = new Point3D(2.3, 5.2, 1.4);
            pt[3] = new Point3D(0, 1, 0);
            pt[4] = new Point3D(3.3, -2.2, 1.4);
            pt[5] = new Point3D(4.3, 5.2, -1.4);
            pt[6] = new Point3D(2.3, -3.2, 1.4);
            pt[7] = new Point3D(2.3, -2.2, 1.4);
            pt[8] = new Point3D(-2.3, 5.2, 2.4);
            pt[9] = new Point3D(2.3, 5.2, -0.4);

            Canvas activeCanvas = new Canvas();
            activeCanvas.Tag = "plot3D_Vector";
            for (int i = 0; i < pt.Length; i++)
                createlines(pt[i],viewport);
            activeCanvas.Children.Add(viewport);
            canvas2 = activeCanvas;
                int count=viewport.Children.Count;
                for (int i = 0; i < count; i++)
                {
                    Visual3D item = viewport.Children[0];
                    viewport.Children.RemoveAt(0);
                    this.mainViewport.Children.Add(item);
                }
                this.mainViewport.Visibility = Visibility.Visible;
        } 

        private Model3DGroup createlines(Point3D pt, Viewport3D viewport)
        {
            Model3DGroup normalGroup = new Model3DGroup();
            Point3D p = pt;
            int length = 1;
            double partx, party;

            #region lines
            ScreenSpaceLines3D normal0Wire = new ScreenSpaceLines3D();
            normal0Wire.Thickness = 2;
            normal0Wire.Color = Colors.Blue;

            if (pt.X > pt.Y)
            {
                partx = 1; party = pt.Y / pt.X;
            }
            else
            {
                partx = pt.X / pt.Y; party = 1;
            }

            normal0Wire.Points.Add(pt);
            for (int i = 0; i < length; i++)
            {
                p = new Point3D(pt.X + ((i + 1) * partx), pt.Y + ((i + 1) * party), pt.Z);
                normal0Wire.Points.Add(p);
                normal0Wire.Points.Add(p);
            }
            normal0Wire.Points.Add(p);
            viewport.Children.Add(normal0Wire);
            #endregion
            #region arrowhead

            MeshGeometry3D triangleMesh = new MeshGeometry3D();
            Point3D point0 = new Point3D(p.X + 0.05, p.Y, p.Z);
            Point3D point1 = new Point3D(p.X, p.Y + 0.05, p.Z);
            Point3D point2 = new Point3D(p.X, p.Y, p.Z + 0.05);
            triangleMesh.Positions.Add(point0);
            triangleMesh.Positions.Add(point1);
            triangleMesh.Positions.Add(point2);
            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(1);
            triangleMesh.TriangleIndices.Add(2);
            Vector3D normal = new Vector3D(0, 1, 0);
            triangleMesh.Normals.Add(normal);
            triangleMesh.Normals.Add(normal);
            triangleMesh.Normals.Add(normal);

            Material material = new DiffuseMaterial(
                new SolidColorBrush(Colors.Blue));
            GeometryModel3D triangleModel = new GeometryModel3D(
                triangleMesh, material);
            ModelVisual3D model = new ModelVisual3D();
            model.Content = triangleModel;
            viewport.Children.Add(model);

            #endregion
            return normalGroup;
        }
    }
}

            