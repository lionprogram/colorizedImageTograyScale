using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MahdiAskariFirstProject
{
    public partial class Form1 : Form
    {
        Bitmap RowPic;
        public Form1()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Img_Open = new OpenFileDialog();
            Img_Open.Filter = "Image File(*.Gif; *.jpg)| *.Gif; *.jpg";
            Img_Open.Title = "بارگذاری تصویر";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Img_Open.ShowDialog() == DialogResult.OK) { 

                pictureBox1.Image = Image.FromFile(Img_Open.FileName);
                RowPic = new Bitmap(pictureBox1.Image);
                textBox1.Text += "width: "+Convert.ToString(RowPic.Width)+" - height: "+ Convert.ToString(RowPic.Height);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Bitmap result = new Bitmap(pictureBox1.Image);
            Color pix1, pix2;
            int r, g, b, intensity;
            for (int x = 0; x <= RowPic.Width-1; x++)
            {
                for (int y = 0; y <= RowPic.Height-1 ; y++)
                {
                    pix1 = RowPic.GetPixel(x,y);
                    r = pix1.R;
                    g = pix1.G;
                    b = pix1.B;
                    intensity = (r + g + b) / 3;
                    pix2 = Color.FromArgb(intensity,intensity,intensity);
                    result.SetPixel(x,y,pix2);
                    
                }
                    pictureBox2.Image = result;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int XPoint = Cursor.Position.X;
            int YPoint = Cursor.Position.Y;
            int r, g, b;
            r = RowPic.GetPixel(XPoint, YPoint).R;
            g = RowPic.GetPixel(XPoint, YPoint).G;
            b = RowPic.GetPixel(XPoint, YPoint).B;
            richTextBox1.Text = "RED: "+r+" - GREEN: "+g+" - BLUE: "+b;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int XPoint = Cursor.Position.X;
            int YPoint = Cursor.Position.Y;
            int r, g, b;
            r = RowPic.GetPixel(XPoint, YPoint).R;
            g = RowPic.GetPixel(XPoint, YPoint).G;
            b = RowPic.GetPixel(XPoint, YPoint).B;
            richTextBox2.Text = "RED: " + r + " - GREEN: " + g + " - BLUE: " + b;
        }
    }
}
