using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserApp.Models.Comments
{
    public class CommentModel
    {
        #region MEMBER_VARIABLES
        private int _id;
        private DateTime _date;
        private int _rate;
        private string _content;
        private string _username;
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
                }
            }
        }

        public int Rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
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
                }
            }
        }

        #endregion

        #region BUILDERS
        public CommentModel()
        {
            Id = -1;
            Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Rate = 0;
            Content = string.Empty;
            Username = string.Empty;
        }

        public CommentModel(CommentDTO commentDTO)
        {
            Id = commentDTO.Id;
            Date = commentDTO.Date;
            Rate = commentDTO.Rate;
            Content = commentDTO.Content;
            Username = commentDTO.Username;
        }
        #endregion
    }
}
