﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace DemoCTControls
{
    public class NARadioButton : RadioButton
    {
        // fields
        private Color checkedColor = Color.MediumSlateBlue;
        private Color unCheckedColor = Color.Gray;
        //properties
        public Color CheckedColor
        {
            get
            {
                return checkedColor;
            }
            set
            {
                checkedColor = value ;
                this.Invalidate();
            }
        }
        public Color UnCheckedColor
        {
            get
            {
                return unCheckedColor;
            }
            set
            {
                  unCheckedColor = value;
                this.Invalidate();
            }

        }
        public NARadioButton()
        {
            this.MinimumSize = new Size(0, 21);
            this.Padding = new Padding(10, 0, 0, 0);
        }
        // Overridden methods
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //Fields
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2, //Center
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Center
                Y = (this.Height - rbCheckSize) / 2, //Center
                Width = rbCheckSize,
                Height = rbCheckSize
            };
            //Drawing
            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                //Draw surface
                graphics.Clear(this.BackColor);
                //Draw Radio Button
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                    graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
                }
                //Draw text
                graphics.DrawString(this.Text, this.Font, brushText,
                    rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);//Y=Center
            }
        }

    }
}
