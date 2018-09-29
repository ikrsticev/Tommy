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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LabelLogin.Text = "";

            //Local Admin
            if (txtUsername.Text == "Admin" && txtPassword.Text == "Ttom83Mt")
            {
                Session["username"] = "Admin";
                Response.Redirect("Admin.aspx");
            }
            else
            {
                //Active Directory login
                bool isValid = false;
                bool ADcon = true;
                try
                {
                    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.252.4"))
                    {
                        // validate the credentials
                        isValid = pc.ValidateCredentials(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    }
                }
                catch
                {
                    LabelLogin.Text = "Ne može se pristupiti Active Directoryu.";
                    ADcon = false;
                }

                if (isValid)
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                    {
                        sqlCon.Open();

                        string query = "SELECT COUNT(1) FROM Users WHERE username=@username";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count == 1)
                        {
                            Session["username"] = txtUsername.Text.Trim();

                            //Spremamo UserId u Session dictionary
                            query = "SELECT UserId FROM Users WHERE username=@username";
                            SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                            sqlCmd3.Parameters.AddWithValue("@username", Session["username"]);
                            Session["ID"] = int.Parse(sqlCmd3.ExecuteScalar().ToString());

                            //Provjeravamo je li račun neaktivan
                            query = "SELECT disabled FROM Users WHERE UserId = @UserId";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.Parameters.AddWithValue("@UserId", Session["ID"]);
                            bool disabled = Convert.ToBoolean(sqlCmd5.ExecuteScalar());

                            if (!disabled)
                            {
                                //Pamtimo login
                                query = "INSERT INTO Logins VALUES (CURRENT_TIMESTAMP, @UserId)";
                                SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                                sqlCmd4.Parameters.AddWithValue("@UserId", Session["ID"]);
                                sqlCmd4.ExecuteScalar();

                                //Uzimamo Razinu korisnika iz baze koja će 
                                //odrediti stranicu na koju se korisnik preusmjerava
                                query = "SELECT RazinaId FROM Users WHERE username=@username";
                                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                                sqlCmd2.Parameters.AddWithValue("@username", Session["username"]);

                                //Provjeravamo je li korisnik ima pravo unosa
                                query = "SELECT write FROM Users WHERE UserId = @UserId";
                                SqlCommand sqlCmd6 = new SqlCommand(query, sqlCon);
                                sqlCmd6.Parameters.AddWithValue("UserId", Session["ID"]);
                                Session["Write"] = Convert.ToBoolean(sqlCmd6.ExecuteScalar());

                                Session["Razina"] = int.Parse(sqlCmd2.ExecuteScalar().ToString());
                                switch (Session["Razina"])
                                {
                                    case 1:
                                        Response.Redirect("Admin.aspx");
                                        break;
                                    case 2:
                                        Response.Redirect("Regionalni menadzer.aspx");
                                        break;
                                    case 3:
                                        Response.Redirect("Poslovnica.aspx");
                                        break;
                                    case 4:
                                        Response.Redirect("Korisnik.aspx");
                                        break;

                                }
                            }
                            else
                            {
                                LabelLogin.Text = "Ovaj račun je disabled (neaktivan).";
                            }
                        }
                        else
                        {
                            LabelLogin.Text = "Korisnik je u AD-u, ali ne u bazi.";
                        }
                    }
                }
                else if(ADcon)
                {
                    LabelLogin.Text = "Netočna kombinacija imena i lozinke";
                }
            }
        }
    }
}