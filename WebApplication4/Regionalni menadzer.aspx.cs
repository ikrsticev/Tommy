using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class Regionalni_menadzer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUnesi_Click(object sender, EventArgs e)
        {
            bool unos = true;

            lblLabela.Text = "";

            bool mesnica = false;
            bool ribarnica = false;
            bool gastro = false;
            string odjeli = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {
                sqlCon.Open();
                string query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = " + Session["PoslId"];
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    odjeli += dr["OdjelId"];
                }
                dr.Close();
                if (odjeli != "")
                {
                    if (odjeli.Contains("1"))
                    {
                        mesnica = true;
                    }
                    if (odjeli.Contains("2"))
                    {
                        ribarnica = true;
                    }
                    if (odjeli.Contains("3"))
                    {
                        gastro = true;
                    }
                }
            }

            //Provjera unosa za svaki odijel

            try
            {
                double.Parse(txtPoslovnicaUBR.Text);
                double.Parse(txtPoslovnicaBRKR.Text);
                if (txtPoslovnicaBRSD.Text != "") { double.Parse(txtPoslovnicaBRSD.Text); }
                if (txtPoslovnicaBRGO.Text != "") { double.Parse(txtPoslovnicaBRSD.Text); }
                if (txtPoslovnicaBRKB.Text != "") { double.Parse(txtPoslovnicaBRSD.Text); }
                if (txtPoslovnicaBRDB.Text != "") { double.Parse(txtPoslovnicaBRSD.Text); }
                if (txtPoslovnicaBS.Text != "") { double.Parse(txtPoslovnicaBRSD.Text); }
                double.Parse(txtPoslovnicaSati.Text);
                double.Parse(txtPoslovnicaPromet.Text);
                double.Parse(txtPoslovnicaUcinkovitost.Text);
            }
            catch
            {
                lblLabela.Text += "Neispravan unos: poslovnica<br>";
                unos = false;
            }
            
            if (mesnica)
            {
                try
                {
                    double.Parse(txtMesnicaUBR.Text);
                    double.Parse(txtMesnicaBRKR.Text);
                    if (txtMesnicaBRSD.Text != "") { double.Parse(txtMesnicaBRSD.Text); }
                    if (txtMesnicaBRGO.Text != "") { double.Parse(txtMesnicaBRGO.Text); }
                    if (txtMesnicaBRKB.Text != "") { double.Parse(txtMesnicaBRKB.Text); }
                    if (txtMesnicaBRDB.Text != "") { double.Parse(txtMesnicaBRDB.Text); }
                    if (txtMesnicaBS.Text != "") { double.Parse(txtMesnicaBS.Text); }
                    double.Parse(txtMesnicaSati.Text);
                    double.Parse(txtMesnicaPromet.Text);
                    double.Parse(txtMesnicaUcinkovitost.Text);
                }
                catch
                {
                    lblLabela.Text += "Neispravan unos: mesnica<br>";
                    unos = false;
                }
            }

            if (ribarnica)
            {
                try
                {
                    double.Parse(txtRibarnicaUBR.Text);
                    double.Parse(txtRibarnicaBRKR.Text);
                    if (txtRibarnicaBRSD.Text != "") { double.Parse(txtRibarnicaBRSD.Text); }
                    if (txtRibarnicaBRGO.Text != "") { double.Parse(txtRibarnicaBRGO.Text); }
                    if (txtRibarnicaBRKB.Text != "") { double.Parse(txtRibarnicaBRKB.Text); }
                    if (txtRibarnicaBRDB.Text != "") { double.Parse(txtRibarnicaBRDB.Text); }
                    if (txtRibarnicaBS.Text != "") { double.Parse(txtRibarnicaBS.Text); }
                    double.Parse(txtRibarnicaSati.Text);
                    double.Parse(txtRibarnicaPromet.Text);
                    double.Parse(txtRibarnicaUcinkovitost.Text);
                }
                catch
                {
                    lblLabela.Text += "Neispravan unos: ribarnica<br>";
                    unos = false;
                }
            }

            if (gastro)
            {
                try
                {
                    double.Parse(txtGastroUBR.Text);
                    double.Parse(txtGastroBRKR.Text);
                    if (txtGastroBRSD.Text != "") { double.Parse(txtGastroBRSD.Text); }
                    if (txtGastroBRGO.Text != "") { double.Parse(txtGastroBRGO.Text); }
                    if (txtGastroBRKB.Text != "") { double.Parse(txtGastroBRKB.Text); }
                    if (txtGastroBRDB.Text != "") { double.Parse(txtGastroBRDB.Text); }
                    if (txtGastroBS.Text != "") { double.Parse(txtGastroBS.Text); }
                    double.Parse(txtGastroSati.Text);
                    double.Parse(txtGastroPromet.Text);
                    double.Parse(txtGastroUcinkovitost.Text);
                }
                catch
                {
                    lblLabela.Text += "Neispravan unos: gastro<br>";
                    unos = false;
                }
            }

            if (unos)
            {
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                    {
                        sqlCon.Open();

                        string query = @"INSERT INTO Report
                                    VALUES(" + txtPoslovnicaUBR.Text + ", " + txtPoslovnicaBRKR.Text + ", " + txtPoslovnicaBRSD.Text + ", " +
                                        txtPoslovnicaBRGO.Text + ", " + txtPoslovnicaBRKB.Text + ", " + txtPoslovnicaBRDB.Text + ", " +
                                        txtPoslovnicaBS.Text + ", " + txtPoslovnicaSati.Text + ", " + txtPoslovnicaPromet.Text + ", " + txtPoslovnicaUcinkovitost.Text + ", CURRENT_TIMESTAMP, " + "4," + Session["PoslId"] + ")";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteScalar();

                        if (mesnica)
                        {
                            query = @"INSERT INTO Report
                                    VALUES(" + txtMesnicaUBR.Text + ", " + txtMesnicaBRKR.Text + ", " + txtMesnicaBRSD.Text + ", " +
                                        txtMesnicaBRGO.Text + ", " + txtMesnicaBRKB.Text + ", " + txtMesnicaBRDB.Text + ", " +
                                        txtMesnicaBS.Text + ", " + txtMesnicaSati.Text + ", " + txtMesnicaPromet.Text + ", " + txtMesnicaUcinkovitost.Text + ", CURRENT_TIMESTAMP, " + "1," + Session["PoslId"] + ")";
                            SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                            sqlCmd2.ExecuteScalar();
                        }
                        if (ribarnica)
                        {
                            query = @"INSERT INTO Report
                                    VALUES(" + txtRibarnicaUBR.Text + ", " + txtRibarnicaBRKR.Text + ", " + txtRibarnicaBRSD.Text + ", " +
                                        txtRibarnicaBRGO.Text + ", " + txtRibarnicaBRKB.Text + ", " + txtRibarnicaBRDB.Text + ", " +
                                        txtRibarnicaBS.Text + ", " + txtRibarnicaSati.Text + ", " + txtRibarnicaPromet.Text + ", " + txtRibarnicaUcinkovitost.Text + ", CURRENT_TIMESTAMP, " + "2," + Session["PoslId"] + ")";
                            SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                            sqlCmd3.ExecuteScalar();
                        }
                        if (gastro)
                        {
                            query = @"INSERT INTO Report
                                    VALUES(" + txtGastroUBR.Text + ", " + txtGastroBRKR.Text + ", " + txtGastroBRSD.Text + ", " +
                                        txtGastroBRGO.Text + ", " + txtGastroBRKB.Text + ", " + txtGastroBRDB.Text + ", " +
                                        txtGastroBS.Text + ", " + txtGastroSati.Text + ", " + txtGastroPromet.Text + ", " + txtGastroUcinkovitost.Text + ", CURRENT_TIMESTAMP, " + "3," + Session["PoslId"] + ")";
                            SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                            sqlCmd4.ExecuteScalar();
                        }
                    }
                    lblLabela.Text = "Unos uspješan.";
                }
                catch
                {
                    lblLabela.Text = "Promijenite poslovnicu.";
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {
                sqlCon.Open();

                string query = @"SELECT P.PoslovnicaId from Users U
                    left outer join Poslovnica_Users PU on PU.UserId = U.UserId
                    left outer join Poslovnica P on PU.PoslovnicaId = P.PoslovnicaId
                    WHERE U.UserId = @UserId and P.[Broj Poslovnice] = '" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserId", Session["ID"]);
                Session["PoslId"] = sqlCmd.ExecuteScalar().ToString();

                string odjeli = "";
                query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = " + Session["PoslId"];
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd2.ExecuteReader();
                while (dr.Read())
                {
                    odjeli += dr["OdjelId"];
                }
                dr.Close();
                if (odjeli != "")
                {
                    if (odjeli.Contains("1"))
                    {
                        txtMesnicaUBR.Enabled = true;
                        txtMesnicaBRKR.Enabled = true;
                        txtMesnicaBRSD.Enabled = true;
                        txtMesnicaBRGO.Enabled = true;
                        txtMesnicaBRKB.Enabled = true;
                        txtMesnicaBRDB.Enabled = true;
                        txtMesnicaBS.Enabled = true;
                        txtMesnicaSati.Enabled = true;
                        txtMesnicaPromet.Enabled = true;
                        txtMesnicaUcinkovitost.Enabled = true;
                    }
                    else
                    {
                        txtMesnicaUBR.Enabled = false;
                        txtMesnicaBRKR.Enabled = false;
                        txtMesnicaBRSD.Enabled = false;
                        txtMesnicaBRGO.Enabled = false;
                        txtMesnicaBRKB.Enabled = false;
                        txtMesnicaBRDB.Enabled = false;
                        txtMesnicaBS.Enabled = false;
                        txtMesnicaSati.Enabled = false;
                        txtMesnicaPromet.Enabled = false;
                        txtMesnicaUcinkovitost.Enabled = false;
                    }
                    if (odjeli.Contains("2"))
                    {
                        txtRibarnicaUBR.Enabled = true;
                        txtRibarnicaBRKR.Enabled = true;
                        txtRibarnicaBRSD.Enabled = true;
                        txtRibarnicaBRGO.Enabled = true;
                        txtRibarnicaBRKB.Enabled = true;
                        txtRibarnicaBRDB.Enabled = true;
                        txtRibarnicaBS.Enabled = true;
                        txtRibarnicaSati.Enabled = true;
                        txtRibarnicaPromet.Enabled = true;
                        txtRibarnicaUcinkovitost.Enabled = true;
                    }
                    else
                    {
                        txtRibarnicaUBR.Enabled = false;
                        txtRibarnicaBRKR.Enabled = false;
                        txtRibarnicaBRSD.Enabled = false;
                        txtRibarnicaBRGO.Enabled = false;
                        txtRibarnicaBRKB.Enabled = false;
                        txtRibarnicaBRDB.Enabled = false;
                        txtRibarnicaBS.Enabled = false;
                        txtRibarnicaSati.Enabled = false;
                        txtRibarnicaPromet.Enabled = false;
                        txtRibarnicaUcinkovitost.Enabled = false;
                    }
                    if (odjeli.Contains("3"))
                    {
                        txtGastroUBR.Enabled = true;
                        txtGastroBRKR.Enabled = true;
                        txtGastroBRSD.Enabled = true;
                        txtGastroBRGO.Enabled = true;
                        txtGastroBRKB.Enabled = true;
                        txtGastroBRDB.Enabled = true;
                        txtGastroBS.Enabled = true;
                        txtGastroSati.Enabled = true;
                        txtGastroPromet.Enabled = true;
                        txtGastroUcinkovitost.Enabled = true;
                    }
                    else
                    {
                        txtGastroUBR.Enabled = false;
                        txtGastroBRKR.Enabled = false;
                        txtGastroBRSD.Enabled = false;
                        txtGastroBRGO.Enabled = false;
                        txtGastroBRKB.Enabled = false;
                        txtGastroBRDB.Enabled = false;
                        txtGastroBS.Enabled = false;
                        txtGastroSati.Enabled = false;
                        txtGastroPromet.Enabled = false;
                        txtGastroUcinkovitost.Enabled = false;
                    }
                }
            }
        }
    }
}