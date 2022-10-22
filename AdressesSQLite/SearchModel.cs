using System.ComponentModel.DataAnnotations;
namespace AdressesSQLite
{
    public class SearchModel
    {
        [StringLength(50)]
        public string SearchRequest { get; set; } = "";

        public HowToSort SortDist { get; set; }
        
    }
    public enum HowToSort
    {
        Up, Down
    }
}
