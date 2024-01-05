using System.Collections.Generic;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteFilm { get; set; }
        public string FavoriteBook { get; set; }

        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutgoingMessages { get; }

        public IEnumerable<User> Friends { get; }

        public User(int id,
                    string firstName,
                    string lastName,
                    string password,
                    string email,
                    string photo,
                    string favoriteFilm,
                    string favoriteBook,
                    IEnumerable<Message> incomingMessages,
                    IEnumerable<Message> outcomingMessages,
                    IEnumerable<User> friends)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteFilm = favoriteFilm;
            FavoriteBook = favoriteBook;
            IncomingMessages = incomingMessages;
            OutgoingMessages = outcomingMessages;
            Friends = friends;
        }
    }
}
