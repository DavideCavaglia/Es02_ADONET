using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es02_ADONET
{
    public partial class Default : System.Web.UI.Page
    {
        //popolare una DropDownList con le marche automobili
        //al cambiare della selezione popolare una seconda DropDownList 
        //con i modelli e visualizzare un immagine della vettura
        clsDB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Inserire cartelle aspnet
            //App_Code per classi Tasto destro su App_Code e aggiungi elemento esistente
            //(ricordarsi di impostare proprietà contenuto a compilazione)
            //App_Data per DataBase
            db = new clsDB("App_Data\\Automobili.mdf");
            
            //vedo se la pagina è stata richiesta la prima volta
            //o le successive in seguito al Postback (roundTrip)
            if (!Page.IsPostBack)
            {
                popolacmbMarche();
                popolacmbModelli(cmbMarche.SelectedValue);
            }
            
        }

        private void popolacmbMarche()
        {
            cmbMarche.DataSource = db.CaricaMarche();
            cmbMarche.DataValueField = "IdMarca"; //campo nascosto per la chiave
            cmbMarche.DataTextField = "Marca";//campo da visualizzare
            cmbMarche.DataBind(); //senza questo metodo non fa visualizzare i dati nella dropdown list
            ListItem l = new ListItem();
            l.Value = "-1";
            l.Text = "---Selezionare Marca---";
            cmbMarche.Items.Insert(0,l);
            //l = new ListItem("pluto");
            //cmbMarche.Items.Add(l);
            //l = new ListItem("topolino");
            //cmbMarche.Items.Add(l);
            //cmbMarche.DataBind();
        }

        private void popolacmbModelli(string idMarca)
        {
            cmbModelli.DataSource = db.CaricaModelli(idMarca);
            cmbModelli.DataValueField = "IdAuto"; //campo nascosto per la chiave
            cmbModelli.DataTextField = "Modello";//campo da visualizzare
            cmbModelli.DataBind();
            ListItem l = new ListItem();
            l.Value = "-1";
            l.Text = "---Selezionare Modelli---";
            cmbModelli.Items.Insert(0, l);

        }
        protected void cmbMarche_SelectedIndexChanged(object sender, EventArgs e)
        {
            popolacmbModelli(cmbMarche.SelectedValue);
            //l'unico controllo che genera una richeista al server è il submit
            //in ASPNET la richiesta viene chiamata PostBack
            //per ovviare a questa limitazione i controlli hanno una proprietà chiamata autoPostBack
        }

        protected void cmbModelli_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgModello.ImageUrl = db.leggiUrl(cmbModelli.SelectedValue);
        }

        protected void btnScelta_Click(object sender, EventArgs e)
        {

            //l'unico controllo che genera una richeista al server è il submit
            //in ASPNET la richiesta viene chiamata PostBack
            //per ovviare a questa limitazione i controlli hanno una proprietà chiamata autoPostBack
        }
    }
}