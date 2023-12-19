using DataAccess.Repositories;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _productoRepository.GetProductos();
            if (productos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(productos);
            }

        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var priducto = await _productoRepository.GetProducto(id); 
            if (priducto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(priducto);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            var result = await _productoRepository.AddProducto(producto);
           if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(Producto producto)
        {
            var result = await _productoRepository.UpdateProducto(producto);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productoRepository.DeleteProducto(id);
            if (result)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest();

            }
        }
    }
}
