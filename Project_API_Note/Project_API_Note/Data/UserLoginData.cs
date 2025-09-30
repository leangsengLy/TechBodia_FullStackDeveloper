using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API_Note.DataModel;
using Project_API_Note.Dto;
using Project_API_Note.Model;
using Project_API_Note.Service;

namespace Project_API_Note.Data
{
    public static class UserLoginData
    {

        public static async Task<UserLoginDto> Register(UserLoginDataModel model, ApplicationDbContext _db)
        {
            var hasPw = new UserLoginService();
            var user = new LSUSER_LOGIN();
            user.EMAIL = model.Email;
            user.PASSWORD = hasPw.HashPassword(user, model.Password);
            user.CREATED_AT = DateTime.Now;
            _db.LSUSER_LOGINs.Add(user);
            await _db.SaveChangesAsync();
            return MappingData(user);
        }
        public static async Task<bool> IsLoginSuccess(UserLoginDataModel model, ApplicationDbContext _db)
        {
            var hasPw = new UserLoginService();
            var find = await _db.LSUSER_LOGINs.FirstOrDefaultAsync(s => s.EMAIL == model.Email);
            var isCorrect = hasPw.VerifyPassword(find, find.PASSWORD, model.Password);
            return isCorrect;
        }
        public static async Task<UserLoginDto> Update(UserLoginDataModel model, ApplicationDbContext _db)
        {
            var user = await _db.LSUSER_LOGINs.FirstOrDefaultAsync(s => s.ID == model.Id);
            user.EMAIL = model.Email;
            user.PASSWORD = model.Password;
            user.UPDATED_AT = DateTime.Now;
            await _db.SaveChangesAsync();
            return MappingData(user);
        }
        public static async Task<bool> Delete(Guid id, ApplicationDbContext _db)
        {
            var data = await _db.LSUSER_LOGINs.FirstOrDefaultAsync(s => s.ID == id);
            _db.LSUSER_LOGINs.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }

        private static UserLoginDto MappingData(LSUSER_LOGIN obj)
        {
            var data = new UserLoginDto();
            data.Id = obj.ID;
            data.Email = obj.EMAIL;
            data.Password = obj.PASSWORD;
            data.CreatedAt = obj.CREATED_AT;
            data.UpdatedAt = obj.UPDATED_AT;
            return data;
        }

    }
}
