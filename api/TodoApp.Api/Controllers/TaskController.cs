namespace TodoApp.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Request;
    using Models.Response;
    using Swashbuckle.AspNetCore.Annotations;
    using Swashbuckle.AspNetCore.Filters;

    [ApiController]
    [Route("tasks")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class TaskController : ControllerBase
    {
        private static List<Task> _tasks = new List<Task>
        {
            new Task("Melhorar o processo de API Design")
        };

        [HttpGet]
        [SwaggerOperation(OperationId = "get-tasks", Summary = "Returns a paged list of tasks.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(PagedResponse<Task>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error")]
        public IActionResult Get([FromQuery] PagedTasksParameters parameters)
        {
            return Ok(new PagedResponse<Task>()
            {
                Total = _tasks.Count,
                TotalOfPages = _tasks.Count <= parameters.PageSize ? 1 : _tasks.Count / parameters.PageSize,
                Values = _tasks
            });
        }

        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "get-task", Summary = "Get task by id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(Task))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute, SwaggerParameter("Task Id")] Guid id)
        {
            return Ok(_tasks.Find(t => t.Id == id));
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "create-task", Summary = "Create a task")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseHeader(StatusCodes.Status201Created, "Location", "string", "Location of the created task /tasks/{id}")]
        public IActionResult Post([FromBody, Required] Task task)
        {
            _tasks.Add(task);

            return Created($"tasks/{task.Id}", task);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(OperationId = "update-task", Summary = "Update a task")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute] Guid id, [FromBody, Required] Task task)
        {
            var currentTask = _tasks.Find(t => t.Id == id);

            currentTask.Name = task.Name;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "delete-task", Summary = "Delete a task")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var task = _tasks.Find(t => t.Id == id);

            if(task == null)
            {
                return NotFound();
            }
            
            _tasks.Remove(task);

            return NoContent();
        }
    }
}