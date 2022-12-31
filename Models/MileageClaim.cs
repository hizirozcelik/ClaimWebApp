using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClaimWebApp.Models
{
    public class MileageClaim
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Trip Date")]
        
        //[Required]
        public DateTime TripDate { get; set; } = DateTime.Now;

        [Display(Name = "From Where")]
        //[Required]
        public string FromWhere { get; set; } = string.Empty;

        //[Required]
        public string Destination { get; set; } = string.Empty;

        //[Required]
        public decimal Distance { get; set; }
        public int ClaimRequestId { get; set; }
    }
}
