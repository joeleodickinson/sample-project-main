using System.Collections.Generic;
using System.Net.Cache;
using BusinessEntities;
using Common;
using Core.Services.Users.Interfaces;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, int age, decimal? annualSalary, IEnumerable<string> tags)
        {
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type); 
            user.SetAge(age);
            user.SetMonthlySalary(annualSalary / 12);
            user.SetTags(tags);
        }
    }
}