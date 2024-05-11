﻿using System.Collections.ObjectModel;
using ISSLab.Model;

namespace ISSLab.ViewModel
{
    public interface IChatViewModel
    {
        ObservableCollection<Message> AllMessages { get; set; }
        Post RefferedPost { get; set; }
        User ChatUser { get; set; }

        void AddMessage(Message message);
        void SendBuyingMessage(string imagePath);
        void SendMessage(string message, bool isMine, bool isSellingPost);
    }
}