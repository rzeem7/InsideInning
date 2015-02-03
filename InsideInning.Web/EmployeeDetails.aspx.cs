using InsideInning.BO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InsideInning.Web
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            var restClient = new RestClient("http://localhost:26197/api/");
            var req = new RestRequest("EmployeeDetails/", Method.POST);


            var empDeatilsData = new BOEmployeeDetails();
            empDeatilsData.gender = RadioBtnFeMale.Checked ? "M" : "F";
            empDeatilsData.MaritalStatus = RadioBtnMarried.Checked ? "M": "S";
            empDeatilsData.DateOfBirth = DOBCal.SelectedDate;
            empDeatilsData.DateOfAniversary = DOACal.SelectedDate;
            empDeatilsData.ContactNumber = Convert.ToInt32(ContactTxtbox.Text);
            empDeatilsData.Landline = Convert.ToInt32(lanlinetxtbox.Text);
            empDeatilsData.CompanyProfile = CpyProfiletxtbox.Text;
            empDeatilsData.JoinningDate = JoinCal.SelectedDate;
            //empDeatilsData.IsActive = CheckIsActive.Checked;
            
            req.RequestFormat = RestSharp.DataFormat.Json;
            req.AddHeader("X-ApiKey", "XMLHttpRequest");
            req.AddBody(empDeatilsData);
            restClient.Execute<BOEmployeeDetails>(req);
        }

    }
}