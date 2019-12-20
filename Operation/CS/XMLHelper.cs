using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace excel_operation.CS
{
    public class XMLHelper
    {

        public static string xmlurl = Application.StartupPath + "\\DB.xml";

        #region FileIsHas
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="url">文件地址，例如：Application.StartupPath + "\\Image</param>
        /// <returns></returns>
        public static bool FileIsHas(string url)
        {
            if (!System.IO.File.Exists(url))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region CreateDBXml
        /// <summary>
        /// 创建DB.xml
        /// </summary>
        public static void CreateDBXml()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xe = xmldoc.CreateElement("Data");
                xmldoc.AppendChild(xe);
                xmldoc.Save(xmlurl);
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
        }
        #endregion

        #region GetNode
        /// <summary>
        /// 根据Name属性找到Node，如果没有返回空
        /// </summary>
        /// <param name="name">属性值</param>
        /// <returns></returns>
        public static XmlElement GetNode(string name)
        {
            XmlElement xe = GetNode("name", name);
            return xe;
        }
        #endregion

        #region GetValue
        /// <summary>
        /// 根据Name属性找到Node,然后找到属性值，如果没有返回空
        /// </summary>
        /// <param name="name1">name属性值</param>
        /// <param name="name2">返回值的属性名称</param>
        /// <returns></returns>
        public static string GetValue(string name1, string name2)
        {
            //XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load(xmlurl);
            //XmlNodeList xmllist = xmldoc.SelectNodes("//*[@title='" + title + "']");
            //string res = "";
            //foreach (XmlElement xe in xmllist)
            //{
            //    res = xe.GetAttribute(att);
            //}
            //return res;

            string res = GetValue("name", name1, name2);
            return res;
        }
        #endregion

        #region GetValue
        /// <summary>
        /// 根据name1属性值value1找到Node,然后找到att2属性值，如果没有返回空
        /// </summary>
        /// <param name="name1">要查找的属性名称</param>
        /// <param name="value1">要查找的属性值</param>
        /// <param name="name2">要返回的属性值</param>
        /// <returns></returns>
        public static string GetValue(string name1, string value1, string name2)
        {
            //XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load(xmlurl);
            //XmlNodeList xmllist = xmldoc.SelectNodes("//*[@" + att1 + "='" + value1 + "']");
            //string res = "";
            //foreach (XmlElement xe in xmllist)
            //{
            //    res = xe.GetAttribute(att2);
            //}
            //return res;
            string res = "";
            try
            {
                XmlElement xe = GetNode(name1, value1);
                if (xe != null)
                {
                    res = xe.GetAttribute(name2);
                }
            }
            catch { }
            return res;
        }
        #endregion

        #region GetValue
        /// <summary>
        /// 根据Name属性找到Node,然后找到value属性值，如果没有返回空
        /// </summary>
        /// <param name="name1">name属性值</param>
        /// <returns></returns>
        public static string GetValue(string name1)
        {
            string res = GetValue(name1, "value");
            return res;
        }
        #endregion

        #region GetNode
        /// <summary>
        /// 根据name1属性值value1找到Node，如果没有返回空
        /// </summary>
        /// <param name="name1">要查找的属性名称</param>
        /// <param name="value1">要查找的属性值</param>
        /// <returns></returns>
        public static XmlElement GetNode(string name1, string value1)
        {
            XmlElement xe_res = null;
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlurl);
                XmlNodeList xmllist = xmldoc.SelectNodes("//*[@" + name1 + "='" + value1 + "']");

                foreach (XmlElement xe in xmllist)
                {
                    xe_res = xe;
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
            return xe_res;
        }
        #endregion

        #region SetValue
        /// <summary>
        /// 设置Xml中节点值
        /// </summary>
        /// <param name="name1">查找节点属性名称</param>
        /// <param name="value1">查找节点名</param>
        /// <param name="name2">要设置的属性名称</param>
        /// <param name="value2">要设置的属性值</param>
        public static void SetValue(string name1, string value1, string name2, string value2)
        {
            //判断是否有文件， 没有就创建
            if (!FileIsHas(xmlurl))
            {
                CreateDBXml();
            }
            XmlElement xe = GetNode(name1, value1);
            if (xe != null)
            {
                //找到了该节点
                xe.SetAttribute(name2, value2);
                xe.OwnerDocument.Save(xmlurl);
            }
            else
            {
                //没有找到该节点
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlurl);
                XmlNodeList nodeList = xmldoc.SelectSingleNode("Data").ChildNodes;
                XmlElement xe1 = xmldoc.CreateElement("Add");
                xe1.SetAttribute(name2, value2);
                nodeList[0].AppendChild(xe1);
                xmldoc.Save(xmlurl);
            }
        }
        #endregion

        #region SetValue
        /// <summary>
        /// 快速设置Xml属性值
        /// </summary>
        /// <param name="value1">找到节点中name属性为value1的Node</param>
        /// <param name="value2">设置节点中value属性</param>
        public static void SetValue(string value1, string value2)
        {
            SetValue("name", value1, "value", value2);
        }
        #endregion






        #region 参考代码



        public static void caozuo()
        {
            //设置点击次数
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("db.xml");

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("huashu").ChildNodes;//获取Employees节点的所有子节点

            foreach (XmlNode xn in nodeList)//遍历所有子节点 
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                foreach (XmlNode xn1 in nls)//遍历 
                {
                    XmlElement xe2 = (XmlElement)xn1;//转换类型 
                    if (xe2.GetAttribute("htitle") == "test")//如果找到 
                    {
                        string sort = xe2.GetAttribute("htitle");
                        int _sort = 0;
                        int.TryParse(sort, out _sort);
                        _sort++;
                        xe2.SetAttribute("hcount", _sort.ToString());//则修改话术点击次数
                        sort = xe.GetAttribute("hcount");
                        int.TryParse(sort, out _sort);
                        _sort++;
                        xe.SetAttribute("hcount", _sort.ToString());//则修改话术类型点击次数
                        break;
                    }
                }
            }
            xmlDoc.Save("db.xml");//保存。
        }



        public void tongbu()
        {/*
            try
            {
                IList<huashu> ilist1 = BLL.huashuManager.SearchAll("1");
                //判断是否可以连接到数据库
                if (ilist1.Count > 1)
                {
                    toolStripProgressBar1.Value = 5;
                    List<huashu> list = new List<huashu>();
                    huashu hs = new huashu();
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("db.xml");    //加载Xml文件  
                        XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                        XmlNodeList personNodes = rootElem.GetElementsByTagName("Node"); //获取person子节点集合  
                        foreach (XmlNode node in personNodes)
                        {

                            hs = convert_xml(node);
                            update(hs);

                            //开始处理话术
                            XmlNodeList Nodes_hua = ((XmlElement)node).GetElementsByTagName("hua");  //获取hua子XmlElement集合  
                            foreach (XmlNode hua_node in Nodes_hua)
                            {
                                hs = convert_xml(hua_node);
                                list.Add(hs);
                            }
                        }
                        //本地数据获取完毕
                        toolStripProgressBar1.Value = 25;

                        //本地数据更新到网络数据库
                        foreach (huashu h in list)
                        {
                            update(h);
                        }
                        //本地数据更新完毕
                        toolStripProgressBar1.Value = 50;

                        //删除本地数据
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load("db.xml");
                        XmlNode root = xmlDoc.SelectSingleNode("huashu");
                        root.RemoveAll();
                        //xmlDoc.Save("db.xml");
                        //删除本地数据
                        toolStripProgressBar1.Value = 75;

                        //下载网络数据
                        //IList<huashu> ilist1 = BLL.huashuManager.SearchAll("1");
                        foreach (huashu _hs1 in ilist1)
                        {
                            XmlElement xe1 = xmlDoc.CreateElement("Node");//创建一个<Node>节点 
                            xe1.SetAttribute("htitle", _hs1.htitle);//设置该节点htitle属性 
                            xe1.SetAttribute("hid", _hs1.hid.ToString());//设置该节点hid属性 
                            xe1.SetAttribute("hfid", "0");//设置该节点hfid属性
                            xe1.SetAttribute("hsort", _hs1.hsort.ToString());//设置该节点hsort属性 
                            xe1.SetAttribute("hcount", _hs1.hcount.ToString());//设置该节点hcount属性
                            xe1.SetAttribute("hdate", _hs1.hdate.ToString());//设置该节点hdate属性 
                            xe1.SetAttribute("hstate", _hs1.hstate);//设置该节点hstate属性
                            xe1.SetAttribute("hcontext", _hs1.hcontext);//设置该节点hcontext属性

                            IList<huashu> ilist2 = BLL.huashuManager.Search(0, 100, "", "1", _hs1.hid.ToString(), new DateTime(), new DateTime());
                            foreach (huashu _hs2 in ilist2)
                            {
                                XmlElement xe2 = xmlDoc.CreateElement("hua");//创建一个<Node>节点 
                                xe2.SetAttribute("htitle", _hs2.htitle);//设置该节点htitle属性 
                                xe2.SetAttribute("hid", _hs2.hid.ToString());//设置该节点hid属性 
                                xe2.SetAttribute("hfid", _hs2.hfid.ToString());//设置该节点hfid属性
                                xe2.SetAttribute("hsort", _hs2.hsort.ToString());//设置该节点hsort属性 
                                xe2.SetAttribute("hcount", _hs2.hcount.ToString());//设置该节点hcount属性
                                xe2.SetAttribute("hdate", _hs2.hdate.ToString());//设置该节点hdate属性 
                                xe2.SetAttribute("hstate", _hs2.hstate);//设置该节点hstate属性
                                xe2.SetAttribute("hcontext", _hs2.hcontext);//设置该节点hcontext属性
                                xe1.AppendChild(xe2);
                            }
                            root.AppendChild(xe1);
                        }
                        xmlDoc.Save("db.xml");
                    }
                    catch { }

                }
            }
            catch { }*/
        }
        #endregion




    }
}
