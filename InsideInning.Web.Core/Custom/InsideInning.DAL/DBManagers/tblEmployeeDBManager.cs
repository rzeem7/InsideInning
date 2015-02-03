using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations;
using InsideInning.BO;
using InsideInning.DAL.Procedures;
using InsideInning.Web.Core.Custom.InsideInning.DAL.Procedures;

namespace InsideInning.DAL
{

    /// <summary>
    /// The tblEmployeeDBManager class is responsible for interacting with the database to retriece and store info about tblEmployee objects.
    /// </summary>
    public partial class tblEmployeeDBManager
    {
        public static BOEmployee GetEmployeeByID(int id)
        {
            BOEmployee itemObj = null;
            var ds = spGetEmployeeByID.ExecuteDataset(id);
            if (ds!=null && ds.Tables[0].Rows.Count > 1)
                throw new Exception("More than one row returned");
            if (ds != null &&  ds.Tables[0].Rows.Count == 1)
                itemObj = FillDataRecord(ds.Tables[0].Rows[0]);
            return itemObj;
        }
        public static BOEmployeeList GetAllEmployees()
        {
            BOEmployeeList itemObjs = null;
            var ds = spGetEmployees.ExecuteDataset();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                itemObjs = new BOEmployeeList();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    itemObjs.Add(FillDataRecord(dr));
                }
            }
            return itemObjs;
        }
        public static BOEmployeeList GetEmployeeDetails()
        {
            BOEmployeeList itemObjs = null;
            var ds = spGetEmployeeDetails.ExecuteDataset();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                itemObjs = new BOEmployeeList();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    itemObjs.Add(FillDataRecord(dr));
                }
            }
            return itemObjs;
        }
        public static BOEmployeeList GetEmployeeDetailsByID(int id)
        {
            BOEmployeeList itemObjs = null;
            var ds = spGetEmployeeDetails.ExecuteDataset();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                itemObjs = new BOEmployeeList();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    itemObjs.Add(FillDataRecord(dr));
                }
            }
            return itemObjs;
        }
        public static BOEmployee CheckLogin(string username, string password)
        {

            BOEmployee itemObj = null;
            var ds = spCheckLogin.ExecuteDataset(username,password);

            if (ds != null && ds.Tables[0].Rows.Count > 1)
                throw new Exception("More than one row returned");
            if (ds != null && ds.Tables[0].Rows.Count == 1)
                itemObj = FillDataRecord(ds.Tables[0].Rows[0]);
            return itemObj;
        }
    }     
}
