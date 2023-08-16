using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace little_face_api.Data.Models
{
    public class GoalChild
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int Face { get; set; }

        [Required]
        public DateTime DateGoal { get; set; }

        public long ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        public virtual Child Child { get; set; }

        public long GoalId { get; set; }

        [ForeignKey(nameof(GoalId))]
        public virtual Goal Goal { get; set; }


        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
