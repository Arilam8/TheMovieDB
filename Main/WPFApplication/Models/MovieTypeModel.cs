using DataTransferObject;
using System;
using System.Windows.Media.Imaging;

namespace WPFApplication.Models
{
    public class MovieTypeModel : ModelBase
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _name;
        private BitmapImage _image;
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

        public BitmapImage Image
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
        #endregion

        #region BUILDERS
        public MovieTypeModel()
        {
            Id = -1;
            Name = string.Empty;
            Image = new BitmapImage();
        }

        public MovieTypeModel(MovieTypeDTO movieTypeDTO)
        {
            Id = movieTypeDTO.Id;
            Name = movieTypeDTO.Name;
            Image = Utils.Utils.MovieTypeDTOToImageMovieType(movieTypeDTO.Id);
        }
        #endregion
    }
}
