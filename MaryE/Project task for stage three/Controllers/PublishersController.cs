using AutoMapper;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.IServicesRepo;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersRepo _publishersRepo;
       
        public PublishersController(IPublishersRepo publishersRepo)
        {
            _publishersRepo = publishersRepo;
           
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _publishersRepo.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publishersRepo.GetPublisherById(id);
            return Ok(publisher);
        }

        [HttpGet("{id:int}/GetAuthorsToAPublisher")]
        public IActionResult GetAuthorsAttachedToAPublisher(int id)
        {
            var aut = _publishersRepo.GetAuthorsAttachedToAPublisher(id);
            return Ok(aut);
        }

        [HttpPost]
        public IActionResult CreatePublisher([FromBody] PublishersDto publishersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _publishersRepo.CreatePublisher(publishersDto);
            return Ok();
        }


    }
}
