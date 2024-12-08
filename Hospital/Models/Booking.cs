using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    [PrimaryKey(nameof(PatientID), nameof(ClinicId))]
    public class Booking
    {
        [ForeignKey("PId")]
        public int? PatientID { get; set; }

        public virtual Patient PId { get; set; }
        [ForeignKey("CId")]
        public int? ClinicId { get; set; }
        public virtual Clinic CId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Slots_Number { get; set; }

    }
}
