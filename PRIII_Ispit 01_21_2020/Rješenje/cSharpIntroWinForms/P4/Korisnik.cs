using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpIntroWinForms
{
    [Table("Korisnik")]
    public class Korisnik
    {
        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        //public Image Slika { get; set; }
        public byte[] Slika { get; set; }

        public virtual Spolovi Spol { get; set; }
        //public string Spol { get; set; }
        public bool Admin { get; set; }
        public List<PolozeniPredmet> Polozeni { get; set; } = new List<PolozeniPredmet>();
        public virtual List<KorisniciPredmeti> Uspjeh { get; set; } = new List<KorisniciPredmeti>();


        public override string ToString()
        {
            return $"{Ime} {Prezime} ({KorisnickoIme})";
        }
        public double ProsjekStudenta()
        {
            double prosjek = 0;

            foreach (var predmet in Uspjeh)
            {
                prosjek += predmet.Ocjena;
            }

            if (Uspjeh.Count > 0)
                prosjek /= Uspjeh.Count;

            return Math.Round(prosjek, 2);
        }
        public List<Predmeti> LoadNepolozene()
        {
            List<Predmeti> predmeti = new List<Predmeti>();
            bool provjera = false;
            foreach (var predmet in konekcijaNaBazu.Predmeti)
            {
                foreach (var polozeni in Uspjeh)
                {
                    if (predmet == polozeni.Predmet)
                    {
                        provjera = true;
                        break;
                    }
                }
                if (!provjera)
                    predmeti.Add(predmet);
                provjera = false;
            }
            return predmeti;
        }
    }
}
