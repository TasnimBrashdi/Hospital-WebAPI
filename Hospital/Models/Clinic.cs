using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Clinic
    {
        [Key]

        public int CID { get; set; }

        [Required]

        public string Specialization { get; set; }

        [Required]

        public int NoOfSlots { get; set; }

    }
}
