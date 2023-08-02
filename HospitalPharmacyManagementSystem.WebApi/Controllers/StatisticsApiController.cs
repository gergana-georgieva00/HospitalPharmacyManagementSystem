namespace HospitalPharmacyManagementSystem.WebApi.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Services.Data.Models.Statistics;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IDrugService drugService;

        public StatisticsApiController(IDrugService drugService)
        {
            this.drugService = drugService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel model = await this.drugService.GetStatisticsAsync();
                return this.Ok(model);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
