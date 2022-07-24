﻿namespace SourDictionary.WebApp.Infrastructure.Models
{
    public class FavoriteClickedEventArgs : EventArgs
    {
        public Guid? EntryId { get; set; }
        public bool IsFaved { get; set; }
    }
}
