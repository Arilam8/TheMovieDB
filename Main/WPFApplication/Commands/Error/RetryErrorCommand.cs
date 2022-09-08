using WPFApplication.ViewModels;

namespace WPFApplication.Commands
{
    public class RetryErrorCommand : CommandBase
    {
        #region MEMBER_VARIABLES
        private ErrorsViewModel _errorsViewModel;
        #endregion

        #region PROPERTIES
        public ErrorsViewModel ErrorsViewModel
        {
            get { return _errorsViewModel; }
            set
            {
                if (_errorsViewModel != value)
                {
                    _errorsViewModel = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public RetryErrorCommand(ErrorsViewModel errorsViewModel)
        {
            ErrorsViewModel = errorsViewModel;
        }
        #endregion

        #region METHODS
        public override void Execute(object? parameter)
        {
            ErrorsViewModel.Retry();   
        }
        #endregion
    }
}
