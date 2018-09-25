using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class Korisnik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || Session["Razina"].ToString() != 4.ToString())
            {
                Session.Clear();
                Response.Redirect("Login.aspx.cs");
            }

            string odjeli = "";

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {
                sqlCon.Open();

                string query = @"SELECT P.PoslovnicaId from Users U
                    left outer join Poslovnica_Users PU on PU.UserId = U.UserId
                    left outer join Poslovnica P on PU.PoslovnicaId = P.PoslovnicaId
                    WHERE U.UserId = @UserId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserId", Session["ID"]);
                Session["PoslId"] = sqlCmd.ExecuteScalar().ToString();

                query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = " + Session["PoslId"];
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd2.ExecuteReader();
                while (dr.Read())
                {
                    odjeli += dr["OdjelId"];
                }
            }
            

            if(odjeli != "")
            {
                if (!odjeli.Contains("1")) { GridViewMesnica.Visible = false; }
                if (!odjeli.Contains("2")) { GridViewRibarnica.Visible = false; }
                if (!odjeli.Contains("3")) { GridViewGastro.Visible = false; }
            }
            else { lblLabela.Text = "Došlo je do greške pri učitavanju podataka iz baze."; }
        }
    }
}