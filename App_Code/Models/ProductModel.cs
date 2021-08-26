using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            GarageEntities6 db = new GarageEntities6();
            db.Products.Add(product);
            db.SaveChanges();

            return product.Name + " was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProduct(int id, Product product)
    {
        try
        {
            GarageEntities6 db = new GarageEntities6();

            //Fetch object from db
            Product p = db.Products.Find(id);

            p.Name = product.Name;
            p.Price = product.Price;
            p.TypeID = product.TypeID;
            p.Description = product.Description;
            p.Image = product.Image;

            db.SaveChanges();
            return product.Name + " was succesfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            GarageEntities6 db = new GarageEntities6();
            Product product = db.Products.Find(id);

            db.Products.Attach(product);
            db.Products.Remove(product);
            db.SaveChanges();

            return product.Name + " was succesfully deleted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            using (GarageEntities6 db = new GarageEntities6())
            {
                Product product = db.Products.Find(id);
                return product;
            }
        }
        catch (Exception )
        {
            return null;
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            using (GarageEntities6 db = new GarageEntities6())
            {
                List<Product> products = (from x in db.Products
                                select x).ToList();
                return products;
            }
        }
        catch (Exception )
        {
            return null;
        }
    }

    public List<Product> GetProductsByType(int typeId)
    {
        try
        {
            using (GarageEntities6 db = new GarageEntities6())
            {
                List<Product> products = (from x in db.Products
                                                where x.TypeID == typeId
                                                select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}