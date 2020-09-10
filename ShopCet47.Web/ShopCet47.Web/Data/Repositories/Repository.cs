using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using ShopCet47.Web.Data.Entities;

namespace ShopCet47.Web.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _contex;

        public Repository(DataContext context)
        {
            _contex = context;
        }

        // Metodo que vai os produtos todos
        public IEnumerable<Product> GetProducts()
        {
            return _contex.Products.OrderBy(p => p.Name);
        }

        //Metodo que vai um produto pelo id
        public Product GetProduct(int id)
        {
            return _contex.Products.Find(id);
        }

        //Metodo que adiciona um produto a tabela
        public void AddProduct(Product product)
        {
            _contex.Products.Add(product);
        }

        //Metodo que atualiza(update) o produto
        public void UpdateProduct(Product product)
        {
            _contex.Update(product);
        }

        //Metodo que remove um produto
        public void RemoveProduct(Product product)
        {
            _contex.Products.Remove(product);
        }

        //Metodo que atualiza a BD
        public async Task<bool> SaveAllAsync()
        {
            return await _contex.SaveChangesAsync() > 0;
        }

        // Metodo que verifica se o produto existe
        public bool ProductExists(int Id)
        {
            return _contex.Products.Any(p => p.Id == Id);
        }


    }
}
