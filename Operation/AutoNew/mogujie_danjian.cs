using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using System.Diagnostics;
using CefSharp.WinForms;
using Operation.CS;
using Common;

namespace Operation
{
    public partial class mogujie_danjian : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public mogujie_danjian()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                webBrowser1 = new ChromiumWebBrowser("http://www.xiaodian.com/goods/publish/add?cid=118u");
                webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;

                webBrowser1.Size = new Size(1301, 253);
                webBrowser1.Location = new Point(12, 527);
                webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                this.Controls.Add(webBrowser1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            //login_m_danjian();
            bing_m_danjianbao();
            bind_at();
        }


        #region login
        void login_m_danjian()
        {
            webBrowser1.Load("http://www.xiaodian.com/goods/publish/add?cid=118u");
            Mogujie.login(webBrowser1);
        }



        void login_m_shuangjian()
        {
            webBrowser1.Load("http://www.xiaodian.com/goods/publish/add?cid=118s");
            Mogujie.login(webBrowser1);
        }
        #endregion

        #region tabControl1_SelectedIndexChanged
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    //login_m_danjian();
                    //bing_m_danjianbao();
                    break;
                case 1:
                    //Main child = new Main();
                    //child.TopLevel = false;
                    //child.Dock = System.Windows.Forms.DockStyle.Fill;
                    //child.FormBorderStyle = FormBorderStyle.None;
                    //TabPage tp = sender as TabPage;
                    //tp.Controls.Add(child);
                    //child.Show();
                    break;
            }
        }
        #endregion

        #region 上新

        #region save
        private void save()
        {
            //Point temp_p = Browser.GetPointBrowserByHtmlElement(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1')[0]", webBrowser1);
            //MessageBox.Show(temp_p.ToString());
            try
            {
                autonew_model am = am = new autonew_model();


                string title = txt_title.Text.Trim();
                string jianshu = txt_jianshu.Text.Trim();
                string bianma = txt_bianma.Text.Trim();
                string color = "";
                string size = "";
                string jiaceng = "";
                string yingdu = "";
                string jiage = txt_jiage.Text.Trim();
                int temp_jiage = 0;
                string kucun = txt_kucun.Text.Trim();
                string daxiao = "";
                string tilin = "";
                string waidai = "";
                string chicunshuoming = txt_chicun.Text.Trim();
                string dianpuxinxi = txt_dianpuxinxi.Text.Trim();
                string zhucaizhi = "";
                string waixing = "";
                string liuxing = "";

                if (cb_color_hei.Checked)
                {
                    color += "hei|";
                }
                if (cb_color_hui.Checked)
                {
                    color += "hui|";
                }
                if (cb_color_bai.Checked)
                {
                    color += "bai|";
                }
                if (cb_color_zong.Checked)
                {
                    color += "zong|";
                }
                if (cb_color_huang.Checked)
                {
                    color += "huang|";
                }
                if (cb_color_lan.Checked)
                {
                    color += "lan|";
                }
                if (cb_color_hong.Checked)
                {
                    color += "hong|";
                }
                if (cb_color_zi.Checked)
                {
                    color += "zi|";
                }
                if (cb_color_lv.Checked)
                {
                    color += "lv|";
                }
                if (cb_color_hua.Checked)
                {
                    color += "hua|";
                }
                if (cb_color_touming.Checked)
                {
                    color += "touming|";
                }
                if (cb_color_kaqi.Checked)
                {
                    color += "kaqi|";
                }



                if (cb_size_mini.Checked)
                {
                    size += "mini|";
                }
                if (cb_size_xiao.Checked)
                {
                    size += "xiao|";
                }
                if (cb_size_zhong.Checked)
                {
                    size += "zhong|";
                }
                if (cb_size_da.Checked)
                {
                    size += "da|";
                }



                if (rb_jiaceng_you.Checked)
                {
                    jiaceng = "you";
                }
                else if (rb_jiaceng_wu.Checked)
                {
                    jiaceng = "wu";
                }



                if (rb_yingdu_ruan.Checked)
                {
                    yingdu = "ruan";
                }
                else if (rb_yingdu_ying.Checked)
                {
                    yingdu = "ying";
                }



                if (int.TryParse(jiage, out temp_jiage))
                {
                    jiage = (Math.Ceiling(temp_jiage * 100 / 0.7) / 100).ToString();
                }



                if (rb_size_mini.Checked)
                {
                    daxiao = "mini";
                }
                else if (rb_size_xiao.Checked)
                {
                    daxiao = "xiao";
                }
                else if (rb_size_zhong.Checked)
                {
                    daxiao = "zhong";
                }
                else if (rb_size_da.Checked)
                {
                    daxiao = "da";
                }



                //提拎
                if (rb_tilin_zhuangxie.Checked)
                {
                    tilin = "zhuangxie";
                }
                else if (rb_tilin_shensuo.Checked)
                {
                    tilin = "shensuo";
                }
                else if (rb_tilin_ruanba.Checked)
                {
                    tilin = "ruanba";
                }
                else if (rb_tilin_yingba.Checked)
                {
                    tilin = "yingba";
                }
                else if (rb_tilin_suolian.Checked)
                {
                    tilin = "suolian";
                }



                //waidai外袋
                if (rb_waidai_wadai.Checked)
                {
                    waidai = "wadai";
                }
                else if (rb_waidai_neitie.Checked)
                {
                    waidai = "neitie";
                }
                else if (rb_waidai_changkou.Checked)
                {
                    waidai = "changkou";
                }
                else if (rb_waidai_daigai.Checked)
                {
                    waidai = "daigai";
                }
                else if (rb_waidai_liti.Checked)
                {
                    waidai = "liti";
                }



                //zhucaizhi主材质
                if (rb_caizhi_pu.Checked)
                {
                    zhucaizhi = "pu";
                }
                else if (rb_caizhi_niupi.Checked)
                {
                    zhucaizhi = "niupi";
                }
                else if (rb_caizhi_niujinbu.Checked)
                {
                    zhucaizhi = "niujin";
                }
                else if (rb_caizhi_yangpi.Checked)
                {
                    zhucaizhi = "yangpi";
                }
                else if (rb_caizhi_tumao.Checked)
                {
                    zhucaizhi = "tumao";
                }
                else if (rb_caizhi_jinlun.Checked)
                {
                    zhucaizhi = "jinlun";
                }
                else if (rb_caizhi_fanbu.Checked)
                {
                    zhucaizhi = "fanbu";
                }
                else if (rb_caizhi_shepi.Checked)
                {
                    zhucaizhi = "shepi";
                }
                else if (rb_caizhi_nizi.Checked)
                {
                    zhucaizhi = "nizi";
                }
                else if (rb_caizhi_zhi.Checked)
                {
                    zhucaizhi = "zhizhi";
                }
                else if (rb_caizhi_juzhixianwei.Checked)
                {
                    zhucaizhi = "juzhi";
                }
                else if (rb_caizhi_eyu.Checked)
                {
                    zhucaizhi = "eyu";
                }
                else if (rb_caizhi_zhupi.Checked)
                {
                    zhucaizhi = "zhupi";
                }
                else if (rb_caizhi_fanmaopi.Checked)
                {
                    zhucaizhi = "fanmao";
                }
                else if (rb_caizhi_wangmian.Checked)
                {
                    zhucaizhi = "wangmian";
                }
                else if (rb_caizhi_wufangbu.Checked)
                {
                    zhucaizhi = "wufang";
                }
                else if (rb_caizhi_pvc.Checked)
                {
                    zhucaizhi = "pvc";
                }
                else if (rb_caizhi_mabu.Checked)
                {
                    zhucaizhi = "mabu";
                }
                else if (rb_caizhi_sirong.Checked)
                {
                    zhucaizhi = "sirong";
                }
                else if (rb_caizhi_sichou.Checked)
                {
                    zhucaizhi = "sichou";
                }
                else if (rb_caizhi_caolei.Checked)
                {
                    zhucaizhi = "caolei";
                }
                else if (rb_caizhi_guijiao.Checked)
                {
                    zhucaizhi = "guijiao";
                }
                else if (rb_caizhi_toucengniupi.Checked)
                {
                    zhucaizhi = "touceng";
                }
                else if (rb_caizhi_ercengniupi.Checked)
                {
                    zhucaizhi = "erceng";
                }
                else if (rb_caizhi_huaxuexianwei.Checked)
                {
                    zhucaizhi = "huaxue";
                }
                else if (rb_caizhi_picao.Checked)
                {
                    zhucaizhi = "picao";
                }
                else if (rb_caizhi_tianerong.Checked)
                {
                    zhucaizhi = "tiane";
                }
                else if (rb_caizhi_qita.Checked)
                {
                    zhucaizhi = "qita";
                }


                //外形
                if (rb_waixing_hengkuan.Checked)
                {
                    waixing = "hengkuan";
                }
                else if (rb_waixing_shukuan.Checked)
                {
                    waixing = "shukuan";
                }
                else if (rb_waixing_beike.Checked)
                {
                    waixing = "beike";
                }
                else if (rb_waixing_shuitong.Checked)
                {
                    waixing = "shuitong";
                }
                else if (rb_waixing_shuijiao.Checked)
                {
                    waixing = "shuijiao";
                }
                else if (rb_waixing_chibang.Checked)
                {
                    waixing = "chibang";
                }
                else if (rb_waixing_yuanhe.Checked)
                {
                    waixing = "yuanhe";
                }
                else if (rb_waixing_fanghe.Checked)
                {
                    waixing = "fanghe";
                }
                else if (rb_waixing_xiangxing.Checked)
                {
                    waixing = "xiangxing";
                }
                else if (rb_waixing_youchai.Checked)
                {
                    waixing = "youchai";
                }
                else if (rb_waixing_xinfeng.Checked)
                {
                    waixing = "xinfeng";
                }
                else if (rb_waixing_dongwu.Checked)
                {
                    waixing = "dongwu";
                }
                else if (rb_waixing_cailan.Checked)
                {
                    waixing = "cailan";
                }
                else if (rb_waixing_zhentou.Checked)
                {
                    waixing = "zhentou";
                }
                else if (rb_waixing_xiangti.Checked)
                {
                    waixing = "xiangti";
                }
                else if (rb_waixing_fengqin.Checked)
                {
                    waixing = "fengqin";
                }
                else if (rb_waixing_lasheng.Checked)
                {
                    waixing = "lasheng";
                }
                else if (rb_waixing_fangxingjianbao.Checked)
                {
                    waixing = "fangxing";
                }
                else if (rb_waixing_baolingqiu.Checked)
                {
                    waixing = "baoling";
                }
                else if (rb_waixing_hezi.Checked)
                {
                    waixing = "hezi";
                }
                else if (rb_waixing_xiaofangbao.Checked)
                {
                    waixing = "xiaofang";
                }
                else if (rb_waixing_xiaoyuanbao.Checked)
                {
                    waixing = "xiaoyuan";
                }
                else if (rb_waixing_egao.Checked)
                {
                    waixing = "egao";
                }
                else if (rb_waixing_yuanhuan.Checked)
                {
                    waixing = "yuanhuan";
                }
                else if (rb_waixing_mini.Checked)
                {
                    waixing = "mini";
                }
                else if (rb_waixing_maan.Checked)
                {
                    waixing = "maan";
                }
                else if (rb_waixing_mingxing.Checked)
                {
                    waixing = "mingxing";
                }
                else if (rb_waixing_maanbao.Checked)
                {
                    waixing = "maanbao";
                }
                else if (rb_waixing_jiche.Checked)
                {
                    waixing = "jiche";
                }
                else if (rb_waixing_pinjie.Checked)
                {
                    waixing = "pinjie";
                }
                else if (rb_waixing_sanjiao.Checked)
                {
                    waixing = "sanjiao";
                }
                else if (rb_waixing_xiaomao.Checked)
                {
                    waixing = "xiaomao";
                }
                else if (rb_waixing_cuican.Checked)
                {
                    waixing = "cuican";
                }
                else if (rb_waixing_panduola.Checked)
                {
                    waixing = "panduo";
                }
                else if (rb_waixing_zhezhou.Checked)
                {
                    waixing = "zhezhou";
                }
                else if (rb_waixing_doudou.Checked)
                {
                    waixing = "doudou";
                }
                else if (rb_waixing_qita.Checked)
                {
                    waixing = "qita";
                }


                //liuxing流行
                if (cb_liuxing_zhuangse.Checked)
                {
                    liuxing += "zhuangse|";
                }
                if (cb_liuxing_huaduo.Checked)
                {
                    liuxing += "huaduo|";
                }
                if (cb_liuxing_baowen.Checked)
                {
                    liuxing += "baowen|";
                }
                if (cb_liuxing_liantiao.Checked)
                {
                    liuxing += "liantiao|";
                }
                if (cb_liuxing_loukong.Checked)
                {
                    liuxing += "loukong|";
                }
                if (cb_liuxing_hudiejie.Checked)
                {
                    liuxing += "hudie|";
                }
                if (cb_liuxing_liangpian.Checked)
                {
                    liuxing += "liangpian|";
                }
                if (cb_liuxing_leisi.Checked)
                {
                    liuxing += "leisi|";
                }
                if (cb_liuxing_zhezhou.Checked)
                {
                    liuxing += "zhezhou|";
                }
                if (cb_liuxing_chuanzhu.Checked)
                {
                    liuxing += "chuanzhu|";
                }
                if (cb_liuxing_maoding.Checked)
                {
                    liuxing += "maoding|";
                }
                if (cb_liuxing_suokou.Checked)
                {
                    liuxing += "suokou|";
                }
                if (cb_liuxing_liusu.Checked)
                {
                    liuxing += "liusu|";
                }
                if (cb_liuxing_zimu.Checked)
                {
                    liuxing += "zimu|";
                }
                if (cb_liuxing_xiuhua.Checked)
                {
                    liuxing += "xiuhua|";
                }
                if (cb_liuxing_gewen.Checked)
                {
                    liuxing += "gewen|";
                }
                if (cb_liuxing_yahua.Checked)
                {
                    liuxing += "yahua|";
                }
                if (cb_liuxing_zhihua.Checked)
                {
                    liuxing += "zhihua|";
                }
                if (cb_liuxing_bianzhi.Checked)
                {
                    liuxing += "bianzhi|";
                }
                if (cb_liuxing_pinjie.Checked)
                {
                    liuxing += "pinjie|";
                }
                if (cb_liuxing_daizuan.Checked)
                {
                    liuxing += "daizuan|";
                }
                if (cb_liuxing_lingge.Checked)
                {
                    liuxing += "lingge|";
                }
                if (cb_liuxing_eyuwen.Checked)
                {
                    liuxing += "eyu|";
                }
                if (cb_liuxing_tangguo.Checked)
                {
                    liuxing += "tangguo|";
                }
                if (cb_liuxing_jiche.Checked)
                {
                    liuxing += "jiche|";
                }
                if (cb_liuxing_youchai.Checked)
                {
                    liuxing += "youchai|";
                }
                if (cb_liuxing_xinfeng.Checked)
                {
                    liuxing += "xinfeng|";
                }
                if (cb_liuxing_yinhua.Checked)
                {
                    liuxing += "yinhua|";
                }
                if (cb_liuxing_touming.Checked)
                {
                    liuxing += "touming|";
                }
                if (cb_liuxing_yakeli.Checked)
                {
                    liuxing += "yake|";
                }

                string motexiaoguo = txt_mote.Text.Trim();
                string jingwuxiaoguo = txt_jingwu.Text.Trim();
                string xijiezuogong = txt_xijie.Text.Trim();
                string chanpin = txt_chanpinjieshao.Text.Trim();
                string pinpai = txt_pinpai.Text.Trim();
                string baozhuang = txt_baozhuang.Text.Trim();
                string fuwu = txt_fuwu.Text.Trim();
                string zizhi = txt_zizhi.Text.Trim();



                am.ambaozhuang = baozhuang;
                am.amcaizhi = zhucaizhi;
                am.amchanghe = cb_changhe.SelectedItem.ToString();
                am.amchanpin = txt_chanpinjieshao.Text.Trim();
                am.amchicun = chicunshuoming;
                am.amchushou = "";
                am.amcode = bianma;
                am.amcolor = color;
                am.amdakai = cb_kaidai.SelectedItem.ToString();
                am.amdaxiao = daxiao;
                am.amdianpu = dianpuxinxi;
                am.amfenlei = "";
                am.amfuwu = fuwu;
                am.amjiankucun = "";
                am.amjianshu = jianshu;
                am.amjiazeng = jiaceng;
                am.amjingwu = jingwuxiaoguo;
                am.amliliao = cb_liliao.SelectedItem.ToString();
                am.ammote = motexiaoguo;
                am.amname = txt_name.Text.Trim();
                am.amneibu = cb_neibu.SelectedItem.ToString();
                am.amnum = kucun;
                am.ampinpai = pinpai;
                am.amsize = size;
                am.amtilin = tilin;
                am.amtitle = title;
                am.amtuan = cb_tuan.SelectedItem.ToString();
                am.amtype = "1";
                am.amwaidai = waidai;
                am.amwaixing = waixing;
                am.amxijie = xijiezuogong;
                am.amyingdu = yingdu;
                am.amyuansu = liuxing;
                am.amzizhi = zizhi;


                int res = 0;

                res = BLL2.autonew_modelManager.Insert(am);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("保存上架商品失败：");
                Debug.WriteLine(ex.ToString());
            }

        }
        #endregion

        #region btn_muban_Click
        private void btn_muban_Click(object sender, EventArgs e)
        {
            //Point temp_p = Browser.GetPointBrowserByHtmlElement(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1')[0]", webBrowser1);
            //MessageBox.Show(temp_p.ToString());
            try
            {
                string name = txt_name.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请输入模板名称");
                    txt_name.Focus();
                    return;
                }

                autonew_model am = BLL2.autonew_modelManager.search("", "1");
                bool isnotnull = true;
                if (am == null)
                {
                    isnotnull = false;
                    am = new autonew_model();
                }


                string title = txt_title.Text.Trim();
                string jianshu = txt_jianshu.Text.Trim();
                string bianma = txt_bianma.Text.Trim();
                string color = "";
                string size = "";
                string jiaceng = "";
                string yingdu = "";
                string jiage = txt_jiage.Text.Trim();
                int temp_jiage = 0;
                string kucun = txt_kucun.Text.Trim();
                string daxiao = "";
                string tilin = "";
                string waidai = "";
                string chicunshuoming = txt_chicun.Text.Trim();
                string dianpuxinxi = txt_dianpuxinxi.Text.Trim();
                string zhucaizhi = "";
                string waixing = "";
                string liuxing = "";

                if (cb_color_hei.Checked)
                {
                    color += "hei|";
                }
                if (cb_color_hui.Checked)
                {
                    color += "hui|";
                }
                if (cb_color_bai.Checked)
                {
                    color += "bai|";
                }
                if (cb_color_zong.Checked)
                {
                    color += "zong|";
                }
                if (cb_color_huang.Checked)
                {
                    color += "huang|";
                }
                if (cb_color_lan.Checked)
                {
                    color += "lan|";
                }
                if (cb_color_hong.Checked)
                {
                    color += "hong|";
                }
                if (cb_color_zi.Checked)
                {
                    color += "zi|";
                }
                if (cb_color_lv.Checked)
                {
                    color += "lv|";
                }
                if (cb_color_hua.Checked)
                {
                    color += "hua|";
                }
                if (cb_color_touming.Checked)
                {
                    color += "touming|";
                }
                if (cb_color_kaqi.Checked)
                {
                    color += "kaqi|";
                }



                if (cb_size_mini.Checked)
                {
                    size += "mini|";
                }
                if (cb_size_xiao.Checked)
                {
                    size += "xiao|";
                }
                if (cb_size_zhong.Checked)
                {
                    size += "zhong|";
                }
                if (cb_size_da.Checked)
                {
                    size += "da|";
                }



                if (rb_jiaceng_you.Checked)
                {
                    jiaceng = "you";
                }
                else if (rb_jiaceng_wu.Checked)
                {
                    jiaceng = "wu";
                }



                if (rb_yingdu_ruan.Checked)
                {
                    yingdu = "ruan";
                }
                else if (rb_yingdu_ying.Checked)
                {
                    yingdu = "ying";
                }



                if (int.TryParse(jiage, out temp_jiage))
                {
                    jiage = (Math.Ceiling(temp_jiage * 100 / 0.7) / 100).ToString();
                }



                if (rb_size_mini.Checked)
                {
                    daxiao = "mini";
                }
                else if (rb_size_xiao.Checked)
                {
                    daxiao = "xiao";
                }
                else if (rb_size_zhong.Checked)
                {
                    daxiao = "zhong";
                }
                else if (rb_size_da.Checked)
                {
                    daxiao = "da";
                }



                //提拎
                if (rb_tilin_zhuangxie.Checked)
                {
                    tilin = "zhuangxie";
                }
                else if (rb_tilin_shensuo.Checked)
                {
                    tilin = "shensuo";
                }
                else if (rb_tilin_ruanba.Checked)
                {
                    tilin = "ruanba";
                }
                else if (rb_tilin_yingba.Checked)
                {
                    tilin = "yingba";
                }
                else if (rb_tilin_suolian.Checked)
                {
                    tilin = "suolian";
                }



                //waidai外袋
                if (rb_waidai_wadai.Checked)
                {
                    waidai = "wadai";
                }
                else if (rb_waidai_neitie.Checked)
                {
                    waidai = "neitie";
                }
                else if (rb_waidai_changkou.Checked)
                {
                    waidai = "changkou";
                }
                else if (rb_waidai_daigai.Checked)
                {
                    waidai = "daigai";
                }
                else if (rb_waidai_liti.Checked)
                {
                    waidai = "liti";
                }



                //zhucaizhi主材质
                if (rb_caizhi_pu.Checked)
                {
                    zhucaizhi = "pu";
                }
                else if (rb_caizhi_niupi.Checked)
                {
                    zhucaizhi = "niupi";
                }
                else if (rb_caizhi_niujinbu.Checked)
                {
                    zhucaizhi = "niujin";
                }
                else if (rb_caizhi_yangpi.Checked)
                {
                    zhucaizhi = "yangpi";
                }
                else if (rb_caizhi_tumao.Checked)
                {
                    zhucaizhi = "tumao";
                }
                else if (rb_caizhi_jinlun.Checked)
                {
                    zhucaizhi = "jinlun";
                }
                else if (rb_caizhi_fanbu.Checked)
                {
                    zhucaizhi = "fanbu";
                }
                else if (rb_caizhi_shepi.Checked)
                {
                    zhucaizhi = "shepi";
                }
                else if (rb_caizhi_nizi.Checked)
                {
                    zhucaizhi = "nizi";
                }
                else if (rb_caizhi_zhi.Checked)
                {
                    zhucaizhi = "zhizhi";
                }
                else if (rb_caizhi_juzhixianwei.Checked)
                {
                    zhucaizhi = "juzhi";
                }
                else if (rb_caizhi_eyu.Checked)
                {
                    zhucaizhi = "eyu";
                }
                else if (rb_caizhi_zhupi.Checked)
                {
                    zhucaizhi = "zhupi";
                }
                else if (rb_caizhi_fanmaopi.Checked)
                {
                    zhucaizhi = "fanmao";
                }
                else if (rb_caizhi_wangmian.Checked)
                {
                    zhucaizhi = "wangmian";
                }
                else if (rb_caizhi_wufangbu.Checked)
                {
                    zhucaizhi = "wufang";
                }
                else if (rb_caizhi_pvc.Checked)
                {
                    zhucaizhi = "pvc";
                }
                else if (rb_caizhi_mabu.Checked)
                {
                    zhucaizhi = "mabu";
                }
                else if (rb_caizhi_sirong.Checked)
                {
                    zhucaizhi = "sirong";
                }
                else if (rb_caizhi_sichou.Checked)
                {
                    zhucaizhi = "sichou";
                }
                else if (rb_caizhi_caolei.Checked)
                {
                    zhucaizhi = "caolei";
                }
                else if (rb_caizhi_guijiao.Checked)
                {
                    zhucaizhi = "guijiao";
                }
                else if (rb_caizhi_toucengniupi.Checked)
                {
                    zhucaizhi = "touceng";
                }
                else if (rb_caizhi_ercengniupi.Checked)
                {
                    zhucaizhi = "erceng";
                }
                else if (rb_caizhi_huaxuexianwei.Checked)
                {
                    zhucaizhi = "huaxue";
                }
                else if (rb_caizhi_picao.Checked)
                {
                    zhucaizhi = "picao";
                }
                else if (rb_caizhi_tianerong.Checked)
                {
                    zhucaizhi = "tiane";
                }
                else if (rb_caizhi_qita.Checked)
                {
                    zhucaizhi = "qita";
                }


                //外形
                if (rb_waixing_hengkuan.Checked)
                {
                    waixing = "hengkuan";
                }
                else if (rb_waixing_shukuan.Checked)
                {
                    waixing = "shukuan";
                }
                else if (rb_waixing_beike.Checked)
                {
                    waixing = "beike";
                }
                else if (rb_waixing_shuitong.Checked)
                {
                    waixing = "shuitong";
                }
                else if (rb_waixing_shuijiao.Checked)
                {
                    waixing = "shuijiao";
                }
                else if (rb_waixing_chibang.Checked)
                {
                    waixing = "chibang";
                }
                else if (rb_waixing_yuanhe.Checked)
                {
                    waixing = "yuanhe";
                }
                else if (rb_waixing_fanghe.Checked)
                {
                    waixing = "fanghe";
                }
                else if (rb_waixing_xiangxing.Checked)
                {
                    waixing = "xiangxing";
                }
                else if (rb_waixing_youchai.Checked)
                {
                    waixing = "youchai";
                }
                else if (rb_waixing_xinfeng.Checked)
                {
                    waixing = "xinfeng";
                }
                else if (rb_waixing_dongwu.Checked)
                {
                    waixing = "dongwu";
                }
                else if (rb_waixing_cailan.Checked)
                {
                    waixing = "cailan";
                }
                else if (rb_waixing_zhentou.Checked)
                {
                    waixing = "zhentou";
                }
                else if (rb_waixing_xiangti.Checked)
                {
                    waixing = "xiangti";
                }
                else if (rb_waixing_fengqin.Checked)
                {
                    waixing = "fengqin";
                }
                else if (rb_waixing_lasheng.Checked)
                {
                    waixing = "lasheng";
                }
                else if (rb_waixing_fangxingjianbao.Checked)
                {
                    waixing = "fangxing";
                }
                else if (rb_waixing_baolingqiu.Checked)
                {
                    waixing = "baoling";
                }
                else if (rb_waixing_hezi.Checked)
                {
                    waixing = "hezi";
                }
                else if (rb_waixing_xiaofangbao.Checked)
                {
                    waixing = "xiaofang";
                }
                else if (rb_waixing_xiaoyuanbao.Checked)
                {
                    waixing = "xiaoyuan";
                }
                else if (rb_waixing_egao.Checked)
                {
                    waixing = "egao";
                }
                else if (rb_waixing_yuanhuan.Checked)
                {
                    waixing = "yuanhuan";
                }
                else if (rb_waixing_mini.Checked)
                {
                    waixing = "mini";
                }
                else if (rb_waixing_maan.Checked)
                {
                    waixing = "maan";
                }
                else if (rb_waixing_mingxing.Checked)
                {
                    waixing = "mingxing";
                }
                else if (rb_waixing_maanbao.Checked)
                {
                    waixing = "maanbao";
                }
                else if (rb_waixing_jiche.Checked)
                {
                    waixing = "jiche";
                }
                else if (rb_waixing_pinjie.Checked)
                {
                    waixing = "pinjie";
                }
                else if (rb_waixing_sanjiao.Checked)
                {
                    waixing = "sanjiao";
                }
                else if (rb_waixing_xiaomao.Checked)
                {
                    waixing = "xiaomao";
                }
                else if (rb_waixing_cuican.Checked)
                {
                    waixing = "cuican";
                }
                else if (rb_waixing_panduola.Checked)
                {
                    waixing = "panduo";
                }
                else if (rb_waixing_zhezhou.Checked)
                {
                    waixing = "zhezhou";
                }
                else if (rb_waixing_doudou.Checked)
                {
                    waixing = "doudou";
                }
                else if (rb_waixing_qita.Checked)
                {
                    waixing = "qita";
                }


                //liuxing流行
                if (cb_liuxing_zhuangse.Checked)
                {
                    liuxing += "zhuangse|";
                }
                if (cb_liuxing_huaduo.Checked)
                {
                    liuxing += "huaduo|";
                }
                if (cb_liuxing_baowen.Checked)
                {
                    liuxing += "baowen|";
                }
                if (cb_liuxing_liantiao.Checked)
                {
                    liuxing += "liantiao|";
                }
                if (cb_liuxing_loukong.Checked)
                {
                    liuxing += "loukong|";
                }
                if (cb_liuxing_hudiejie.Checked)
                {
                    liuxing += "hudie|";
                }
                if (cb_liuxing_liangpian.Checked)
                {
                    liuxing += "liangpian|";
                }
                if (cb_liuxing_leisi.Checked)
                {
                    liuxing += "leisi|";
                }
                if (cb_liuxing_zhezhou.Checked)
                {
                    liuxing += "zhezhou|";
                }
                if (cb_liuxing_chuanzhu.Checked)
                {
                    liuxing += "chuanzhu|";
                }
                if (cb_liuxing_maoding.Checked)
                {
                    liuxing += "maoding|";
                }
                if (cb_liuxing_suokou.Checked)
                {
                    liuxing += "suokou|";
                }
                if (cb_liuxing_liusu.Checked)
                {
                    liuxing += "liusu|";
                }
                if (cb_liuxing_zimu.Checked)
                {
                    liuxing += "zimu|";
                }
                if (cb_liuxing_xiuhua.Checked)
                {
                    liuxing += "xiuhua|";
                }
                if (cb_liuxing_gewen.Checked)
                {
                    liuxing += "gewen|";
                }
                if (cb_liuxing_yahua.Checked)
                {
                    liuxing += "yahua|";
                }
                if (cb_liuxing_zhihua.Checked)
                {
                    liuxing += "zhihua|";
                }
                if (cb_liuxing_bianzhi.Checked)
                {
                    liuxing += "bianzhi|";
                }
                if (cb_liuxing_pinjie.Checked)
                {
                    liuxing += "pinjie|";
                }
                if (cb_liuxing_daizuan.Checked)
                {
                    liuxing += "daizuan|";
                }
                if (cb_liuxing_lingge.Checked)
                {
                    liuxing += "lingge|";
                }
                if (cb_liuxing_eyuwen.Checked)
                {
                    liuxing += "eyu|";
                }
                if (cb_liuxing_tangguo.Checked)
                {
                    liuxing += "tangguo|";
                }
                if (cb_liuxing_jiche.Checked)
                {
                    liuxing += "jiche|";
                }
                if (cb_liuxing_youchai.Checked)
                {
                    liuxing += "youchai|";
                }
                if (cb_liuxing_xinfeng.Checked)
                {
                    liuxing += "xinfeng|";
                }
                if (cb_liuxing_yinhua.Checked)
                {
                    liuxing += "yinhua|";
                }
                if (cb_liuxing_touming.Checked)
                {
                    liuxing += "touming|";
                }
                if (cb_liuxing_yakeli.Checked)
                {
                    liuxing += "yake|";
                }

                string motexiaoguo = txt_mote.Text.Trim();
                string jingwuxiaoguo = txt_jingwu.Text.Trim();
                string xijiezuogong = txt_xijie.Text.Trim();
                string chanpin = txt_chanpinjieshao.Text.Trim();
                string pinpai = txt_pinpai.Text.Trim();
                string baozhuang = txt_baozhuang.Text.Trim();
                string fuwu = txt_fuwu.Text.Trim();
                string zizhi = txt_zizhi.Text.Trim();

                //string title = txt_title.Text.Trim();
                //string jianshu = txt_jianshu.Text.Trim();
                //string bianma = txt_bianma.Text.Trim();
                //string color = "";
                //string size = "";
                //string jiaceng = "";
                //string yingdu = "";
                //string jiage = txt_jiage.Text.Trim();
                //int temp_jiage = 0;
                //string kucun = txt_kucun.Text.Trim();
                //string daxiao = "";
                //string tilin = "";
                //string waidai = "";
                //string chicunshuoming = txt_chicun.Text.Trim();
                //string dianpuxinxi = txt_dianpuxinxi.Text.Trim();
                //string zhucaizhi = "";
                //string waixing = "";
                //string liuxing = "";


                am.ambaozhuang = baozhuang;
                am.amcaizhi = zhucaizhi;
                am.amchanghe = cb_changhe.SelectedItem.ToString();
                am.amchanpin = txt_chanpinjieshao.Text.Trim();
                am.amchicun = chicunshuoming;
                am.amchushou = "";
                am.amcode = bianma;
                am.amcolor = color;
                am.amdakai = cb_kaidai.SelectedItem.ToString();
                am.amdaxiao = daxiao;
                am.amdianpu = dianpuxinxi;
                am.amfenlei = "";
                am.amfuwu = fuwu;
                am.amjiankucun = "";
                am.amjianshu = jianshu;
                am.amjiazeng = jiaceng;
                am.amjingwu = jingwuxiaoguo;
                am.amliliao = cb_liliao.SelectedItem.ToString();
                am.ammote = motexiaoguo;
                am.amname = txt_name.Text.Trim();
                am.amneibu = cb_neibu.SelectedItem.ToString();
                am.amnum = kucun;
                am.ampinpai = pinpai;
                am.amsize = size;
                am.amtilin = tilin;
                am.amtitle = title;
                am.amtuan = cb_tuan.SelectedItem.ToString();
                am.amtype = "1";
                am.amwaidai = waidai;
                am.amwaixing = waixing;
                am.amxijie = xijiezuogong;
                am.amyingdu = yingdu;
                am.amyuansu = liuxing;
                am.amzizhi = zizhi;


                int res = 0;
                if (isnotnull)
                {
                    res = BLL2.autonew_modelManager.Update(am);
                }
                else
                {
                    res = BLL2.autonew_modelManager.Insert(am);
                }

                if (res == 1)
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("保存模板失败：");
                Debug.WriteLine(ex.ToString());
            }

        }
        #endregion

        #region bind
        void bing_m_danjianbao()
        {
            try
            {
                autonew_model am = BLL2.autonew_modelManager.search("", "1");
                if (am == null)
                {
                    return;
                }

                txt_baozhuang.Text = am.ambaozhuang;
                txt_bianma.Text = am.amcode;
                txt_chanpinjieshao.Text = am.amchanpin;
                txt_chicun.Text = am.amchicun;
                txt_dianpuxinxi.Text = am.amdianpu;
                txt_fuwu.Text = am.amfuwu;
                txt_jianshu.Text = am.amjianshu;
                txt_jingwu.Text = am.amjingwu;
                txt_kucun.Text = am.amnum;
                txt_mote.Text = am.ammote;
                txt_name.Text = am.amname;
                txt_pinpai.Text = am.ampinpai;
                txt_title.Text = am.amtitle;
                txt_xijie.Text = am.amxijie;
                txt_zizhi.Text = am.amzizhi;



                //绑定颜色
                string temp_color = am.amcolor;
                if (!string.IsNullOrEmpty(temp_color))
                {
                    string[] temp_color2 = temp_color.Split(new char[1] { '|' });
                    foreach (string temp_c in temp_color2)
                    {
                        if (!string.IsNullOrEmpty(temp_c))
                        {
                            switch (temp_c)
                            {
                                case "hei":
                                    cb_color_hei.Checked = true;
                                    break;
                                case "hui":
                                    cb_color_hui.Checked = true;
                                    break;
                                case "bai":
                                    cb_color_bai.Checked = true;
                                    break;
                                case "zong":
                                    cb_color_zong.Checked = true;
                                    break;
                                case "huang":
                                    cb_color_huang.Checked = true;
                                    break;
                                case "lan":
                                    cb_color_lan.Checked = true;
                                    break;
                                case "hong":
                                    cb_color_hong.Checked = true;
                                    break;
                                case "zi":
                                    cb_color_zi.Checked = true;
                                    break;
                                case "lv":
                                    cb_color_lv.Checked = true;
                                    break;
                                case "hua":
                                    cb_color_hua.Checked = true;
                                    break;
                                case "touming":
                                    cb_color_touming.Checked = true;
                                    break;
                                case "kaqi":
                                    cb_color_kaqi.Checked = true;
                                    break;
                            }
                        }
                    }
                }

                //尺寸 size
                string temp_size = am.amsize;
                if (!string.IsNullOrEmpty(temp_size))
                {
                    string[] temp_size2 = temp_size.Split(new char[1] { '|' });
                    foreach (string temp_c in temp_size2)
                    {
                        if (!string.IsNullOrEmpty(temp_c))
                        {
                            switch (temp_c)
                            {
                                case "mini":
                                    cb_size_mini.Checked = true;
                                    break;
                                case "xiao":
                                    cb_size_xiao.Checked = true;
                                    break;
                                case "zhong":
                                    cb_size_zhong.Checked = true;
                                    break;
                                case "da":
                                    cb_size_da.Checked = true;
                                    break;
                            }
                        }
                    }
                }
                //夹层
                if (!string.IsNullOrEmpty(am.amjiazeng))
                {
                    if (am.amjiazeng == "you")
                        rb_jiaceng_you.Checked = true;
                    else if (am.amjiazeng == "wu")
                        rb_jiaceng_wu.Checked = true;
                }
                //硬度
                if (!string.IsNullOrEmpty(am.amyingdu))
                {
                    if (am.amyingdu == "ruan")
                        rb_yingdu_ruan.Checked = true;
                    else if (am.amyingdu == "ying")
                        rb_yingdu_ying.Checked = true;
                }
                //大小 chicun
                if (!string.IsNullOrEmpty(am.amdaxiao))
                {
                    if (am.amdaxiao == "mini")
                        rb_size_mini.Checked = true;
                    else if (am.amdaxiao == "xiao")
                        rb_size_xiao.Checked = true;
                    else if (am.amdaxiao == "zhong")
                        rb_size_zhong.Checked = true;
                    else if (am.amdaxiao == "da")
                        rb_size_da.Checked = true;
                }
                //提拎
                if (!string.IsNullOrEmpty(am.amtilin))
                {
                    if (am.amtilin == "zhuangxie")
                        rb_tilin_zhuangxie.Checked = true;
                    else if (am.amtilin == "shensuo")
                        rb_tilin_shensuo.Checked = true;
                    else if (am.amtilin == "ruanba")
                        rb_tilin_ruanba.Checked = true;
                    else if (am.amtilin == "yingba")
                        rb_tilin_yingba.Checked = true;
                    else if (am.amtilin == "suolian")
                        rb_tilin_suolian.Checked = true;
                }
                //外袋
                if (!string.IsNullOrEmpty(am.amwaidai))
                {
                    if (am.amwaidai == "wadai")
                        rb_waidai_wadai.Checked = true;
                    else if (am.amwaidai == "neitie")
                        rb_waidai_neitie.Checked = true;
                    else if (am.amwaidai == "changkou")
                        rb_waidai_changkou.Checked = true;
                    else if (am.amwaidai == "daigai")
                        rb_waidai_daigai.Checked = true;
                    else if (am.amwaidai == "liti")
                        rb_waidai_liti.Checked = true;
                }
                //内部结构
                if (!string.IsNullOrEmpty(am.amneibu))
                {
                    cb_neibu.SelectedItem = am.amneibu;
                }
                //场合
                if (!string.IsNullOrEmpty(am.amchanghe))
                {
                    cb_changhe.SelectedItem = am.amchanghe;
                }
                //里料
                if (!string.IsNullOrEmpty(am.amliliao))
                {
                    cb_liliao.SelectedItem = am.amliliao;
                }
                //开袋
                if (!string.IsNullOrEmpty(am.amdakai))
                {
                    cb_kaidai.SelectedItem = am.amdakai;
                }
                //图案
                if (!string.IsNullOrEmpty(am.amtuan))
                {
                    cb_tuan.SelectedItem = am.amtuan;
                }

                //主材质
                if (!string.IsNullOrEmpty(am.amcaizhi))
                {
                    if (am.amcaizhi == "pu")
                        rb_caizhi_pu.Checked = true;
                    else if (am.amcaizhi == "niupi")
                        rb_caizhi_niupi.Checked = true;
                    else if (am.amcaizhi == "niujin")
                        rb_caizhi_niujinbu.Checked = true;
                    else if (am.amcaizhi == "yangpi")
                        rb_caizhi_yangpi.Checked = true;
                    else if (am.amcaizhi == "tumao")
                        rb_caizhi_tumao.Checked = true;
                    else if (am.amcaizhi == "jinlun")
                        rb_caizhi_jinlun.Checked = true;
                    else if (am.amcaizhi == "fanbu")
                        rb_caizhi_fanbu.Checked = true;
                    else if (am.amcaizhi == "shepi")
                        rb_caizhi_shepi.Checked = true;
                    else if (am.amcaizhi == "nizi")
                        rb_caizhi_nizi.Checked = true;
                    else if (am.amcaizhi == "zhizhi")
                        rb_caizhi_zhi.Checked = true;
                    else if (am.amcaizhi == "juzhi")
                        rb_caizhi_juzhixianwei.Checked = true;
                    else if (am.amcaizhi == "eyu")
                        rb_caizhi_eyu.Checked = true;
                    else if (am.amcaizhi == "zhupi")
                        rb_caizhi_zhupi.Checked = true;
                    else if (am.amcaizhi == "fanmao")
                        rb_caizhi_fanmaopi.Checked = true;
                    else if (am.amcaizhi == "wangmian")
                        rb_caizhi_wangmian.Checked = true;
                    else if (am.amcaizhi == "wufang")
                        rb_caizhi_wufangbu.Checked = true;
                    else if (am.amcaizhi == "pvc")
                        rb_caizhi_pvc.Checked = true;
                    else if (am.amcaizhi == "mabu")
                        rb_caizhi_mabu.Checked = true;
                    else if (am.amcaizhi == "sirong")
                        rb_caizhi_sirong.Checked = true;
                    else if (am.amcaizhi == "sichou")
                        rb_caizhi_sichou.Checked = true;
                    else if (am.amcaizhi == "caolei")
                        rb_caizhi_caolei.Checked = true;
                    else if (am.amcaizhi == "guijiao")
                        rb_caizhi_guijiao.Checked = true;
                    else if (am.amcaizhi == "touceng")
                        rb_caizhi_toucengniupi.Checked = true;
                    else if (am.amcaizhi == "erceng")
                        rb_caizhi_ercengniupi.Checked = true;
                    else if (am.amcaizhi == "huaxue")
                        rb_caizhi_huaxuexianwei.Checked = true;
                    else if (am.amcaizhi == "picao")
                        rb_caizhi_picao.Checked = true;
                    else if (am.amcaizhi == "tiane")
                        rb_caizhi_tianerong.Checked = true;
                    else if (am.amcaizhi == "qita")
                        rb_caizhi_qita.Checked = true;
                }

                //外形
                if (!string.IsNullOrEmpty(am.amwaixing))
                {
                    if (am.amwaixing == "hengkuan")
                        rb_waixing_hengkuan.Checked = true;
                    else if (am.amwaixing == "shukuan")
                        rb_waixing_shukuan.Checked = true;
                    else if (am.amwaixing == "beike")
                        rb_waixing_beike.Checked = true;
                    else if (am.amwaixing == "shuitong")
                        rb_waixing_shuitong.Checked = true;
                    else if (am.amwaixing == "shuijiao")
                        rb_waixing_shuijiao.Checked = true;
                    else if (am.amwaixing == "chibang")
                        rb_waixing_chibang.Checked = true;
                    else if (am.amwaixing == "yuanhe")
                        rb_waixing_yuanhe.Checked = true;
                    else if (am.amwaixing == "fanghe")
                        rb_waixing_fanghe.Checked = true;
                    else if (am.amwaixing == "xiangxing")
                        rb_waixing_xiangxing.Checked = true;
                    else if (am.amwaixing == "youchai")
                        rb_waixing_youchai.Checked = true;
                    else if (am.amwaixing == "xinfeng")
                        rb_waixing_xinfeng.Checked = true;
                    else if (am.amwaixing == "dongwu")
                        rb_waixing_dongwu.Checked = true;
                    else if (am.amwaixing == "cailan")
                        rb_waixing_cailan.Checked = true;
                    else if (am.amwaixing == "zhentou")
                        rb_waixing_zhentou.Checked = true;
                    else if (am.amwaixing == "xiangti")
                        rb_waixing_xiangti.Checked = true;
                    else if (am.amwaixing == "fengqin")
                        rb_waixing_fengqin.Checked = true;
                    else if (am.amwaixing == "lasheng")
                        rb_waixing_lasheng.Checked = true;
                    else if (am.amwaixing == "fangxing")
                        rb_waixing_fangxingjianbao.Checked = true;
                    else if (am.amwaixing == "baoling")
                        rb_waixing_baolingqiu.Checked = true;
                    else if (am.amwaixing == "hezi")
                        rb_waixing_hezi.Checked = true;
                    else if (am.amwaixing == "xiaofang")
                        rb_waixing_xiaofangbao.Checked = true;
                    else if (am.amwaixing == "xiaoyuan")
                        rb_waixing_xiaoyuanbao.Checked = true;
                    else if (am.amwaixing == "egao")
                        rb_waixing_egao.Checked = true;
                    else if (am.amwaixing == "yuanhuan")
                        rb_waixing_yuanhuan.Checked = true;
                    else if (am.amwaixing == "mini")
                        rb_waixing_mini.Checked = true;
                    else if (am.amwaixing == "maan")
                        rb_waixing_maan.Checked = true;
                    else if (am.amwaixing == "mingxing")
                        rb_waixing_mingxing.Checked = true;
                    else if (am.amwaixing == "maanbao")
                        rb_waixing_maanbao.Checked = true;
                    else if (am.amwaixing == "jiche")
                        rb_waixing_jiche.Checked = true;
                    else if (am.amwaixing == "pinjie")
                        rb_waixing_pinjie.Checked = true;
                    else if (am.amwaixing == "sanjiao")
                        rb_waixing_sanjiao.Checked = true;
                    else if (am.amwaixing == "xiaomao")
                        rb_waixing_xiaomao.Checked = true;
                    else if (am.amwaixing == "cuican")
                        rb_waixing_cuican.Checked = true;
                    else if (am.amwaixing == "panduo")
                        rb_waixing_panduola.Checked = true;
                    else if (am.amwaixing == "zhezhou")
                        rb_waixing_zhezhou.Checked = true;
                    else if (am.amwaixing == "doudou")
                        rb_waixing_doudou.Checked = true;
                    else if (am.amwaixing == "qita")
                        rb_waixing_qita.Checked = true;
                }

                //流行元素
                if (!string.IsNullOrEmpty(am.amyuansu))
                {
                    string[] liuxing = am.amyuansu.Split(new char[1] { '|' });
                    foreach (string l in liuxing)
                    {
                        switch (l)
                        {
                            case "zhuangse":
                                cb_liuxing_zhuangse.Checked = true;
                                break;
                            case "huaduo":
                                cb_liuxing_huaduo.Checked = true;
                                break;
                            case "baowen":
                                cb_liuxing_baowen.Checked = true;
                                break;
                            case "liantiao":
                                cb_liuxing_liantiao.Checked = true;
                                break;
                            case "loukong":
                                cb_liuxing_loukong.Checked = true;
                                break;
                            case "hudie":
                                cb_liuxing_hudiejie.Checked = true;
                                break;
                            case "liangpian":
                                cb_liuxing_liangpian.Checked = true;
                                break;
                            case "leisi":
                                cb_liuxing_leisi.Checked = true;
                                break;
                            case "zhezhou":
                                cb_liuxing_zhezhou.Checked = true;
                                break;
                            case "chuanzhu":
                                cb_liuxing_chuanzhu.Checked = true;
                                break;
                            case "maoding":
                                cb_liuxing_maoding.Checked = true;
                                break;
                            case "suokou":
                                cb_liuxing_suokou.Checked = true;
                                break;
                            case "liusu":
                                cb_liuxing_liusu.Checked = true;
                                break;
                            case "zimu":
                                cb_liuxing_zimu.Checked = true;
                                break;
                            case "xiuhua":
                                cb_liuxing_xiuhua.Checked = true;
                                break;
                            case "gewen":
                                cb_liuxing_gewen.Checked = true;
                                break;
                            case "yahua":
                                cb_liuxing_yahua.Checked = true;
                                break;
                            case "zhihua":
                                cb_liuxing_zhihua.Checked = true;
                                break;
                            case "bianzhi":
                                cb_liuxing_bianzhi.Checked = true;
                                break;
                            case "pinjie":
                                cb_liuxing_pinjie.Checked = true;
                                break;
                            case "daizuan":
                                cb_liuxing_daizuan.Checked = true;
                                break;
                            case "lingge":
                                cb_liuxing_lingge.Checked = true;
                                break;
                            case "eyu":
                                cb_liuxing_eyuwen.Checked = true;
                                break;
                            case "tangguo":
                                cb_liuxing_tangguo.Checked = true;
                                break;
                            case "jiche":
                                cb_liuxing_jiche.Checked = true;
                                break;
                            case "youchai":
                                cb_liuxing_youchai.Checked = true;
                                break;
                            case "xinfeng":
                                cb_liuxing_xinfeng.Checked = true;
                                break;
                            case "yinhua":
                                cb_liuxing_yinhua.Checked = true;
                                break;
                            case "touming":
                                cb_liuxing_touming.Checked = true;
                                break;
                            case "yake":
                                cb_liuxing_yakeli.Checked = true;
                                break;
                        }
                    }
                }

                //绑定完毕





            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }



        #endregion

        #region btn_reset_Click
        private void btn_reset_Click(object sender, EventArgs e)
        {
            string res = txt_dianpuxinxi.Text.Trim();
            Browser.JS_CEFBrowser_NoReturn(res, webBrowser1);
            //return;

            Manager.Reset_Control(tabPage_mogujie_danjian.Controls);
            Manager.Reset_Control(groupBox1.Controls);
            Manager.Reset_Control(groupBox2.Controls);
            Manager.Reset_Control(groupBox3.Controls);
            Manager.Reset_Control(groupBox4.Controls);
            Manager.Reset_Control(groupBox5.Controls);
            bing_m_danjianbao();
            login_m_danjian();
        }






        #endregion

        #region btn_bind_Click
        private void btn_bind_Click(object sender, EventArgs e)
        {

            string p = txt_jiage.Text.Trim();
            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("请输入价格");
                txt_jiage.Focus();
            }

            //if (Browser.WaitWebPageLoad("getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1')[0]", webBrowser1))
            if (Browser.WaitWebPageLoad("getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1')[0]", webBrowser1))
            {

                //标题

                //.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1
                //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1')[0]", webBrowser1);
                //Browser.JS_CEFBrowser_NoReturn("alert(getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1')[0].innerText);", webBrowser1);

                //让鼠标进入webBrowser，同时关闭提示框
                Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$0.1.0.0.0')[0] ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" removeElement( document.getElementById('J_feedBack')) ", webBrowser1);
                lbl_state.Text = "进入蘑菇街系统";

                //标题
                lbl_state.Text = "正在处理标题属性";
                string title = txt_title.Text.Trim();
                //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$0.1.0.0')[0].value='" + title + "'; ", webBrowser1);
                Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$0.1.0.0')[0] ", webBrowser1);
                Auto.Clipboard_In(title);
                Auto.Clipboard_Out();
                lbl_state.Text = "标题属性处理完成";
                //Browser.Delay(1000);


                //简述
                lbl_state.Text = "正在处理简述属性";
                string jianshu = txt_jianshu.Text.Trim();
                //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$1.1.0.0')[0].value='" + jianshu + "'; ", webBrowser1);
                Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$1.1.0.0')[0] ", webBrowser1);
                Auto.Clipboard_In(jianshu);
                Auto.Clipboard_Out();
                lbl_state.Text = "简述属性处理完成";



                //编码
                lbl_state.Text = "正在处理编码属性";
                string bianma = txt_bianma.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$2.1.0.0')[0].value='" + bianma + "'; ", webBrowser1);
                lbl_state.Text = "编码属性处理完成";
                //string color = "";
                //string size = "";
                //string jiaceng = "";
                //string yingdu = "";


                //string daxiao = "";
                //string tilin = "";
                //string waidai = "";




                //Browser.Delay(500);
                //店铺
                lbl_state.Text = "正在处理店铺属性";
                string dianpuxinxi = txt_dianpuxinxi.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:9.2:$0.1.0.0.0')[0].value='" + dianpuxinxi + "'; ", webBrowser1);
                lbl_state.Text = "店铺说明属性处理完成";




                //string zhucaizhi = "";
                //string waixing = "";
                //string liuxing = "";

                //颜色
                lbl_state.Text = "正在处理颜色属性";
                if (cb_color_hei.Checked)
                {
                    //点击黑色系
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$5.1')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$0')[0].click(); ", webBrowser1);
                }
                if (cb_color_hui.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$9.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$0 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_bai.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$4.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$2.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_zong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$1.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$7.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_huang.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$0.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$8.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_lan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$3.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$3.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_hong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$7.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$6.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_zi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$8.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$4.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_lv.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$10.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$2.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_hua.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$6.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$0.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_touming.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$2.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$0.1 ')[0].click(); ", webBrowser1);
                }
                if (cb_color_kaqi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.1.$0.1 ')[0].click(); ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$0.0.1.0.3.2.$2.1 ')[0].click(); ", webBrowser1);
                }
                lbl_state.Text = "颜色属性处理完成";





                //尺寸
                lbl_state.Text = "正在处理尺寸属性";
                if (cb_size_mini.Checked)
                {
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$0.1  ')[0] ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$0.1 ')[0].click() ", webBrowser1);
                }
                if (cb_size_xiao.Checked)
                {
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$1.1 ')[0] ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$1.1 ')[0].click() ", webBrowser1);
                }
                if (cb_size_zhong.Checked)
                {
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$2.1 ')[0] ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$2.1 ')[0].click() ", webBrowser1);
                }
                if (cb_size_da.Checked)
                {
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$3.1 ')[0] ", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:0:$1.0.1.0.3.2.$3.1 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "尺寸属性处理完成";

                //先绑定颜色和尺寸===============================
                //价格
                lbl_state.Text = "正在处理价格属性";
                string jiage = txt_jiage.Text.Trim();
                int temp_jiage = 0;
                if (int.TryParse(jiage, out temp_jiage))
                {
                    jiage = (Math.Ceiling(temp_jiage * 100 / 0.7) / 100).ToString();
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:2.1.0.1:$0.0')[0] ", webBrowser1);
                    //Auto.Key_Write(jiage);
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:2.1.0.1:$0.0')[0] ", webBrowser1);
                    Auto.Clipboard_In(jiage);
                    Auto.Clipboard_Out();
                    //Browser.Delay(500);
                }
                lbl_state.Text = "价格属性处理完成";

                //库存
                lbl_state.Text = "正在处理库存属性";
                string kucun = txt_kucun.Text.Trim();
                //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:2.1.0.1:$1.0')[0] ", webBrowser1);
                //Auto.Key_Write(kucun);
                Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:2.1.0.1:$1.0')[0] ", webBrowser1);
                Auto.Clipboard_In(kucun);
                Auto.Clipboard_Out();
                //Browser.Delay(500);
                lbl_state.Text = "库存属性处理完成";
                //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:2.1.0.1:$1.0')[0].value='" + kucun + "'; ", webBrowser1);
                //确定价格库存按钮

                lbl_state.Text = "正在处理确定价格属性";
                Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$1.1.0.0.2:2.1.0.2')[0] ", webBrowser1);
                //**************************************************************************************************************************************************
                lbl_state.Text = "确定价格属性库存处理完成";



                //有无夹层
                lbl_state.Text = "正在处理夹层属性";
                if (rb_jiaceng_you.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$0.1.0.0.0.$0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_jiaceng_wu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$0.1.0.0.0.$1.1 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "夹层属性处理完成";


                //硬度
                lbl_state.Text = "正在处理硬度属性";
                if (rb_yingdu_ruan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$1.1.0.0.0.$0.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_yingdu_ying.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$1.1.0.0.0.$1.0.0 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "硬度属性处理完成";


                //if (int.TryParse(jiage, out temp_jiage))
                //{
                //    jiage = (Math.Ceiling(temp_jiage * 100 / 0.7) / 100).ToString();
                //}


                //包袋大小*
                lbl_state.Text = "正在处理包袋大小属性";
                if (rb_size_mini.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$2.1.0.0.0.$0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_size_xiao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$2.1.0.0.0.$1.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_size_zhong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$2.1.0.0.0.$2.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_size_da.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$2.1.0.0.0.$3.0.0 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "包袋大小属性处理完成";


                //提拎
                lbl_state.Text = "正在处理提拎属性";
                if (rb_tilin_zhuangxie.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$3.1.0.0.0.$0.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_tilin_shensuo.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$3.1.0.0.0.$1.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_tilin_ruanba.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$3.1.0.0.0.$2.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_tilin_yingba.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$3.1.0.0.0.$3.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_tilin_suolian.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$3.1.0.0.0.$4.0.0 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "提拎属性处理完成";


                //waidai外袋
                lbl_state.Text = "正在处理外袋属性";
                if (rb_waidai_wadai.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$4.1.0.0.0.$0.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_waidai_neitie.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$4.1.0.0.0.$1.0.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_waidai_changkou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$4.1.0.0.0.$2.0 ')[0].click() ", webBrowser1);
                }
                else if (rb_waidai_daigai.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$4.1.0.0.0.$3.0.0')[0].click() ", webBrowser1);
                }
                else if (rb_waidai_liti.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$4.1.0.0.0.$4.0 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "外袋属性处理完成";


                //zhucaizhi主材质
                lbl_state.Text = "正在处理主材质属性";
                if (rb_caizhi_pu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$0.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_niupi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$1.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_niujinbu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$14.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_yangpi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$2.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_tumao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$3.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_jinlun.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$5.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_fanbu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$6.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_shepi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$9.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_nizi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$11.1')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_zhi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$13.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_juzhixianwei.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$7.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_eyu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$10.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_zhupi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$4.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_fanmaopi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$27.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_wangmian.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$10.1.0.0.3.2.$28.1')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_wufangbu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$10.1.0.0.3.2.$12.1')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_pvc.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$15.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_mabu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$10.1.0.0.3.2.$16.1')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_sirong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$17.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_sichou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$18.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_caolei.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$10.1.0.0.3.2.$19.1')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_guijiao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$20.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_toucengniupi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$21.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_ercengniupi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$22.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_huaxuexianwei.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$24.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_picao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$10.1.0.0.3.2.$25.1')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_tianerong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$26.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_caizhi_qita.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$10.1.0.0.3.2.$23.1 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "主材质属性处理完成";

                //外形
                lbl_state.Text = "正在处理外形属性";
                if (rb_waixing_hengkuan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$11.1.0.0.3.2.$13.1')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_shukuan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$14.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_beike.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$15.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_shuitong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$16.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_shuijiao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$17.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_chibang.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$11.1.0.0.3.2.$18.1')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_yuanhe.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$19.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_fanghe.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$20.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_xiangxing.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$11.1.0.0.3.2.$21.1')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_youchai.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$22.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_xinfeng.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$23.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_dongwu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$24.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_cailan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$25.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_zhentou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$26.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_xiangti.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$0.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_fengqin.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$1.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_lasheng.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$2.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_fangxingjianbao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$3.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_baolingqiu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$4.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_hezi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$5.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_xiaofangbao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$6.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_xiaoyuanbao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$7.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_egao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$11.1.0.0.3.2.$8.1')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_yuanhuan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$11.1.0.0.3.2.$9.1')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_mini.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$11.1.0.0.3.2.$10.1')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_maan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$11.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_mingxing.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$12.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_maanbao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$11.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_jiche.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$28.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_pinjie.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$29.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_sanjiao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$31.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_xiaomao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$32.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_cuican.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$33.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_panduola.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$34.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_zhezhou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$35.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_doudou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$36.1 ')[0].click() ", webBrowser1);
                }
                else if (rb_waixing_qita.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$11.1.0.0.3.2.$37.1 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "外形属性处理完成";

                //liuxing流行
                lbl_state.Text = "正在处理流行属性";
                if (cb_liuxing_zhuangse.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$0.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_huaduo.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$1.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_baowen.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$2.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_liantiao.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$3.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_loukong.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$4.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_hudiejie.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$5.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_liangpian.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$6.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_leisi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$7.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_zhezhou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$8.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_chuanzhu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$10.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_maoding.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$11.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_suokou.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$12 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_liusu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$13.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_zimu.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$14.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_xiuhua.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$15.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_gewen.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$16.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_yahua.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$17.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_zhihua.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$18.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_bianzhi.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$12.1.0.0.3.2.$19.1')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_pinjie.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$20.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_daizuan.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$21.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_lingge.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid(' .4.2.1.$2.1.0.2:$12.1.0.0.3.2.$22.1')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_eyuwen.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$23.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_tangguo.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$24.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_jiche.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$25.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_youchai.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$26.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_xinfeng.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$27.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_yinhua.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$28.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_touming.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$29.1 ')[0].click() ", webBrowser1);
                }
                if (cb_liuxing_yakeli.Checked)
                {
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$2.1.0.2:$12.1.0.0.3.2.$30.1 ')[0].click() ", webBrowser1);
                }
                lbl_state.Text = "流行元素属性处理完成";

                lbl_state.Text = "正在处理模特说明属性";
                string motexiaoguo = txt_mote.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:1.2:$0.1.0.0.0')[0].value='" + motexiaoguo + "'; ", webBrowser1);
                lbl_state.Text = "模特说明属性处理完成";

                lbl_state.Text = "正在处理静物说明属性";
                string jingwuxiaoguo = txt_jingwu.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:2.2:$0.1.0.0.0 ')[0].value='" + jingwuxiaoguo + "'; ", webBrowser1);
                lbl_state.Text = "静物说明属性处理完成";

                lbl_state.Text = "正在处理细节说明属性";
                string xijiezuogong = txt_xijie.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:3.2:$0.1.0.0.0 ')[0].value='" + xijiezuogong + "'; ", webBrowser1);
                lbl_state.Text = "细节说明属性处理完成";

                lbl_state.Text = "正在处理产品说明属性";
                string chanpin = txt_chanpinjieshao.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:4.2:$0.1.0.0.0 ')[0].value='" + chanpin + "'; ", webBrowser1);
                lbl_state.Text = "产品说明属性处理完成";

                lbl_state.Text = "品牌说明属性处理完成";
                string pinpai = txt_pinpai.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:5.2:$0.1.0.0.0 ')[0].value='" + pinpai + "'; ", webBrowser1);
                lbl_state.Text = "品牌说明属性处理完成";

                lbl_state.Text = "正在处理保障说明属性";
                string baozhuang = txt_baozhuang.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:6.2:$0.1.0.0.0 ')[0].value='" + baozhuang + "'; ", webBrowser1);
                lbl_state.Text = "保障说明属性处理完成";

                lbl_state.Text = "正在处理服务说明属性";
                string fuwu = txt_fuwu.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:7.2:$0.1.0.0.0 ')[0].value='" + fuwu + "'; ", webBrowser1);
                lbl_state.Text = "服务说明属性处理完成";

                lbl_state.Text = "正在处理资质说明属性";
                string zizhi = txt_zizhi.Text.Trim();
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:8.2:$0.1.0.0.0 ')[0].value='" + zizhi + "'; ", webBrowser1);
                lbl_state.Text = "资质说明属性处理完成";

                //尺寸说明
                /*
                 * .4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$1.0.0
                 * .4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$1.$1.0.0
                 * .4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$2.$1.0.0
                 * .4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$1.0.0
                 * .4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$2.0.0
                 */
                lbl_state.Text = "正在处理尺寸属性";
                //等动态html添加完成后处理
                if (Browser.WaitWebPageLoad("getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$1.0.0')[0]", webBrowser1))
                {
                    string jiandai = txt_jiandai.Text.Trim();
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$1.0.0')[0]", webBrowser1);
                    Auto.Clipboard_In(jiandai);
                    Auto.Clipboard_Out();

                    string binggao = txt_binggao.Text.Trim();
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$2.0.0 ')[0] ", webBrowser1);
                    Auto.Clipboard_In(binggao);
                    Auto.Clipboard_Out();

                    string dihou = txt_dihou.Text.Trim();
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$3.0.0 ')[0]", webBrowser1);
                    Auto.Clipboard_In(dihou);
                    Auto.Clipboard_Out();

                    string dichang = txt_dichang.Text.Trim();
                    //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$4.0.0 ')[0].value='" + dichang + "'; ", webBrowser1);
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$4.0.0 ')[0]", webBrowser1);
                    Auto.Clipboard_In(dichang);
                    Auto.Clipboard_Out();

                    string gaodu = txt_gaodu.Text.Trim();
                    //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$5.0.0 ')[0].value='" + gaodu + "'; ", webBrowser1);
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.0.1.1.$0.$5.0.0 ')[0]", webBrowser1);
                    Auto.Clipboard_In(gaodu);
                    Auto.Clipboard_Out();
                    //尺寸说明
                    lbl_state.Text = "正在处理尺寸属性";
                    string chicunshuoming = txt_chicun.Text.Trim();
                    //.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.2.0
                    //.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.2.0
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:0.2:$0.1.0.0.1.2.0')[0] ", webBrowser1);
                    Auto.Clipboard_In(chicunshuoming);
                    Auto.Clipboard_Out();
                    lbl_state.Text = "尺寸说明属性处理完成";
                }
                lbl_state.Text = "尺寸属性处理完成";

                //选择分类
                //本周上新
                lbl_state.Text = "正在处理选择分类属性";
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$0.1 ')[0].click() ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$2.1 ')[0].click() ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$3.1 ')[0].click() ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$4.1 ')[0].click() ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$5.1 ')[0].click() ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$0.1.0.0.3.2.$6.1 ')[0].click() ", webBrowser1);
                //付款减库存
                lbl_state.Text = "正在处理付款减库存属性";
                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$3.1.0.2:$1.1.0.0.$1.1 ')[0].click() ", webBrowser1);



                /*
                 * 内部结构
                 * 拉链暗袋
                 * 手机袋
                 * 证件袋
                 * 夹层拉链袋
                 * 电脑插袋
                 * 相机插袋
                 */
                lbl_state.Text = "正在处理内部结构属性";
                string neibu = cb_neibu.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(neibu))
                {
                    //点击内部结构dropdown-menu ul
                    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.2.1.$2.1.0.2:$5.1.0.0.0')[0].click()", webBrowser1);
                    //显示隐藏下拉菜单选项
                    Browser.JS_CEFBrowser_NoReturn("getClassName('dropdown-menu ul')[0].setAttribute('style','max-height:500')  ", webBrowser1);
                    switch (neibu)
                    {
                        case "拉链暗袋":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[0]  ", webBrowser1);
                            break;
                        case "手机袋":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[1]  ", webBrowser1);
                            break;
                        case "证件袋":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[2]  ", webBrowser1);
                            break;
                        case "夹层拉链袋":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[3]  ", webBrowser1);
                            break;
                        case "电脑插袋":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[4]  ", webBrowser1);
                            break;
                        case "相机插袋":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[5]  ", webBrowser1);
                            break;
                    }
                    Browser.WaitJS("getElementsByDataReactid('.4.2.1.$2.1.0.2:$5.1.0.0.0.0')[0].innerText!='请选择'  ", webBrowser1);

                }
                /*休闲/街头
宴会
运动
其他
旅行
商务
             */

                lbl_state.Text = "正在处理箱包场合属性";
                //string changhe = cb_changhe.SelectedItem.ToString();
                int int_changhe = cb_changhe.SelectedIndex;
                Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.2.1.$2.1.0.2:$6.1.0.0.0')[0].click()", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("  getClassName('dropdown-menu ul')[0].setAttribute('style','max-height:500')  ", webBrowser1);
                Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[" + int_changhe.ToString() + "]  ", webBrowser1);
                //if (!string.IsNullOrEmpty(changhe))
                //{
                //    //点击内部结构dropdown-menu ul
                //    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.2.1.$2.1.0.2:$6.1.0.0.0')[0].click()", webBrowser1);
                //    //显示隐藏下拉菜单选项
                //    Browser.JS_CEFBrowser_NoReturn("  getClassName('dropdown-menu ul')[0].setAttribute('style','max-height:500')  ", webBrowser1);
                //    switch (changhe)
                //    {
                //        case "休闲街头":
                //            //点击下拉菜单选项
                //            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[0]  ", webBrowser1);
                //            break;
                //        case "宴会":
                //            //点击下拉菜单选项
                //            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[1]  ", webBrowser1);
                //            break;
                //        case "运动":
                //            //点击下拉菜单选项
                //            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[2]  ", webBrowser1);
                //            break;
                //        case "其他":
                //            //点击下拉菜单选项
                //            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[3]  ", webBrowser1);
                //            break;
                //        case "旅行":
                //            //点击下拉菜单选项
                //            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[4]  ", webBrowser1);
                //            break;
                //        case "商务":
                //            //点击下拉菜单选项
                //            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[5]  ", webBrowser1);
                //            break;
                //    }
                //}
                Browser.WaitJS("getElementsByDataReactid('.4.2.1.$2.1.0.2:$6.1.0.0.0.0')[0].innerText!='请选择'  ", webBrowser1);

                /*聚酯纤维
合成革
棉
锦纶
无里布
涤棉
真皮
其他化学纤维
         */
                lbl_state.Text = "正在处理里料属性";
                string liliao = cb_liliao.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(liliao))
                {
                    //点击内部结构dropdown-menu ul
                    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.2.1.$2.1.0.2:$7.1.0.0.0')[0].click()", webBrowser1);
                    //显示隐藏下拉菜单选项
                    Browser.JS_CEFBrowser_NoReturn("  getClassName('dropdown-menu ul')[0].setAttribute('style','max-height:500')  ", webBrowser1);
                    switch (liliao)
                    {
                        case "聚酯纤维":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[0]  ", webBrowser1);
                            break;
                        case "合成革":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[1]  ", webBrowser1);
                            break;
                        case "棉":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[2]  ", webBrowser1);
                            break;
                        case "锦纶":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[3]  ", webBrowser1);
                            break;
                        case "无里布":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[4]  ", webBrowser1);
                            break;
                        case "涤棉":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[5]  ", webBrowser1);
                            break;
                        case "真皮":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[6]  ", webBrowser1);
                            break;
                        case "其他化学纤维":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[7]  ", webBrowser1);
                            break;

                    }
                }
                Browser.WaitJS("getElementsByDataReactid('.4.2.1.$2.1.0.2:$7.1.0.0.0.0')[0].innerText!='请选择'  ", webBrowser1);

                /*拉链
磁扣
抽带
拉链搭扣
抽带搭扣
其他
魔术贴
包盖式
敞口
挂钩
海关锁
     */
                lbl_state.Text = "正在处理箱包开袋方式属性";
                string kaidaifangshi = cb_kaidai.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(kaidaifangshi))
                {
                    //点击内部结构dropdown-menu ul
                    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.2.1.$2.1.0.2:$8.1.0.0.0')[0].click()", webBrowser1);
                    //显示隐藏下拉菜单选项
                    Browser.JS_CEFBrowser_NoReturn("  getClassName('dropdown-menu ul')[0].setAttribute('style','max-height:500')  ", webBrowser1);
                    switch (kaidaifangshi)
                    {
                        case "拉链":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[0]  ", webBrowser1);
                            break;
                        case "磁扣":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[1]  ", webBrowser1);
                            break;
                        case "抽带":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[2]  ", webBrowser1);
                            break;
                        case "拉链搭扣":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[3]  ", webBrowser1);
                            break;
                        case "抽带搭扣":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[4]  ", webBrowser1);
                            break;
                        case "其他":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[5]  ", webBrowser1);
                            break;
                        case "魔术贴":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[6]  ", webBrowser1);
                            break;
                        case "包盖式":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[7]  ", webBrowser1);
                            break;
                        case "敞口":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[8]  ", webBrowser1);
                            break;
                        case "挂钩":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[9]  ", webBrowser1);
                            break;
                        case "海关锁":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[10]  ", webBrowser1);
                            break;


                    }
                }
                Browser.WaitJS("getElementsByDataReactid('.4.2.1.$2.1.0.2:$8.1.0.0.0.0')[0].innerText!='请选择'  ", webBrowser1);

                /*纯色
文字
花卉
人物
动物
几何图案
卡通
水果
风景
条纹
格纹
透明
 */
                lbl_state.Text = "正在处理箱包图案属性";
                string xiangbaotuan = cb_tuan.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(xiangbaotuan))
                {
                    //点击内部结构dropdown-menu ul
                    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.2.1.$2.1.0.2:$9.1.0.0.0')[0].click()", webBrowser1);
                    //显示隐藏下拉菜单选项
                    Browser.JS_CEFBrowser_NoReturn("  getClassName('dropdown-menu ul')[0].setAttribute('style','max-height:500')  ", webBrowser1);
                    switch (xiangbaotuan)
                    {
                        case "纯色":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[0]  ", webBrowser1);
                            break;
                        case "文字":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[1]  ", webBrowser1);
                            break;
                        case "花卉":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[2]  ", webBrowser1);
                            break;
                        case "人物":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[3]  ", webBrowser1);
                            break;
                        case "动物":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[4]  ", webBrowser1);
                            break;
                        case "几何图案":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[5]  ", webBrowser1);
                            break;
                        case "卡通":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[6]  ", webBrowser1);
                            break;
                        case "水果":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[7]  ", webBrowser1);
                            break;
                        case "风景":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[8]  ", webBrowser1);
                            break;
                        case "条纹":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[9]  ", webBrowser1);
                            break;
                        case "格纹":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[10]  ", webBrowser1);
                            break;
                        case "透明":
                            //点击下拉菜单选项
                            Browser.MouseLeftByHtmlElement(" getClassName('dropdown-menu-content-children-one')[11]  ", webBrowser1);
                            break;

                    }
                }
                Browser.WaitJS("getElementsByDataReactid('.4.2.1.$2.1.0.2:$9.1.0.0.0.0')[0].innerText!='请选择'  ", webBrowser1);



            }
            save();
            lbl_state.Text = "所有信息处理完成";
            MessageBox.Show("所有信息处理完成");

        }







        #endregion

        #region btn_02_Click
        private void btn_02_Click(object sender, EventArgs e)
        {
            Browser.SetScrollByHtmlElement(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$3.1.0.0.5.0.1.1')[0] ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$3.1.0.0.5.0.1.1')[0].click(); ", webBrowser1);
            //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.2.1.$0.1.0.2:$3.1.0.0.5.0.1.1')[0] ", webBrowser1);
            ClickUpImage();

        }
        #endregion

        #region btn_03_Click
        private void btn_03_Click(object sender, EventArgs e)
        {
            Browser.SetScrollByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:1.2:$0.1.0.1.0.5.0.1')[0] ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:1.2:$0.1.0.1.0.5.0.1')[0].click(); ", webBrowser1);
            ClickUpImage();
        }
        #endregion

        #region btn_04_Click
        private void btn_04_Click(object sender, EventArgs e)
        {
            Browser.SetScrollByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:2.2:$0.1.0.1.0.5.0.1')[0] ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:2.2:$0.1.0.1.0.5.0.1')[0].click(); ", webBrowser1);
            ClickUpImage();
        }
        #endregion

        #region btn_05_Click
        private void btn_05_Click(object sender, EventArgs e)
        {
            Browser.SetScrollByHtmlElement(" getElementsByDataReactid('.4.2.1.$4.1.0.0:3.2:$0.1.0.1.0.5.0.1.1')[0] ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.2.1.$4.1.0.0:3.2:$0.1.0.1.0.5.0.1.1')[0].click(); ", webBrowser1);
            ClickUpImage();
        }
        #endregion

        #region btn_06_Click
        private void btn_06_Click(object sender, EventArgs e)
        {
            //打折
            string url = "http://www.xiaodian.com/pc/home";
            webBrowser1.Load(url);
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                url = Browser.JS_CEFBrowser(" getElementsByDataReactid('.2.$6.1.$0')[0].getElementsByTagName('a')[0].href ", webBrowser1);
                webBrowser1.Load(url);
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    url = Browser.JS_CEFBrowser(" getElementsByDataReactid('.5.0.2.$1.0')[0].href ", webBrowser1);
                    webBrowser1.Load(url);
                    if (Browser.WaitWebPageLoad(webBrowser1))
                    {
                        Browser.SetScroll(0, 200, webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn(" SetTargetSelfByA(); ", webBrowser1);
                    }
                }
            }

        }
        #endregion

        #region btn_07_Click
        private void btn_07_Click(object sender, EventArgs e)
        {
            Browser.SetScrollByHtmlElement("getElementsByDataReactid('.4.2.1.$1.1.0.0.2:1.1')[0]", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("window.scrollTo(0,document.body.scrollTop+80);", webBrowser1);
        }
        #endregion

        #region btn_login_Click
        private void btn_login_Click(object sender, EventArgs e)
        {
            login_m_danjian();

        }
        #endregion

        #region mogujie_FormClosing
        private void mogujie_FormClosing(object sender, FormClosingEventArgs e)
        {
            CefSharp.Cef.Shutdown();
            Application.Exit();
        }
        #endregion

        #region ClickUpImage
        void ClickUpImage()
        {

            Browser.Delay(500);

            //设置上传图片格式、、mc-modal-wrap
            Browser.JS_CEFBrowser_NoReturn(" getClassName('mc-modal-wrap')[1].getElementsByTagName('input')[0].setAttribute('accept','image/*') ", webBrowser1);


            Point res = webBrowser1.PointToScreen(new Point(0, 0));
            int h = webBrowser1.Height;
            int w = webBrowser1.Width;
            res.Offset(w / 2 - 60, h / 2);
            Cursor.Position = res;
            Auto.Mouse_Left();
        }
        #endregion

        #endregion

        #region 标题参考

        #region bind_at
        void bind_at()
        {
            try
            {
                dgv_title.AutoGenerateColumns = false;


                IList<Entity.aotunew_title> list = BLL2.aotunew_titleManager.Search(1, 1, "", "1", "", new DateTime(), new DateTime(), "");
                if (list.Count > 0)
                {
                    aotunew_title at = list[0];
                    string temp_date = at.atdate.ToString("yyyy-MM-dd");
                    DateTime dt = Convert.ToDateTime(temp_date);
                    list = BLL2.aotunew_titleManager.Search(1, 1000, "", "1", "", dt, dt, "");
                    dgv_title.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("绑定采集信息失败:" + ex.ToString());
            }
        }
        #endregion

        #region btn_caiji_Click
        private void btn_caiji_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_state.Text = "正在采集蘑菇街单肩包综合排序第一页共69件商品……";
                string url1 = XMLHelper.GetValue("CaiJi_Title_Url1");
                List<Entity.aotunew_title> list = CaiJi_MoGuJie.caiji_listpage(url1, "1", webBrowser1);

                lbl_state.Text = "正在向数据库添加第一页信息……";
                foreach (aotunew_title at in list)
                {
                    BLL2.aotunew_titleManager.Insert(at);
                }

                lbl_state.Text = "正在采集蘑菇街单肩包综合排序第二页共60件商品……";
                list = CaiJi_MoGuJie.caiji_listpage("http://list.mogujie.com/book/bags/50695/2/pop?sort=pop&action=bags&fcid=50695&ad=0&ptp=1.HS4n8.0.0.jpEha#category_all", "1", webBrowser1);

                lbl_state.Text = "正在向数据库添加第二页信息……";
                foreach (aotunew_title at in list)
                {
                    BLL2.aotunew_titleManager.Insert(at);
                }

                bind_at();

                lbl_state.Text = "采集完成";
                MessageBox.Show("采集完成");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("采集商品失败:" + ex.ToString());
            }

        }




        #endregion

        #region btn_reset_dgv_Click
        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            bind_at();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
        }
        #endregion

        #region dgv_title_MouseDoubleClick
        private void dgv_title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point hit = this.dgv_title.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hitTest = this.dgv_title.HitTest(hit.X, hit.Y);
            //MessageBox.Show(hitTest.Type + " Row=" + hitTest.RowIndex + " Col" + hitTest.ColumnIndex);
            //判断不是首行
            if (hitTest.RowIndex != -1)
            {
                //int a = dgv_title.CurrentRow.Index;
                Entity.aotunew_title og = (Entity.aotunew_title)dgv_title.CurrentRow.DataBoundItem;
                if (og != null)
                {
                    if (!string.IsNullOrEmpty(og.aturl))
                        Manager.OpenProgram(og.aturl);
                }
            }
        }
        #endregion

        #region dgv_title_CellFormatting
        private void dgv_title_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //    if (e.Value != null)
            //    {
            //        if (dgv1.DataSource != null)
            //        {
            //            if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_type1"))
            //            {

            //                string name = e.Value.ToString();
            //                string path = Application.StartupPath + "\\" + "Image" + "\\" + name;
            //                e.Value = Browser.GetImage(path);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("======================================================================");
            //    Debug.WriteLine("网址：" + Browser.urlstr);
            //    Debug.WriteLine(DateTime.Now.ToString());
            //    Debug.WriteLine("信息绑定失败：" + ex.Message);
            //}
        }
        #endregion

        #region dgv_title_CellMouseClick
        private void dgv_title_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point hit = this.dgv_title.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hitTest = this.dgv_title.HitTest(hit.X, hit.Y);
            //MessageBox.Show(hitTest.Type + " Row=" + hitTest.RowIndex + " Col" + hitTest.ColumnIndex);
            //判断不是首行
            if (hitTest.RowIndex != -1)
            {
                try
                {
                    string res = dgv_title.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Auto.Clipboard_In(res);
                }
                catch (Exception ex)
                {
                     ("点击后添加到内存中失败"+ex.ToString()).ToLog();
                }
            }
        }
        #endregion

        #region dateTimePicker1_CloseUp
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            (sender as DateTimePicker).Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region btn_search_Click
        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime temp_date2 = new DateTime();
            DateTime.TryParse(dateTimePicker1.Text, out temp_date2);
            string key = txt_key.Text.Trim();
            dgv_title.DataSource = BLL2.aotunew_titleManager.Search(1, 1000, key, "1", "", temp_date2, temp_date2, "");

        }









        #endregion

        #endregion

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            string jjss = txt_js.Text.Trim();
            if (!string.IsNullOrEmpty(jjss))
            {
                Browser.JS_CEFBrowser_NoReturn(jjss, webBrowser1);
            }
        }
        #endregion

        #region mogujie_danjian_Shown
        private void mogujie_danjian_Shown(object sender, EventArgs e)
        {
            Mogujie.login(webBrowser1);
        }
        #endregion
    }
}

