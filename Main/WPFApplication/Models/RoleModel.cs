using DataTransferObject;

namespace WPFApplication.Models
{
    public class RoleModel : ModelBase
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
                    OnPropertyChanaged(nameof(Id));
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
                    OnPropertyChanaged(nameof(Character));
                }
            }
        }
        #endregion

        #region BUILDERS
        public RoleModel()
        {
            Id = -1;
            Character = string.Empty;
        }

        public RoleModel(RoleDTO roleDTO)
        {
            Id = roleDTO.Id;
            Character = roleDTO.Character;
        }
        #endregion
    }
}
