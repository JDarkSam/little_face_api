using little_face_api.Data;
using little_face_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace little_face_api.Services
{
    public class UserService : IUserService
    {

        private readonly little_face_DBContext _context;


        public UserService(little_face_DBContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }

}
