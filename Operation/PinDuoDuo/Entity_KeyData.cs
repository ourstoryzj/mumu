/*
系统名称：Entity
作    者：张建
完成日期：2015-04-26
内容摘要：实体类
*/
using System;

namespace Operation
{

    /// <summary>
    /// class: address
    /// </summary>
    [Serializable]
    public class Entity_KeyData
    {
       
        private string m_key;

        //Name:aCity Type:adLongVarWChar		
        private string m_xiangguan;

        //Name:aDistrict Type:adLongVarWChar		
        private int m_sousuoredu;

        //Name:aid Type:adInteger		
        private int m_dianjiredu;

        //Name:aPostNumber Type:adVarWChar		
        private decimal m_dianjilv;

        //Name:aProvince Type:adLongVarWChar		
        private decimal m_zhuanhualv;

        //Name:aremark Type:adVarWChar		
        private int m_jingzhengqiangdu;

        //Name:astate Type:adVarWChar		
        private decimal m_chujia;

        private decimal m_dianjisousuo;

        private decimal m_zonghezhi;

        private decimal m_zonghejingzheng;

        private int m_sort;


        public string Key
        {
            get
            {
                return m_key;
            }

            set
            {
                m_key = value;
            }
        }

        public string Xiangguan
        {
            get
            {
                return m_xiangguan;
            }

            set
            {
                m_xiangguan = value;
            }
        }

        public int Sousuoredu
        {
            get
            {
                return m_sousuoredu;
            }

            set
            {
                m_sousuoredu = value;
            }
        }

        public int Dianjiredu
        {
            get
            {
                return m_dianjiredu;
            }

            set
            {
                m_dianjiredu = value;
            }
        }

        public decimal Dianjilv
        {
            get
            {
                return m_dianjilv;
            }

            set
            {
                m_dianjilv = value;
            }
        }

        public decimal Zhuanhualv
        {
            get
            {
                return m_zhuanhualv;
            }

            set
            {
                m_zhuanhualv = value;
            }
        }

        public int Jingzhengqiangdu
        {
            get
            {
                return m_jingzhengqiangdu;
            }

            set
            {
                m_jingzhengqiangdu = value;
            }
        }

        public decimal Chujia
        {
            get
            {
                return m_chujia;
            }

            set
            {
                m_chujia = value;
            }
        }

        public decimal Dianjisousuo
        {
            get
            {
                return m_dianjisousuo;
            }

            set
            {
                m_dianjisousuo = value;
            }
        }

        public decimal Zonghezhi
        {
            get
            {
                return m_zonghezhi;
            }

            set
            {
                m_zonghezhi = value;
            }
        }

        public decimal Zonghejingzheng
        {
            get
            {
                return m_zonghejingzheng;
            }

            set
            {
                m_zonghejingzheng = value;
            }
        }

        public int Sort
        {
            get
            {
                return m_sort;
            }

            set
            {
                m_sort = value;
            }
        }
    }
}




