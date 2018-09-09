using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.252.4", "sso.appizvjestaji", "Nak0nN0ciD0laziDan"))
            //{
            //    // validate the credentials
            //    bool isValid = pc.ValidateCredentials("sso.apprezervacije", "Nak0nN0ciD0laziDan");
            //    Label1.Text = isValid.ToString();
            //}

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {
                sqlCon.Open();

                string query = "SELECT [Broj poslovnice] FROM Poslovnica P left outer join Poslovnica_Users PU on P.PoslovnicaId = PU.PoslovnicaId WHERE PU.UserId = @UserId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserId", Session["ID"]);
                LabelPoslovnica.Text = sqlCmd.ExecuteScalar().ToString();
            }
        }
    }
}