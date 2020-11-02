using System;
using System.Windows.Forms;


namespace adresar
{
    class Kontakt
    {
        private string ime;
        private string prezime;
        private string broj;
        private string id;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public string Broj
        {
            get { return broj; }
            set
            {
                broj = value;
            }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public  Kontakt(){
            Ime="Nemanja";
            Prezime = "Mihajlovic";
            Broj = "0655002731";
            id = "";
        }
        public Kontakt(string ime,string prezime,string broj,string id)
        {
            Ime = ime;
            Prezime = prezime;
            Broj = broj;
            Id = id;
        }
        public override string ToString()
        {
            string output = string.Empty;
            output += string.Format("{0}, {1} ", Prezime, Ime, Id);

            return output;
        }


    }
}
