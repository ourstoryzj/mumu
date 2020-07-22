/*
系统名称：Entity
作    者：张建
完成日期：2020-07-22
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: Porfit
    /// </summary>
    [Serializable]
    public class Porfit
    {
        //Name:pid Type:int
        private int m_pid;

        //Name:pprice Type:float
        private double m_pprice;

        //Name:pdate Type:datetime
        private DateTime m_pdate;

        //Name:pbeiyong Type:varchar
        private string m_pbeiyong;



        ///<summary>
        ///Name:pid Type:int
        ///</summary>
        public int pid
        {
            get { return m_pid; }
            set { m_pid = value; }
        }
        ///<summary>
        ///Name:pprice Type:float
        ///</summary>
        public double pprice
        {
            get { return m_pprice; }
            set { m_pprice = value; }
        }
        ///<summary>
        ///Name:pdate Type:datetime
        ///</summary>
        public DateTime pdate
        {
            get { return m_pdate; }
            set { m_pdate = value; }
        }
        ///<summary>
        ///Name:pbeiyong Type:varchar
        ///</summary>
        public string pbeiyong
        {
            get { return m_pbeiyong; }
            set { m_pbeiyong = value; }
        }

    }
}
