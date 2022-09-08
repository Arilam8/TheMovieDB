using DataTransferObject;
using System;

namespace WPFApplication.Models
{
    public class CommentModel : ModelBase
    {
        #region MEMBER_VARIABLES
        private int _id;
        private DateTime _date;
        private float _rate;
        private string _content;
        private string _username;
        private bool _valid;
        private bool _modify;
        private bool _manipulation;
        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanaged(nameof(Id));
                }
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanaged(nameof(Date));
                }
            }
        }

        public float Rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    OnPropertyChanaged(nameof(Rate));
                }
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanaged(nameof(Content));
                }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanaged(nameof(Username));
                }
            }
        }

        public bool Valid
        {
            get { return _valid; }
            set
            {
                if (_valid != value)
                {
                    _valid = value;
                    OnPropertyChanaged(nameof(Valid));
                }
            }
        }

        public bool Modify
        {
            get { return _modify; }
            set
            {
                if (_modify != value)
                {
                    _modify = value;
                    OnPropertyChanaged(nameof(Modify));
                }
            }
        }

        public bool Manipulation
        {
            get { return _manipulation; }
            set
            {
                if (_manipulation != value)
                {
                    _manipulation = value;
                    OnPropertyChanaged(nameof(Manipulation));
                }
            }
        }
        #endregion

        #region BUILDERS
        public CommentModel()
        {
            Id = -1;
            Date = DateTime.Now;
            Rate = 0;
            Content = string.Empty;
            Username = string.Empty;
            Valid = false;
            Modify = false;
            Manipulation = false;
        }

        public CommentModel(CommentDTO commentDTO)
        {
            Id = commentDTO.Id;
            Date = commentDTO.Date;
            Rate = commentDTO.Rate;
            Content = commentDTO.Content;
            Username = commentDTO.Username;
            Valid = commentDTO.Valid;
            Modify = false;
            Manipulation = false;
        }
        #endregion
    }
}
