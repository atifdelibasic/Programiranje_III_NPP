using Microsoft.Reporting.WinForms;
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
    public partial class Izvjestaj : Form
    {
        private Korisnik korisnik;
        private GodineStudija godinaStudija;

        public Izvjestaj()
        {
            InitializeComponent();
        }

        public Izvjestaj(Korisnik korisnik, GodineStudija godina) :this()
        {
            this.korisnik = korisnik;
            this.godinaStudija = godina;
        }

        private void Izvjestaj_Load(object sender, EventArgs e)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImePrezime", $"{korisnik.Ime} {korisnik.Prezime}"));
            rpc.Add(new ReportParameter("Prosjek", $"Prosjek: {korisnik.Prosjek().ToString()}"));

            DataSet.TblPolozeniDataTable tbl = new DataSet.TblPolozeniDataTable();

            foreach (var uspjeh in korisnik.Uspjeh)
            {
                if (godinaStudija == uspjeh.GodineStudija || godinaStudija == null)
                {
                    DataSet.TblPolozeniRow red = tbl.NewTblPolozeniRow();
                    red.Ocjena = uspjeh.Ocjena;
                    red.Predmet = uspjeh.Predmet.Naziv;
                    red.Datum = uspjeh.Datum;
                    tbl.AddTblPolozeniRow(red);
                }
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "RepTblPolozeni";
            rds.Value = tbl;

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

    }
}
