using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 1000;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            Brush myBrush = new SolidBrush(Color.Red);

            float x = 50;
            float y = 50;


            for (int i = 0; i < 100000; i++)
            {
                g.DrawLine(myPen, x, y, x, y + 1);
                float[] locXY = CalculatePoint(x, y);
                x = locXY[0];
                y = locXY[1];
            }
        }


        public float[] CalculatePoint(float x, float y)
        {

            float[] locXY = new float[2];
            int corners = 3;
            Random seed = new Random();
            float triX = 0;
            float triY = 0;

            //get corner
            int setCorner = seed.Next(1, corners + 1);

            int formLength = 1000;
            int formHeight = 1000;
            int corrX = 25;
            int corrY = 50;

            switch (corners)
            {
                case 3:
                    //triangle
                    switch (setCorner)
                    {
                        case 1:
                            triX = formLength / 2;
                            triY = 0;
                            break;
                        case 2:
                            triX = corrX;
                            triY = formHeight - corrY;
                            break;
                        case 3:
                            triX = formLength - corrX;
                            triY = formHeight - corrY;
                            break;
                    }
                    break;
                case 5:
                    //pentagon
                    switch (setCorner)
                    {
                        case 1:
                            triX = formLength / 2;
                            triY = 0;
                            break;
                        case 2:
                            triX = corrX;
                            triY = formHeight / 5 * 2;
                            break;
                        case 3:
                            triX = formLength - corrX;
                            triY = formHeight / 5 * 2;
                            break;
                        case 4:
                            triX = formLength / 5 + corrX;
                            triY = formHeight - corrY;
                            break;
                        case 5:
                            triX = formLength - (formLength / 5) - corrX;
                            triY = formHeight - corrY;
                            break;
                    }
                    break;
            }




            locXY[0] = (triX + x) / 2;
            locXY[1] = (triY + y) / 2;

            return locXY;
        }
    }
}
