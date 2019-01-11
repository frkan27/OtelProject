using Otel.BLL.Repository;
using Otel.Models.Entities;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {//boşun secilipsecilmediğini kontrol edip ona göre subcategoryi null yapıcaz.
            if (cmbKategori.SelectedItem == null) return;
            try
            {
                var selectedCate = cmbKategori.SelectedItem as CategoryCmbViewModel;
                new CategoryRepo().Insert(new Category()//insert kaydetme işlemi.
                {
                    Name = txtKategoriAdi.Text,
                    Description=rtbAciklama.Text,
                    SupCategoryId=selectedCate.Id==0?(int?)null:selectedCate.Id 
                    //Eğer secili kategorinin ıd si =sıfırsa üst kategori ekliyorumdur.
                    //==0 sa null değilse ıd yi ekle.
                });
                

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            GetCategories();
        }

        private void GetCategories()
        {
            var categories = new List<CategoryCmbViewModel>();
            categories.Add(new CategoryCmbViewModel()
            {
                Id=0,
                Name="Boş"
            });//Başta  boş gelsin istiyorum.
            try
            {
                categories.AddRange(new CategoryRepo().GetAll().OrderBy(x => x.Name)
                        //Diğer kategorilerde veri tabanından gelsin diye kategorireponun getall metoduyla hepsini cağırdım.
                        .Select(x => new CategoryCmbViewModel()
                //gelen tüm kategorileri selectle kategoriviewmodel ceviriyoruz.
                {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            TotalSubCategory = x.Categories.Count
                    //x.categories alt kategorilerin listesini veriyor.subcategorylerin sayısını verir.
                }
                        ));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            cmbKategori.DataSource = categories;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCategories();
        }
    }
}
