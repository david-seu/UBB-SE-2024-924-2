﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ISSLab.Model.Entities
{
    public class UserMarketplace
    {
        private Guid id;
        private string username;
        private string realName;
        private DateOnly dateOfBirth;
        private string profilePicture;
        private string password;
        private int numberOfSales;
        private DateTime creationDate;
        private List<Guid> groupsWithSellingPrivilege;
        private List<Guid> groupsWithActiveRequestToSell;
        private List<Cart> carts;
        private List<UsersFavoritePosts> favorites;
        private List<Guid> groups;

        public UserMarketplace(string username, string realName, DateOnly dateOfBirth, string profilePicture, string password)
        {
            id = Guid.NewGuid();
            this.username = username;
            this.realName = realName;
            this.dateOfBirth = dateOfBirth;
            this.profilePicture = profilePicture;
            this.password = password;
            creationDate = DateTime.Now;
            groupsWithSellingPrivilege = new List<Guid>();
            groupsWithActiveRequestToSell = new List<Guid>();
            carts = new List<Cart>();
            favorites = new List<UsersFavoritePosts>();
            groups = new List<Guid>();
            numberOfSales = 0;
        }
        public UserMarketplace(Guid id, string username, string realName, DateOnly dateOfBirth, string profilePicture, string password, DateTime creationDate, List<Guid> groupsWithSellingPrivelage, List<Guid> groupsWithActiveRequestToSell, List<Cart> carts, List<UsersFavoritePosts> favorites, List<Guid> groups, int nrOfSells)
        {
            this.id = id;
            this.username = username;
            this.realName = realName;
            this.dateOfBirth = dateOfBirth;
            this.profilePicture = profilePicture;
            this.password = password;
            this.creationDate = creationDate;
            groupsWithSellingPrivilege = groupsWithSellingPrivelage;
            this.groupsWithActiveRequestToSell = groupsWithActiveRequestToSell;
            this.carts = carts;
            this.favorites = favorites;
            this.groups = groups;
            numberOfSales = nrOfSells;
            this.carts = carts;
            this.favorites = favorites;
            this.groups = groups;
        }

        public UserMarketplace()
        {
            id = Guid.NewGuid();
            username = Constants.EMPTY_STRING;
            realName = Constants.EMPTY_STRING;
            dateOfBirth = new DateOnly();
            profilePicture = Constants.EMPTY_STRING;
            password = Constants.EMPTY_STRING;
            creationDate = DateTime.Now;
            groupsWithSellingPrivilege = new List<Guid>();
            groupsWithActiveRequestToSell = new List<Guid>();
            numberOfSales = 0;
            carts = new List<Cart>();
            favorites = new List<UsersFavoritePosts>();
            groups = new List<Guid>();
        }

        public Guid Id { get => id; }
        public string Username { get => username; set => username = value; }
        public string RealName { get => realName; set => realName = value; }
        public DateOnly DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string ProfilePicture { get => profilePicture; set => profilePicture = value; }
        public string Password { get => password; set => password = value; }
        public DateTime CreationDate { get => creationDate; }

        public List<Cart> Carts { get => carts; }

        public List<UsersFavoritePosts> Favorites { get => favorites; }

        public List<Guid> Groups { get => groups; }

        public List<Guid> GroupsWithSellingPrivilege { get => groupsWithSellingPrivilege; }
        public List<Guid> GroupsWithActiveRequestToSell { get => groupsWithActiveRequestToSell; }

        public ImageSource? ProfilePictureImageSource
        {
            get
            {
                try
                {
                    return new BitmapImage(new Uri(profilePicture));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void AddCart(Cart newCart)
        {
            carts.Add(newCart);
        }

        public void AddFavorites(UsersFavoritePosts newFavorite)
        {
            favorites.Add(newFavorite);
        }
        public void AddGroup(Guid newGroup)
        {
            groups.Add(newGroup);
        }

        public int NumberOfSales { get => numberOfSales; set => numberOfSales = value; }

        public void RequestSellingAccess(Guid groupId)
        {
            if (groupsWithActiveRequestToSell.Contains(groupId))
            {
                throw new Exception("Already requested access to sell in this groupMarketplace");
            }
            if (groupsWithSellingPrivilege.Contains(groupId))
            {
                throw new Exception("Already have access to sell in this groupMarketplace");
            }
            groupsWithActiveRequestToSell.Add(groupId);
        }
        public void DenyAccessToSellInGroup(Guid groupId)
        {
            if (!groupsWithActiveRequestToSell.Contains(groupId))
            {
                throw new Exception("No active request to sell in this groupMarketplace");
            }
            groupsWithActiveRequestToSell = groupsWithActiveRequestToSell.FindAll(testedGroupId => testedGroupId != groupId);
        }
        public void TakeAwayAccessToSellInGroup(Guid groupId)
        {
            if (!groupsWithSellingPrivilege.Contains(groupId))
            {
                throw new Exception("No access to sell in this groupMarketplace");
            }
            groupsWithSellingPrivilege = groupsWithSellingPrivilege.FindAll(testedGroupId => testedGroupId != groupId);
        }

        public void GiveAccessToSellInGroup(Guid groupId)
        {
            if (groupsWithSellingPrivilege.Contains(groupId))
            {
                throw new Exception("You can already sell in this groupMarketplace");
            }
            groupsWithActiveRequestToSell = groupsWithActiveRequestToSell.FindAll(testedGroupId => testedGroupId != groupId);
            groupsWithSellingPrivilege.Add(groupId);
        }

        public bool HasAccessToSellInGroup(Guid groupId)
        {
            if (!groupsWithSellingPrivilege.Contains(groupId))
            {
                return false;
            }
            return true;
        }
    }
}