using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserOutgoingMessageView
    {
        public void Show(IEnumerable<Message> outgoingMessages)
        {
            Console.WriteLine("Исходящие сообщения");

            if (outgoingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет.");
                return;
            }

            outgoingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("Кому: {0}. Текст сообщения: {1}", message.RecipientEmail, message.Content);
            });
        }
    }
}
