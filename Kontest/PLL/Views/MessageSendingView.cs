﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;

        public MessageSendingView(UserService userService, MessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine();

            Console.Write("Введите электронную почту получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите сообщение (не более 5000 символов): ");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("Сообщение успешно отправлено!");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }
        }
    }
}
