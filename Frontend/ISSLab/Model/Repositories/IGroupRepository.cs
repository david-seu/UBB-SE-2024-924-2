using ISSLab.Model.Entities;

namespace ISSLab.Model.Repositories
{
    public interface IGroupRepository
    {
        void AddGroup(GroupMarketplace newGroupMarketplace);
        List<GroupMarketplace> FindAll();
        GroupMarketplace FindById(Guid id);
        void RemoveGroup(Guid id);
    }
}