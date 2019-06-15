using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
    public sealed class DbInstance
    {
        private static Models.DBcontext instance = null;
        private DbInstance()
        {
        }
        public static Models.DBcontext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Models.DBcontext();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }

    }
}