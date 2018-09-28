using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication4
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || Session["Razina"].ToString() != 1.ToString())
            {
                Session.Clear();
                Response.Redirect("Login.aspx.cs");
            }

            lblUsername.Text = Session["Username"].ToString();
            lblDate.Text = DateTime.Today.ToString().Split(' ')[0];
        }

        protected void btnAdministracija_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administracija.aspx");
        }

        protected void btnUnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnosKorisnika.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login info.aspx");
        }
    }
}