using Otel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL.Repository
{
   public class ProductRepo:RepositoryBase<Product,Guid>
    {
        //En alt kategoriye yemek eklemem lazım.ınsert yaparken kategorinin altında kategori yoksa en alt kategoridir. 
        //sadece product repodaki insertü değiştitiriz.

        public override int Insert(Product entity)
        {
            //eklemek istediğimkategorinin en alt kategori olup olmadıgını kontrol edelim.
            try
            {
                var category= db.Categories.Find(entity.CategoryId);
                if (category == null)
                    throw new Exception("kategori bulunamadı");
                if (category.Categories.Any())//hiç kategori var mı diye kontrol ediyoruz.
                    throw new Exception("Ust kategorilere urunekleyemezsin.");
               return base.Insert(entity);

            }
            catch 
            {

                throw;
            }
        }





    }
}
