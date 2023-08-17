using little_face_api.Data.Models;
using little_face_api.Enumerations;

namespace little_face_api.Data
{
    public class SeedDb
    {
        private readonly little_face_DBContext context;
        private readonly Random random;

        public SeedDb(little_face_DBContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Clients.Any())
            {
                this.AddClient("First Client");
                this.AddClient("Second Client");
                this.AddClient("Third Client");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.UserRoles.Any())
            {
                this.AddUserRole("Administrator", RoleType.SuperAdmin);
                this.AddUserRole("Staff", RoleType.Staff);
                this.AddUserRole("Guest", RoleType.Guest);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Users.Any())
            {
                this.AddUser("AdminUser", "123", 1);
                this.AddUser("StaffUser", "123", 2);
                this.AddUser("GuestUser", "123", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Childs.Any())
            {
                this.AddChild("Matias","Ayra",9,"Mati", 1);
                this.AddChild("Pepito","Perez", 5, "Pepe", 2);
                this.AddChild("Lupe","Castro", 4, "Lupe", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Goals.Any())
            {
                this.AddGoal("Cepillo mis dientes", 1);
                this.AddGoal("Recojo mis jueguetes", 1);
                this.AddGoal("Hago mis tareas", 1);
                this.AddGoal("Obedezco a mis mayores", 1);
                this.AddGoal("Como toda mi comida", 1);
                this.AddGoal("Cepillo mis dientes", 2);
                this.AddGoal("Recojo mis jueguetes", 2);
                this.AddGoal("Hago mis tareas", 2);
                this.AddGoal("Obedezco a mis mayores", 2);
                this.AddGoal("Como toda mi comida", 2);
                this.AddGoal("Cepillo mis dientes", 3);
                this.AddGoal("Recojo mis jueguetes", 3);
                this.AddGoal("Hago mis tareas", 3);
                this.AddGoal("Obedezco a mis mayores", 3);
                this.AddGoal("Como toda mi comida", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Rewards.Any())
            {
                this.AddReward(33, 2, false, "Helado", 1);
                this.AddReward(33, 2, true, "Juguete", 2);
                this.AddReward(31, 4, false, "Cine", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.GoalChilds.Any())
            {
                //1 carita feliz 
                //2 carita triste 
                //0 sin carita 

                this.AddGoalChild(1, Convert.ToDateTime("14/08/2023"), 1, 1, 1);
                this.AddGoalChild(2, Convert.ToDateTime("14/08/2023"), 1, 2, 1);
                this.AddGoalChild(0, Convert.ToDateTime("14/08/2023"), 1, 3, 1);

                this.AddGoalChild(1, Convert.ToDateTime("15/08/2023"), 1, 4, 1);
                this.AddGoalChild(2, Convert.ToDateTime("15/08/2023"), 1, 5, 1);
                this.AddGoalChild(0, Convert.ToDateTime("15/08/2023"), 1, 6, 1);

                this.AddGoalChild(1, Convert.ToDateTime("16/08/2023"), 1, 7, 1);
                this.AddGoalChild(2, Convert.ToDateTime("16/08/2023"), 1, 8, 1);
                this.AddGoalChild(0, Convert.ToDateTime("16/08/2023"), 1, 8, 1);

                await this.context.SaveChangesAsync();
            }

        }

        private void AddClient(string name)
        {
            this.context.Clients.Add(new Models.Client
            {
                Name = name,
                Dna = this.random.Next(1000000, 1999999).ToString()
            });
        }

        private void AddUserRole(string roleName, RoleType roleType)
        {
            this.context.UserRoles.Add(new Models.UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }

        private void AddUser(string userId, string password, long userRoleId)
        {
            this.context.Users.Add(new Models.User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }

        private void AddChild(string names, string surnames, int age, string alias, long userId)
        {
            this.context.Childs.Add(new Models.Child
            {
                Names = names,
                Surnames = surnames,
                Age = age,
                Alias = alias,
                UserId = userId
            });
        }

        private void AddGoal(string taskName, long userId)
        {
            this.context.Goals.Add(new Models.Goal
            {
                Taskname = taskName,
                UserId = userId
            });
        }

        private void AddReward(int numberFaceGood, int numberFaceBad, bool validateFaceGood, string recompense, long userId)
        {
            this.context.Rewards.Add(new Models.Reward
            {
                NumberFaceGood = numberFaceGood,
                NumberFaceBad = numberFaceBad,
                ValidateFaceGood = validateFaceGood,
                Recompense = recompense,
                UserId = userId
            });
        }

        private void AddGoalChild(int face, DateTime dateGoal, long childId, long goalId, long userId)
        {
            this.context.GoalChilds.Add(new Models.GoalChild
            {
                Face = face,
                DateGoal = dateGoal,
                ChildId = childId,
                GoalId = goalId,
                UserId = userId
            });
        }

    }

}
