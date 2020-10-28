namespace TodoApp.Api.Models.Request
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class PagedTasksParameters
    {
        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int Page { get; set; }
        
        [Range(10, 100)]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 100;
    }
}