using DataTransferObject;
using System;
using BrowserApp.Models.Actors;

namespace BrowserApp.Models
{
    public class ActorModel : LightActorModel
    {
        #region MEMBER_VARIABLES
        private int _nbMovies;
        private int _age;
        private string _bio;
        private DateTime _birthdate;
        private DateTime _deathdate;
        #endregion

        #region PROPERTIES
        public int NbMovies
        {
            get { return _nbMovies; }
            set
            {
                if (_nbMovies != value)
                {
                    _nbMovies = value;
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                }
            }
        }

        public string Bio
        {
            get { return _bio; }
            set
            {
                if (_bio != value)
                {
                    _bio = value;
                }
            }
        }

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                }
            }
        }

        public DateTime Deathdate
        {
            get { return _deathdate; }
            set
            {
                if (_deathdate != value)
                {
                    _deathdate = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public ActorModel() : base()
        {
            NbMovies = 0;
            Bio = string.Empty;
            Birthdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Deathdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Age = -1;
        }

        public ActorModel(ActorDTO actorDTO) : base(actorDTO)
        {
            NbMovies = actorDTO.NbMovies;
            Bio = actorDTO.Bio;
            Birthdate = actorDTO.Birthdate;
            Deathdate = actorDTO.Deathdate;
            Age = GetAge();
        }
        #endregion

        #region METHODS
        private int GetAge()
        {
            if (Birthdate == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                return -1;
            TimeSpan timeSpan;
            if (Deathdate == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                timeSpan = DateTime.Now - Birthdate;
            else
                timeSpan = Deathdate - Birthdate;
            return (new DateTime(1, 1, 1) + timeSpan).Year - 1;
        }
        #endregion
    }
}