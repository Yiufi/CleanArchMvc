using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
<<<<<<< HEAD
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);

        //Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
=======
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetById(int? id);

        Task<ProductDTO> GetProductCategory(int? id);

        Task Add(ProductDTO productDTO);

        Task Update(ProductDTO productDTO);
>>>>>>> parent of c5bbb72 (CQRS)
        Task Remove(int? id);
    }
}
