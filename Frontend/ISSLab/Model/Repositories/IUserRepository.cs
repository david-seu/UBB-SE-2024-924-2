using ISSLab.Model.Entities;

namespace ISSLab.Model.Repositories
{
    public interface IUserRepository
    {
        void AddPostToCart(Guid groupId, Guid userId, Guid postId);
        void AddToFavorites(Guid groupId, Guid userId, Guid postId);
        void AddUser(UserMarketplace newUser);
        void DeleteUser(Guid id);
        List<UserMarketplace> GetAll();
        UserMarketplace GetById(Guid id);
        void RemoveFromCart(Guid groupId, Guid userId, Guid postId);
        void RemoveFromFavorites(Guid groupId, Guid userId, Guid postId);
        void UpdateUserDateOfBirth(Guid userId, DateOnly newDateOfBirth);
        void UpdateUserUsername(Guid userId, string newUsername);
    }
}