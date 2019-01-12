using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Otel.Models.ViewModels;

namespace Otel.WFA.UserControls
{
    public partial class ReservasyonkisiUserControl : UserControl
    {
        public ReservasyonkisiUserControl()
        {
            InitializeComponent();
        }
        //public string FirstName => txtAd.Text;//Sadece get kullanacağımdan böyle yapabilirim.Kısayoldan readonly yapmak.
        //public string Surname => txtSoyad.Text;

        //public string Telephone => txtTelefon.Text;
        //Bunları tek tek alacağıma ReservationRegisterViewModel tasarlayıp modelle ordan alırım.

        public ReservationRegisterViewModel Model => new ReservationRegisterViewModel()
        {
            FirstName=txtAd.Text,
            Surname=txtSoyad.Text,
            Telephone=txtTelefon.Text
        };




    }
}
