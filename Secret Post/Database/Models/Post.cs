using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace SecretPost.Database.Models
{
    [Table("Post")]
    public class Post
    {
        private uint id;
        private uint userId;
        private string title;
        private string message;
        private long createdAt;


        [PrimaryKey, AutoIncrement]
        public uint Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        public uint UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged(nameof(userId));
            }
        }

        [MaxLength(10)]
        public string Title
        {
            get { return title.ToUpper(); }
            set
            {
                title = value;
                OnPropertyChanged(nameof(title));
            }
        }

        [MaxLength(144)]
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(message));
            }
        }

        public DateTime CreatedAt
        {
            get { return new DateTime(createdAt); }
            set
            {
                createdAt = value.Ticks;
                OnPropertyChanged(nameof(createdAt));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
