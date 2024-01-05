using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int Create(UserEntity user)
        {
            return Execute(@"insert into users (firstname,lastname,password,email) values (:firstname,:lastname,:password,:email)", user);
        }

        public int DeleteById(int id)
        {
            return Execute(@"delete from users where id = :user_id", new { user_id = id });
        }

        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from users");
        }

        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :user_email",
                new { user_email = email });
        }

        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :user_id",
                new { user_id = id });
        }

        public int Update(UserEntity userEntity)
        {
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
                             photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
        }
    }
}
