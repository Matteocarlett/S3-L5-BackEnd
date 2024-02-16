using System.Collections.Generic;

namespace S3_L5
{
    public partial class Carrello
    {
        public List<Articolo> Articoli { get; set; }

        public Carrello()
        {
            Articoli = new List<Articolo>();
        }

    }
}
