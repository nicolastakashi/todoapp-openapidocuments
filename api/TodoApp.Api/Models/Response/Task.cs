namespace TodoApp.Api.Models.Response
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Swashbuckle.AspNetCore.Annotations;

    public class Task
    {
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public string Name { get; set; }

        public Task(string name)
        {
            Name = name;
        }

        public Task()
        {
        }
    }
}