namespace DataTransferObject
{
    public class MovieTypeDTO
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _name;
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
        #endregion

        #region BUILDERS
        public MovieTypeDTO()
        {
            Id = -1;
            Name = string.Empty;
        }

        public MovieTypeDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return "Id : " + Id + " Name : " + Name;
        }
        #endregion
    }
}
