using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JMusik.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JMusik.Data
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private TiendaDbContext _context;

        public RepositorioProductos(TiendaDbContext tiendaDbContext )
        {
            _context = tiendaDbContext;
        }


        public async Task<bool> Actualizar(Producto producto)
        {
            _context.Productos.Attach(producto);
            _context.Entry(producto).State = EntityState.Modified;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch
            {
            }
            return false;
        }

        public async Task<Producto> Agregar(Producto producto)
        {

            await _context.Productos.AddAsync(producto);
            _context.Entry(producto).State = EntityState.Added;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                ;
            }

            return producto;
        }

        public async Task<bool> Eliminar(int id)
        {
            var producto = await _context.Productos.SingleOrDefaultAsync(p => p.Id.Equals(id));
            producto.Estatus = EstatusProducto.Inactivo;
            _context.Attach(producto);
            _context.Entry(producto).State = EntityState.Modified;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Producto> GetProductoAsync(int id)
        {
            return await _context.Productos.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<List<Producto>> GetProductosAsync()
        {
            return await _context.Productos.OrderBy(p => p.Nombre).ToListAsync();
        }
    }
}
