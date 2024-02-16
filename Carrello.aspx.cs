using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace S3_L5
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carrello cart = Session["Carrello"] as Carrello;
                if (cart != null)
                {
                    rptCarrello.DataSource = cart.Articoli;
                    rptCarrello.DataBind();
                    AggiornaTotale(cart);
                }
            }
        }
        protected void btnRimuovi_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Button).CommandArgument);
            Carrello cart = Session["Carrello"] as Carrello;
            if (cart != null)
            {
                Articolo articoloDaRimuovere = cart.Articoli.FirstOrDefault(a => a.Id == id);
                if (articoloDaRimuovere != null)
                {
                    cart.Articoli.Remove(articoloDaRimuovere);
                    AggiornaTotale(cart);
                    rptCarrello.DataSource = cart.Articoli;
                    rptCarrello.DataBind();
                }
            }
        }

        protected void btnSvuotaCarrello_Click(object sender, EventArgs e)
        {
            Carrello cart = Session["Carrello"] as Carrello;
            if (cart != null)
            {
                cart.Articoli.Clear();
                AggiornaTotale(cart);
                rptCarrello.DataSource = cart.Articoli;
                rptCarrello.DataBind();
            }
        }

        private void AggiornaTotale(Carrello cart)
        {
            decimal totale = cart.Articoli.Sum(a => a.Prezzo);
            litTotale.Text = totale.ToString("C");
        }
    }
}
