using DataAccess.Entities;
using LoginWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Producto> AddProducto(Producto producto)
        {

            var result =  _context.Productos.Add(producto);
            _context.SaveChanges();
            if (result == null)
            {
                return null;
            }
            else
            {
                return Task.FromResult(producto);
            }

        }

        public Task<Producto> UpdateProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProducto(int id)
        {
        
           Producto producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            _context.Productos.Remove(producto); // se podria hacer con un update y ponerle un bool a la entidad para que no se muestre en la vista
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
