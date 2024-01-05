using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AddingFriendView
    {
        UserService userService;

        public AddingFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            try
            {
                var addingFriendData = new AddingFriendData();

                Console.WriteLine("Введите электронную почту пользователя, которого хотите добавить в друзья: ");

                addingFriendData.FriendEmail = Console.ReadLine();
                addingFriendData.UserId = user.Id;

                this.userService.AddFriend(addingFriendData);

                SuccessMessage.Show("Вы успешно добавили пользователя в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с указанной электронной почтой не существует!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении пользователя в друзья!");
            }
        }
    }
}
