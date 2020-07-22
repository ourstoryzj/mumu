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
using System.Xml;
using System.Xml.Linq;

namespace Operation
{
    public partial class Profit : Form
    {

        string xmlurl = Application.StartupPath + "\\profit.xml";
        Common.XMLHelpers xml = new XMLHelpers("profit");
        List<GoodsProfit> list = null;

        public Profit()
        {

            InitializeComponent();

            bind();
        }



        #region bind
        void bind()
        {
            list = new List<GoodsProfit>();

            //获取xml文件中的商品利润表
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlurl);
            XmlElement xmlele = xmldoc.DocumentElement;//获取根节点
            XmlNodeList nodelist = xmlele.GetElementsByTagName("Add"); //获取Data子节点

            foreach (var item in nodelist)
            {
                XmlElement ele = (XmlElement)item;
                string name = ele.GetAttribute("name");
                if (!string.IsNullOrEmpty(name.Trim()))
                {

                    GoodsProfit gp = new GoodsProfit();
                    gp.Name = name;
                    gp.Price = ele.GetAttribute("value").ToDecimal();
                    list.Add(gp);
                }
            }

            dataGridView1.DataSource = list.ToDataTable();


            dataGridView2.DataSource = BLL2.PorfitManager.Search(1, 1000, "", new DateTime(), new DateTime(), " pdate desc ").ToDataTable();

            #region bak
            //XElement element = XElement.Load(xmlurl);
            //foreach (var item in element.DescendantsAndSelf())
            //{
            //    foreach (var attr in item.Attributes())
            //    {


            //        Debug.WriteLine("名称：{0}；值：{1}", attr.Name, attr.Value);
            //    }
            //} 
            #endregion

        } 
        #endregion


        #region dataGridView1_CellContentClick
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv1 = (DataGridView)sender;
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    //GoodsProfit gp = (GoodsProfit)dataGridView1.CurrentRow.DataBoundItem;
                    txt_price.Text = dgv1.CurrentRow.Cells[1].Value.ToString(); 
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion



        #region btn_add_Click
        private void btn_add_Click(object sender, EventArgs e)
        {
            string price_temp = txt_price.Text;
            string num_temp = txt_num.Text;
            double price;
            int num = 0;
            if (!double.TryParse(price_temp, out price))
            {
                "请输入正确的价格".ToShow();
                return;
            }
            if (!int.TryParse(num_temp, out num))
            {
                "请输入正确的数量".ToShow();
                return;
            }

            price = price * num;


            Porfit pf = null;
            DateTime dt1 = Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd"));
            IList<Porfit> lists  = BLL2.PorfitManager.Search(1, 1000, "", dt1, dt1, "");
            if (lists.Count > 0)
            {
                pf = lists[0];
            }
            else
            {
                pf = new Porfit();
            }

            pf.pdate = dt1;
            pf.pprice += price;

            if (lists.Count > 0)
            {
                BLL2.PorfitManager.Update(pf);
            }
            else
            {
                BLL2.PorfitManager.Insert(pf);
            }

            bind();

        }

        #endregion


        #region dataGridView2_CellFormatting
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }
        #endregion


        #region dataGridView2_CellParsing

        private void dataGridView2_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv1 = (DataGridView)sender;
            if (e.Value != null)
            {
                if (dgv1.DataSource != null)
                {
                    if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_num"))
                    {
                        string name = e.Value.ToString();
                        //Porfit pf = (Porfit)dgv1.CurrentRow.DataBoundItem;
                        Porfit pf = BLL2.PorfitManager.SearchByID(dgv1.CurrentRow.Cells[0].Value.ToString().ToInt());
                        pf.pbeiyong = name;
                        BLL2.PorfitManager.Update(pf);
                    }
                }
            }
        } 
        #endregion
    }



    #region GoodsProfit
    class GoodsProfit
    {
        string name;
        decimal price;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
    #endregion


}
