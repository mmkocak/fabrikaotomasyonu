﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fabrikaotomasyonu
{
    internal class CustomButton : Button
    {
        // fields
        private int  borderSize = 0;
        private int  borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;
        // Constructor
        public CustomButton()
        { 
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.ForeColor= Color.White;
            this.BackColor= Color.MediumSlateBlue;
        }
        // Methodlar
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Height , radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height, radius, radius, 270, 90);
            path.AddArc(rect.X, rect.Height, radius, radius, 270, 90);
            path.CloseFigure();
            return path;

        }
        protected override void OnPaint(PaintEventArgs e)
        { 
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectSurface = new RectangleF(0,0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width-0.8f, this.Height-1);
            if (borderRadius > 2)
            {
                using(GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                    using(GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius-1f))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                    using(Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                }
            }
            else
            {

            }
                
        }
    }
}
