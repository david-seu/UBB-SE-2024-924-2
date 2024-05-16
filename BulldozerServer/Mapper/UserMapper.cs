using BulldozerServer.Domain;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Mapper
{
    public class UserMapper
    {
        public static UserDto MapUserToUserDto(User user)
        {
            UserDto userDto = new UserDto();
            userDto.UserId = user.UserId;
            userDto.Username = user.Username;
            userDto.FullName = user.FullName;
            userDto.Password = user.Password;
            userDto.Email = user.Email;
            userDto.PhoneNumber = user.PhoneNumber;
            userDto.BirthDay = user.BirthDay;
            userDto.CreatedDate = user.CreatedDate;
            userDto.PostsInCart = user.PostsInCart;
            userDto.FavoritePosts = user.FavoritePosts;
            userDto.GroupsPartOf = user.GroupsPartOf;
            userDto.GroupsTryingToJoin = user.GroupsTryingToJoin;
            userDto.MarketplacePosts = user.MarketplacePosts;
            userDto.JoinRequests = user.JoinRequests;
            userDto.OwnedGroups = user.OwnedGroups;
            userDto.Memberships = user.Memberships;
            return userDto;
        }

        public static User MapUserDtoToUser(UserDto userDto)
        {
            User user = new User();
            user.UserId = userDto.UserId;
            user.Username = userDto.Username;
            user.FullName = userDto.FullName;
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.BirthDay = userDto.BirthDay;
            user.CreatedDate = userDto.CreatedDate;
            user.PostsInCart = userDto.PostsInCart;
            user.FavoritePosts = userDto.FavoritePosts;
            user.GroupsPartOf = userDto.GroupsPartOf;
            user.GroupsTryingToJoin = userDto.GroupsTryingToJoin;
            user.JoinRequests = userDto.JoinRequests;
            user.OwnedGroups = userDto.OwnedGroups;
            user.MarketplacePosts = userDto.MarketplacePosts;
            user.Memberships = userDto.Memberships;

            return user;
        }
    }
}
