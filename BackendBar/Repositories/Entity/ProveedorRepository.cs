using BackendBar.Data;
using BackendBar.Interfaces;
using BackendBar.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendBar.Repositories.Entity
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly BackendBarDbContext _context;
        public ProveedorRepository(BackendBarDbContext context)
        {
            _context = context;
        }
        public async Task addProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}
