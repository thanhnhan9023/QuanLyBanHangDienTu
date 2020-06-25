using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT0
{
    public class Account
    {

        string username;
        string password;
        bool active;
        string loai;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public string Loai
        {
            get
            {
                return loai;
            }

            set
            {
                loai = value;
            }
        }

        public Account(string username, string password,string loai,bool active)
        {
            this.username = username;
            this.password = password;
            this.loai = loai;
            this.active = active;

        }
     
    }
}
