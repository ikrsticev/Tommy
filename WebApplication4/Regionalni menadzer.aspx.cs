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
            if (Session["ID"] == null || Session["Razina"].ToString() != 2.ToString())
            {
                Session.Clear();
                Response.Redirect("Login.aspx.cs");
            }

            if (!IsPostBack)
            {
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

                    query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 4 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                    SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                    sqlCmd3.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                    SqlDataReader dr2 = sqlCmd3.ExecuteReader();
                    while (dr2.Read())
                    {
                        txtPoslovnicaUBR.Text = dr2["Ukupan_broj_radnika"].ToString();
                        txtPoslovnicaBRKR.Text = dr2["Broj_radnika_koji_su_radili"].ToString();
                        txtPoslovnicaBRSD.Text = dr2["Broj_radnika_na_slobodnim_danima"].ToString();
                        txtPoslovnicaBRGO.Text = dr2["Broj_radnika_na_godisnjem_odmoru"].ToString();
                        txtPoslovnicaBRKB.Text = dr2["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                        txtPoslovnicaBRDB.Text = dr2["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                        txtPoslovnicaBS.Text = dr2["Broj_studenata"].ToString();
                        txtPoslovnicaSati.Text = dr2["Utroseni_radni_sati"].ToString();
                        txtPoslovnicaPromet.Text = dr2["Promet"].ToString();
                        txtPoslovnicaUcinkovitost.Text = dr2["Ucinkovitost"].ToString();
                    }
                    dr2.Close();

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

                            query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 1 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                            SqlDataReader dr3 = sqlCmd5.ExecuteReader();

                            if (dr3.HasRows)
                            {
                                while (dr3.Read())
                                {
                                    txtMesnicaUBR.Text = dr3["Ukupan_broj_radnika"].ToString();
                                    txtMesnicaBRKR.Text = dr3["Broj_radnika_koji_su_radili"].ToString();
                                    txtMesnicaBRSD.Text = dr3["Broj_radnika_na_slobodnim_danima"].ToString();
                                    txtMesnicaBRGO.Text = dr3["Broj_radnika_na_godisnjem_odmoru"].ToString();
                                    txtMesnicaBRKB.Text = dr3["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                                    txtMesnicaBRDB.Text = dr3["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                                    txtMesnicaBS.Text = dr3["Broj_studenata"].ToString();
                                    txtMesnicaSati.Text = dr3["Utroseni_radni_sati"].ToString();
                                    txtMesnicaPromet.Text = dr3["Promet"].ToString();
                                    txtMesnicaUcinkovitost.Text = dr3["Ucinkovitost"].ToString();
                                }
                            }
                            dr3.Close();
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

                            query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 2 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                            SqlDataReader dr3 = sqlCmd5.ExecuteReader();
                            if (dr3.HasRows)
                            {
                                while (dr3.Read())
                                {
                                    txtRibarnicaUBR.Text = dr3["Ukupan_broj_radnika"].ToString();
                                    txtRibarnicaBRKR.Text = dr3["Broj_radnika_koji_su_radili"].ToString();
                                    txtRibarnicaBRSD.Text = dr3["Broj_radnika_na_slobodnim_danima"].ToString();
                                    txtRibarnicaBRGO.Text = dr3["Broj_radnika_na_godisnjem_odmoru"].ToString();
                                    txtRibarnicaBRKB.Text = dr3["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                                    txtRibarnicaBRDB.Text = dr3["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                                    txtRibarnicaBS.Text = dr3["Broj_studenata"].ToString();
                                    txtRibarnicaSati.Text = dr3["Utroseni_radni_sati"].ToString();
                                    txtRibarnicaPromet.Text = dr3["Promet"].ToString();
                                    txtRibarnicaUcinkovitost.Text = dr3["Ucinkovitost"].ToString();
                                }
                            }
                            dr3.Close();
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

                            query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 3 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                            SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                            sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                            SqlDataReader dr3 = sqlCmd5.ExecuteReader();
                            if (dr3.HasRows)
                            {
                                while (dr3.Read())
                                {
                                    txtGastroUBR.Text = dr3["Ukupan_broj_radnika"].ToString();
                                    txtGastroBRKR.Text = dr3["Broj_radnika_koji_su_radili"].ToString();
                                    txtGastroBRSD.Text = dr3["Broj_radnika_na_slobodnim_danima"].ToString();
                                    txtGastroBRGO.Text = dr3["Broj_radnika_na_godisnjem_odmoru"].ToString();
                                    txtGastroBRKB.Text = dr3["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                                    txtGastroBRDB.Text = dr3["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                                    txtGastroBS.Text = dr3["Broj_studenata"].ToString();
                                    txtGastroSati.Text = dr3["Utroseni_radni_sati"].ToString();
                                    txtGastroPromet.Text = dr3["Promet"].ToString();
                                    txtGastroUcinkovitost.Text = dr3["Ucinkovitost"].ToString();
                                }
                            }
                            dr3.Close();
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

        protected void btnUnesi_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Write"]))
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
                    if (txtPoslovnicaUBR.Text.Length > 7) { throw new ArgumentException(); }
                    double.Parse(txtPoslovnicaBRKR.Text);
                    if (txtPoslovnicaBRKR.Text.Length > 7) { throw new ArgumentException(); }
                    if (txtPoslovnicaBRSD.Text != "") { double.Parse(txtPoslovnicaBRSD.Text); }
                    if (txtPoslovnicaBRSD.Text.Length > 7) { throw new ArgumentException(); }
                    if (txtPoslovnicaBRGO.Text != "") { double.Parse(txtPoslovnicaBRGO.Text); }
                    if (txtPoslovnicaBRGO.Text.Length > 7) { throw new ArgumentException(); }
                    if (txtPoslovnicaBRKB.Text != "") { double.Parse(txtPoslovnicaBRKB.Text); }
                    if (txtPoslovnicaBRKB.Text.Length > 7) { throw new ArgumentException(); }
                    if (txtPoslovnicaBRDB.Text != "") { double.Parse(txtPoslovnicaBRDB.Text); }
                    if (txtPoslovnicaBRDB.Text.Length > 7) { throw new ArgumentException(); }
                    if (txtPoslovnicaBS.Text != "") { double.Parse(txtPoslovnicaBS.Text); }
                    if (txtPoslovnicaBS.Text.Length > 7) { throw new ArgumentException(); }
                    double.Parse(txtPoslovnicaSati.Text);
                    if (txtPoslovnicaSati.Text.Length > 7) { throw new ArgumentException(); }
                    double.Parse(txtPoslovnicaPromet.Text);
                    if (txtPoslovnicaPromet.Text.Length > 7) { throw new ArgumentException(); }
                    double.Parse(txtPoslovnicaUcinkovitost.Text);
                    if (txtPoslovnicaUcinkovitost.Text.Length > 7) { throw new ArgumentException(); }
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
                        if (txtMesnicaUBR.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtMesnicaBRKR.Text);
                        if (txtMesnicaBRKR.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtMesnicaBRSD.Text != "") { double.Parse(txtMesnicaBRSD.Text); }
                        if (txtMesnicaBRSD.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtMesnicaBRGO.Text != "") { double.Parse(txtMesnicaBRGO.Text); }
                        if (txtMesnicaBRGO.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtMesnicaBRKB.Text != "") { double.Parse(txtMesnicaBRKB.Text); }
                        if (txtMesnicaBRKB.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtMesnicaBRDB.Text != "") { double.Parse(txtMesnicaBRDB.Text); }
                        if (txtMesnicaBRDB.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtMesnicaBS.Text != "") { double.Parse(txtMesnicaBS.Text); }
                        if (txtMesnicaBS.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtMesnicaSati.Text);
                        if (txtMesnicaSati.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtMesnicaPromet.Text);
                        if (txtMesnicaPromet.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtMesnicaUcinkovitost.Text);
                        if (txtMesnicaUcinkovitost.Text.Length > 7) { throw new ArgumentException(); }
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
                        if (txtRibarnicaUBR.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtRibarnicaBRKR.Text);
                        if (txtRibarnicaBRKR.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtRibarnicaBRSD.Text != "") { double.Parse(txtRibarnicaBRSD.Text); }
                        if (txtRibarnicaBRSD.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtRibarnicaBRGO.Text != "") { double.Parse(txtRibarnicaBRGO.Text); }
                        if (txtRibarnicaBRGO.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtRibarnicaBRKB.Text != "") { double.Parse(txtRibarnicaBRKB.Text); }
                        if (txtRibarnicaBRKB.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtRibarnicaBRDB.Text != "") { double.Parse(txtRibarnicaBRDB.Text); }
                        if (txtRibarnicaBRDB.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtRibarnicaBS.Text != "") { double.Parse(txtRibarnicaBS.Text); }
                        if (txtRibarnicaBS.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtRibarnicaSati.Text);
                        if (txtRibarnicaSati.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtRibarnicaPromet.Text);
                        if (txtRibarnicaPromet.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtRibarnicaUcinkovitost.Text);
                        if (txtRibarnicaUcinkovitost.Text.Length > 7) { throw new ArgumentException(); }
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
                        if (txtGastroUBR.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtGastroBRKR.Text);
                        if (txtGastroBRKR.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtGastroBRSD.Text != "") { double.Parse(txtGastroBRSD.Text); }
                        if (txtGastroBRSD.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtGastroBRGO.Text != "") { double.Parse(txtGastroBRGO.Text); }
                        if (txtGastroBRGO.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtGastroBRKB.Text != "") { double.Parse(txtGastroBRKB.Text); }
                        if (txtGastroBRKB.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtGastroBRDB.Text != "") { double.Parse(txtGastroBRDB.Text); }
                        if (txtGastroBRDB.Text.Length > 7) { throw new ArgumentException(); }
                        if (txtGastroBS.Text != "") { double.Parse(txtGastroBS.Text); }
                        if (txtGastroBS.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtGastroSati.Text);
                        if (txtGastroSati.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtGastroPromet.Text);
                        if (txtGastroPromet.Text.Length > 7) { throw new ArgumentException(); }
                        double.Parse(txtGastroUcinkovitost.Text);
                        if (txtGastroUcinkovitost.Text.Length > 7) { throw new ArgumentException(); }
                    }
                    catch
                    {
                        lblLabela.Text += "Neispravan unos: gastro<br>";
                        unos = false;
                    }
                }
                if (unos)
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
                    {
                        sqlCon.Open();

                        bool odjeliRows = false;
                        string query = "SELECT * FROM Report WHERE LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11) and PoslovnicaId = @PoslovnicaId";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                        SqlDataReader dr = sqlCmd5.ExecuteReader();
                        if (dr.HasRows) { odjeliRows = true; }
                        dr.Close();

                        if (odjeliRows)
                        {
                            query = @"UPDATE Report
                                SET Ukupan_broj_radnika = @PoslovnicaUBR, Broj_radnika_koji_su_radili = @PoslovnicaBRKR,
                                Broj_radnika_na_slobodnim_danima = @PoslovnicaBRSD, Broj_radnika_na_godisnjem_odmoru = @PoslovnicaBRGO,
                                Broj_radnika_na_kratkotrajnom_bolovanju = @PoslovnicaBRKB, Broj_radnika_na_dugotrajnom_bolovanju = @PoslovnicaBRDB,
                                Broj_studenata = @PoslovnicaBS, Utroseni_radni_sati = @PoslovnicaSati, 
                                Promet = @PoslovnicaPromet, Ucinkovitost = @PoslovnicaUcinkovitost, Datum = CURRENT_TIMESTAMP
                                WHERE OdjelId = 4 and PoslovnicaId = @PoslovnicaId and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaUBR", Convert.ToDouble(txtPoslovnicaUBR.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRKR", Convert.ToDouble(txtPoslovnicaBRKR.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRSD", Convert.ToDouble(txtPoslovnicaBRSD.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRGO", Convert.ToDouble(txtPoslovnicaBRGO.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRKB", Convert.ToDouble(txtPoslovnicaBRKB.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRDB", Convert.ToDouble(txtPoslovnicaBRDB.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBS", Convert.ToDouble(txtPoslovnicaBS.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaSati", Convert.ToDouble(txtPoslovnicaSati.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaPromet", Convert.ToDouble(txtPoslovnicaPromet.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaUcinkovitost", Convert.ToDouble(txtPoslovnicaUcinkovitost.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                            sqlCmd.ExecuteScalar();
                        }
                        else
                        {
                            query = @"INSERT INTO Report
                            VALUES(@PoslovnicaUBR, @PoslovnicaBRKR, @PoslovnicaBRSD, @PoslovnicaBRGO, @PoslovnicaBRKB, @PoslovnicaBRDB, @PoslovnicaBS, @PoslovnicaSati, @PoslovnicaPromet, @PoslovnicaUcinkovitost, CURRENT_TIMESTAMP, 4, @PoslovnicaId)";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaUBR", Convert.ToDouble(txtPoslovnicaUBR.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRKR", Convert.ToDouble(txtPoslovnicaBRKR.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRSD", Convert.ToDouble(txtPoslovnicaBRSD.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRGO", Convert.ToDouble(txtPoslovnicaBRGO.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRKB", Convert.ToDouble(txtPoslovnicaBRKB.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBRDB", Convert.ToDouble(txtPoslovnicaBRDB.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaBS", Convert.ToDouble(txtPoslovnicaBS.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaSati", Convert.ToDouble(txtPoslovnicaSati.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaPromet", Convert.ToDouble(txtPoslovnicaPromet.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaUcinkovitost", Convert.ToDouble(txtPoslovnicaUcinkovitost.Text));
                            sqlCmd.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                            sqlCmd.ExecuteScalar();
                        }

                        if (mesnica)
                        {
                            if (odjeliRows)
                            {
                                query = @"UPDATE Report
                                SET Ukupan_broj_radnika = @MesnicaUBR, Broj_radnika_koji_su_radili = @MesnicaBRKR,
                                Broj_radnika_na_slobodnim_danima = @MesnicaBRSD, Broj_radnika_na_godisnjem_odmoru = @MesnicaBRGO,
                                Broj_radnika_na_kratkotrajnom_bolovanju = @MesnicaBRKB, Broj_radnika_na_dugotrajnom_bolovanju = @MesnicaBRDB,
                                Broj_studenata = @MesnicaBS, Utroseni_radni_sati = @MesnicaSati, 
                                Promet = @MesnicaPromet, Ucinkovitost = @MesnicaUcinkovitost, Datum = CURRENT_TIMESTAMP
                                WHERE OdjelId = 1 and PoslovnicaId = @PoslovnicaId and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MesnicaUBR", Convert.ToDouble(txtMesnicaUBR.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaBRKR", Convert.ToDouble(txtMesnicaBRKR.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaBRSD", Convert.ToDouble(txtMesnicaBRSD.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaBRGO", Convert.ToDouble(txtMesnicaBRGO.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaBRKB", Convert.ToDouble(txtMesnicaBRKB.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaBRDB", Convert.ToDouble(txtMesnicaBRDB.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaBS", Convert.ToDouble(txtMesnicaBS.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaSati", Convert.ToDouble(txtMesnicaSati.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaPromet", Convert.ToDouble(txtMesnicaPromet.Text));
                                sqlCmd.Parameters.AddWithValue("@MesnicaUcinkovitost", Convert.ToDouble(txtMesnicaUcinkovitost.Text));
                                sqlCmd.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                                sqlCmd.ExecuteScalar();
                            }
                            else
                            {
                                query = @"INSERT INTO Report
                            VALUES(@MesnicaUBR, @MesnicaBRKR, @MesnicaBRSD, @MesnicaBRGO, @MesnicaBRKB, @MesnicaBRDB, @MesnicaBS, @MesnicaSati, @MesnicaPromet, @MesnicaUcinkovitost, CURRENT_TIMESTAMP, 1, @PoslovnicaId)";
                                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                                sqlCmd2.Parameters.AddWithValue("@MesnicaUBR", Convert.ToDouble(txtMesnicaUBR.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaBRKR", Convert.ToDouble(txtMesnicaBRKR.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaBRSD", Convert.ToDouble(txtMesnicaBRSD.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaBRGO", Convert.ToDouble(txtMesnicaBRGO.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaBRKB", Convert.ToDouble(txtMesnicaBRKB.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaBRDB", Convert.ToDouble(txtMesnicaBRDB.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaBS", Convert.ToDouble(txtMesnicaBS.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaSati", Convert.ToDouble(txtMesnicaSati.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaPromet", Convert.ToDouble(txtMesnicaPromet.Text));
                                sqlCmd2.Parameters.AddWithValue("@MesnicaUcinkovitost", Convert.ToDouble(txtMesnicaUcinkovitost.Text));
                                sqlCmd2.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                                sqlCmd2.ExecuteScalar();
                            }
                        }
                        if (ribarnica)
                        {
                            if (odjeliRows)
                            {
                                query = @"UPDATE Report
                                SET Ukupan_broj_radnika = @RibarnicaUBR, Broj_radnika_koji_su_radili = @RibarnicaBRKR,
                                Broj_radnika_na_slobodnim_danima = @RibarnicaBRSD, Broj_radnika_na_godisnjem_odmoru = @RibarnicaBRGO,
                                Broj_radnika_na_kratkotrajnom_bolovanju = @RibarnicaBRKB, Broj_radnika_na_dugotrajnom_bolovanju = @RibarnicaBRDB,
                                Broj_studenata = @RibarnicaBS, Utroseni_radni_sati = @RibarnicaSati, 
                                Promet = @RibarnicaPromet, Ucinkovitost = @RibarnicaUcinkovitost, Datum = CURRENT_TIMESTAMP
                                WHERE OdjelId = 2 and PoslovnicaId = @PoslovnicaId and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@RibarnicaUBR", Convert.ToDouble(txtRibarnicaUBR.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaBRKR", Convert.ToDouble(txtRibarnicaBRKR.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaBRSD", Convert.ToDouble(txtRibarnicaBRSD.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaBRGO", Convert.ToDouble(txtRibarnicaBRGO.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaBRKB", Convert.ToDouble(txtRibarnicaBRKB.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaBRDB", Convert.ToDouble(txtRibarnicaBRDB.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaBS", Convert.ToDouble(txtRibarnicaBS.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaSati", Convert.ToDouble(txtRibarnicaSati.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaPromet", Convert.ToDouble(txtRibarnicaPromet.Text));
                                sqlCmd.Parameters.AddWithValue("@RibarnicaUcinkovitost", Convert.ToDouble(txtRibarnicaUcinkovitost.Text));
                                sqlCmd.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                                sqlCmd.ExecuteScalar();
                            }
                            else
                            {
                                query = @"INSERT INTO Report
                            VALUES(@RibarnicaUBR, @RibarnicaBRKR, @RibarnicaBRSD, @RibarnicaBRGO, @RibarnicaBRKB, @RibarnicaBRDB, @RibarnicaBS, @RibarnicaSati, @RibarnicaPromet, @RibarnicaUcinkovitost, CURRENT_TIMESTAMP, 2, @PoslovnicaId)";
                                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaUBR", Convert.ToDouble(txtRibarnicaUBR.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaBRKR", Convert.ToDouble(txtRibarnicaBRKR.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaBRSD", Convert.ToDouble(txtRibarnicaBRSD.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaBRGO", Convert.ToDouble(txtRibarnicaBRGO.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaBRKB", Convert.ToDouble(txtRibarnicaBRKB.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaBRDB", Convert.ToDouble(txtRibarnicaBRDB.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaBS", Convert.ToDouble(txtRibarnicaBS.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaSati", Convert.ToDouble(txtRibarnicaSati.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaPromet", Convert.ToDouble(txtRibarnicaPromet.Text));
                                sqlCmd2.Parameters.AddWithValue("@RibarnicaUcinkovitost", Convert.ToDouble(txtRibarnicaUcinkovitost.Text));
                                sqlCmd2.Parameters.AddWithValue("@PoslovnicaId", Convert.ToDouble(Session["PoslId"]));
                                sqlCmd2.ExecuteScalar();
                            }
                        }
                        if (gastro)
                        {
                            if (odjeliRows)
                            {
                                query = @"UPDATE Report
                                SET Ukupan_broj_radnika = @GastroUBR, Broj_radnika_koji_su_radili = @GastroBRKR,
                                Broj_radnika_na_slobodnim_danima = @GastroBRSD, Broj_radnika_na_godisnjem_odmoru = @GastroBRGO,
                                Broj_radnika_na_kratkotrajnom_bolovanju = @GastroBRKB, Broj_radnika_na_dugotrajnom_bolovanju = @GastroBRDB,
                                Broj_studenata = @GastroBS, Utroseni_radni_sati = @GastroSati, 
                                Promet = @GastroPromet, Ucinkovitost = @GastroUcinkovitost, Datum = CURRENT_TIMESTAMP
                                WHERE OdjelId = 3 and PoslovnicaId = @PoslovnicaId and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@GastroUBR", Convert.ToDouble(txtGastroUBR.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroBRKR", Convert.ToDouble(txtGastroBRKR.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroBRSD", Convert.ToDouble(txtGastroBRSD.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroBRGO", Convert.ToDouble(txtGastroBRGO.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroBRKB", Convert.ToDouble(txtGastroBRKB.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroBRDB", Convert.ToDouble(txtGastroBRDB.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroBS", Convert.ToDouble(txtGastroBS.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroSati", Convert.ToDouble(txtGastroSati.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroPromet", Convert.ToDouble(txtGastroPromet.Text));
                                sqlCmd.Parameters.AddWithValue("@GastroUcinkovitost", Convert.ToDouble(txtGastroUcinkovitost.Text));
                                sqlCmd.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                                sqlCmd.ExecuteScalar();
                            }
                            else
                            {
                                query = @"INSERT INTO Report
                            VALUES(@GastroUBR, @GastroBRKR, @GastroBRSD, @GastroBRGO, @GastroBRKB, @GastroBRDB, @GastroBS, @GastroSati, @GastroPromet, @GastroUcinkovitost, CURRENT_TIMESTAMP, 3, @PoslovnicaId)";
                                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                                sqlCmd2.Parameters.AddWithValue("@GastroUBR", Convert.ToDouble(txtGastroUBR.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroBRKR", Convert.ToDouble(txtGastroBRKR.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroBRSD", Convert.ToDouble(txtGastroBRSD.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroBRGO", Convert.ToDouble(txtGastroBRGO.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroBRKB", Convert.ToDouble(txtGastroBRKB.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroBRDB", Convert.ToDouble(txtGastroBRDB.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroBS", Convert.ToDouble(txtGastroBS.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroSati", Convert.ToDouble(txtGastroSati.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroPromet", Convert.ToDouble(txtGastroPromet.Text));
                                sqlCmd2.Parameters.AddWithValue("@GastroUcinkovitost", Convert.ToDouble(txtGastroUcinkovitost.Text));
                                sqlCmd2.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                                sqlCmd2.ExecuteScalar();
                            }
                        }
                    }
                    lblLabela.Text = "Unos uspješan.";
                }
            }
            else
            {
                lblLabela.Text = "Nemate pravo unosa.";
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
                    WHERE U.UserId = @UserId and P.[Broj Poslovnice] = @BrojPoslovnice";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserId", Session["ID"]);
                sqlCmd.Parameters.AddWithValue("@BrojPoslovnice", DropDownList1.SelectedValue.ToString());
                Session["PoslId"] = sqlCmd.ExecuteScalar().ToString();

                query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 4 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                sqlCmd3.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                SqlDataReader dr2 = sqlCmd3.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        txtPoslovnicaUBR.Text = dr2["Ukupan_broj_radnika"].ToString();
                        txtPoslovnicaBRKR.Text = dr2["Broj_radnika_koji_su_radili"].ToString();
                        txtPoslovnicaBRSD.Text = dr2["Broj_radnika_na_slobodnim_danima"].ToString();
                        txtPoslovnicaBRGO.Text = dr2["Broj_radnika_na_godisnjem_odmoru"].ToString();
                        txtPoslovnicaBRKB.Text = dr2["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                        txtPoslovnicaBRDB.Text = dr2["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                        txtPoslovnicaBS.Text = dr2["Broj_studenata"].ToString();
                        txtPoslovnicaSati.Text = dr2["Utroseni_radni_sati"].ToString();
                        txtPoslovnicaPromet.Text = dr2["Promet"].ToString();
                        txtPoslovnicaUcinkovitost.Text = dr2["Ucinkovitost"].ToString();
                    }
                }
                else
                {
                    txtPoslovnicaUBR.Text = "";
                    txtPoslovnicaBRKR.Text = "";
                    txtPoslovnicaBRSD.Text = "";
                    txtPoslovnicaBRGO.Text = "";
                    txtPoslovnicaBRKB.Text = "";
                    txtPoslovnicaBRDB.Text = "";
                    txtPoslovnicaBS.Text = "";
                    txtPoslovnicaSati.Text = "";
                    txtPoslovnicaPromet.Text = "";
                    txtPoslovnicaUcinkovitost.Text = "";
                }
                dr2.Close();

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

                        query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 1 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                        SqlDataReader dr3 = sqlCmd5.ExecuteReader();

                        if (dr3.HasRows)
                        {
                            while (dr3.Read())
                            {
                                txtMesnicaUBR.Text = dr3["Ukupan_broj_radnika"].ToString();
                                txtMesnicaBRKR.Text = dr3["Broj_radnika_koji_su_radili"].ToString();
                                txtMesnicaBRSD.Text = dr3["Broj_radnika_na_slobodnim_danima"].ToString();
                                txtMesnicaBRGO.Text = dr3["Broj_radnika_na_godisnjem_odmoru"].ToString();
                                txtMesnicaBRKB.Text = dr3["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                                txtMesnicaBRDB.Text = dr3["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                                txtMesnicaBS.Text = dr3["Broj_studenata"].ToString();
                                txtMesnicaSati.Text = dr3["Utroseni_radni_sati"].ToString();
                                txtMesnicaPromet.Text = dr3["Promet"].ToString();
                                txtMesnicaUcinkovitost.Text = dr3["Ucinkovitost"].ToString();
                            }
                        }
                        else
                        {
                            txtMesnicaUBR.Text = "";
                            txtMesnicaBRKR.Text = "";
                            txtMesnicaBRSD.Text = "";
                            txtMesnicaBRGO.Text = "";
                            txtMesnicaBRKB.Text = "";
                            txtMesnicaBRDB.Text = "";
                            txtMesnicaBS.Text = "";
                            txtMesnicaSati.Text = "";
                            txtMesnicaPromet.Text = "";
                            txtMesnicaUcinkovitost.Text = "";
                        }
                        dr3.Close();
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

                        txtMesnicaUBR.Text = "";
                        txtMesnicaBRKR.Text = "";
                        txtMesnicaBRSD.Text = "";
                        txtMesnicaBRGO.Text = "";
                        txtMesnicaBRKB.Text = "";
                        txtMesnicaBRDB.Text = "";
                        txtMesnicaBS.Text = "";
                        txtMesnicaSati.Text = "";
                        txtMesnicaPromet.Text = "";
                        txtMesnicaUcinkovitost.Text = "";
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

                        query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 2 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                        SqlDataReader dr3 = sqlCmd5.ExecuteReader();
                        if (dr3.HasRows)
                        {
                            while (dr3.Read())
                            {
                                txtRibarnicaUBR.Text = dr3["Ukupan_broj_radnika"].ToString();
                                txtRibarnicaBRKR.Text = dr3["Broj_radnika_koji_su_radili"].ToString();
                                txtRibarnicaBRSD.Text = dr3["Broj_radnika_na_slobodnim_danima"].ToString();
                                txtRibarnicaBRGO.Text = dr3["Broj_radnika_na_godisnjem_odmoru"].ToString();
                                txtRibarnicaBRKB.Text = dr3["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                                txtRibarnicaBRDB.Text = dr3["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                                txtRibarnicaBS.Text = dr3["Broj_studenata"].ToString();
                                txtRibarnicaSati.Text = dr3["Utroseni_radni_sati"].ToString();
                                txtRibarnicaPromet.Text = dr3["Promet"].ToString();
                                txtRibarnicaUcinkovitost.Text = dr3["Ucinkovitost"].ToString();
                            }
                        }
                        else
                        {
                            txtRibarnicaUBR.Text = "";
                            txtRibarnicaBRKR.Text = "";
                            txtRibarnicaBRSD.Text = "";
                            txtRibarnicaBRGO.Text = "";
                            txtRibarnicaBRKB.Text = "";
                            txtRibarnicaBRDB.Text = "";
                            txtRibarnicaBS.Text = "";
                            txtRibarnicaSati.Text = "";
                            txtRibarnicaPromet.Text = "";
                            txtRibarnicaUcinkovitost.Text = "";
                        }
                        dr3.Close();
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

                        txtRibarnicaUBR.Text = "";
                        txtRibarnicaBRKR.Text = "";
                        txtRibarnicaBRSD.Text = "";
                        txtRibarnicaBRGO.Text = "";
                        txtRibarnicaBRKB.Text = "";
                        txtRibarnicaBRDB.Text = "";
                        txtRibarnicaBS.Text = "";
                        txtRibarnicaSati.Text = "";
                        txtRibarnicaPromet.Text = "";
                        txtRibarnicaUcinkovitost.Text = "";
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

                        query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 3 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                        SqlDataReader dr3 = sqlCmd5.ExecuteReader();
                        if (dr3.HasRows)
                        {
                            while (dr3.Read())
                            {
                                txtGastroUBR.Text = dr3["Ukupan_broj_radnika"].ToString();
                                txtGastroBRKR.Text = dr3["Broj_radnika_koji_su_radili"].ToString();
                                txtGastroBRSD.Text = dr3["Broj_radnika_na_slobodnim_danima"].ToString();
                                txtGastroBRGO.Text = dr3["Broj_radnika_na_godisnjem_odmoru"].ToString();
                                txtGastroBRKB.Text = dr3["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                                txtGastroBRDB.Text = dr3["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                                txtGastroBS.Text = dr3["Broj_studenata"].ToString();
                                txtGastroSati.Text = dr3["Utroseni_radni_sati"].ToString();
                                txtGastroPromet.Text = dr3["Promet"].ToString();
                                txtGastroUcinkovitost.Text = dr3["Ucinkovitost"].ToString();
                            }
                        }
                        else
                        {
                            txtGastroUBR.Text = "";
                            txtGastroBRKR.Text = "";
                            txtGastroBRSD.Text = "";
                            txtGastroBRGO.Text = "";
                            txtGastroBRKB.Text = "";
                            txtGastroBRDB.Text = "";
                            txtGastroBS.Text = "";
                            txtGastroSati.Text = "";
                            txtGastroPromet.Text = "";
                            txtGastroUcinkovitost.Text = "";
                        }
                        dr3.Close();
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

                        txtGastroUBR.Text = "";
                        txtGastroBRKR.Text = "";
                        txtGastroBRSD.Text = "";
                        txtGastroBRGO.Text = "";
                        txtGastroBRKB.Text = "";
                        txtGastroBRDB.Text = "";
                        txtGastroBS.Text = "";
                        txtGastroSati.Text = "";
                        txtGastroPromet.Text = "";
                        txtGastroUcinkovitost.Text = "";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}