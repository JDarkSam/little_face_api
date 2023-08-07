using little_face_api.Data.Models;

namespace little_face_api.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }

}
