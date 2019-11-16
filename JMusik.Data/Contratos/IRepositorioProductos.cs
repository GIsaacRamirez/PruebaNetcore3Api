using JMusik.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JMusik.Data
{
    public interface IRepositorioProductos
    {
        Task<List<Producto>> GetProductosAsync();
        Task<Producto> GetProductoAsync(int id);
        Task<Producto> Agregar(Producto producto);
        Task<bool> Actualizar(Producto producto);
        Task<bool> Eliminar(int id);
    }
}
