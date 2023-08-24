
using System.ComponentModel.DataAnnotations;


namespace little_face_api.Data.Dto
{
    public class ChildDto
    {
      
        [Required]
        public string Names { get; set; }

        [Required]
        public string Surnames { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Alias { get; set; }

        public long UserId { get; set; }

    }
}
