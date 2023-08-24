using API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICars _CarsService;

        public UsersController(ICars CarsService)
        {

            _CarsService = CarsService;

        }
        // GET: api/<UsersController>
        [HttpGet]
        [Route("GetCars")]
        public IActionResult GetCars()
        {
            try
            {
                var Cars = _CarsService.GetCars();

                if (Cars != null)
                    return Ok(Cars);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return NoContent();
        }


        [HttpGet]
        [Route("GetCars/{Carno}")]
        public IActionResult GetCarsByno(int Carno)
        {
            try
            {
                var Cars = _CarsService.GetCars().Find(a => a.Carno == Carno);

                if (Cars != null)
                    return Ok(Cars);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return NoContent();
        }


    }
}
