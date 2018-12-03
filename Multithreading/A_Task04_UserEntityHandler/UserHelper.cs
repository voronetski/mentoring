using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace A_Task04_UserEntityHandler
{
    public class UserHelper
    {

        public async static Task<List<User>> GetAllUsersAsync()
        {
            var db = new UserContext();

            var query = from item in db.Users
                        select item;

            return await query.ToListAsync();

        }



        public async static Task<User> GetUserAsync(int id)
        {
            var db = new UserContext();

            var query = (from item in db.Users
                         where item.Id == id
                         select item).SingleOrDefaultAsync();

            return await query;
        }

        public async static Task<string> InsertUserAsync(User User)
        {
            var db = new UserContext();

            db.Users.Add(User);

            await db.SaveChangesAsync();

            return "User Added Successfully";
        }

        public async static Task<string> UpdateUserAsync(User User)
        {
            var db = new UserContext();
            User EditUser = await db.Users.FindAsync(User.Id);

            EditUser.LastName = User.LastName;

            EditUser.FirstName = User.FirstName;

            EditUser.Age = User.Age;

            await db.SaveChangesAsync();

            return "User Updated Successfully";

        }



        public static async Task<string> DeleteUserAsync(int id)
        {
            var db = new UserContext();
            User DeleteUser = await db.Users.FindAsync(id);

            db.Users.Remove(DeleteUser);

            await db.SaveChangesAsync();

            return "User Deleted Successfully";
        }
    }
}
