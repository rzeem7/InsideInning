using InsideInning.Data;
using InsideInning.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace InsideInning
{
    public static class App
    {
        private static Page homeView;
        public static Page RootPage
        {
            get { return homeView ?? (homeView = new EmployeeAccount()); }
        }

        #region Database Instance

        private static InsideInningData _database;

        public static InsideInningData DataBase
        {
            get
            {
                if (_database == null)
                    _database = new InsideInningData();
                return _database;
            }
        }

        #endregion
    }
}
