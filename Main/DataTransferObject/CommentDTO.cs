using System;

namespace DataTransferObject
{
    public class CommentDTO
    {
        #region MEMBER_VARIABLES
        private int _id;
        private DateTime _date;
        private int _rate;
        private string _content;
        private string _username;
        private bool _valid;
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

        public bool Valid
        {
            get { return _valid; }
            set
            {
                if (_valid != value)
                {
                    _valid = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public CommentDTO()
        {
            Id = -1;
            Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Rate = 0;
            Content = string.Empty;
            Username = string.Empty;
            Valid = false;
        }

        public CommentDTO(int id, DateTime date, int rate, string content, string username, bool valid = false)
        {
            Id = id;
            Date = date;
            Rate = rate;
            Content = content;
            Username = username;
            Valid = valid;
        }

        public CommentDTO(DateTime date, int rate, string content, string username, bool valid = false)
        {
            Date = date;
            Rate = rate;
            Content = content;
            Username = username;
            Valid = valid;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return "Id : " + Id + " Date : " + Date + " Rating : " + Rate + " Content : " + Content + " Username : " + Username + " Valid : " + Valid;
        }
        #endregion
    }
}
