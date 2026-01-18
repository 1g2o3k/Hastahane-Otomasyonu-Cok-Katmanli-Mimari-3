using System;
using System.Collections.Generic;
using cok_katmanli_mimari_db.DAL;
using cok_katmanli_mimari_db.Models;

namespace cok_katmanli_mimari_db.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _repo = new ProductRepository();

        public List<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }

        public int CreateProduct(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(price));

            var p = new Product { Name = name.Trim(), Price = price };
            return _repo.Add(p);
        }

        public void UpdateProduct(int id, string name, decimal price)
        {
            if (id <= 0) throw new ArgumentException("Invalid Id", nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required", nameof(name));
            if (price < 0) throw new ArgumentException("Price cannot be negative", nameof(price));

            var p = new Product { Id = id, Name = name.Trim(), Price = price };
            _repo.Update(p);
        }

        public void DeleteProduct(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Id", nameof(id));
            _repo.Delete(id);
        }
    }
}