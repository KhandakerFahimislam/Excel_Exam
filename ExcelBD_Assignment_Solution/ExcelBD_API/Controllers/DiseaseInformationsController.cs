using ExcelBD_API.Repositories.Interfaces;
using ExelBD_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelBD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseInformationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<DiseaseInformation> repo;
        public DiseaseInformationsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepository<DiseaseInformation>();
        }
        [HttpGet]
        public async Task<IEnumerable<DiseaseInformation>> GetDiseaseInformations()
        {
            var data = await repo.GetAllAsync();

            return data.ToList();
        }
    }
}
