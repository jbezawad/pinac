////////////////////////////////////////////////////////////////////////
// Paint.cs - contains Paint class which generates points and returns
//            Canvas object depending on the properties and data given to
//            it.
// version: 1.0
// 
// author: Mahesh Uma Gudladona (ugudlado@syr.edu) & Rushabh Ravindra Gandhi (rugandhi@syr.edu)
// language: C#
////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Collections;
using _3DTools;

namespace Spinach
{
    // Paints the canvas
    public class Paint
    {   //Private data members
        private int numPanes;
        private int spanX,spanY;
        private double factx, facty;
        private Point origin;
        private Canvas activeCanvas;
        private Canvas smallCanvas;
        private Viewport3D mainViewport;
        private List<Point> pointslist;
        private List<Point3D>pointslist3D;
        private List<Color>colorlist;
        private PlotManager pm;
        private int mode;
        private string xtitle;
        private string ytitle;
        private string ztitle;
        private string plottitle;
        private Hashtable delaunaypoints = new Hashtable();

        public delegate void PlotError(int code, string message);
        public event PlotError error;

        public void OnError(int code, string message)
        {
            if (error != null)
                error(code, message);

        } 

        //Properties
        #region Properties    
        public string Xtitle
        {
            get { return xtitle; }
            set { xtitle = value; }
        }

        public PlotManager pmanager
        {
            get { return pm; }
            set { pm = value; }

        }
        public string Ytitle
        {
            get { return ytitle; }
            set { ytitle = value; }
        }

        public string Ztitle
        {
            get { return ztitle; }
            set { ztitle = value; }
        }

        public string Plottitle
        {
            get { return plottitle; }
            set { plottitle = value; }
        }
            
        //Number of Panes
        public int NumberPanes  
        {           
            get { return numPanes; }
            set { numPanes = value; }
        }

        //Origin of Plot
        public Point Origin 
        {
            get { return origin; }
            set { origin = value; }
        }

        //Active Canvas
        public Canvas ActiveCanvas
        {
            get { return activeCanvas; }
            set { activeCanvas = value; }
        }

        //X-Factor
        public double X_Fact
        {
            get{return factx;}
            set { factx = value; }
        }

        //Y-Factor
        public double Y_Fact
        {
            get { return facty; }
            set { facty = value; }
        }

        //Scale Mode
        public int Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        //Active viewport Rohan
        public Viewport3D Mainviewport
        {
            get { return mainViewport; }
            set { mainViewport = value; }
        }

        #endregion

        #region Methods
        //Methods

        //Paint Constructor
        public Paint()
        {
            numPanes = 1;
            spanX = 30;
            spanY = 30;
            activeCanvas = new Canvas();
            activeCanvas.Width = 500;
            activeCanvas.Height = 500;
            mainViewport = new Viewport3D();
            mainViewport.Height = 500;
            mainViewport.Width = 500;
            mode = 1;
            factx = 1;
            facty = 1;
            Xtitle = "X-Axis";
            Ytitle = "Y-Axis";
            Plottitle = "sample plot";
            pm = new PlotManager(this);
            pm.error += new PlotManager.PlotError(OnError);
        }

        //Reset method
        public void reset()
        {
            numPanes = 1;
            spanX = 30;
            spanY = 30;      
            activeCanvas = new Canvas();
            activeCanvas.Width = 500;
            activeCanvas.Height = 500;
            mainViewport = new Viewport3D();
            mainViewport.Height = 500;
            mainViewport.Width = 500;
            mode = 1;
            factx = 1;
            facty = 1;
            pm = new PlotManager(this);
        }


        //Method for setting Xaxis Title
        public void setXaxisTitle(string title)
        {
            Point xpoint = new Point();
            double x = (activeCanvas.Width - Origin.X) / 2;
            xpoint.X = x + Origin.X;
            xpoint.Y = Origin.Y + 5;
            setText(title, xpoint);
            
        }
        //Method for setting Yaxis Title
        public void setYaxisTitle(string title)
        {
            Point ypoint = new Point();
            double y = Origin.Y / 2;
            ypoint.X = Origin.X - 35;
            ypoint.Y = y;
            setText(title, ypoint);

        }

        ////Method for setting zaxis Title
        //private void setzaxisTitle(string title)
        //{
        //    Point zpoint = new Point();
        //    double z = activeCanvas.Width / 2;
        //    ypoint.X = origin.X - 35;
        //    ypoint.Y = y;
        //    setText(title, ypoint);

        //}

        //Method for setting Plot Title
        public void setPlotTitle(string title)
        {
            Point point = new Point();
            double x = (activeCanvas.Width - Origin.X);
            x = 0.5 * x;
            point.X = x + Origin.X;
            double y = activeCanvas.Height - Origin.Y;
            point.Y = 0.4 * y;
            setText(title, point);

        }


                //Method for setting axes        

        private string pointToText(Point point)
        {
            string temp = ((point.X - origin.X) / spanX).ToString() + "," + ((origin.Y - point.Y) / spanY).ToString();
            return temp;
        }

        //Helper method for setting text at specified point on Pane
        private void setText(string pointText,Point point)
        {
            TextBlock txt = new TextBlock();
            txt.Text = pointText;
            Canvas.SetLeft(txt, point.X );
            Canvas.SetTop(txt, point.Y);
            activeCanvas.Children.Add(txt);
        }

        //Helper method for transforming values to 2D points
        private List<Point> transformValuesToPoints(double[] pvalues)
        {
            List<Point> templist = new List<Point>();
            for (int i = 0; i < pvalues.GetLength(0); i++)
            {
                Point temp = new Point(i, pvalues[i]);
                templist.Add(temp);
            }
            return templist;
        }

        //Plot method for displaying value into 2D points in a line graph
        public void plot2D(double[] plist)
        {
            activeCanvas = new Canvas();
            activeCanvas.Width = 500;
            activeCanvas.Height = 500;
            try
            {
                switch (mode)
                {
                    case 1: pointslist = transformValuesToPoints(plist);
                        plotPoints(pointslist);
                        break;
                    case 2:
                        pointslist = transformValuesToPoints(plist);
                        plotLogPoints();
                        break;
                }
                pm.Convert_to_Image(activeCanvas, -1);
                subplot2D(plist, -1);
                activeCanvas = new Canvas();
                activeCanvas.Width = 500;
                activeCanvas.Height = 500;
            }
            catch (Exception e)
            {
                OnError(122, e.Message);
            }
        }                


        public void plotPoints(List<Point> pointslist)
        {                        
            setAxes();
            setXaxisTitle(Xtitle);
            setYaxisTitle(Ytitle);
            setPlotTitle(Plottitle);
            GeometryGroup s = new GeometryGroup();
            PathGeometry pg = new PathGeometry();
            PathFigureCollection pfc = new PathFigureCollection();
            PathFigure pf = new PathFigure();
            PathSegmentCollection psc = new PathSegmentCollection();
            Point stpoint = pointslist[0];            
            stpoint.X = origin.X + spanX * stpoint.X;
            stpoint.Y = origin.Y - spanY * stpoint.Y;
            pf.StartPoint = stpoint;
            EllipseGeometry elg = new EllipseGeometry(stpoint, 2, 2);
            s.Children.Add(elg);
            string pointText = pointToText(stpoint);
            setText(pointText,stpoint);
            for (int i = 1; i < pointslist.Count; i++)
            {
                Point point = pointslist[i];
                point.X = origin.X + spanX * point.X ;
                point.Y = origin.Y - spanY * point.Y;
                LineSegment ls = new LineSegment(point, true);
                elg = new EllipseGeometry(point, 2, 2);
                setText(pointToText(point),point);
                s.Children.Add(elg);
                psc.Add(ls);
            }
            pf.Segments = psc;
            pfc.Add(pf);           
            pg.Figures = pfc;
            Path p = new Path();
            Path p1 = new Path();
            p.Data = pg;            
            p.Stroke = Brushes.Green;
            p1.Data = s;
            p1.Fill = Brushes.Blue;            
            activeCanvas.Children.Add(p);
            activeCanvas.Children.Add(p1);
            activeCanvas.ClipToBounds = true;            
        }

        //Method to plot depending on the given pane number
        public void subplot2D(double[] plist,int panenum)
         {
            if (panenum != -1){
            activeCanvas = new Canvas();
            activeCanvas.Tag = "subplot2D";
            activeCanvas.Width = 500;
            activeCanvas.Height = 500;
            adjustPaneSize(panenum);
            pointslist = transformValuesToPoints(plist);
            if (mode == 1)
                plotPoints(pointslist);
            else
                plotLogPoints();
            pm.Convert_to_Image(activeCanvas, panenum);
            }
            else{
                activeCanvas = new Canvas();
                
                activeCanvas.Width = 500;
                activeCanvas.Height = 500;
                adjustPaneSize(4);
                pointslist = transformValuesToPoints(plist);
                if (mode == 1)
                    plotPoints(pointslist);
                else
                    plotLogPoints();
                smallCanvas = activeCanvas;
            }                           
        }

        public Canvas resubplot2D()
        {            
            
            return smallCanvas;
        }


        //Helper method which adjusts the pane size depending on the number of panes property
        private void adjustPaneSize(int panenum)
        {
            int wfactor=1;
            int hfactor = 1;
            if (panenum > NumberPanes)
            {
                switch (panenum - NumberPanes)
                {                    
                    case 1:                             
                    case 2:
                    case 3:
                        NumberPanes = 4;
                        break;
                    default:
                        NumberPanes = 1;
                        break;
                }
                //NumberPanes *= 2;
                //break;
            }
            switch (NumberPanes)
            {
                case 2:
                    wfactor = 2;
                    break;
                case 4:
                    wfactor = 2;
                    hfactor = 2;
                    break;
                default:
                    wfactor = 1;
                    hfactor = 1;
                    break;
            }
            activeCanvas.Width = 500 / wfactor;
            activeCanvas.Height = 500 / hfactor;
        }
   
        #endregion
        
        #region Rushabh
        // made by rushabh
        public Point MinPoint()
        {
            Point MinXY = pointslist[0];
            for (int i = 1; i < pointslist.Count; i++)
            {
                if (pointslist[i].X < MinXY.X)
                    MinXY.X = pointslist[i].X;
                if (pointslist[i].Y < MinXY.Y)
                    MinXY.Y = pointslist[i].Y;
            }
            return (MinXY);
        }

        // made by rushabh
        public Point MaxPoint()
        {
            Point MaxXY = pointslist[0];
            for (int i = 1; i < pointslist.Count; i++)
            {
                if (pointslist[i].X > MaxXY.X)
                    MaxXY.X = pointslist[i].X;
                if (pointslist[i].Y > MaxXY.Y)
                    MaxXY.Y = pointslist[i].Y;
            }
            return (MaxXY);
        }

        // made by rushabh
        private void CalOrigin()
        {
            Point min = MinPoint();
            Point max = MaxPoint();
            double orix = ((max.X >= 0 && min.X <= 0) || (max.X <= 0 && min.X >= 0)) ? Math.Abs(min.X) + 1 : (min.X > 0) ? 1 : Math.Abs(min.X) + 1;
            double oriy = ((max.Y >= 0 && min.Y <= 0) || (max.Y <= 0 && min.Y >= 0)) ? Math.Abs(min.Y) + 1 : (min.Y > 0) ? 1 : Math.Abs(min.Y) + 1;
<<<<<<< HEAD
            Origin = new Point(orix * spanX+20, activeCanvas.Height - ((oriy * spanY))-20);
=======
            Origin = new Point(orix * spanX + 20, activeCanvas.Height - ((oriy * spanY)) - 20);
>>>>>>> 834c3dfe74b29eca92d2abc2e4ab2dbfd31f4590
        }




        // made by rushabh
        public void setScale()
        {
            Point minPt = MinPoint();
            Point maxPt = MaxPoint();
            double Xlen = ((maxPt.X >= 0 && minPt.X <= 0) || (maxPt.X <= 0 && minPt.X >= 0)) ? (Math.Abs(maxPt.X) + Math.Abs(minPt.X)) + 2 : (minPt.X > 0) ? maxPt.X + 2 : Math.Abs(minPt.X) + 2;
            double Ylen = ((maxPt.Y >= 0 && minPt.Y <= 0) || (maxPt.Y <= 0 && minPt.Y >= 0)) ? (Math.Abs(maxPt.Y) + Math.Abs(minPt.Y)) + 2 : (minPt.Y > 0) ? maxPt.Y + 2 : Math.Abs(minPt.Y) + 2;
<<<<<<< HEAD
            spanX = (int)((activeCanvas.Width-40) / Xlen / factx);
            spanY = (int)((activeCanvas.Height-40) / Ylen / facty);
            spanX=spanX==0?1:spanX;
            spanY=spanY==0?1:spanY;
=======
            spanX = (int)((activeCanvas.Width - 40) / Xlen / factx);
            spanY = (int)((activeCanvas.Height - 40) / Ylen / facty);
            spanX = spanX == 0 ? 1 : spanX;
            spanY = spanY == 0 ? 1 : spanY;
>>>>>>> 834c3dfe74b29eca92d2abc2e4ab2dbfd31f4590
        }

        // changed by rushabh
        public void setAxes()
        {
            EllipseGeometry elg;
            setScale();
            CalOrigin();
            double xstep = spanX;
            double ystep = -spanY;
            Line l = new Line();
            l.X1 = origin.X;
            l.Y1 = origin.Y;
            l.X2 = activeCanvas.Width - 20;
            l.Y2 = origin.Y;
            l.Stroke = Brushes.Black;
            Line ly = new Line();
            ly.X1 = origin.X;
            ly.Y1 = (origin.Y - activeCanvas.Height) < 20 ? 20 : origin.Y - activeCanvas.Height;
            ly.X2 = origin.X;
            ly.Y2 = origin.Y;
            ly.Stroke = Brushes.Black;
            Line l1 = new Line();
            l1.X1 = origin.X;
            l1.Y1 = origin.Y;
            l1.X2 = 20;
            l1.Y2 = origin.Y;
            l1.Stroke = Brushes.Black;
            Line ly1 = new Line();
            ly1.X1 = origin.X;
            ly1.Y1 = activeCanvas.Height - 20;
            ly1.X2 = origin.X;
            ly1.Y2 = origin.Y;
            ly1.Stroke = Brushes.Black;
            activeCanvas.Children.Add(ly);
            activeCanvas.Children.Add(l);
            activeCanvas.Children.Add(ly1);
            activeCanvas.Children.Add(l1);
            Path path1 = new Path();
            path1.Fill = Brushes.Black;
            GeometryGroup gg = new GeometryGroup();

            int jx, jy, xtext, ytext;
            int xpart = (int)(activeCanvas.Width - 40) / spanX;
            int ypart = (int)(activeCanvas.Height - 40) / spanY;
            //xtext = jx = (xpart < 25) ? 1 : (xpart < 50) ? 2 : (xpart < 100) ? 5 : (xpart < 200) ? 10 : 50;
            //ytext = jy = (ypart < 25) ? 1 : (ypart < 50) ? 2 : (ypart < 100) ? 5 : (ypart < 200) ? 10 : 50;
            xtext = jx = Math.Ceiling((double)xpart / 10) == 0 ? 1 : (int)Math.Ceiling((double)xpart / 10);
            ytext = jy = Math.Ceiling((double)ypart / 10) == 0 ? 1 : (int)Math.Ceiling((double)ypart / 10);
            xstep *= jx;
            ystep *= jy;
            int xincre = (int)xstep;
            int yincre = (int)ystep;

            setText(Convert.ToString(0), new Point(origin.X - 5, origin.Y));
            gg.Children.Add(new EllipseGeometry(origin, 2, 2));
            while ((origin.X + xstep < activeCanvas.Width - 40) || (origin.Y + ystep > 20) || (origin.X - xstep > 20) || (origin.Y - ystep < activeCanvas.Height - 40))
            {
                Point px = (origin.X + xstep < activeCanvas.Width - 40) ? new Point(origin.X + xstep, origin.Y) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);
                Point py = (origin.Y + ystep > 20) ? new Point(origin.X, origin.Y + ystep) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);
                Point pnx = (origin.X - xstep > 20) ? new Point(origin.X - xstep, origin.Y) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);
                Point pny = (origin.Y - ystep < activeCanvas.Height - 40) ? new Point(origin.X, origin.Y - ystep) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);

                elg = new EllipseGeometry(px, 2, 2);
                setText(Convert.ToString(xtext), new Point(origin.X + xstep, origin.Y));
                gg.Children.Add(elg);

                elg = new EllipseGeometry(py, 2, 2);
                setText(Convert.ToString(ytext), new Point(origin.X - 10, origin.Y + ystep));
                gg.Children.Add(elg);

                elg = new EllipseGeometry(pnx, 2, 2);
                setText(Convert.ToString(-xtext), new Point(origin.X - xstep, origin.Y));
                gg.Children.Add(elg);

                elg = new EllipseGeometry(pny, 2, 2);
                setText(Convert.ToString(-ytext), new Point(origin.X - 10, origin.Y - ystep));
                gg.Children.Add(elg);

                xstep += xincre;
                ystep += yincre;
                xtext += jx;
                ytext += jy;
            }
            path1.Data = gg;
            activeCanvas.Children.Add(path1);
        }

        //changed by Rushabh
        private void setlogAxes()
        {
            EllipseGeometry elg;
            setLogScale();
            CalLogOrigin();
            double xstep = spanX;
            double ystep = -spanY;
            Line l = new Line();
            l.X1 = origin.X;
            l.Y1 = origin.Y;
            l.X2 = activeCanvas.Width - 20;
            l.Y2 = origin.Y;
            l.Stroke = Brushes.Black;
            Line ly = new Line();
            ly.X1 = origin.X;
            ly.Y1 = (origin.Y - activeCanvas.Height) < 20 ? 20 : origin.Y - activeCanvas.Height;
            ly.X2 = origin.X;
            ly.Y2 = origin.Y;
            ly.Stroke = Brushes.Black;
            Line l1 = new Line();
            l1.X1 = origin.X;
            l1.Y1 = origin.Y;
            l1.X2 = 20;
            l1.Y2 = origin.Y;
            l1.Stroke = Brushes.Black;
            Line ly1 = new Line();
            ly1.X1 = origin.X;
            ly1.Y1 = activeCanvas.Height - 20;
            ly1.X2 = origin.X;
            ly1.Y2 = origin.Y;
            ly1.Stroke = Brushes.Black;
            activeCanvas.Children.Add(ly);
            activeCanvas.Children.Add(l);
            activeCanvas.Children.Add(ly1);
            activeCanvas.Children.Add(l1);
            Path path1 = new Path();
            path1.Fill = Brushes.Black;
            GeometryGroup gg = new GeometryGroup();

            int jx, jy, xtext, ytext;
            int xpart = (int)(activeCanvas.Width - 20) / spanX;
            int ypart = (int)(activeCanvas.Height - 20) / spanY;
            xtext = jx = (xpart < 25) ? 1 : (xpart < 50) ? 2 : (xpart < 100) ? 5 : (xpart < 200) ? 10 : 50;
            ytext = 10;
            jy = 10;
            xstep *= jx;
            int xincre = (int)xstep;
            int yincre = (int)ystep;

            setText(Convert.ToString(0), new Point(origin.X - 5, origin.Y));
            gg.Children.Add(new EllipseGeometry(origin, 2, 2));
            while ((origin.X + xstep < activeCanvas.Width - 40) || (origin.Y + ystep > 20) || (origin.X - xstep > 20) || (origin.Y - ystep < activeCanvas.Height - 40))
            {
                Point px = (origin.X + xstep < activeCanvas.Width - 40) ? new Point(origin.X + xstep, origin.Y) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);
                Point py = (origin.Y + ystep > 20) ? new Point(origin.X, origin.Y + ystep) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);
                Point pnx = (origin.X - xstep > 20) ? new Point(origin.X - xstep, origin.Y) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);
                Point pny = (origin.Y - ystep < activeCanvas.Height - 40) ? new Point(origin.X, origin.Y - ystep) : new Point(activeCanvas.Width + 10, activeCanvas.Height + 10);

                elg = new EllipseGeometry(px, 2, 2);
                setText(Convert.ToString(xtext), new Point(origin.X + xstep, origin.Y));
                gg.Children.Add(elg);

                elg = new EllipseGeometry(py, 2, 2);
                setText(Convert.ToString(ytext), new Point(origin.X - 10, origin.Y + ystep));
                gg.Children.Add(elg);

                elg = new EllipseGeometry(pnx, 2, 2);
                setText(Convert.ToString(-xtext), new Point(origin.X - xstep, origin.Y));
                gg.Children.Add(elg);

                elg = new EllipseGeometry(pny, 2, 2);
                setText(Convert.ToString(-1 / ytext), new Point(origin.X - 10, origin.Y - ystep));
                gg.Children.Add(elg);

                xstep += xincre;
                ystep += yincre;
                xtext += jx;
                ytext *= jy;
            }
            path1.Data = gg;
            activeCanvas.Children.Add(path1);
        }

        //changed by rushabh
        private void plotLogPoints()
        {
            setlogAxes();
            setXaxisTitle(Xtitle);
            setYaxisTitle(Ytitle);
            setPlotTitle(Plottitle);
            GeometryGroup s = new GeometryGroup();
            PathGeometry pg = new PathGeometry();
            PathFigureCollection pfc = new PathFigureCollection();
            PathFigure pf = new PathFigure();
            PathSegmentCollection psc = new PathSegmentCollection();
            Point stpoint = pointslist[0];
            Point pt = new Point();
            //stpoint.X = Math.Round(origin.X + spanX * stpoint.X, 2);
            //stpoint.Y = Math.Round(origin.Y - spanY * stpoint.Y, 2);
            pt.X = Math.Round(origin.X + spanX * stpoint.X, 2);
            pt.Y = Math.Round(origin.Y - spanY * Math.Log10(stpoint.Y), 2);

            pf.StartPoint = pt;
            EllipseGeometry elg = new EllipseGeometry(pt, 2, 2);
            s.Children.Add(elg);
            setText(stpoint.X.ToString() + "," + stpoint.Y.ToString(), pt);
            for (int i = 1; i < pointslist.Count; i++)
            {
                Point point = pointslist[i];
                point.X = Math.Round(point.X, 2);
                point.Y = Math.Round(point.Y, 2);
                pt.X = Math.Round(origin.X + spanX * point.X, 2);
                pt.Y = Math.Round(origin.Y - spanY * Math.Log10(point.Y), 2);
                LineSegment ls = new LineSegment(pt, true);
                elg = new EllipseGeometry(pt, 2, 2);
                setText(point.X.ToString() + "," + point.Y.ToString(), pt);
                s.Children.Add(elg);
                psc.Add(ls);
            }
            pf.Segments = psc;
            pfc.Add(pf);
            pg.Figures = pfc;
            Path p = new Path();
            Path p1 = new Path();
            p.Data = pg;
            p.Stroke = Brushes.Green;
            p1.Data = s;
            p1.Fill = Brushes.Blue;
            activeCanvas.Children.Add(p);
            activeCanvas.Children.Add(p1);
            activeCanvas.ClipToBounds = true;
        }

        //made by rushabh
        private void CalLogOrigin()
        {
            Point min = MinPoint();
            Point max = MaxPoint();
            double orix = ((max.X >= 0 && min.X <= 0) || (max.X <= 0 && min.X >= 0)) ? Math.Abs(min.X) + 1 : (min.X > 0) ? 1 : Math.Abs(min.X) + 1;
            double oriy = ((Math.Log10(max.Y) >= 0 && Math.Log10(min.Y) <= 0) || (Math.Log10(max.Y) <= 0 && Math.Log10(min.Y) >= 0)) ? Math.Abs(Math.Log10(min.Y)) : (Math.Log10(min.Y) > 0) ? 0.1 : Math.Abs(Math.Log10(min.Y));
            Origin = new Point(orix * spanX + 20, activeCanvas.Height - ((oriy * spanY)) - 20);
        }

         // made by rushabh
        private void setLogScale()
        {
            Point minPt = MinPoint();
            Point maxPt = MaxPoint();
            double Xlen = ((maxPt.X >= 0 && minPt.X <= 0) || (maxPt.X <= 0 && minPt.X >= 0)) ? (Math.Abs(maxPt.X) + Math.Abs(minPt.X)) + 2 : (minPt.X > 0) ? maxPt.X + 2 : Math.Abs(minPt.X) + 2;
            double Ylen = Math.Ceiling(((Math.Log10(maxPt.Y) >= 0 && Math.Log10(minPt.Y) <= 0) || (Math.Log10(maxPt.Y) <= 0 && Math.Log10(minPt.Y) >= 0)) ? (Math.Abs(Math.Log10(maxPt.Y)) + Math.Abs(Math.Log10(minPt.Y))) : ((Math.Log10(minPt.Y)) > 0) ? Math.Log10(maxPt.Y) : Math.Abs(Math.Log10(minPt.Y)));
            Ylen += Ylen / 10;
            spanX = (int)((activeCanvas.Width - 40) / Xlen / factx);
            spanY = (int)((activeCanvas.Height - 40) / Ylen / facty);
        }
 
 

        #endregion

        #region 3D-Rushabh

        public void vector3D(double[,] data)
        {
            pointslist3D=transformValuesTo3DPoints(data);
            Viewport3D viewport = new Viewport3D();
            viewport.Height = 500;
            viewport.Width = 500;
            viewport.Camera = Camera_Details();
            viewport.Children.Add(ModelVisual3D_Details());
            viewport.ClipToBounds = true;
            //Point3D[] pt = new Point3D[10];
            //pt[0] = new Point3D(5, 6, 0);
            //pt[1] = new Point3D(0, -2, 3);
            //pt[2] = new Point3D(2.3, 5.2, 1.4);
            //pt[3] = new Point3D(0, 1, 0);
            //pt[4] = new Point3D(3.3, -2.2, 1.4);
            //pt[5] = new Point3D(4.3, 5.2, -1.4);
            //pt[6] = new Point3D(2.3, -3.2, 1.4);
            //pt[7] = new Point3D(2.3, -2.2, 1.4);
            //pt[8] = new Point3D(-2.3, 5.2, 2.4);
            //pt[9] = new Point3D(2.3, 5.2, -0.4);

            activeCanvas = new Canvas();
            activeCanvas.Tag = "plot3D_Vector";
            for (int i = 0; i < pointslist3D.Count; i++)
                createlines(pointslist3D[i],viewport);
            activeCanvas.Children.Add(viewport);
            
            pm.Convert_to_Image(activeCanvas,-2);
        }

        public void vector3D_sub(double[,] data, int paneno)
        {
            pointslist3D = transformValuesTo3DPoints(data);
            Viewport3D viewport = new Viewport3D();
            viewport.Height = 250;
            viewport.Width = 250;
            viewport.Camera = Camera_Details();
            viewport.Children.Add(ModelVisual3D_Details());
            viewport.ClipToBounds = true;
            //Point3D[] pt = new Point3D[10];
            //pt[0] = new Point3D(5, 6, 0);
            //pt[1] = new Point3D(0, -2, 3);
            //pt[2] = new Point3D(2.3, 5.2, 1.4);
            //pt[3] = new Point3D(0, 1, 0);
            //pt[4] = new Point3D(3.3, -2.2, 1.4);
            //pt[5] = new Point3D(4.3, 5.2, -1.4);
            //pt[6] = new Point3D(2.3, -3.2, 1.4);
            //pt[7] = new Point3D(2.3, -2.2, 1.4);
            //pt[8] = new Point3D(-2.3, 5.2, 2.4);
            //pt[9] = new Point3D(2.3, 5.2, -0.4);

            activeCanvas = new Canvas();
            activeCanvas.Tag = "subplot3D_Vector";
            activeCanvas.Height = 250;
            activeCanvas.Width = 250;
            for (int i = 0; i < pointslist3D.Count; i++)
                createlines(pointslist3D[i], viewport);
            activeCanvas.Children.Add(viewport);

            pm.Convert_to_Image(activeCanvas, paneno);
        }

        private Model3DGroup createlines(Point3D pt, Viewport3D viewport)
        {
            Model3DGroup normalGroup = new Model3DGroup();
            Point3D p = pt;
            int length = 1;
            double partx, party;

            #region lines
            ScreenSpaceLines3D normal0Wire = new ScreenSpaceLines3D();
            normal0Wire.Thickness = 5;
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

        private Point3D MinPoint3D()
        {
            Point3D Min = pointslist3D[0];
            for (int i = 1; i < pointslist3D.Count; i++)
            {
                if (pointslist3D[i].X < Min.X)
                    Min.X = pointslist3D[i].X;
                if (pointslist3D[i].Y < Min.Y)
                    Min.Y = pointslist3D[i].Y;
                if (pointslist3D[i].Z < Min.Z)
                    Min.Z = pointslist3D[i].Z;
            }
            return (Min);
        }

        private Point3D MaxPoint3D()
        {
            Point3D Max = pointslist3D[0];
            for (int i = 1; i < pointslist3D.Count; i++)
            {
                if (pointslist3D[i].X > Max.X)
                    Max.X = pointslist3D[i].X;
                if (pointslist3D[i].Y > Max.Y)
                    Max.Y = pointslist3D[i].Y;
                if (pointslist3D[i].Z > Max.Z)
                    Max.Z = pointslist3D[i].Z;
            }
            return (Max);
        }

        #endregion

        #region 3D-Mahesh
        //Helper method for transforming values to 3D points
        public List<Point3D> transformValuesTo3DPoints(double[,] pvalues)
        {
            List<Point3D> templist = new List<Point3D>();
            for (int i = 0; i < pvalues.GetLength(0); i++)
            {
                for (int j = 0; j < pvalues.GetLength(1); j++)
                {
                    Point3D temp = new Point3D(i + 1, j + 1, pvalues[i, j]);
                    templist.Add(temp);
                }
            }
            return templist;
        }

        public void subplot_3Dto2D(double[,] values,int panenum)
        {
            activeCanvas = new Canvas();
            adjustPaneSize(4);
            plot3D_2D(values);
            activeCanvas.Tag = "subplot2D";
            pm.Convert_to_Image(activeCanvas, panenum);
        }
        Canvas resubPlot3D()
        {
            return smallCanvas;
        }

        //Method to plot 3D data into 2D with z-index as color variation
        public void plot3DInto2D(double[,] values)
        {
            
            numPanes = 1;
            activeCanvas = new Canvas();
            activeCanvas.Width = 500;
            activeCanvas.Height = 500;
            activeCanvas.Tag = "plot2D";
            plot3D_2D(values);            
            pm.Convert_to_Image(activeCanvas, -1);
            activeCanvas = new Canvas();
            adjustPaneSize(4);
            plot3D_2D(values);
            smallCanvas = activeCanvas;
            activeCanvas = new Canvas();
            activeCanvas.Width = 500;
            activeCanvas.Height = 500;

        }
        private void plot3D_2D(double[,] values)
        {
            List<Point3D> plist = transformValuesTo3DPoints(values);
            pointslist3D = plist;
            pointslist = new List<Point>();
            for (int i = 0; i < plist.Count; i++)
            {
                pointslist.Add(new Point(plist[i].X, plist[i].Y));
            }            
            setAxes();
            setColorBand();
            printColorBand();
            GeometryGroup s = new GeometryGroup();
            for (int i = 0; i < plist.Count; i++)
            {
                Point point = new Point(plist[i].X, plist[i].Y);
                point.X = origin.X + spanX * point.X;
                point.Y = origin.Y - spanY * point.Y;
                Ellipse el = new Ellipse();
                el.Height = 8;
                el.Width = 8;
                Canvas.SetLeft(el, point.X);
                Canvas.SetTop(el, point.Y);
                Brush b = new SolidColorBrush(getColor(plist[i].Z));
                el.Fill = b;
                el.Stroke = b;
                setText(pointToText(point), point);
                activeCanvas.Children.Add(el);

            }
            activeCanvas.ClipToBounds = true;
        }

        void printColorBand()
        {
            for (int i = 0; i < 10; i++)
            {
                Rectangle r = new Rectangle();
                r.Width = 30;
                r.Height = 30;
                Canvas.SetLeft(r, activeCanvas.Width - 60);
                Canvas.SetTop(r, 10 + i * 20);
                r.Fill = new SolidColorBrush(colorlist[i]);
                activeCanvas.Children.Add(r);
            }
            double max = MaxPoint3D().Z;
            double min = MinPoint3D().Z;
            double diff = Math.Abs(max - min);
            double partdiff = diff / 10;
            setText(MinPoint3D().Z.ToString(), new Point(activeCanvas.Width - 50, 195 + 10));
            for (int i = 1; i < 10; i++)
            {
                setText((MinPoint3D().Z + partdiff * i).ToString() + '-' + (MinPoint3D().Z + partdiff * (i + 1) - 0.01).ToString(), new Point(activeCanvas.Width - 60, 20 * (10 - i) + 10));
            }
            setText(MaxPoint3D().Z.ToString(), new Point(activeCanvas.Width - 50, 15));
        }

        void setColorBand()
        {
            colorlist = new List<Color>();
            for (int i = 0; i < 10; i++)
            {
                Color temp = new Color();
                temp.ScB = 1 - 0.1F * i;
                temp.ScG = 0.1F * i;
                temp.ScR = 0.1F * i;
                temp.ScA = 1;
                colorlist.Add(temp);
            }
        }

        Color getColor(double zindex)
        {
            double max = MaxPoint3D().Z;
            double min = MinPoint3D().Z;
            double diff = Math.Abs(max - min);
            double partdiff = diff / 10;
            Color tempColor = new Color();
            int i;
            for (i = 0; i < 10; i++)
                if (partdiff * i + min >= zindex)
                    break;
            i = i <= 9 ? i : 9;
            int colorindex = i;
            tempColor = colorlist[9 - i];
            return tempColor;
        }
        #endregion

        #region 3D-Rohan
        private PerspectiveCamera Camera_Details()
        {
            PerspectiveCamera camera = new PerspectiveCamera();
            camera.FarPlaneDistance = 100;
            camera.LookDirection = new Vector3D(-11,-10, -9);
            camera.UpDirection = new Vector3D(0, 1, 0);
            camera.NearPlaneDistance = 1;
            camera.Position = new Point3D(11,10,9);
            camera.FieldOfView = 30;
            return camera;
        }

        //sets the properties for visual content for plot 3D
        private ModelVisual3D ModelVisual3D_Details()
        {
            ModelVisual3D md = new ModelVisual3D();
            DirectionalLight d = new DirectionalLight();
            d.Color = Colors.White;
            d.Direction = new Vector3D(-2, -3, -1);
            md.Content = d;
            return md;
        }

        private List<Triangulator.Geometry.Point> Points3dtoPoints2d(Point3D[] points3d)
        {

            int index = 0;
            //Point[] points2d = new Point[points3d.Length];
            List<Triangulator.Geometry.Point> points2d = new List<Triangulator.Geometry.Point>();
            int count = 0;
            for (; index < points3d.Length; index++)
            {

                Triangulator.Geometry.Point gmpoint = new Triangulator.Geometry.Point(points3d[index].X, points3d[index].Y);
                points2d.Add(gmpoint);
                string s;
                s = gmpoint.X.ToString();
                s += gmpoint.Y.ToString();
                delaunaypoints[s] = points3d[index];
                count++;

            }
            return points2d;
        }
        
        //plot 3D 
        public void plot3D_Terrain(double[,] data)
        {
            mainViewport = new Viewport3D();
            this.mainViewport.Height = 500;
            this.mainViewport.Width = 500;

            mainViewport.Camera = Camera_Details();
            mainViewport.Children.Add(ModelVisual3D_Details());
            Model3DGroup cube = new Model3DGroup();
            Point3D[] points = new Point3D[data.GetLength(0) * data.GetLength(1)];
            TransformPoints(data, points);
            List<Triangulator.Geometry.Point> points2d = Points3dtoPoints2d(points);
            if (points2d.Count > 2)
            {
                List<Triangulator.Geometry.Triangle> tris = Triangulator.Delauney.Triangulate(points2d);
                foreach (Triangulator.Geometry.Triangle t in tris)
                {
                    string s1 = points2d[t.p1].X.ToString() + points2d[t.p1].Y.ToString();
                    string s2 = points2d[t.p2].X.ToString() + points2d[t.p2].Y.ToString();
                    string s3 = points2d[t.p3].X.ToString() + points2d[t.p3].Y.ToString();
                    Point3D p1 = (Point3D)delaunaypoints[s1];
                    Point3D p2 = (Point3D)delaunaypoints[s2];
                    Point3D p3 = (Point3D)delaunaypoints[s3];
                    cube.Children.Add(CreateTriangleModel(p2, p1, p3));

                }
            }
            ModelVisual3D model = new ModelVisual3D();
            model.Content = cube;


            this.mainViewport.Children.Add(model);
            activeCanvas = new Canvas();
            //  activeCanvas.Height = 500;
            //activeCanvas.Width = 500;
            activeCanvas.Tag = "plot3D_Terrain";
            mainViewport.ClipToBounds = true;
            activeCanvas.Children.Add(mainViewport);
            pm.Convert_to_Image(activeCanvas,-2);

        }


            //subplot 3D 
        public void subplot3D_terrain(double[,] data,int paneno)
        {
            mainViewport = new Viewport3D();
            this.mainViewport.Height = 250;
            this.mainViewport.Width = 250;

            mainViewport.Camera = Camera_Details();
            mainViewport.Children.Add(ModelVisual3D_Details());
            Model3DGroup cube = new Model3DGroup();
            Point3D[] points = new Point3D[data.GetLength(0) * data.GetLength(1)];
            TransformPoints(data, points);
            List<Triangulator.Geometry.Point> points2d = Points3dtoPoints2d(points);
            if (points2d.Count > 2)
            {
                List<Triangulator.Geometry.Triangle> tris = Triangulator.Delauney.Triangulate(points2d);
                foreach (Triangulator.Geometry.Triangle t in tris)
                {
                    string s1 = points2d[t.p1].X.ToString() + points2d[t.p1].Y.ToString();
                    string s2 = points2d[t.p2].X.ToString() + points2d[t.p2].Y.ToString();
                    string s3 = points2d[t.p3].X.ToString() + points2d[t.p3].Y.ToString();
                    Point3D p1 = (Point3D)delaunaypoints[s1];
                    Point3D p2 = (Point3D)delaunaypoints[s2];
                    Point3D p3 = (Point3D)delaunaypoints[s3];
                    cube.Children.Add(CreateTriangleModel(p2, p1, p3));

                }
            }


            #region cube_code
            //Point3D p0 = new Point3D(0, 0, 0);
            //Point3D p1 = new Point3D(5, 0, 0);
            //Point3D p2 = new Point3D(5, 0, 5);
            //Point3D p3 = new Point3D(0, 0, 5);
            //Point3D p4 = new Point3D(0, 5, 0);
            //Point3D p5 = new Point3D(5, 5, 0);
            //Point3D p6 = new Point3D(5, 5, 5);
            //Point3D p7 = new Point3D(0, 5, 5);
            ////front side triangles
            //cube.Children.Add(CreateTriangleModel(p3, p2, p6));
            //cube.Children.Add(CreateTriangleModel(p3, p6, p7));
            ////right side triangles
            //cube.Children.Add(CreateTriangleModel(p2, p1, p5));
            //cube.Children.Add(CreateTriangleModel(p2, p5, p6));
            ////back side triangles
            //cube.Children.Add(CreateTriangleModel(p1, p0, p4));
            //cube.Children.Add(CreateTriangleModel(p1, p4, p5));
            ////left side triangles
            //cube.Children.Add(CreateTriangleModel(p0, p3, p7));
            //cube.Children.Add(CreateTriangleModel(p0, p7, p4));
            ////top side triangles
            //cube.Children.Add(CreateTriangleModel(p7, p6, p5));
            //cube.Children.Add(CreateTriangleModel(p7, p5, p4));
            ////bottom side triangles
            //cube.Children.Add(CreateTriangleModel(p2, p3, p0));
            //cube.Children.Add(CreateTriangleModel(p2, p0, p1));
            #endregion
            ModelVisual3D model = new ModelVisual3D();
            model.Content = cube;


            this.mainViewport.Children.Add(model);
            activeCanvas = new Canvas();
            //  activeCanvas.Height = 500;
            //activeCanvas.Width = 500;
            activeCanvas.Tag = "subplot3D_Terrain";
            activeCanvas.Height = 250;
            activeCanvas.Width = 250;
            mainViewport.ClipToBounds = true;
            activeCanvas.Children.Add(mainViewport);
            pm.Convert_to_Image(activeCanvas, paneno);

        
        }

        //convert matrix points to point3D
        private void TransformPoints(double[,] data, Point3D[] points)
        {
            int count = 0;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    points[count] = new Point3D(i, j, data[i, j]);
                    count += 1;
                }
            }
        }

        //creates triangle model 
        private Model3DGroup CreateTriangleModel(Point3D p0, Point3D p1, Point3D p2)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            Vector3D normal = CalculateNormal(p0, p1, p2);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            //// Create a horizontal linear gradient with four stops.   
            //LinearGradientBrush myHorizontalGradient = new LinearGradientBrush();
            //myHorizontalGradient.StartPoint = new Point(0, 0.5);
            //myHorizontalGradient.EndPoint = new Point(1, 0.5);
            //myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            //myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            //myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            //myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.MediumVioletRed, 1.0));
            Material material = new DiffuseMaterial(
                new SolidColorBrush(Colors.Gold));
            //DiffuseMaterial material = new DiffuseMaterial(myHorizontalGradient);
            GeometryModel3D model = new GeometryModel3D(
                mesh, material);
            // RotateTransform3D myrotate = new RotateTransform3D();
            // Apply a transform to the object. In this sample, a rotation transform is applied,  
            // rendering the 3D object rotated.

            RotateTransform3D myRotateTransform3D = new RotateTransform3D();
            AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
            // myAxisAngleRotation3d.Axis = new Vector3D(2, 2, 2);
            myAxisAngleRotation3d.Angle = 200;
            myRotateTransform3D.Rotation = myAxisAngleRotation3d;
            model.Transform = myRotateTransform3D;

            // Add the geometry model to the model group.
            // myModel3DGroup.Children.Add(myGeometryModel);

            // Add the group of models to the ModelVisual3d.
            // myModelVisual3D.Content = myModel3DGroup;

            // 
            // myViewport3D.Children.Add(myModelVisual3D);
            Model3DGroup group = new Model3DGroup();
            group.Children.Add(model);
            return group;

        }

        //calculates the normal to each triangle surface
        private Vector3D CalculateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            Vector3D v0 = new Vector3D(
                p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            Vector3D v1 = new Vector3D(
                p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            return Vector3D.CrossProduct(v0, v1);
        }

        //set camera position
        private void SetCamera()
        {
            //PerspectiveCamera camera = (PerspectiveCamera)mainViewport.Camera;
            //Point3D position = new Point3D(
            //    Convert.ToDouble(cameraPositionXTextBox.Text),
            //    Convert.ToDouble(cameraPositionYTextBox.Text),
            //    Convert.ToDouble(cameraPositionZTextBox.Text)
            //);
            //Vector3D lookDirection = new Vector3D(
            //    Convert.ToDouble(lookAtXTextBox.Text),
            //    Convert.ToDouble(lookAtYTextBox.Text),
            //    Convert.ToDouble(lookAtZTextBox.Text)
            //);
            //camera.Position = position;
            //camera.LookDirection = lookDirection;
        }

        //clear previous terain from the viewport
        private void ClearViewport()
        {
            ModelVisual3D m;
            for (int i = mainViewport.Children.Count - 1; i >= 0; i--)
            {
                m = (ModelVisual3D)mainViewport.Children[i];
                if (m.Content is DirectionalLight == false)
                    mainViewport.Children.Remove(m);
            }
        }
        #endregion

        
    }
}

