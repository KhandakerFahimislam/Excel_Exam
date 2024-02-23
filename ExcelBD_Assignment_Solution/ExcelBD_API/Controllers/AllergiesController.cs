using ExcelBD_API.Repositories.Interfaces;
using ExelBD_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelBD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Allergy> repo;
        public AllergiesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepository<Allergy>();
        }
        [HttpGet]
        public async Task<IEnumerable<Allergy>> GetAllergies()
        {
            var data= await repo.GetAllAsync();
           
            return  data.ToList();
        }
    }
}
