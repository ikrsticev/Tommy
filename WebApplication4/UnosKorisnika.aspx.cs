using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Data.SqlClient;


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
            
            if(txtUsername.Text.Length == 0)
            {
                unos = false;
                lblLabela.Text += "Username prazan.";
            }
            else
            {
                //Provjerava je li korisnik već unešen
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                {
                    sqlCon.Open();

                    string query = "SELECT COUNT(1) FROM Users WHERE username=@username";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        unos = false;
                        lblLabela.Text += "Korisnik je već u bazi.";
                    }
                }

                //Provjera je li korisnik postoji u AD-u
                bool isValid;
                
                try
                {
                    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain,"192.168.252.4", "sso.appizvjestaji", "Nak0nN0ciD0laziDan"))
                    {
                        UserPrincipal foundUser = UserPrincipal.FindByIdentity(pc, IdentityType.UserPrincipalName, txtUsername.Text.Trim());
                        
                        isValid =  foundUser != null;
                        
                    }
                }
                catch
                {
                    lblLabela.Text += "Ne može se pristupiti Active Directoryu ili korisnik ne postoji. ";
                    unos = false;
                }

            }
            if (!txtIme.Text.All(Char.IsLetter) && !rdb3.Checked)
            {
                unos = false;
                lblLabela.Text += "Ime smije sadržavati samo slova. ";
            }

            if (txtPrezime.Text.Any(Char.IsNumber) || txtPrezime.Text.Any(Char.IsPunctuation) && !rdb3.Checked)
            {
                unos = false;
                lblLabela.Text += "Prezime neispravno. ";
            }

            if(!rdb3.Checked && (txtIme.Text.Length == 0 || txtPrezime.Text.Length == 0))
            {
                unos = false;
                lblLabela.Text += "Ime i/ili prezime smiju biti prazni samo ako je odabrana poslovnica. ";
            }

            if (unos && IsValid)
            {
                string razina;
                if (rdb1.Checked) { razina = "1"; }
                else if (rdb2.Checked) { razina = "2"; }
                else if (rdb3.Checked) { razina = "3"; }
                else { razina = "4"; }

                //Unos novog korisnika
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                {
                    sqlCon.Open();

                    string query = @"INSERT INTO Users VALUES('" + txtUsername.Text + "','" +
                        txtIme.Text + "','" + txtPrezime.Text + "','" + razina + "','" + cbxDisabled.Checked
                        + "','" + cbxWrite.Checked + "')";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteScalar();

                    query = "SELECT SCOPE_IDENTITY()";
                    SqlCommand sqlCmd6 = new SqlCommand(query, sqlCon);
                    string UserId = sqlCmd6.ExecuteScalar().ToString();

                    lblLabela.Text += "Unos uspješan.";

                    //Poslovnica
                    if (razina == "3")
                    {
                        query = "INSERT INTO Poslovnica VALUES('" + txtUsername.Text + "')";
                        SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                        sqlCmd2.ExecuteScalar();

                        query = "SELECT SCOPE_IDENTITY()";
                        SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                        string PoslId = sqlCmd3.ExecuteScalar().ToString();

                        query = "INSERT INTO Poslovnica_Users VALUES('" + UserId + "','" + PoslId + "')";
                        SqlCommand sqlCmd7 = new SqlCommand(query, sqlCon);
                        sqlCmd7.ExecuteScalar();

                        query = "INSERT INTO Odjel_Poslovnica VALUES(4,'" + PoslId + "')";
                        SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                        sqlCmd4.ExecuteScalar();

                        if (cbxMesnica.Checked)
                        {
                            query = "INSERT INTO Odjel_Poslovnica VALUES(1,'" + PoslId + "')";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.ExecuteScalar();
                        }
                        if (cbxRibarnica.Checked)
                        {
                            query = "INSERT INTO Odjel_Poslovnica VALUES(2,'" + PoslId + "')";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.ExecuteScalar();
                        }
                        if (cbxGastro.Checked)
                        {
                            query = "INSERT INTO Odjel_Poslovnica VALUES(3,'" + PoslId + "')";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.ExecuteScalar();
                        }
                    }

                    //Regionalni menadžer
                    if(razina == "2")
                    {
                        foreach(object item in ListBox1.Items)
                        {
                            query = "SELECT PoslovnicaId FROM Poslovnica WHERE [Broj poslovnice] = '" + item.ToString() + "'";
                            SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                            string PoslId = sqlCmd2.ExecuteScalar().ToString();

                            query = "INSERT INTO Poslovnica_Users VALUES('" + UserId + "','" + PoslId + "')";
                            SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                            sqlCmd3.ExecuteScalar();
                        }
                    }

                    //Unos Korisnika
                    if(razina == "4")
                    {
                        query = "SELECT PoslovnicaId FROM Poslovnica WHERE [Broj poslovnice] = '" + ListBox1.Items[0].ToString() + "'";
                        SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                        string PoslId = sqlCmd2.ExecuteScalar().ToString();

                        query = "INSERT INTO Poslovnica_Users VALUES('" + UserId + "','" + PoslId + "')";
                        SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                        sqlCmd3.ExecuteScalar();
                    }
                }
            }
            else
            {
                lblLabela.Text = "Neuspješan unos. " + lblLabela.Text;
            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void btnDodajPoslovnicu_Click(object sender, EventArgs e)
        {
            if((rdb2.Checked || (rdb4.Checked && ListBox1.Items.Count == 0)) && !ListBox1.Items.Contains(DropDownList1.SelectedItem))
            {
                ListBox1.Items.Add(DropDownList1.SelectedItem.Value);
                ListBox1.Visible = true;
            }
                
        }

        protected void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1.Checked)
            {
                DropDownList1.Enabled = false;
                ListBox1.Items.Clear();
                ListBox1.Visible = false;
                btnDodajPoslovnicu.Enabled = false;

                cbxMesnica.Visible = false;
                cbxRibarnica.Visible = false;
                cbxGastro.Visible = false;
                lblOdijeli.Visible = false;
            }
        }

        protected void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb3.Checked)
            {
                DropDownList1.Enabled = false;
                ListBox1.Items.Clear();
                ListBox1.Visible = false;
                btnDodajPoslovnicu.Enabled = false;

                cbxMesnica.Visible = true;
                cbxRibarnica.Visible = true;
                cbxGastro.Visible = true;
                lblOdijeli.Visible = true;
            }
        }

        protected void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2.Checked)
            {
                btnDodajPoslovnicu.Enabled = true;
                DropDownList1.Enabled = true;

                cbxMesnica.Visible = false;
                cbxRibarnica.Visible = false;
                cbxGastro.Visible = false;
                lblOdijeli.Visible = false;
            }
        }

        protected void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb4.Checked)
            {
                btnDodajPoslovnicu.Enabled = true;
                ListBox1.Items.Clear();
                DropDownList1.Enabled = true;

                cbxMesnica.Visible = false;
                cbxRibarnica.Visible = false;
                cbxGastro.Visible = false;
                lblOdijeli.Visible = false;
            }
        }
    }
}