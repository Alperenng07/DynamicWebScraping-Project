using AutoMapper;
using Business;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ACurrencyTransactions.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<User> _service;
        private readonly IMapper _mapper;

        public UserController(IBaseService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserForCreateDto userForCreateDto)
        {
            var ppd = _mapper.Map<User>(userForCreateDto);
            await _service.AddAsync(ppd);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<UserForGetDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<UserForGetDto>(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UserForCreateDto userForCreateDto)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var pud = _mapper.Map(userForCreateDto, user);
            await _service.UpdateAsync(pud);
            return Ok(pud);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return await _service.DeleteAsync(id) ? NoContent() : throw new Exception();
        }

        
    }
}
