using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer.Models
{
    [Table("Comment")]
    public class Comment
    {
        #region MEMBER_VARIABLES
        private int _id;
        private int _movieId;
        private Movie _movie;
        private DateTime _date;
        private int _rate;
        private string _content;
        private string _username;
        private bool _valid;
        #endregion

        #region PROPERTIES
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public int MovieId
        {
            get { return _movieId; }
            set
            {
                if (_movieId != value)
                {
                    _movieId = value;
                }
            }
        }

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                if (_movie != value)
                {
                    _movie = value;
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

        [AllowNull]
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
        public Comment()
        {
            Id = -1;
            MovieId = -1;
            Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Rate = 0;
            Content = string.Empty;
            Username = string.Empty;
            Valid = false;
        }

        public Comment(Movie movie, DateTime date, int rate, string content, string username, bool valid = false)
        {
            MovieId = movie.Id;
            Movie = movie;
            Date = date;
            Rate = rate;
            Content = content;
            Username = username;
            Valid = valid;
        }

        public Comment(int id, Movie movie, DateTime date, int rate, string content, string username, bool valid = false)
        {
            Id = id;
            MovieId = movie.Id;
            Movie = movie;
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
            return "Id : " + Id + " Date : " + Date + " Rate : " + Rate + " Content : " + Content + " Username : " + Username + " Valid : " + Valid;
        }
        #endregion
    }
}
