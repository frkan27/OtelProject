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
                MessageBox.Show("Kategorileri eklendi.");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            GetCategories();//ekleme yapınca combobox dolsun.
            GetCategoryTreeView();//Her ekleme yaptıktan somra treeview dolsun diye burda çağırdık.
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
            GetCategoryTreeView();
        }

        private void GetCategoryTreeView()
        {
            //burda kendini çağıran bir fonksiyon (recursive) yazmam lazım.
            //çünkü en üst menüden sonra ne kadar alt menü olcağı belli değil. her seferinde tekrar etmesi lazım.
            tvCategory.Nodes.Clear();
            var categories = new CategoryRepo().GetAll(x => x.SupCategoryId == null).OrderBy(x=>x.Name).ToList();//en üst kategoriler gelsin.subcategoryıd leri null çünkü.
            foreach (var category in categories)
            {
                //root u oluşturan mekanizma.
                TreeNode node = new TreeNode(category.Name);//category.Name i nodeaekliyor.//içeceklerin ismini yazdı.
                {
                    node.Tag = category.Id;//tag object tipinde oldupu için istefiğim değeri vereblirim.categoryıdyi gömüyorum
                }

                    tvCategory.Nodes.Add(node);//içeceklerin isminien dıstaki root a ekledi.
                if(category.Categories.Count>0)//içeceklerin içinde 2 alt kategori var. true oldu içeri girdi.
                {
                    SetSubNodes(node, category.Categories.ToList());
                }
            }

            tvCategory.ExpandAll();//hepsini açıyo dallı görünüş.
        }

        private void SetSubNodes(TreeNode node,List<Category> categories)
        //node nereye ekliceğimi söyliyeecek. list te içine neleri ekliceğimi.
        {
            foreach (var category in categories)//birden fazla kategori gelceğiiçin foreach.//iki tane var diyelim limonata ve kahve.
            {
                TreeNode subnode = new TreeNode(category.Name);
                {
                    node.Tag = category.Id;//etiket demek arka planda veri tasımak için kullanılır.
                }
                node.Nodes.Add(subnode);//bununda alt kategorisi varsa if le sorguluyoruz.//categoryname limonata yazıyor.
                if (category.Categories.Count>0)
                {
                    SetSubNodes(subnode, category.Categories.OrderBy(x => x.Name).ToList());
                    //metot içinde aynı metodu çağırıyorum.recursive metot.
                }
            }
        }
        private int? categoryId;//nullable yapıyorum cünkü kontrol edicem seçilipsecilmediğini.
        //treenode dan secim yapışdıktan sonra.
        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            categoryId = (int)e.Node.Tag;
            var category = new CategoryRepo().GetById(categoryId.Value);
            //seçili kategoriyi veri tabanında çekiyoruz.
            lstUrunler.DataSource = new ProductRepo()
                .GetAll(x=>x.CategoryId==categoryId)
                .OrderBy(x => x.Name)//secili categorynin products ı geldi.
                .Select(x => new ProductViewModel()//objemizi initializ edelim.//productviewmodel tipinde çağırdım.
                {
                    Name=x.Name,
                    Id=x.Id,
                    CategoryId=x.CategoryId,
                    IsActive=x.IsActive,
                    Price=x.Price 

                })
                .ToList();




        }

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (categoryId==null)
            {
                MessageBox.Show("lütfen bir kategori seciniz");
                return;
            }
            try
            {
                //yeni ürün ekliyoruz.
                new ProductRepo().Insert(new Product()
                {
                    CategoryId=categoryId.Value,
                    Name=txtUrunAdi.Text,
                    Price=nudFiyat.Value,
                    IsActive=cbSatistaMi.Checked
                });
                MessageBox.Show("Urun ekleme basarılı.");
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
