using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public int Create(FriendEntity friend)
        {
            return Execute(@"insert into friends (user_id, friend_id) values (:user_id, :friend_id)", friend);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :user_id", new { user_id = id });
        }

        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }
    }
}
