using ExcelBD_API.Repositories.Interfaces;
using ExelBD_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelBD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<NCD> repo;
        public NCDsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepository<NCD>();
        }
        [HttpGet]
        public async Task<IEnumerable<NCD>> GetNCDs()
        {
            var data = await repo.GetAllAsync();

            return data.ToList();
        }
    }
}
