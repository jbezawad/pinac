////////////////////////////////////////////////////////////////////////
// PlotManager.cs: Convert paint objects to image and send it to UI team,
// saving image to local directory
// version: 1.0
// description: Manages all the plots
// author: Rohan Pandit (rspandit@syr.edu)
// language: Visual C#
////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Collections;


namespace Spinach
{
    public partial  class PlotManager
    {
        private Hashtable Canvas_Obj;
        private Hashtable Updates;
        private string imagepath = "..\\images";
        private Paint paint;
        private PngBitmapEncoder encoder1;

        public delegate void PlotError(int code, string message);
        public event PlotError error;

        public void OnError(int code, string message)
        {
            if (error != null)
                error(code, message);
        }

        public PlotManager(Paint pa)
        {
            Canvas_Obj = new Hashtable();
            Updates = new Hashtable();
            encoder1 = new PngBitmapEncoder();
            paint = pa;


        }


        public void Convert_to_Image(Canvas can, int pane_number)
        {

            if (pane_number == -1)
            {

                //clear hashtable as new plot will overwirte previous image
                Canvas_Obj.Clear();
                Updates.Clear();

                PngBitmapEncoder encoder = new PngBitmapEncoder();
                Canvas_Obj[1] = can;
                Transform transform = can.LayoutTransform;

                // reset current transform incase of scalling or rotating
                can.LayoutTransform = null;

                // get size of canvas
                Size size = new Size(can.Width, can.Height);

                // measure and arrange the canvas
                can.Measure(size);
                can.Arrange(new Rect(size));

                // create and render surface and push bitmap to it
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((Int32)size.Width, (Int32)size.Height, 100d, 100d, PixelFormats.Pbgra32);

                // now render surface to bitmap
                renderBitmap.Render(can);

                // puch rendered bitmap into it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

                encoder1 = encoder;

                //passing encoder to plotreceiver module
                returnEncoderImage();

                //// create image to return
                //Image returnImage = new Image();
                //// set source of image as frame
                //returnImage.Source = encoder.Frames[0];

                //// restore previously saved layout
                //can.LayoutTransform = transform;

                ////check if the directory exists or not and if not exist create a new one.
                //if (!Directory.Exists(imagepath))
                //    Directory.CreateDirectory(imagepath);

                //// string for saving
                //String tempPath = imagepath + "\\image.png";

                //// create a file stream for saving image
                //using (FileStream outStream = new FileStream(tempPath, FileMode.Create))
                //{
                //    encoder.Save(outStream);
                //}
                
            }
            #region code
            else if (pane_number == -2)
            {
                Canvas_Obj.Clear();
                Updates.Clear();


                PngBitmapEncoder encoder = new PngBitmapEncoder();
                Canvas_Obj[1] = can;
                Viewport3D vi = new Viewport3D();
                vi = (Viewport3D)can.Children[0];
                Transform transform = vi.LayoutTransform;
                //TextBlock txt = new TextBlock() { Text = "Plot3D" };
                // reset current transform incase of scalling or rotating
                vi.LayoutTransform = null;

                // get size of canvas
                Size size = new Size(vi.Width, vi.Height);

                // measure and arrange the canvas
                vi.Measure(size);
                vi.Arrange(new Rect(size));

                // create and render surface and push bitmap to it
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((Int32)size.Width, (Int32)size.Height, 100d, 100d, PixelFormats.Pbgra32);

                // now render surface to bitmap
                renderBitmap.Render(vi);

                // puch rendered bitmap into it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

                encoder1 = encoder;

                //passing encoder to plotreceiver module
                returnEncoderImage();

                //// create image to return
                //Image returnImage = new Image();
                //// set source of image as frame
                //returnImage.Source = encoder.Frames[0];

                //// restore previously saved layout
                //vi.LayoutTransform = transform;

                ////check if the directory exists or not and if not exist create a new one.
                //if (!Directory.Exists(imagepath))
                //    Directory.CreateDirectory(imagepath);

                //// string for saving
                //String tempPath = imagepath + "\\image.png";

                //// create a file stream for saving image
                //using (FileStream outStream = new FileStream(tempPath, FileMode.Create))
                //{
                //    encoder.Save(outStream);
                //}

            }
            #endregion
            else
            {
                object a=can.Tag;
                if((string)a=="subplot3D_Terrain"|| (string)a=="subplot3D_Vector")
                {
                    //Canvas_Obj.Clear();
                    //Updates.Clear();
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                //Canvas_Obj[1] = can;

                int resized_pane_number = 0;

                Canvas resized_canvas = new Canvas();
                foreach (DictionaryEntry entry in Canvas_Obj)
                {

                    Canvas canvas_value = (Canvas)entry.Value;
                    if (canvas_value.Height != can.Height)
                    {
                        resized_canvas = resize_canvas(canvas_value, pane_number);
                        resized_pane_number = FindKey(canvas_value);
                        Updates.Add(resized_pane_number, resized_canvas);
                    }
                }
                foreach (DictionaryEntry upd in Updates)
                {
                    Canvas_Obj[upd.Key] = upd.Value;
                }


                Canvas_Obj[pane_number] = can;
                Canvas cannew = new Canvas();
                cannew = mergePlots();
               // Viewport3D vi = new Viewport3D();
                //vi = (Viewport3D)can.Children[0];
                Transform transform = cannew.LayoutTransform;
                //TextBlock txt = new TextBlock() { Text = "Plot3D" };
                // reset current transform incase of scalling or rotating
                cannew.LayoutTransform = null;

                // get size of canvas
                Size size = new Size(cannew.Width, cannew.Height);

                // measure and arrange the canvas
                cannew.Measure(size);
                cannew.Arrange(new Rect(size));

                // create and render surface and push bitmap to it
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((Int32)size.Width, (Int32)size.Height, 100d, 100d, PixelFormats.Pbgra32);

                // now render surface to bitmap
                renderBitmap.Render(cannew);

                // puch rendered bitmap into it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

                encoder1 = encoder;

                //passing encoder to plotreceiver module
                returnEncoderImage();

                // create image to return
                Image returnImage = new Image();
                // set source of image as frame
                returnImage.Source = encoder.Frames[0];

                // restore previously saved layout
                cannew.LayoutTransform = transform;

                //check if the directory exists or not and if not exist create a new one.
                if (!Directory.Exists(imagepath))
                    Directory.CreateDirectory(imagepath);

                // string for saving
                String tempPath = imagepath + "\\image.png";

                // create a file stream for saving image
                using (FileStream outStream = new FileStream(tempPath, FileMode.Create))
                {
                    encoder.Save(outStream);
                }

                }
                else 
                {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                int resized_pane_number = 0;

                Canvas resized_canvas = new Canvas();


                //IDictionaryEnumerator entry = Canvas_Obj.GetEnumerator();
                foreach (DictionaryEntry entry in Canvas_Obj)
                {

                    Canvas canvas_value = (Canvas)entry.Value;
                    if (canvas_value.Height != can.Height)
                    {
                        resized_canvas = resize_canvas(canvas_value, pane_number);
                        resized_pane_number = FindKey(canvas_value);
                        Updates.Add(resized_pane_number, resized_canvas);
                    }
                }
                foreach (DictionaryEntry upd in Updates)
                {
                    Canvas_Obj[upd.Key] = upd.Value;
                }


                Canvas_Obj[pane_number] = can;
                Canvas cannew = new Canvas();
                cannew = mergePlots();



                Transform transform = can.LayoutTransform;

                // reset current transform incase of scalling or rotating
                can.LayoutTransform = null;

                // get size of canvas
                Size size = new Size(cannew.Width, cannew.Height);

                // measure and arrange the canvas 
                cannew.Measure(size);
                cannew.Arrange(new Rect(size));

                // create and render surface and push bitmap to it
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((Int32)size.Width, (Int32)size.Height, 100d, 100d, PixelFormats.Pbgra32);

                // now render surface to bitmap
                renderBitmap.Render(cannew);

                // puch rendered bitmap into it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder1 = encoder;

                //passing encoder to plotreceiver module
                returnEncoderImage();

                // create image to return
                Image returnImage = new Image();
                // set source of image as frame
                returnImage.Source = encoder.Frames[0];

                // restore previously saved layout
                can.LayoutTransform = transform;

                //check if the directory exists or not and if not exist create a new one.
                if (!Directory.Exists(imagepath))
                    Directory.CreateDirectory(imagepath);

                // string for saving
                String tempPath = imagepath + "\\image.png";

                // create a file stream for saving image
                using (FileStream outStream = new FileStream(tempPath, FileMode.Create))
                {
                    encoder.Save(outStream);
                }
            }
            }

        }
        public int FindKey(Canvas myValue)
        {
            int myKey = 0;

            foreach (int aKey in Canvas_Obj.Keys)
            {
                if (Canvas_Obj[aKey] == myValue)
                    myKey = aKey;
            }
            return myKey;
        }

        public Canvas resize_canvas(Canvas resize_canvas, int size_number)
        {
            //int i = resize_canvas.Children.Count;
            //System.Windows.Shapes.Path p = new System.Windows.Shapes.Path();
            //p = (System.Windows.Shapes.Path)resize_canvas.Children[i - 1];
            //GeometryGroup temp = (GeometryGroup)p.GetValue(System.Windows.Shapes.Path.DataProperty);
            //List<Point> templist = new List<Point>();
            //for (int k = 0; k < temp.Children.Count; k++)
            //{
            //    EllipseGeometry elg = (EllipseGeometry)temp.Children[k];
            //    templist.Add(elg.Center);
            //}
            //paint.subplot2D(templist, size_number);
            // Canvas resize_canvas = new Canvas();
            //Viewport3D vi = new Viewport3D();
            //vi = (Viewport3D)resize_canvas.Children[0
            object a = resize_canvas.Tag;
            Canvas can1 = new Canvas();
            if ((string)a == "plot3D_Terrain" || (string)a == "plot3D_Vector")
            {
                Viewport3D vi = new Viewport3D();
                vi = (Viewport3D)resize_canvas.Children[0];
                vi.Height = 250;
                vi.Width = 250;
                resize_canvas.Height = 250;
                resize_canvas.Width = 250;
                can1 = resize_canvas;

            }
            else
            {
                can1 = paint.resubplot2D();
                can1.Tag = "plot2D";
            }
            return can1;
        }
        public Canvas mergePlots()
        {

            Canvas newCanvas = new Canvas();
            newCanvas.Children.Capacity = 4;
            newCanvas.Height = 550;
            newCanvas.Width = 550;
            foreach (DictionaryEntry entry in Canvas_Obj)
            {
                Canvas canvas_value = (Canvas)entry.Value;
                if (canvas_value.Parent != null)
                {
                    Canvas temp = (Canvas)canvas_value.Parent;
                    temp.Children.Remove(canvas_value);
                }
                object a = canvas_value.Tag;
                switch ((int)entry.Key)
                {
                    case 1:
                        
                        if ((string)a == "plot2D")
                        {
                            Canvas.SetTop(canvas_value, 0);
                            Canvas.SetLeft(canvas_value, 0);
                        }
                        else
                        {
                            Viewport3D vi = new Viewport3D();
                            vi = (Viewport3D)canvas_value.Children[0];
                            Canvas.SetTop(vi, 0);
                            Canvas.SetLeft(vi, 0);
                        }
                        break;
                    case 2:
                        if ((string)a == "subplot2D")
                        {
                            Canvas.SetTop(canvas_value, 0);
                            Canvas.SetLeft(canvas_value, 250);
                        }
                        else
                        {
                            Viewport3D vi = new Viewport3D();
                            vi = (Viewport3D)canvas_value.Children[0];
                            Canvas.SetTop(vi, 0);
                            Canvas.SetLeft(vi, 250);
                        }
                        break;
                    case 3:
                        if ((string)a == "subplot2D")
                        {
                            Canvas.SetTop(canvas_value, 250);
                            Canvas.SetLeft(canvas_value, 0);
                        }
                        else
                        {
                            Viewport3D vi = new Viewport3D();
                            vi = (Viewport3D)canvas_value.Children[0];
                            Canvas.SetTop(vi, 250);
                            Canvas.SetLeft(vi, 0);
                        }
                        break;
                    case 4:
                        if ((string)a == "subplot2D")
                        {
                            Canvas.SetTop(canvas_value, 250);
                            Canvas.SetLeft(canvas_value, 250);
                        }
                        else
                        {
                            Viewport3D vi = new Viewport3D();
                            vi = (Viewport3D)canvas_value.Children[0];
                            Canvas.SetTop(vi, 250);
                            Canvas.SetLeft(vi, 250);
                        }
                            break;
                }

                newCanvas.Children.Add(canvas_value);

            }
            return newCanvas;
        }

        public PngBitmapEncoder returnEncoderImage()
        {
            return encoder1;
        }
    }
}



