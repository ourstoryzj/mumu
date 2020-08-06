using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.Other;
using Operation.CS;
using System.IO;
using System.Diagnostics;
using Common;

namespace Operation
{
    public partial class PDD_PrintLabel : Form
    {



        public PDD_PrintLabel()
        {
          
            InitializeComponent();
            bind();
            this.ActiveControl = textBox4;
            

        }

        void bind()
        {
            
            try
            {
                int fontsize = textBox1.Text.ToInt();
                int x = textBox2.Text.ToInt();
                int y = textBox3.Text.ToInt();



                Image image = Image.FromFile("合格证.jpg");


                Font font = new Font("微软雅黑", fontsize);
                System.Drawing.Brush brush = new SolidBrush(Color.Black);


                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                System.Drawing.Graphics graphics = Graphics.FromImage(bitmap);


                graphics.DrawImage(image, 0, 0);

                graphics.DrawString(DateTime.Now.ToString("yyyy年MM月dd日"), font, brush, new Point(x, y));

                panel1.BackgroundImage = bitmap;
                panel1.Width = 373;
                panel1.Height = 650;
            }
            catch (Exception ex)
            {
                ex.ToShow();
            }
        }

        private void PrintPreview()
        {

            //设置页面的预览的页码
            //设置显示页面显示的大小(也就是原页面的倍数)
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
             printPreviewDialog1.PrintPreviewControl.StartPage = 0;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            //设置或返回窗口状态，即该窗口是最小化、正常大小还是其他状态。
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            //设置和获取需要预览的文档
            //将窗体显示为指定者的模式对话框
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog1.Document = printDocument;
            printPreviewDialog1.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //打印
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            //设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 40, 70);
            printDocument.PrintPage += PrintDocument_PrintPage;

           

            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;
            printDialog.Document = printDocument;
            printDialog.PrinterSettings.Copies = (short)textBox4.Text.ToInt();
            //printDialog


            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }


            #region bak
            //Font titleFont = new Font("黑体", 11, FontStyle.Bold);
            //Font font = new Font("黑体", 10, FontStyle.Bold);
            //Font font1 = new Font("黑体", 8, FontStyle.Bold);
            //System.Drawing.Brush brush = new SolidBrush(Color.Black);
            //System.Drawing.Pen pen = new Pen(Color.Black);


            //System.Drawing.Bitmap image = new System.Drawing.Bitmap(400, 700);
            //System.Drawing.Graphics g = Graphics.FromImage(image);

            //try
            //{
            //    g.DrawString("合格证", titleFont, brush, new Point(20, 10));
            //    Point[] points = { new Point(20, 28), new Point(230, 28) };
            //    g.DrawLines(pen, points);

            //    g.DrawString("生产日期", font, brush, new Point(20, 40));
            //    g.DrawString("生产日期2", font, brush, new Point(20, 60));

            //    panel1.BackgroundImage = image;
            //}
            //catch (Exception ex)
            //{
            //    ex.ToShow();
            //}
            //finally
            //{
            //    //g.Dispose();
            //    //image.Dispose();
            //} 
            #endregion

        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //图片抗锯齿
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Stream fs = new FileStream(fileList[printNum].ToString().Trim(), FileMode.Open, FileAccess.Read);
            //System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            System.Drawing.Image image = panel1.BackgroundImage;
            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;
            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            float temp_width = 150;
            float temp_height = image.Height / (image.Width / temp_width);
            e.Graphics.DrawImage(image, 120, 0, temp_width, temp_height);
            //e.Graphics.DrawImage(image, 105, 0, 180,280);
            /*
            //DrawImage参数根据打印机和图片大小自行调整
            //System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            //System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(0, 0, width, height);
            if (image.Height < 310)
            {
                e.Graphics.DrawImage(image, 0, 30, image.Width + 20, image.Height);
                //    System.Drawing.Rectangle destRect1 = new System.Drawing.Rectangle(0, 30, image.Width, image.Height);
                //    e.Graphics.DrawImage(image, destRect1, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.DrawImage(image, 0, 0, image.Width + 20, image.Height);
                //    System.Drawing.Rectangle destRect2 = new System.Drawing.Rectangle(0, 0, image.Width, image.Height);
                //    e.Graphics.DrawImage(image, destRect2, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
            }

            //if (printNum < fileList.Count - 1)
            //{
            //    printNum++;
            //    e.HasMorePages = true;//HasMorePages为true则再次运行PrintPage事件
            //    return;
            //}
            */
            e.HasMorePages = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            bind();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintPreview();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button1.PerformClick();
            }
        }

        private void PDD_PrintLabel_Load(object sender, EventArgs e)
        {
            textBox4.Focus();
            textBox4.SelectAll();
        }
    }


}
