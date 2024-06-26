﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ISSLab.Model.Entities
{
    public class Message
    {
        public string? Content { get; set; }
        public double Width { get; set; }

        public bool IsMine { get; set; }
        public SolidColorBrush? BubbleColor { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }

        public string? ImagePath { get; set; }

        public bool AcceptButtonIsVisible { get; set; }
        public bool RejectButtonIsVisible { get; set; }

        public RoutedEventHandler? AcceptButtonClicked { get; set; }
        public RoutedEventHandler? RejectButtonClicked { get; set; }
    }
}
