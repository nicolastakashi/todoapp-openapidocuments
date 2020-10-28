namespace TodoApp.Api.Models.Response
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        public Guid Id { get; private set; }
        
        [Required]
        public string Name { get; set; }
    }
}