using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int pageNumber { get; set; }
        [Range(1,50, ErrorMessage ="o  máximo de itens por pagina é 50")]
        public int pageSize { get; set; }
        public string Search { get; set; } = null;
    }
}
