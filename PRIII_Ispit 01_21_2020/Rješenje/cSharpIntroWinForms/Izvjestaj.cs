using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace cSharpIntroWinForms
{
    public partial class Izvjestaj : Form
    {
        private Korisnik korisnik;
        public Izvjestaj()
        {
            InitializeComponent();
        }

        public Izvjestaj(Korisnik korisnik) :this()
        {
            this.korisnik = korisnik;
        }
        private void Izvjestaj_Load(object sender, EventArgs e)
        {

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImePrezime", $"Student: {korisnik.Ime} {korisnik.Prezime}"));
            rpc.Add(new ReportParameter("Prosjek", $"Prosjek studenta: {korisnik.ProsjekStudenta()}"));

            DataSet.tblPolozNepolozDataTable tbl = new DataSet.tblPolozNepolozDataTable();
            foreach (var uspjeh in korisnik.Uspjeh)
            {
                DataSet.tblPolozNepolozRow red = tbl.NewtblPolozNepolozRow();
                red.Ocjena = uspjeh.Ocjena.ToString();
                red.Datum = uspjeh.Datum;
                red.Predmet = uspjeh.Predmet.Naziv;
                tbl.Rows.Add(red);
            }

            foreach (var predmet in korisnik.LoadNepolozene())
            {
                DataSet.tblPolozNepolozRow red = tbl.NewtblPolozNepolozRow();
                red.Ocjena = red.Datum = "Nije polozeno!";
                red.Predmet = predmet.Naziv;
                tbl.Rows.Add(red);
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "tblPolozeniNepolozeni";
            rds.Value = tbl;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.RefreshReport();
        }
    }
}
