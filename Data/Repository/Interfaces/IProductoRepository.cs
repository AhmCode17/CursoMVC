using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();

        //GetById
        Task<Producto> GetById(int Id);
        //Create
        Task<int> Create(Producto producto);
        //Update
        Task<int> Update(Producto producto);
        //Delete
        Task<bool> DeleteById(int Id);
    }
}