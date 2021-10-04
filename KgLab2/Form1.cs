using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KgLab2
{

    public partial class Form1 : Form
    {
        const int scaler = 4;
        public Form1()
        {
            InitializeComponent();
        }

        public double dispToComp(int x)
        {
            /* Using for both X and Y in cases, when width is equal to height.
             * The first action transfers coordinate to center,
             * the second action converts to complex with scaler size. */
            return (double)(x - pictureBox1.Width / 2) / (pictureBox1.Width / scaler);
        }

        public int compToDisp(double x)
        {
            /* Works in the reverse order in comparison with function dispToComp */
            return (int)(x * (pictureBox1.Width / scaler) + pictureBox1.Width / 2);
        }

        public void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            /*const double x0 = -2;
            const double xN = 2;
            const double y0 = -2;
            const double yN = 2;*/

            const double x0 = -1;
            const double xN = 0.7;
            const double y0 = -0.9;
            const double yN = 1.1;

            const double maxIter = 100;
            //Comp c = new Comp(0.2, 0.75);
            Comp c = new Comp(0.36, 0.36);

            for (int x = compToDisp(x0); x < compToDisp(xN); x++)
            {
                for (int y = compToDisp(y0); y < compToDisp(yN); y++)
                {
                    Comp z = new Comp(dispToComp(x), dispToComp(y));
                    int i;

                    for (i = 0; i < maxIter; i++)
                    {
                        z = z.CompMult(z);
                        z = z.CompAdd(c);
                        if (z.CompAbs() > 2) break;
                    }
                    bmp.SetPixel(x, y, i < maxIter ? Color.FromArgb(255, i % 4 * 85, i % 2 * 76) : Color.FromArgb(i, i, i));
                }
                pictureBox1.Image = bmp;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
