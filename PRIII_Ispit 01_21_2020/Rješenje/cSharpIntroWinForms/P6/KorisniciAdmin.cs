using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms
{
    public partial class KorisniciAdmin : Form
    {

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciAdmin()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private void KorisniciAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
            lblProsjek.Text = IzracunajProsjek().ToString();
        }

        private void LoadData(List<Korisnik> korisnici = null)
        {
            try
            {
                List<Korisnik> rezultati = korisnici ?? konekcijaNaBazu.Korisnici.ToList();

                dgvKorisnici.DataSource = null;
                dgvKorisnici.DataSource = rezultati;

            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        private void TxtPretraga_TextChanged(object sender, EventArgs e)
        {
            lblProsjek.Text = IzracunajProsjek().ToString();
        }

        private double IzracunajProsjek()
        {
            double sum = 0;
            List<Korisnik> korisnici = Pretraga();
            if (korisnici != null)
            {
                foreach (var student in korisnici)
                {
                    sum += student.ProsjekStudenta();
                }
                if (sum > 0)
                    sum /= korisnici.Count;
            }
            return Math.Round(sum, 2);
        }

        private List<Korisnik> Pretraga()
        {
            string pretraga = txtPretraga.Text.ToLower();
            List<Korisnik> korisnici = null;
            if (!string.IsNullOrEmpty(pretraga))
            {
                korisnici = konekcijaNaBazu.Korisnici.Where(k => k.Ime.ToLower().Contains(pretraga) ||
                k.Prezime.ToLower().Contains(pretraga)).ToList();
                LoadData(korisnici);
            }
            else
            {
                korisnici = konekcijaNaBazu.Korisnici.ToList();
                LoadData();
            }

            return korisnici;
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKorisnici.Columns[e.ColumnIndex].Name == "Polozeni")
                {
                    Korisnik korisnik = dgvKorisnici.SelectedRows[0].DataBoundItem as Korisnik;
                    KorisniciPolozeniPredmeti kpp = new KorisniciPolozeniPredmeti(korisnik);
                    kpp.ShowDialog();
                    lblProsjek.Text = IzracunajProsjek().ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }
    }
}
