using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

// Sources :
// https://docs.microsoft.com/en-us/ef/core/modeling/generated-properties?tabs=data-annotations
// https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/types
namespace DataAccessLayer.Models
{
    [Table("Movie")]
    public class Movie
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _title;
        private DateTime _releaseDate;
        private float _rating;
        private int _runtime;
        private string _poster;
        private ICollection<Actor> _actors;
        private ICollection<Role> _roles;
        private ICollection<Type> _types;
        private ICollection<Comment> _comments;
        #endregion

        #region PROPERTIES
        [Key]
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

        [AllowNull]
        public String Title 
        {
            get { return _title; }
            set
            {
                if(_title != value)
                {
                    _title = value;
                }
            }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                if (_releaseDate != value)
                {
                    _releaseDate = value;
                }
            }
        }

        public float Rating 
        {
            get { return _rating; }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                }
            }
        }

        public int Runtime 
        {
            get { return _runtime; }
            set
            {
                if (_runtime != value)
                {
                    _runtime = value;
                }
            }
        }

        public string Poster
        {
            get { return _poster; }
            set
            {
                if (_poster != value)
                {
                    _poster = value;
                }
            }
        }

        public virtual ICollection<Actor> Actors
        {
            get { return _actors; }
            set
            {
                if (_actors != value)
                {
                    _actors = value;
                }
            }
        }

        public virtual ICollection<Role> Roles
        {
            get { return _roles; }
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                }
            }
        }

        public virtual ICollection<Type> Types
        {
            get { return _types; }
            set
            {
                if (_types != value)
                {
                    _types = value;
                }
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public Movie ()
        {
            Id = -1;
            Title = string.Empty;
            ReleaseDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Rating = 0;
            Runtime = -1;
            Poster = string.Empty;
            Actors = new List<Actor> ();
            Roles = new List<Role>();
            Types = new List<Type> ();
            Comments = new List<Comment> ();
        }

        public Movie(int id, string title, DateTime releaseDate, float rating, int runtime, string poster)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Rating = rating;
            Runtime = runtime;
            Poster = poster;
            Actors = new List<Actor>();
            Roles = new List<Role>();
            Types = new List<Type>();
            Comments = new List<Comment>();
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return "Id : " + Id + " Title : " + Title + " ReleaseTime : " + ReleaseDate + " Rating : " + Rating + " Runtime : " + Runtime + " Poster : " + Poster;
        }
        #endregion
    }
}
