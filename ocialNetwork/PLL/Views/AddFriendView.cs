using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            FriendsData friendsData = new FriendsData();
            Console.WriteLine("Для добавления друга введите его адрес электронной почты, указанный им при регистрации " +
                              "в нашей социальной сети");
            friendsData.emailForAddFriend = Console.ReadLine();
            friendsData.UserId = user.Id;
            try 
            {
                userService.AddFriend(friendsData);

                SuccessMessage.Show("Вы успешно добавили пользователя в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с указанным почтовым адресом не существует!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произоша ошибка при добавлении пользотваеля в друзья!");
            }
        }
    }
}
