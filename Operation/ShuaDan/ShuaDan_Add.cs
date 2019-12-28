using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.ShuaDan
{
    public partial class ShuaDan_Add : Form
    {
        public ShuaDan_Add()
        {
            InitializeComponent();
            txt_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_address.Clear();
            txt_date.Clear();
            txt_goodsname.Clear();
            txt_orderid.Clear();
            txt_phone2.Clear();
            txt_vpnadd.Clear();
            txt_wuliu.Clear();
            txt_url.Clear();
            cb_fahuo2.Text = "未发货";
            cb_kongbao2.Text = "未获取";
            cb_shoptype.Text = "蘑菇街";
            cb_shoucai2.Text = "未收菜";
            txt_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string address = txt_address.Text;
            string dates = txt_date.Text.Trim();
            string goodsname = txt_goodsname.Text.Trim();
            string orderid = txt_orderid.Text.Trim();
            string phone = txt_phone2.Text.Trim();
            string vpnadd = txt_vpnadd.Text.Trim();
            string wuliu = txt_wuliu.Text.Trim();
            string shoptype = cb_shoptype.Text;
            string kongbao = cb_kongbao2.Text;
            string fahuo = cb_fahuo2.Text;
            string shoucai = cb_shoucai2.Text;
            string url = txt_url.Text.Trim();
            string remark = txt_remark.Text.Trim();
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(dates, out dt))
            {
                MessageBox.Show("请输入正确的时间");
                txt_date.Focus();
                return;
            }

            if (shoptype == "蘑菇街")
            {
                shoptype = "1";
            }
            else
            {
                shoptype = "2";
            }
            if (kongbao == "未获取")
            {
                kongbao = "1";
            }
            else
            {
                kongbao = "2";
            }
            if (fahuo == "未发货")
            {
                fahuo = "1";
            }
            else
            {
                fahuo = "2";
            }
            if (shoucai == "未收菜")
            {
                shoucai = "1";
            }
            else if (shoucai == "已收菜")
            {
                shoucai = "2";
            }
            else
            {
                shoucai = "3";
            }




            Entity.shuadan_records sd = new Entity.shuadan_records();
            sd.sdaddress = address;
            sd.sddate = dt;
            sd.sddptype = shoptype;
            sd.sdgoodsname = goodsname;
            sd.sdgoodsurl = url;
            sd.sdorderid = orderid;
            sd.sdphone = phone;
            sd.sdvpn = vpnadd;
            sd.sdwuliu = wuliu;
            sd.sdremark3 = kongbao;
            sd.sdremark4 = fahuo;
            sd.sdremark2 = shoucai;
            sd.sdremark5 = remark;



            if (BLL2.shuadan_recordsManager.Insert(sd) == 1)
            {
                MessageBox.Show("保存成功");
            }


        }

        private void txt_remark_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
