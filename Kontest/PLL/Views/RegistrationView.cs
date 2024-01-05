using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine();

            Console.WriteLine("Для создания нового профиля введите ваше имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Введите пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Введите электронную почту: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                userService.Register(userRegistrationData);
                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при регистрации.");
            }
        }
    }
}
