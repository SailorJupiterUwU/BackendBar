using BackendBar.Interfaces;
using BackendBar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendBar.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

        public class ProveedoresController : ControllerBase
        {
            private readonly IProveedorRepository _proveedorRepository;

            public ProveedoresController(IProveedorRepository proveedorRepository)
            {
                _proveedorRepository = proveedorRepository;
            }

            [HttpPost]
            [Authorize(Roles = "Admin")]
            public async Task<ActionResult> AddProveedor([FromBody] Proveedor proveedor)
            {
                var newProveedor = new Proveedor
                {
                    Nombre = proveedor.Nombre,
                    Telefono = proveedor.Telefono,
                    Activo = proveedor.Activo,
                };

                await _proveedorRepository.addProveedor(newProveedor);
                return Ok(proveedor);
            }

            
        }
    
}
