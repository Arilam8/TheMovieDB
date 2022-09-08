using System;
using System.Collections.Generic;

namespace DataTransferObject
{
    public class ActorDTO : LightActorDTO
    {
        #region MEMBER_VARIABLES
        private int _nbMovies;
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
        public ActorDTO() : base()
        {
            NbMovies = 0;
            Bio = string.Empty;
            Birthdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Deathdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

        public ActorDTO(int id, string surname, string name, ICollection<RoleDTO> roles, int nbMovies) : base(id, surname, name, roles)
        {
            NbMovies = nbMovies;
            Bio = string.Empty;
            Birthdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Deathdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            string toString = "Id : " + Id + "\nSurname : " + Surname + "\nName : " + Name + "\nCount (Movie(s)) : " + NbMovies;
            if (Roles != null && Roles.Count > 0)
            {
                toString += "\nCharacter(s) : ";
                foreach (RoleDTO roleDTO in Roles)
                {
                    toString += "(" + roleDTO.ToString() + "), ";
                }
                toString = toString.Remove(toString.Length - 2);
            }
            return toString;
        }
        #endregion
    }
}
