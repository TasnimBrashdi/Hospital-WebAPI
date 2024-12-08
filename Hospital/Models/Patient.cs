using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Patient
    {
        public enum GENDER
        {
            Male,
            Female
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }

        [Required]

        public int Age { get; set; }    

        [Required]

        public GENDER gender { get; set; }

    }
}
