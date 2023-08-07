using little_face_api.Data.Models;

namespace little_face_api.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}
