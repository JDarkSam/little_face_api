namespace little_face_api.Data.Dto
{
    public class GoalChildDto
    {
        public long Id { get; set; }

        public int Face { get; set; }
        public DateTime DateGoal { get; set; }
        public long ChildId { get; set; }
        public string Alias { get; set; }

        public long GoalId { get; set; }
        public string Taskname { get; set; }

        public long UserId { get; set; }
    }
}
