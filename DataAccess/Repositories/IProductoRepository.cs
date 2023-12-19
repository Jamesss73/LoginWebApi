using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task<Producto> AddProducto(Producto producto);
        Task<Producto> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}
