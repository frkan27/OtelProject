using Otel.BLL.Repository;
using Otel.Models.ViewModels;
using Otel.WFA.Dialogs;
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

namespace Otel.WFA
{
    public partial class FrmRezervasyon : Form
    {
        public FrmRezervasyon()
        {
            InitializeComponent();
        }

        private void FrmRezervasyon_Load(object sender, EventArgs e)
        {
            GetRooms();
        }

        private void GetRooms()
        {
            try
            {
                lstOdalar.DataSource = new RoomRepo()
                    .GetAll()//tüm verileri repodan getirdim.
                    .Select(x => new RoomViewModel()//Gelen veriyi roomview tipinde listledim.
                    {
                        Id=x.Id,
                        Name=x.Name,
                        Price=x.Price,
                        IsEmpty=x.IsEmpty,
                        IsUseable=x.IsUseable,
                        RoomType=x.RoomType

                    })//Bu listeyi de datasource a bastım.
                    .ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                ReservationRegisterForm dialog = new ReservationRegisterForm();

            }
        }
        private ReservationRegisterForm registerDialog;
        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            if (lstOdalar.SelectedItem == null) return;
            var selectedRoom = lstOdalar.SelectedItem as RoomViewModel;
            int kisiSayisi = Convert.ToInt32(nukisi.Value);//decimal geldiği için integer a ceviriyorum.
            try
            {
                switch (selectedRoom.RoomType)
                {
                    case Models.Enum.RoomTypes.Single:
                        if (kisiSayisi > 1)
                            throw new Exception("maksimum 1 kisilik secebilirsiniz.");
                            break;
                    case Models.Enum.RoomTypes.Double:
                        if (kisiSayisi > 2)
                            throw new Exception("maksimum 2 kisilik secebilirsiniz.");
                        break;
                    case Models.Enum.RoomTypes.Triple:
                        if (kisiSayisi > 3)
                            throw new Exception("maksimum 3 kisilik secebilirsiniz.");
                        break;
                    case Models.Enum.RoomTypes.Suite:
                        if (kisiSayisi > 3)
                            throw new Exception("maksimum 3 kisilik secebilirsiniz.");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            registerDialog = new ReservationRegisterForm();
            List<ReservationRegisterViewModel> model = GenerateRegisterDialog(registerDialog, kisiSayisi);
            if(model!=null)
            {
                try
                {
                    var id = new ReservationRepo().MakeReservation(new MakeReservationModel()
                    {
                        CheckOutDate = dtpCikis.Value,
                        ReservationDate = dtpGiris.Value,
                        RoomId = selectedRoom.Id,
                        RegisterViewModels = model
                    });
                    MessageBox.Show("rezervasyonunuz oluştu")
                }
                catch (Exception ex)
                {

                    MessageBox.Show("hata oluştu"+ex.Message9;
                }
            }
        }

        private List<ReservationRegisterViewModel> GenerateRegisterDialog(ReservationRegisterForm dialog, int kisiSayisi)
        {
            for (int i = 0; i < kisiSayisi; i++)
            {
                var lbl = new Label
                {
                    Text = (i + 1) + ".Kisi"
                };
                dialog.flpPanel.Controls.Add(lbl);//erişebilmek için panelin modifier ınıpublic yaptık.
                var uc = new ReservasyonkisiUserControl();
                dialog.flpPanel.Controls.Add(uc);
            }
            var btn = new Button
            {
                Text = "Kaydet",
                Size = new Size(106, 32),
                DialogResult = DialogResult.OK
            };
            dialog.AcceptButton = btn;//enter a basınca calısır. 
            dialog.flpPanel.Controls.Add(btn);
            DialogResult cevap= dialog.ShowDialog();
            if (cevap==DialogResult.OK)
            {
                return dialog.Models;
            }
            return null;
        }
        
    }
}
