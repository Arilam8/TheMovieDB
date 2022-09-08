using DataTransferObject;
using Utils.APIUtils;
using Utils.DownloadUtils;
using WPFApplication.Utils;

namespace WPFApplication.Models
{
    public class LightActorModel : ModelBase
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _surname;
        private string _name;
        private byte[] _image;
        private RoleModel _role;
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

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanaged(nameof(Surname));
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
                    OnPropertyChanaged(nameof(Name));
                }
            }
        }

        public byte[] Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanaged(nameof(Image));
                }
            }
        }

        public RoleModel Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanaged(nameof(Role));
                }
            }
        }
        #endregion

        #region BUILDERS
        public LightActorModel()
        {
            Id = -1;
            Surname = string.Empty;
            Name = string.Empty;
            Image = new byte[0];
            Role = new RoleModel();
        }

        public LightActorModel(LightActorDTO lightActorDTO)
        {
            Id = lightActorDTO.Id;
            Surname = lightActorDTO.Surname;
            Name = lightActorDTO.Name;
            Image = DownloadUtils.DownloadImage(Constant.URL_IMAGE_THEMOVIEDB + lightActorDTO.Image);
            Role = new RoleModel();
        }

        public LightActorModel(LightActorDTO lightActorDTO, RoleModel roleModel)
        {
            Id = lightActorDTO.Id;
            Surname = lightActorDTO.Surname;
            Name = lightActorDTO.Name;
            Image = DownloadUtils.DownloadImage(Constant.URL_IMAGE_THEMOVIEDB + lightActorDTO.Image);
            Role = roleModel;
        }
        #endregion
    }
}
