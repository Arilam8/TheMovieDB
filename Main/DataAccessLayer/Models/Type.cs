using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    // Sources (MovieType):
    // https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
    // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=data-annotations%2Cfluent-api-simple-key%2Csimple-key
    [Table("Type")]
    public class Type
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _name;
        private ICollection<Movie> _movies;
        #endregion

        #region PROPERTIES
        [Key]
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

        public virtual ICollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public Type()
        {
            Id = -1;
            Name = string.Empty;
            Movies = new List<Movie>();
        }

        public Type(int id, string name)
        {
            Id = id;
            Name = name;
            Movies = new List<Movie>();
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
