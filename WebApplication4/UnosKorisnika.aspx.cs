using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;


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
                bool isValid = false;
                try
                {
                    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.252.4", "sso.appizvjestaji", "Nak0nN0ciD0laziDan"))
                    {
                        using (var foundUser = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, tbxUsername.Text.Trim()))
                        {
                            isValid =  foundUser != null;
                        }
                    }
                }
                catch
                {
                    lblLabela.Text += "Ne može se pristupiti Active Directoryu. ";
                }
                if (!isValid)
                {
                    lblLabela.Text += "Korisnik nije pronađen u Active Directoryu. ";
                }
            }
            if (!tbxIme.Text.All(Char.IsLetter) && !rdb3.Checked)
            {
                unos = false;
                lblLabela.Text += "Ime smije sadržavati samo slova. ";
            }

            if (tbxPrezime.Text.Any(Char.IsNumber) || tbxPrezime.Text.Any(Char.IsPunctuation) && !rdb3.Checked)
            {
                unos = false;
                lblLabela.Text += "Prezime neispravno. ";
            }

            if(!rdb3.Checked && (tbxIme.Text.Length == 0 || tbxPrezime.Text.Length == 0))
            {
                unos = false;
                lblLabela.Text += "Ime i/ili prezime smiju biti prazni samo ako je odabrana poslovnica. ";
            }

            if (unos)
            {
                //Unos novog korisnika
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
    }
}