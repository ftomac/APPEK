using APPEK2.DB;
using APPEK2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;

namespace APPEK2
{
    public partial class Navigacija : System.Web.UI.Page
    {
        Korisnik korisnik;
        DBConnect baza;

        protected void Page_Load(object sender, EventArgs e)
        {
            korisnik = (Korisnik)Session["user"];
            baza = new DBConnect();

            if (!korisnik.Admin)
                rbNavigacija.Items[0].Enabled = false;

            if (korisnik.Admin)
            {
                rbNavigacija.Items[1].Enabled = false;
                rbNavigacija.Items[2].Enabled = false;
            }
                
                
        }

        protected void btnUlazak_Click(object sender, EventArgs e)
        {
            if (rbNavigacija.SelectedIndex == 0)
            {
                Session["admin"] = true;
                
                Response.Redirect("index.aspx");
            }
            else if (rbNavigacija.SelectedIndex == 1)
            {
                Session["admin"] = false;
                Session["odabraniLab"] = "Lab1";

                Response.Redirect("index.aspx");
            }
            else
            {
                Session["admin"] = false;
                Session["odabraniLab"] = "Lab2";

                Response.Redirect("index.aspx");
            }
        }
    }
}