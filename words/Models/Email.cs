using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Email
    {
        private string account;

        /// <summary>
        /// 收件人账号
        /// </summary>
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string name;

        /// <summary>
        /// 收件人名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
