using little_face_api.Data.Models;

namespace little_face_api.Data.Dto
{
    public class UserDto
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public virtual UserRole Role { get; set; }

        public string Token { get; set; }
    }

}
