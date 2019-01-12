using Otel.BLL.Repository;
using Otel.Models.ViewModels;
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
            }
        }
    }
}
