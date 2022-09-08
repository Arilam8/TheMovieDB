using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer.Models
{
    // Sources (ActorMovie):
    // https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
    // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=data-annotations%2Cfluent-api-simple-key%2Csimple-key
    [Table("Actor")]
    public class Actor
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _surname;
        private string _name;
        private ICollection<Role> _roles;
        private ICollection<Movie> _movies;
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
        public string Surname 
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                }
            }
        }

        [AllowNull]
        public string Name 
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
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

        public virtual ICollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public Actor()
        {
            Id = -1;
            Surname = string.Empty;
            Name = string.Empty;
            Roles = new List<Role>();
            Movies = new List<Movie>();
        }

        public Actor(int id, string surname, string name)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Roles = new List<Role>();
            Movies = new List<Movie>();
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return "Id : " + Id + " Name : " + Name + " Surname : " + Surname;
        }
        #endregion
    }
}
