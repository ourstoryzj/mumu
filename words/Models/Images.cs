/*
ϵͳ���ƣ�Entity
��    �ߣ��Ž�
������ڣ�2012-05-10
����ժҪ��ʵ����
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: Images
    /// </summary>
    [Serializable]
    public class Images
    {
        //���		
        private int m_IID;

        //ͼƬ����		
        private string m_IName;

        //������ϢID		
        private int m_OID;



        /// <summary>
        /// ���
        /// </summary>
        public int IID
        {
            get { return m_IID; }
            set { m_IID = value; }
        }
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string IName
        {
            get { return m_IName; }
            set { m_IName = value; }
        }
        /// <summary>
        /// ������ϢID
        /// </summary>
        public int OID
        {
            get { return m_OID; }
            set { m_OID = value; }
        }

    }
}
