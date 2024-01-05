using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Interfaces
{
    public interface IUserRepository
    {
        int Create(UserEntity user);
        UserEntity FindByEmail(string email);
        IEnumerable<UserEntity> FindAll();
        UserEntity FindById(int id);
        int Update(UserEntity user);
        int DeleteById(int id);
    }
}
