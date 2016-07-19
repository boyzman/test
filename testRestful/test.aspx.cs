using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IS_DRP_JSONWebAPI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace testRestful
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IS_DRP_RestAPI restAPI = new IS_DRP_RestAPI();
            JObject jobject = restAPI.GetCheckNum(TextBox1.Text.Trim(), "","R");
            string s = JsonConvert.SerializeObject(jobject);
            Label2.Text = s;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            IS_DRP_RestAPI restAPI = new IS_DRP_RestAPI();
            JObject jobject = restAPI.testUserReg(TextBox3.Text.Trim(), TextBox2.Text.Trim(), "er", TextBox2.Text.Trim(), "123", "123", "23", "2");
            string s = JsonConvert.SerializeObject(jobject);
            Label4.Text = s;
        }

    }
}