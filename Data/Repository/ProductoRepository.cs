using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data.Repository.Interfaces;
using WebAppMVC.Models;

namespace WebAppMVC.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        //Inyectamos dependencia del DbContext
        private readonly ProductosContext _context;

        //Constructor
        public ProductoRepository(ProductosContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await _context.productos.ToListAsync();
            return productos;
        }

        //GetById
        public async Task<Producto> GetById(int Id)
        {
            var producto = await _context.productos.FindAsync(Id);
             return producto;
        }

        //Create
        public async Task<int> Create(Producto producto)
        {
            producto.FechaAlta = DateTime.Now;
            _context.Add(producto);
            return await _context.SaveChangesAsync();
        }

        //Update
        public async Task<int> Update(Producto producto)
        {
            producto.FechaAlta = DateTime.Now;
            _context.Update(producto);
            return await _context.SaveChangesAsync();
        }

        //Delete
        public async Task<bool> DeleteById(int Id)
        {
            var producto = await _context.productos.FindAsync(Id);
            _context.productos.Remove(producto);
           if(await _context.SaveChangesAsync()>=0)
              return true;

            return false;
        }
    }
}