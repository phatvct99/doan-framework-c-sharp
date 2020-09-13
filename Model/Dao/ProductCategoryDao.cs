using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(ProductCategory productcategory)
        {
            db.ProductCategories.Add(productcategory);
            db.SaveChanges();
            return productcategory.ID;
        }
        public long Create(ProductCategory productcategory)
        {
            productcategory.CreatedDate = DateTime.Now;
            productcategory.Status = true;

            db.ProductCategories.Add(productcategory);
            db.SaveChanges();
            return productcategory.ID;
        }
        public long Edit(ProductCategory productcategory)
        {
            //Xử lý alias
            productcategory.CreatedDate = DateTime.Now;
            db.SaveChanges();
            return productcategory.ID;
        }
        public bool Update(ProductCategory entity)
        {
            try
            {
                var ProductCategory = db.ProductCategories.Find(entity.ID);
                ProductCategory.MetaTitle = entity.MetaTitle;
                ProductCategory.Status = entity.Status;
                ProductCategory.Name = entity.Name;
                ProductCategory.ShowOnHome = entity.ShowOnHome;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        //public bool ChangeStatus(long ID)
        //{
        //    var order = db.Orders.Find(ID);
        //    order.Status = !order.Status;
        //    db.SaveChanges();
        //    return order.Status;
        //}

        public bool Delete(int id)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productcategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
