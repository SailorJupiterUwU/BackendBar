using BackendBar.Models;

namespace BackendBar.Interfaces
{
    public interface IProveedorRepository
    {
        Task addProveedor(Proveedor proveedor);
    }
}
