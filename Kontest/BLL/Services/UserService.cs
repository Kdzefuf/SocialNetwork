using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        MessageService messageService;
        IFriendRepository friendRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            messageService = new MessageService();
            friendRepository = new FriendRepository();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            if (string.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException("Не заполнено имя");

            if (string.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException("Не заполнена фамилия");

            if (string.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException("Не заполнен пароль");

            if (string.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException("Не заполнена почта");

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException("Пароль должен содержать не меньше 8 символов");

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException("Неверный email");

            if (_userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                email = userRegistrationData.Email,
                password = userRegistrationData.Password
            };

            if (this._userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = _userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = _userRepository.FindByEmail(email);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                email = user.Email,
                password = user.Password,
                photo = user.Photo,
                favorite_movie = user.FavoriteFilm,
                favorite_book = user.FavoriteBook
            };

            if (this._userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }


        public IEnumerable<User> GetFriendsByUserId(int id)
        {
            return friendRepository.FindAllByUserId(id)
                .Select(friendsEntity => FindById(friendsEntity.friend_id));
        }

        public User FindById(int id)
        {
            var findUserEntity = _userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public void AddFriend(AddingFriendData addingFriendData)
        {
            var findUserEntity = _userRepository.FindByEmail(addingFriendData.FriendEmail);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = addingFriendData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outgoingMessages = messageService.GetOutgoingMessagesByUserId(userEntity.id);
            var friends = GetFriendsByUserId(userEntity.id);

            return new User(userEntity.id,
                            userEntity.firstname,
                            userEntity.lastname,
                            userEntity.password,
                            userEntity.email,
                            userEntity.photo,
                            userEntity.favorite_movie,
                            userEntity.favorite_book,
                            incomingMessages,
                            outgoingMessages,
                            friends);
        }
    }
}
