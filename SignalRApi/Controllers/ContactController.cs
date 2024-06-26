using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact(CreateContactDto dto)
        {
            _contactService.TInsert(_mapper.Map<Contact>(dto));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            _contactService.TUpdate(_mapper.Map<Contact>(dto));
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);
            _contactService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);
        }
    }
}
