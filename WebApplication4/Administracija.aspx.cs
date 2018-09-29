using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class Administracija : System.Web.UI.Page
    {
        string PoslId;
        string UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ID"] == null || Session["Razina"].ToString() != 1.ToString())
            {
                Session.Clear();
                Response.Redirect("Login.aspx.cs");
            }

            if (!IsPostBack)
            {
                if (!Convert.ToBoolean(Session["Write"]))
                {
                    GridView1.Enabled = false;
                }

                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                {
                    sqlCon.Open();

                    string query = "SELECT PoslovnicaId FROM Poslovnica";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    PoslId = sqlCmd.ExecuteScalar().ToString();

                    string odjeli = "";

                    query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = '" + PoslId + "'";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    SqlDataReader dr = sqlCmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        odjeli += dr["OdjelId"];
                    }
                    dr.Close();
                    if (odjeli.Contains("1")) { cbxMesnica.Checked = true; } else { cbxMesnica.Checked = false; }
                    if (odjeli.Contains("2")) { cbxRibarnica.Checked = true; } else { cbxRibarnica.Checked = false; }
                    if (odjeli.Contains("3")) { cbxGastro.Checked = true; } else { cbxGastro.Checked = false; }

                    query = "SELECT UserId FROM Users WHERE RazinaId = 2";
                    SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                    UserId = sqlCmd3.ExecuteScalar().ToString();

                    query = @"SELECT [Broj poslovnice] FROM Poslovnica P 
left outer join Poslovnica_Users PU on P.PoslovnicaId = PU.PoslovnicaId
left outer join Users U on PU.UserId = U.UserId
WHERE  U.UserId = @UserId";
                    SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                    sqlCmd4.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataReader dr2 = sqlCmd4.ExecuteReader();
                    while (dr2.Read())
                    {
                        ListBox1.Items.Add(dr2.GetString(0));
                    }
                    dr2.Close();
                }
            }


        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnosRegPoslovnice.Text = "";
            lblUnosOdjeli.Text = "";

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {
                sqlCon.Open();

                string query = "SELECT PoslovnicaId FROM Poslovnica WHERE [Broj poslovnice] = '" + DropDownList1.SelectedItem + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                PoslId = sqlCmd.ExecuteScalar().ToString();

                string odjeli = "";

                query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = '" + PoslId + "'";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd2.ExecuteReader();
                while (dr.Read())
                {
                    odjeli += dr["OdjelId"];
                }
                dr.Close();
                if (odjeli.Contains("1")) { cbxMesnica.Checked = true; } else { cbxMesnica.Checked = false; }
                if (odjeli.Contains("2")) { cbxRibarnica.Checked = true; } else { cbxRibarnica.Checked = false; }
                if (odjeli.Contains("3")) { cbxGastro.Checked = true; } else { cbxGastro.Checked = false; }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Write"]))
            {
                lblUnosRegPoslovnice.Text = "";
                lblUnosOdjeli.Text = "";

                bool mesnica = cbxMesnica.Checked;
                bool ribarnica = cbxRibarnica.Checked;
                bool gastro = cbxGastro.Checked;

                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                {

                    sqlCon.Open();

                    string query = "SELECT PoslovnicaId FROM Poslovnica WHERE [Broj poslovnice] = '" + DropDownList1.SelectedItem + "'";
                    SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                    PoslId = sqlCmd4.ExecuteScalar().ToString();

                    bool q = true;
                    //DELETE query može biti neuspješan ako postoji report s tom poslovnicom
                    try
                    {
                        query = "DELETE FROM Odjel_Poslovnica WHERE PoslovnicaId = " + PoslId;
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteScalar();
                    }
                    catch
                    {
                        lblUnosOdjeli.Text = "Neuspješan unos. Ta poslovnica ima unesene reportove koji moraju biti izbrisani da bi se odjeli mogli mijenjati.";
                        q = false;
                    }

                    if (q)
                    {
                        query = "INSERT INTO Odjel_Poslovnica VALUES(4," + PoslId + ")";
                        SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                        sqlCmd2.ExecuteScalar();

                        if (mesnica)
                        {
                            query = "INSERT INTO Odjel_Poslovnica VALUES(1," + PoslId + ")";
                            SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                            sqlCmd3.ExecuteScalar();
                        }
                        if (ribarnica)
                        {
                            query = "INSERT INTO Odjel_Poslovnica VALUES(2," + PoslId + ")";
                            SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                            sqlCmd3.ExecuteScalar();
                        }
                        if (gastro)
                        {
                            query = "INSERT INTO Odjel_Poslovnica VALUES(3," + PoslId + ")";
                            SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                            sqlCmd3.ExecuteScalar();
                        }
                    }
                }
                lblUnosOdjeli.Text = "Unos uspješan";
            }
            else
            {
                lblUnosOdjeli.Text = "Nemate pravo unosa.";
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();

            lblUnosRegPoslovnice.Text = "";
            lblUnosOdjeli.Text = "";

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {

                sqlCon.Open();
                
                string query = @"SELECT [Broj poslovnice] FROM Poslovnica P 
left outer join Poslovnica_Users PU on P.PoslovnicaId = PU.PoslovnicaId
left outer join Users U on PU.UserId = U.UserId
WHERE  U.Username = '" + DropDownRM.SelectedItem + "'";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd2.ExecuteReader();
                while (dr.Read())
                {
                    ListBox1.Items.Add(dr.GetString(0));
                }
                dr.Close();
            }
        }

        protected void btnUkloniPoslovnicu_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                ListBox1.Items.Remove(ListBox1.SelectedItem);
            }
            lblUnosRegPoslovnice.Text = "";
            lblUnosOdjeli.Text = "";
        }

        protected void btnDodajPoslovnicu_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(DropDownPoslovnice.SelectedItem);
            lblUnosRegPoslovnice.Text = "";
            lblUnosOdjeli.Text = "";
        }

        protected void btnUnesiPoslovnice_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Write"]))
            {
                lblUnosRegPoslovnice.Text = "";
                lblUnosOdjeli.Text = "";

                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                {
                    sqlCon.Open();

                    string query = "SELECT UserId FROM Users WHERE Username = '" + DropDownRM.SelectedItem + "'";
                    SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                    UserId = sqlCmd4.ExecuteScalar().ToString();

                    query = "DELETE FROM Poslovnica_Users WHERE UserId = '" + UserId + "'";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteScalar();

                    foreach (object item in ListBox1.Items)
                    {
                        query = "SELECT PoslovnicaId FROM Poslovnica WHERE [Broj poslovnice] = '" + item + "'";
                        SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                        string PoslId2 = sqlCmd2.ExecuteScalar().ToString();

                        query = "INSERT INTO Poslovnica_Users VALUES(" + UserId + "," + PoslId2 + ")";
                        SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                        sqlCmd3.ExecuteScalar();
                    }
                }
                lblUnosRegPoslovnice.Text = "Unos uspješan.";
            }
            else
            {
                lblUnosRegPoslovnice.Text = "Nemate pravo unosa.";
            }
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblGreska.Text = "Došlo je do pogreškre pri update-u.";
                e.ExceptionHandled = true;
            }

        }
    }
}