using little_face_api.Data.Models;

namespace little_face_api.Data.Dto
{
    public class ClientDetailDto : Client
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public double LifeExpectancy { get; set; }
    }

}
