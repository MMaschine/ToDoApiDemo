using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Models;
using ToDoApp.Logic.Interfaces;
using ToDoApp.Web.Api.Models;

namespace ToDoApp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(IToDoTaskService toDoTaskService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ToDoTaskViewModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<ToDoTaskViewModel>> GetFilteredToDoTask([FromQuery] ToDoTasksFilter filterParams)
        {
            return (await toDoTaskService.GetFilteredToDoTaskAsync(filterParams))
                .Select(x => mapper.Map<ToDoTaskViewModel>(x));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ToDoTaskDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ToDoTaskDetailsViewModel> GetToDoTask(int id)
        {
            var task = await toDoTaskService.GetTaskByIdAsync(id);

            return mapper.Map<ToDoTaskDetailsViewModel>(task);
        }


        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<int>> CreateNewToDoTask(UpsertToDoTaskDto toDoTaskDto)
        {
            var toDoTask = mapper.Map<ToDoTask>(toDoTaskDto);

            var newTaskId = await toDoTaskService.CreateNewTaskAsync(toDoTask);

            return CreatedAtAction(nameof(CreateNewToDoTask), new { toDoTaskId = newTaskId }, newTaskId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> UpdateToDoTask(int id, [FromBody] UpsertToDoTaskDto taskViewModel)
        {
            var taskToUpdate = mapper.Map<ToDoTask>(taskViewModel);
            taskToUpdate.Id = id;

            await toDoTaskService.UpdateTaskAsync(taskToUpdate);

            return Ok();
        }

        [HttpPatch("{id}/assignment")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> AssignUserToTask(int id, [FromBody] AssignUserDto dto)
        {
            await toDoTaskService.AssignUserToTheTaskAsync(id, dto.AssignedUserId);
            return Ok();
        }

        [HttpPatch("{id}/completion")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> CompleteTask(int id)
        {
            await toDoTaskService.CompleteTheTaskAsync(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> Delete(int id)
        {
            await toDoTaskService.DeleteToDoTaskAsync(id);

            return Ok();
        }
    }
}
