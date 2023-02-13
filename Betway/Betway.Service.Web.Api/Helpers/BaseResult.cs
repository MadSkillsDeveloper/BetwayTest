namespace Betway.Service.Web.Api.Helpers
{
    public class BaseResult
    {
        #region Fields
        private bool _isSuccess;
        private string _message;
        #endregion

        #region Propeties
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public BaseResult()
        {

        }

        public BaseResult(string message, bool isSuccess = true)
        {
            _message = message;
            _isSuccess = isSuccess;
        }
        #endregion
    }
}
