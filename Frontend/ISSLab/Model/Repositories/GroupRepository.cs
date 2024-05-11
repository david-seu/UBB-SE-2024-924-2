using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ISSLab.Model.Entities;

namespace ISSLab.Model.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private List<GroupMarketplace> allGroups;

        public GroupRepository()
        {
            allGroups = new List<GroupMarketplace>();
        }

        public List<GroupMarketplace> FindAll()
        {
            return allGroups;
        }

        public GroupMarketplace FindById(Guid id)
        {
            for (int i = 0; i < allGroups.Count; i++)
            {
                if (allGroups[i].GroupId == id)
                {
                    return allGroups[i];
                }
            }
            throw new Exception("GroupMarketplace does not exist");
        }
        public void RemoveGroup(Guid id)
        {
            for (int i = 0; i < allGroups.Count; i++)
            {
                if (allGroups[i].GroupId == id)
                {
                    allGroups.RemoveAt(i);
                    break;
                }
            }
        }

        public void AddGroup(GroupMarketplace newGroupMarketplace)
        {
            allGroups.Add(newGroupMarketplace);
        }
    }
}
