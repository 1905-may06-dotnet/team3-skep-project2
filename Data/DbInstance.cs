using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
    public sealed class DbInstance
    {
        private static Models.GSBGMFinalContext instance = null;
        private DbInstance()
        {
        }
        public static Models.GSBGMFinalContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Models.GSBGMFinalContext();
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
