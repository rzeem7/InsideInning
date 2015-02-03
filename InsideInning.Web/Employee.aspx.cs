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
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var restClient = new RestClient("http://localhost:26197/api/");
            var request = new RestRequest("CheckLogin/", Method.POST);

            var empData = new BOEmployee();
            empData.EmailAddress = EmployeeEmail.Text;
            empData.Password=EmployeePassword.Text;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("X-ApiKey", "XMLHttpRequest");
            request.AddBody(empData);
            var dd = restClient.Execute<BOEmployee>(request);
            var txtFirstName = EmployeeFirstName.Text;
            var txtLastName = EmployeeLastName.Text;
        }
    }
}