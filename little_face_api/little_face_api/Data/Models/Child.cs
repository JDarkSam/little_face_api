using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace little_face_api.Data.Models
{
    public class Child
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Names { get; set; }

        [Required]
        public string Surnames { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Alias { get; set; }
    }
}
