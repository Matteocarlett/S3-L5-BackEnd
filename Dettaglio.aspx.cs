using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace S3_L5
{
    public partial class Dettaglio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {        
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Default defaultPage = new Default();
                    Articolo articolo = defaultPage.Articoli.FirstOrDefault(a => a.Id == id);
                    if (articolo != null)
                    {
                        imgArticolo.ImageUrl = articolo.ImmagineUrl;
                        litNome.Text = articolo.Nome;
                        litDescrizione.Text = articolo.Descrizione;
                        litPrezzo.Text = articolo.Prezzo.ToString("C");
                    }
                }
            }
        }

        protected void btnAggiungiCarrello_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    Carrello cart = Session["Carrello"] as Carrello;
                    if (cart == null)
                    {
                        cart = new Carrello();
                        Session["Carrello"] = cart;
                    }

                    Default defaultPage = new Default();
                    Articolo articolo = defaultPage.Articoli.FirstOrDefault(a => a.Id == id);

                    if (articolo != null)
                    {
                        cart.Articoli.Add(articolo);

                        AggiornaTotale(cart);
                    }
                }
            }
        }



        protected void btnVaiDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private void AggiornaTotale(Carrello cart)
        {
            decimal totale = cart.Articoli.Sum(a => a.Prezzo);
            Session["TotaleCarrello"] = totale;
        }
    }
}
