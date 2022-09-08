namespace WebAPI.Swagger.Models
{
    public class Operation
    {
        #region MEMBER_VARIABLES
        private string _op;
        private string _path;
        private bool _value;
        #endregion

        #region PROPERTIES
        public string Op
        {
            get { return _op; }
            set
            {
                if (_op != value)
                {
                    _op = value;
                }
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    _path = value;
                }
            }
        }

        public bool Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public Operation()
        {
            Op = string.Empty;
            Path = string.Empty;
            Value = false;
        }

        public Operation(string op, string path, bool value = false)
        {
            Op = op;
            Path = path;
            Value = value;
        }
        #endregion
    }
}
