using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppMVC.Models;
using System;
using WebAppMVC.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data.Repository.Interfaces;

namespace WebAppMVC.Controllers
{
    public class ProductoController: Controller
    {
        //Inyectamos dependencia del DbContext
        private readonly ProductosContext _context;

        //Agregamos Repository
        private readonly IProductoRepository _productoRepository;

        ///Constructor del DbContext
        ///public ProductoController(ProductosContext context)
        ///{
            ///_context = context;
        ///}

        //Constructor del Repository
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var productos = GetData();
            ///var productos = await _context.productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
            return View(productos);
        }

        //GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Producto/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                ///Agregar logica para grabar a DB
                ///producto.FechaAlta = DateTime.Now;
                ///_context.Add(producto);
                ///await _context.SaveChangesAsync();

                var result = await _productoRepository.Create(producto);
                if(result <0)
                {
                     ViewBag.ErrorMessage = "Error al guardar los datos";
                     return View(producto);
                }
        
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = "Modelo no valido";
            return View(producto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id==0)
                return NotFound();
            
            ///var producto = await _context.productos.FindAsync(Id);
            //var producto1 = await _context.productos.FirstOrDefault(p => p.Id==Id);

            var producto = await _productoRepository.GetById(Id);
            if (producto==null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Producto producto)
        {
            if (Id != producto.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                 ///producto.FechaAlta = DateTime.Now;
                ///_context.Update(producto);
                ///await _context.SaveChangesAsync();
                
                var result = await _productoRepository.Update(producto);
                if(result <0)
                {
                     ViewBag.ErrorMessage = "Error al guardar los datos";
                     return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(producto);
        }

         [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id==0)
                return NotFound();
            
            ///var producto = await _context.productos.FindAsync(Id);
            //var producto1 = await _context.productos.FirstOrDefault(p => p.Id==Id);

            var producto = await _productoRepository.GetById(Id);
            if (producto==null)
                return NotFound();

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int Id)
        {
        
            ///var producto = await _context.productos.FindAsync(Id);
            //var producto1 = await _context.productos.FirstOrDefault(p => p.Id==Id);

            ///_context.productos.Remove(producto);
            ///await _context.SaveChangesAsync();

             var result = await _productoRepository.DeleteById(Id);
             if(result)
             {
                 return RedirectToAction(nameof(Index));
             }
            else
            {
                ViewBag.ErrorMessage = "Error al eliminar los datos";
                return View();
            }
                
        }

        ///public List<Producto> GetData()
        ///{
            ///List<Producto> productos = new List<Producto>();
            ///productos.Add(new Producto{Id=1,Nombre="Cafe peruano",Descripcion="Cafe de grano",Precio=201.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=2,Nombre="Cafe colombiano",Descripcion="Cafe de grano",Precio=195.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=3,Nombre="Cafe argentino",Descripcion="Cafe de grano",Precio=180.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=4,Nombre="Cafe venezolano",Descripcion="Cafe de grano",Precio=165.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=5,Nombre="Cafe paraguayo",Descripcion="Cafe de grano",Precio=120.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=6,Nombre="Cafe brazileño",Descripcion="Cafe de grano",Precio=210.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=7,Nombre="Cafe mexicano",Descripcion="Cafe de grano",Precio=110.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});
            ///productos.Add(new Producto{Id=8,Nombre="Cafe chileno",Descripcion="Cafe de grano",Precio=230.00m,Activo=true,FechaAlta=DateTime.Now.AddDays(-1)});

            ///return productos;
        ///}
    }
}