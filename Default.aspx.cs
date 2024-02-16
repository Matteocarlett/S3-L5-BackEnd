using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace S3_L5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (Articolo articolo in Articoli)
                {
                    if (articolo.Descrizione.Length > 35)
                    {
                        articolo.Descrizione = articolo.Descrizione.Substring(0, 35) + "...";
                    }
                }

                ArticoliRepeater.DataSource = Articoli;
                ArticoliRepeater.DataBind();
            }
        }

        public Articolo[] Articoli { get; } = {
       new Articolo { Id = 2, Nome = "Razer Huntsman Elite", Descrizione = "Una tastiera meccanica premium con switch ottici Razer per una risposta ultraveloce. Retroilluminazione personalizzabile Chroma RGB e supporto per poggia polsi magnetico.", Prezzo = 199.99m, ImmagineUrl = "https://i.ebayimg.com/images/g/wkoAAOSwrjxiTU2Y/s-l1600.png",DimensioneImmagine = "200px" },
       new Articolo { Id = 3, Nome = "SteelSeries Arctis Pro", Descrizione = "Cuffie wireless di alta qualità con audio ad alta risoluzione e trasmissione audio senza perdita. Comfort duraturo e microfono con cancellazione del rumore.", Prezzo = 329.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/71zIU+i27PL._AC_SL1433_.jpg",DimensioneImmagine = "200px"},
       new Articolo { Id = 4, Nome = "ASUS ROG Swift PG279Q", Descrizione = "Monitor da 27 pollici con risoluzione 1440p, frequenza di aggiornamento di 165Hz e supporto G-Sync per un'esperienza di gioco fluida e priva di strappi.", Prezzo = 699.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/51b6iSblA2L._AC_SL1000_.jpg",DimensioneImmagine = "200px"},
       new Articolo { Id = 5, Nome = "Secretlab Titan", Descrizione = "Una sedia ergonomica progettata per il massimo comfort durante le lunghe sessioni di gioco. Rivestimento in pelle PU di alta qualità, supporto lombare regolabile e funzione di inclinazione.", Prezzo = 399.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/81PY7dNQkTL.__AC_SX300_SY300_QL70_ML2_.jpg",DimensioneImmagine = "150px"},
       new Articolo { Id = 7, Nome = "Razer Orbweaver Chroma", Descrizione = "Tastierino numerico ergonomico con switch meccanici Razer per un controllo personalizzabile e retroilluminazione Chroma RGB.", Prezzo = 129.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/61xvq+dzo7L._AC_SY300_SX300_.jpg",DimensioneImmagine = "150px"},
       new Articolo { Id = 9, Nome = "Logitech StreamCam", Descrizione = "Webcam Full HD con registrazione video a 1080p e streaming a 60 fps. Dotata di correzione automatica dell'illuminazione e software di streaming integrato.", Prezzo = 169.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/71JkixZlp-L.__AC_SX300_SY300_QL70_ML2_.jpg",DimensioneImmagine = "170px"},
       new Articolo { Id = 11, Nome = "Blue Yeti X", Descrizione = "Microfono USB di alta qualità con registrazione vocale a 24-bit e modalità di registrazione multiple per podcasting, streaming e registrazione musicale.", Prezzo = 169.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/61yw+MkDwpL._AC_SY300_SX300_.jpg",DimensioneImmagine = "70px"},
       new Articolo { Id = 12, Nome = "Samsung Odyssey G7", Descrizione = "Monitor curvo da 32 pollici con risoluzione 1440p, frequenza di aggiornamento di 240Hz e supporto HDR per un'esperienza di gioco immersiva.", Prezzo = 799.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/817CJPmX5wL.__AC_SY300_SX300_QL70_ML2_.jpg",DimensioneImmagine = "200px"},
       new Articolo { Id = 13, Nome = "HyperX Cloud Alpha", Descrizione = "Cuffie cablate con audio surround virtuale 7.1, driver da 50mm e comfort imbottito per lunghe sessioni di gioco.", Prezzo = 99.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/71qhdYulkAL.__AC_SX300_SY300_QL70_ML2_.jpg",DimensioneImmagine = "200px"},
       new Articolo { Id = 14, Nome = "Razer BlackWidow Tournament Edition Chroma V2", Descrizione = "Tastiera meccanica compatta con switch Razer per un'esperienza di gioco reattiva. Retroilluminazione Chroma RGB personalizzabile e design portatile.", Prezzo = 139.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/61O3LfLgwUL.__AC_SY300_SX300_QL70_ML2_.jpg",DimensioneImmagine ="200px"},
       new Articolo { Id = 15, Nome = "Elgato Stream Deck", Descrizione = "Pannello di controllo con tasti LCD personalizzabili per facilitare il controllo di trasmissioni in diretta, registrazione di video e flussi di lavoro creativi.", Prezzo = 149.99m, ImmagineUrl = "https://m.media-amazon.com/images/I/81xN-mI5KBL.__AC_SX300_SY300_QL70_ML2_.jpg",DimensioneImmagine = "200px" },
       new Articolo { Id = 6, Nome = "HyperX Fury S", Descrizione = "Un grande mousepad con superficie in tessuto morbido per un controllo preciso del mouse e base in gomma antiscivolo.", Prezzo = 19.99m, ImmagineUrl = "https://i.ebayimg.com/images/g/PHsAAOSwtuBlpT5S/s-l1600.jpg",DimensioneImmagine = "180px"},

    };

        protected void btnAggiungiCarrello_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Button).CommandArgument);

            Carrello cart = Session["Carrello"] as Carrello;

            if (cart == null)
            {
                cart = new Carrello();
                Session["Carrello"] = cart;
            }

            Default defaultPage = new Default();
            Articolo articolo = defaultPage.Articoli.FirstOrDefault(a => a.Id == id);

            cart.Articoli.Add(articolo);

            AggiornaTotale(cart);
        }


        private void AggiornaTotale(Carrello cart)
        {
            decimal totale = cart.Articoli.Sum(a => a.Prezzo);
            litTotale.Text = totale.ToString("C");
        }
    }
}
