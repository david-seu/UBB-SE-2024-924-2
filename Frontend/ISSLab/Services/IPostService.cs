﻿using ISSLab.Model.Entities;

namespace ISSLab.Services
{
    public interface IPostService
    {
        void AddPost(Post post);
        void ConfirmPost(Guid postID);
        void FavoritePost(Guid postID, Guid userID);
        Post GetPostById(Guid id);
        List<Post> GetPosts();
        void RemoveConfirmation(Guid postID);
        void RemovePost(Post post);
        void UnfavoritePost(Guid postID, Guid userID);
    }
}