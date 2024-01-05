using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine();

            Console.WriteLine("Мои друзья");

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Электронная почта друга: {0}. Имя: {1}. Фамилия: {2}.", friend.Email, friend.FirstName, friend.LastName);
            });
        }
    }
}
