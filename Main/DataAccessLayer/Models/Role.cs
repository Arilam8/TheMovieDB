using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer.Models
{
    [Table("Role")]
    public class Role
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _character;
        private int _actorId;
        private Actor _actor;
        private int _movieId;
        private Movie _movie;
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

        public string Character
        {
            get { return _character; }
            set
            {
                if (_character != value)
                {
                    _character = value;
                }
            }
        }

        public int ActorId
        {
            get { return _actorId; }
            set
            {
                if (_actorId != value)
                {
                    _actorId = value;
                }
            }
        }

        public Actor Actor
        {
            get { return _actor; }
            set
            {
                if (_actor != value)
                {
                    _actor = value;
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
        #endregion

        #region BUILDERS
        public Role()
        {
            Id = -1;
            Character = string.Empty;
            ActorId = -1;
            MovieId = -1;
        }

        public Role(string character, Actor actor, Movie movie)
        {
            Character = character;
            ActorId = actor.Id;
            Actor = actor;
            MovieId = movie.Id;
            Movie = movie;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return "Id : " + Id + " Character : " + Character;
        }
        #endregion
    }
}
