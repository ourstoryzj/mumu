/*
系统名称：Entity
作    者：张建
完成日期：2015-05-02
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: shuadan_record
    /// </summary>
    [Serializable]
    public class shuadan_record
    {
        //下载次数		
        private int m_srcount;

        //文件日期		
        private DateTime m_srdate;

        //编号		
        private int m_srid;

        //文件名称		
        private string m_srname;

        //文件包含数据数量		
        private string m_srnum;

        //文件路径		
        private string m_srpath;

        //备注		
        private string m_srremark;

        //状态1:正常 2:失效		
        private string m_srstate;

        //类型:1账号,2导入地址,3生成地址		
        private string m_srtype;



        /// <summary>
        /// 下载次数
        /// </summary>
        public int srcount
        {
            get { return m_srcount; }
            set { m_srcount = value; }
        }
        /// <summary>
        /// 文件日期
        /// </summary>
        public DateTime srdate
        {
            get { return m_srdate; }
            set { m_srdate = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int srid
        {
            get { return m_srid; }
            set { m_srid = value; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string srname
        {
            get { return m_srname; }
            set { m_srname = value; }
        }
        /// <summary>
        /// 文件包含数据数量
        /// </summary>
        public string srnum
        {
            get { return m_srnum; }
            set { m_srnum = value; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string srpath
        {
            get { return m_srpath; }
            set { m_srpath = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string srremark
        {
            get { return m_srremark; }
            set { m_srremark = value; }
        }
        /// <summary>
        /// 状态1:正常 2:失效
        /// </summary>
        public string srstate
        {
            get { return m_srstate; }
            set { m_srstate = value; }
        }
        /// <summary>
        /// 类型:1账号,2导入地址,3生成地址
        /// </summary>
        public string srtype
        {
            get { return m_srtype; }
            set { m_srtype = value; }
        }
    }
}




