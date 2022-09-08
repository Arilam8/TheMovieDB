using DataTransferObject;
using System.Linq;
using Utils.TextUtils;

namespace BrowserApp.Models.Actors
{
    public class LightActorModel
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _surname;
        private string _name;
        private string _image;
        private string _role;
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

        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
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
            Image = string.Empty;
            Role = string.Empty;
        }

        public LightActorModel(LightActorDTO lightActorDTO)
        {
            Id = lightActorDTO.Id;
            Surname = lightActorDTO.Surname;
            Name = lightActorDTO.Name;
            Image = Utils.Constant.URL_IMAGE_THEMOVIEDB + lightActorDTO.Image;
            Role = TextUtils.GetTextList(lightActorDTO.Roles.Select(a => a.Character).ToList());
        }
        #endregion
    }
}
