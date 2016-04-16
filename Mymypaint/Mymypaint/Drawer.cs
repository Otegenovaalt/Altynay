using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Mymypaint
{
        public enum Shape { pencil, rectangle, circle, erasor, line, triangle,triangle1 };

        class Drawer
        {
            public Graphics g;
            public SolidBrush sb;
            public Bitmap bm;

            public GraphicsPath path;

            public PictureBox picture;
            public Shape sh;
            public Pen pen, er;
            public bool start = false;
            public Point prev;

            public Drawer(PictureBox p)
            {
                picture = p;
                pen = new Pen(Color.Black);
                er = new Pen(Color.White);
                sb = new SolidBrush(Color.Black);

                openImage("");

                picture.Paint += Picture_Paint;
            }
            public void Picture_Paint(object sender, PaintEventArgs e)
            {
                if (path != null)
                    e.Graphics.DrawPath(pen, path);
            }

            public void Draw(Point cur)
            {
                switch (sh)
                {
                    case Shape.pencil:
                        g.DrawLine(pen, prev, cur);
                        prev = cur;
                        break;
                    case Shape.rectangle:
                        path = new GraphicsPath();
                        if (prev.X > cur.X)
                        {
                            if (prev.Y > cur.Y)
                                path.AddRectangle(new Rectangle(cur.X, cur.Y, prev.X - cur.X, prev.Y - cur.Y));
                            if (prev.Y < cur.Y)
                                path.AddRectangle(new Rectangle(cur.X, prev.Y, prev.X - cur.X, cur.Y - prev.Y));
                        }
                        else
                        {
                            if ((prev.Y < cur.Y))
                                path.AddRectangle(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                            else
                                path.AddRectangle(new Rectangle(prev.X, cur.Y, cur.X - prev.X, prev.Y - cur.Y));
                        }
                        break;
                    case Shape.circle:
                        path = new GraphicsPath();
                        path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                        break;                   
                    case Shape.line:
                        path = new GraphicsPath();
                        path.AddLine(prev, cur);
                        break;                    
                    case Shape.triangle:
                        path = new GraphicsPath();
                        Point[] pp = new Point[3];
                        pp[0] = prev;
                        pp[1] = cur;
                        pp[2] = new Point(cur.X - 2 * (cur.X - prev.X), cur.Y);
                        path.AddPolygon(pp);
                        break;
                    case Shape.erasor:
                        path = null;
                        g.DrawLine(er, prev, cur);
                        prev = cur;
                        break;
                    default:
                        break;
                }
                picture.Refresh();
            }

            public void saveLastPath()
            {
                if (path != null)
                {                  
                        g.DrawPath(pen, path);
                }
            }
            public void SaveImage(string filename)
            {
                bm.Save(filename);
            }

            public void openImage(string filename)
            {
                bm = filename == "" ? new Bitmap(picture.Width, picture.Height) : new Bitmap(filename);                
                g = Graphics.FromImage(bm);
                picture.Image = bm;
            }
        }
    }

