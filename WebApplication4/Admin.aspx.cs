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
            lblUsername.Text = Session["Username"].ToString();
            lblDate.Text = DateTime.Today.ToString().Split(' ')[0];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}