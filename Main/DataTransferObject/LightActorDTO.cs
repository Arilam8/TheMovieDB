using System.Collections.Generic;

namespace DataTransferObject
{
    public class LightActorDTO
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _surname;
        private string _name;
        private string _image;
        private ICollection<RoleDTO> _roles;
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

        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                }
            }
        }

        public virtual ICollection<RoleDTO> Roles
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
        #endregion

        #region BUILDERS
        public LightActorDTO()
        {
            Id = -1;
            Surname = string.Empty;
            Name = string.Empty;
            Image = string.Empty;
            Roles = new List<RoleDTO>();
        }

        public LightActorDTO(int id, string surname, string name, ICollection<RoleDTO> roles)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Image = string.Empty;
            Roles = roles;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            string toString = "Id : " + Id + "\nSurname : " + Surname + "\nName : " + Name;
            if (Roles != null && Roles.Count > 0)
            {
                toString += "\nCharacter(s) : ";
                foreach(RoleDTO roleDTO in Roles)
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
