using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class UnosKorisnika : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUnos_Click(object sender, EventArgs e)
        {
            bool unos = true;
            lblLabela.Text = "";
            
            if(tbxUsername.Text.Length == 0)
            {
                unos = false;
                lblLabela.Text += "Username prazan.";
            }
            else
            {
                //Provjera je li korisnik postoji u AD-u
            }


        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}