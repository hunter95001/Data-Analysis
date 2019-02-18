using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalysis
{

    public partial class Form1 : Form
    {
        const int imagenum = 1;

        Bitmap bitmap1;
        Bitmap bitmap2;
        Bitmap bitmap3;

        String imagePath1 = "C:\\Users\\KYJ\\Desktop\\Git Hub\\Som Cluster\\som cluster\\som cluster\\Image\\의사사진\\" + imagenum + "doctor.jpg";
        String imagePath2 = "C:\\Users\\KYJ\\Desktop\\Git Hub\\Som Cluster\\som cluster\\som cluster\\Image\\어깨사진\\" + imagenum + "origin.jpg";
        string savefilename = "C:\\Users\\KYJ\\Desktop\\룩업\\" + imagenum + ".jpg";

        
        public Form1()
        {
            //Part #1 초기화 부분 
            InitializeComponent();
            Init();

            DataProcessing();

            pictureBox1.Image = bitmap1;
            pictureBox2.Image = bitmap2;
            pictureBox3.Image = bitmap3;
            chart1lookup(bitmap2);
        }
        public void Init() {
             bitmap1 = new Bitmap(imagePath1);
             bitmap2 = new Bitmap(imagePath2);
             bitmap3 = new Bitmap(bitmap1.Width, bitmap1.Height);
        }

        public void DataProcessing()
        {
            
            for (int x = 0; x < bitmap1.Width; x++)
                for (int y = 0; y < bitmap1.Height; y++)
                {
                    bitmap3.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }

            for (int x = 0; x < bitmap1.Width; x++)
                for (int y = 0; y < bitmap1.Height; y++)
                {
                    int R = bitmap1.GetPixel(x, y).R;
                    int G = bitmap1.GetPixel(x, y).G;
                    int B = bitmap1.GetPixel(x, y).B;
                    int R1 = bitmap2.GetPixel(x, y).R;
                    int G1 = bitmap2.GetPixel(x, y).G;
                    int B1 = bitmap2.GetPixel(x, y).B;
                    if (R > G + B && R1 < 240)
                    {
                        bitmap3.SetPixel(x, y, Color.FromArgb(R1, 0, 0));
                    }
                }
        }
        
        public void chart1lookup(Bitmap origanlBitmap)
        {
            int[] array = new int[256];
            for (int x = 0; x < origanlBitmap.Width; x++)
                for (int y = 0; y < origanlBitmap.Height; y++)
                {
                    int color = origanlBitmap.GetPixel(x, y).R;
                    array[color]++;

                }


            chart1.Titles.Add("Lookup Table");
            chart1.Series.Add("Color");
            for (int i = 0; i < 255; i++)
                chart1.Series["Color"].Points.AddXY(i.ToString(), array[i]);
        }

        public void chart2lookup(Bitmap origanlBitmap)
        {
            int[] array = new int[256];
            for (int x = 0; x < origanlBitmap.Width; x++)
                for (int y = 0; y < origanlBitmap.Height; y++)
                {
                    int color = origanlBitmap.GetPixel(x, y).R;
                    array[color]++;

                }


            chart2.Titles.Add("Lookup Table");
            chart2.Series.Add("Color");
            for (int i = 0; i < 255; i++)
                chart2.Series["Color"].Points.AddXY(i.ToString(), array[i]);
        }

        private void 캡처ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(this.Left, this.Top, 0, 0, this.Size);
            bitmap.Save(savefilename);
        }

    }
}
