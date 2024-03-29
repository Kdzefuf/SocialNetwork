﻿using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserIncomingMessageView
    {
        internal void Show(IEnumerable<Message> incomingMessages)
        {
            Console.WriteLine();

            Console.WriteLine("Входящие сообщения");

            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщений нет.");
                return;
            }
            incomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine("От кого: {0}. Текст сообщения: {1}", m.SenderEmail, m.Content);
            });
        }
    }
}
