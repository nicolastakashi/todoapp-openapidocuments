namespace TodoApp.Api.Models.Response
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PagedResponse<TEntity>
    {
        [Range(0, int.MaxValue)]
        public int Total { get; set; }
        
        [Range(0, int.MaxValue)]
        public int TotalOfPages { get; set; }

        public IEnumerable<TEntity> Values { get; set; }
    }
}