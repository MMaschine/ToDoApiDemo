using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain;
using ToDoApp.Domain.Models;
using ToDoApp.Logic.Interfaces;
using ToDoApp.Web.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BaseNamedViewModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<BaseNamedViewModel>> GetAllUsers()
        {
            var result = await userService.GetAllUsersAsync();

            return result.Select(mapper.Map<BaseNamedViewModel>);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseNamedViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<BaseNamedViewModel> GetUserById(int id)
        {
            return mapper.Map<BaseNamedViewModel>(await userService.GetUserAsync(id));
        }


        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<int>> CreateUser([FromBody] CreateUserDto dto)
        {
            var userToAdd = mapper.Map<User>(dto);

            var newUserId = await userService.AddUserAsync(userToAdd);

            return CreatedAtAction(nameof(CreateUser), new { userId = newUserId }, newUserId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> Delete(int id)
        {
            await userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
