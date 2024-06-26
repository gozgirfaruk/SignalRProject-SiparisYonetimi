using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDto featureDto)
        {
            _featureService.TInsert(_mapper.Map<Feature>(featureDto));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto featureDto)
        {
            _featureService.TUpdate(_mapper.Map<Feature>(featureDto));
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetById(id);
            _featureService.TDelete(values); 
            return Ok();
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetById(id);
            return Ok(values);
        }
    }
}
