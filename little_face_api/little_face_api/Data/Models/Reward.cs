using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace little_face_api.Data.Models
{
    public class Reward
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int NumberFaceGood { get; set; }

        [Required]
        public int NumberFaceBad { get; set; }

        [Required]
        public bool ValidateFaceGood { get; set; }

        [Required]
        public string Recompense { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
