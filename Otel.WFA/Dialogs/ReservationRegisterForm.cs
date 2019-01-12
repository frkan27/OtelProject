using Otel.Models.ViewModels;
using Otel.WFA.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel.WFA.Dialogs
{
    public partial class ReservationRegisterForm : Form
    {
        public ReservationRegisterForm()
        {
            InitializeComponent();
            Models = new List<ReservationRegisterViewModel>();
            //new liyoruz ki null referans hatası alamasın.
        }

        public int Count { get; set; }
        public List<ReservationRegisterViewModel> Models { get; set; }
        //Kapanırken Models i doldurmam lazım.
        private void ReservationRegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Control control in this.flpPanel.Controls)
            {
                if (control is ReservasyonkisiUserControl rez)
                    Models.Add(rez.Model);

            }
        }
    }
}
