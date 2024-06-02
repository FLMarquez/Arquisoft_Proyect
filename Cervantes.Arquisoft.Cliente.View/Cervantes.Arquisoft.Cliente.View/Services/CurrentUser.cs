using Cervantes.Arquisoft.Application.DTOs;

namespace Cervantes.Arquisoft.View.Services
{
    public interface ICurrentUserService
    {
        UserFromService GetCurrentUser();
        void SetCurrentUser(UserDto user);
    }

    public class CurrentUserService : ICurrentUserService
    {
        private UserFromService currentUser;

        public UserFromService GetCurrentUser()
        {
            return currentUser;
        }

        public void SetCurrentUser(UserDto user)
        {
            if (user != null)
            {
                currentUser = MapUserToUserFromService(user);
            }
            else
            {
                currentUser = null;
            }
        }

        private UserFromService MapUserToUserFromService(UserDto user)
        {
            return new UserFromService
            {
                CurrentUserId = user.UserId.ToString(),
                CurrentUserFirstName = user.Name,
                CurrentUserLastName = user.LastName,
                CurrentUserRole = user.UserRoleId.ToString(),
                CurrentUserEmail = user.Mail
            };
        }
    }
}