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

                query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = @PoslovnicaId";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                SqlDataReader dr = sqlCmd2.ExecuteReader();
                while (dr.Read())
                {
                    odjeli += dr["OdjelId"];
                }
                dr.Close();

                query = "SELECT [Broj Poslovnice] FROM Poslovnica WHERE PoslovnicaId = @PoslovnicaId ";
                SqlCommand sqlCmd3 = new SqlCommand(query, sqlCon);
                sqlCmd3.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                lblPoslovnica.Text = sqlCmd3.ExecuteScalar().ToString();

                query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 4 and LEFT(Datum,11) = LEFT(CURRENT_TIMESTAMP,11)";
                SqlCommand sqlCmd4 = new SqlCommand(query, sqlCon);
                sqlCmd4.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                SqlDataReader dr2 = sqlCmd4.ExecuteReader();
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
                dr2.Close();

                if (odjeli != "")
                {
                    if (odjeli.Contains("1"))
                    {
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
                    if (odjeli.Contains("2"))
                    {
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
                    if (odjeli.Contains("3"))
                    {
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
                    }
                }
                else { lblLabela.Text = "Došlo je do greške pri učitavanju podataka iz baze."; }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\praksa\TommyReport\WebApplication4\App_Data\Tommy_upgrade.mdf;Integrated Security=True"))
            {
                sqlCon.Open();

                string query = "SELECT * FROM Report WHERE LEFT(Datum,11) = @Datum and PoslovnicaId = @PoslovnicaId and OdjelId = 4";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Datum", DropDownList1.SelectedItem.Value);
                sqlCmd.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    txtPoslovnicaUBR.Text = dr["Ukupan_broj_radnika"].ToString();
                    txtPoslovnicaBRKR.Text = dr["Broj_radnika_koji_su_radili"].ToString();
                    txtPoslovnicaBRSD.Text = dr["Broj_radnika_na_slobodnim_danima"].ToString();
                    txtPoslovnicaBRGO.Text = dr["Broj_radnika_na_godisnjem_odmoru"].ToString();
                    txtPoslovnicaBRKB.Text = dr["Broj_radnika_na_kratkotrajnom_bolovanju"].ToString();
                    txtPoslovnicaBRDB.Text = dr["Broj_radnika_na_dugotrajnom_bolovanju"].ToString();
                    txtPoslovnicaBS.Text = dr["Broj_studenata"].ToString();
                    txtPoslovnicaSati.Text = dr["Utroseni_radni_sati"].ToString();
                    txtPoslovnicaPromet.Text = dr["Promet"].ToString();
                    txtPoslovnicaUcinkovitost.Text = dr["Ucinkovitost"].ToString();
                }
                dr.Close();

                string odjeli = "";
                query = "SELECT OdjelId FROM Odjel_Poslovnica OP left outer join Poslovnica P on P.PoslovnicaId = OP.PoslovnicaId WHERE P.PoslovnicaId = @PoslovnicaId";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                SqlDataReader dr2 = sqlCmd2.ExecuteReader();
                while (dr2.Read())
                {
                    odjeli += dr2["OdjelId"];
                }
                dr2.Close();
                if (odjeli != "")
                {
                    if (odjeli.Contains("1"))
                    {
                        query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 1 and LEFT(Datum,11) = @Datum";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@Datum", DropDownList1.SelectedItem.Value);
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
                        query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 2 and LEFT(Datum,11) = @Datum";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                        sqlCmd5.Parameters.AddWithValue("@Datum", DropDownList1.SelectedItem.Value);
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
                        query = "SELECT * FROM Report WHERE PoslovnicaId = @PoslovnicaId and OdjelId = 3 and LEFT(Datum,11) = @Datum";
                        SqlCommand sqlCmd5 = new SqlCommand(query, sqlCon);
                        sqlCmd5.Parameters.AddWithValue("@PoslovnicaId", Session["PoslId"]);
                        sqlCmd5.Parameters.AddWithValue("@Datum", DropDownList1.SelectedItem.Value);
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
    }
}