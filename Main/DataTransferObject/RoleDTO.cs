namespace DataTransferObject
{
    public class RoleDTO
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _character;
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
        #endregion

        #region BUILDERS
        public RoleDTO()
        {
            Id = -1;
            Character = string.Empty;
        }

        public RoleDTO(int id, string character)
        {
            Id = id;
            Character = character;
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
