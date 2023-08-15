using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
