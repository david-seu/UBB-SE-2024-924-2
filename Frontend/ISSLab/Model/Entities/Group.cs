using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model.Entities
{
    public class Group
    {
        private Guid groupId;
        private string name;
        private int memberCount;
        private List<Guid> members;
        private List<Guid> posts;
        private List<Guid> topSellers;
        private List<Guid> admins;
        private List<Guid> sellingUsers;
        private List<Guid> usersRequestingToSell;

        private string description;
        private string type;
        private string bannerPath;
        private DateTime creationDate;

        public Group(string name, string description, string type, string bannerPath)
        {
            groupId = Guid.NewGuid();
            this.name = name;
            memberCount = 0;
            members = new List<Guid>();
            posts = new List<Guid>();
            admins = new List<Guid>();
            sellingUsers = new List<Guid>();
            this.description = description;
            this.type = type;
            this.bannerPath = bannerPath;
            creationDate = DateTime.Now;
            topSellers = new List<Guid>();
            usersRequestingToSell = new List<Guid>();
        }

        public Group()
        {
            groupId = Guid.NewGuid();
            name = Constants.EMPTY_STRING;
            memberCount = 0;
            members = new List<Guid>();
            posts = new List<Guid>();
            admins = new List<Guid>();
            sellingUsers = new List<Guid>();
            description = Constants.EMPTY_STRING;
            type = Constants.EMPTY_STRING;
            bannerPath = Constants.EMPTY_STRING;
            creationDate = DateTime.Now;
            topSellers = new List<Guid>();
            sellingUsers = new List<Guid>();
            usersRequestingToSell = new List<Guid>();
        }
        public Group(Guid id, string name, int memberCount, List<Guid> members, List<Guid> posts, List<Guid> admins, List<Guid> sellingUsers, string description, string type, string banner, DateTime creationDate, List<Guid> topSellers, List<Guid> usersRequestingToSell)
        {
            groupId = id;
            this.name = name;
            this.memberCount = memberCount;
            this.members = members;
            this.posts = posts;
            this.admins = admins;
            this.sellingUsers = sellingUsers;
            this.description = description;
            this.type = type;
            bannerPath = banner;
            this.creationDate = creationDate;
            this.topSellers = topSellers;
            this.usersRequestingToSell = usersRequestingToSell;
        }

        public List<Guid> UsersWithSellRequests { get => sellingUsers; set => sellingUsers = value; }
        public void AddUserWithSellRequest(Guid userID)
        {
            sellingUsers.Add(userID);
        }
        public void RemoveUserWithSellRequest(Guid userID)
        {
            sellingUsers.Remove(userID);
        }

        public List<Guid> TopSellers { get => topSellers; set => topSellers = value; }
        public void AddTopSeller(Guid userID)
        {
            topSellers.Add(userID);
        }
        public void RemoveTopSeller(Guid userID)
        {
            topSellers.Remove(userID);
        }

        public Guid GroupId { get => groupId; }
        public string Name { get => name; set => name = value; }
        public int MemberCount { get => memberCount; }
        public List<Guid> Members { get => members; }
        public List<Guid> Posts { get => posts; }
        public List<Guid> Admins { get => admins; }
        public List<Guid> SellingUsers { get => sellingUsers; }

        public List<Guid> UsersRequestingToSell { get => usersRequestingToSell; }
        public string Description { get => description; set => description = value; }
        public string Type { get => type; set => type = value; }
        public string BannerPath { get => bannerPath; set => bannerPath = value; }
        public DateTime CreationDate { get => creationDate; }

        public void AddMember(Guid user)
        {
            if (!members.Contains(user))
            {
                members.Add(user);
                memberCount++;
            }
            else
            {
                throw new Exception("User is already a member of this group");
            }
        }
        public void RemoveMember(Guid user)
        {
            if (members.Contains(user))
            {
                members.Remove(user);
                memberCount--;
            }
            else
            {
                throw new Exception("User is not a member of this group");
            }
        }
        public void AddPost(Guid post)
        {
            posts.Add(post);
        }
        public void RemovePost(Guid post)
        {
            posts.Remove(post);
        }
        public void AddAdmin(Guid user)
        {
            if (!members.Contains(user))
            {
                throw new Exception("User is not a member of this group");
            }
            if (admins.Contains(user))
            {
                throw new Exception("User is already an admin of this group");
            }
            admins.Add(user);
        }
        public void RemoveAdmin(Guid user)
        {
            if (!members.Contains(user))
            {
                throw new Exception("User is not a member of this group");
            }
            if (!admins.Contains(user))
            {
                throw new Exception("User is not an admin of this group");
            }
            admins.Remove(user);
        }
        public void AddSellingUser(Guid user)
        {
            if (!members.Contains(user))
            {
                throw new Exception("User is not a member of this group");
            }
            if (sellingUsers.Contains(user))
            {
                throw new Exception("User is already a selling user of this group");
            }
            sellingUsers.Add(user);
        }
        public void RemoveSellingUser(Guid user)
        {
            if (!members.Contains(user))
            {
                throw new Exception("User is not a member of this group");
            }
            if (!sellingUsers.Contains(user))
            {
                throw new Exception("User is not a selling user of this group");
            }
            sellingUsers.Remove(user);
        }

        public void AddRequestingToSellUser(Guid user)
        {
            if (!members.Contains(user))
            {
                throw new Exception("User is not a member of this group");
            }
            if (sellingUsers.Contains(user))
            {
                throw new Exception("User is already a selling user of this group");
            }
            sellingUsers.Add(user);
        }
        public void RemoveRequestingToSellUser(Guid user)
        {
            if (!members.Contains(user))
            {
                throw new Exception("User is not a member of this group");
            }
            if (!sellingUsers.Contains(user))
            {
                throw new Exception("User is not a selling user of this group");
            }
            sellingUsers.Remove(user);
        }
    }
}
