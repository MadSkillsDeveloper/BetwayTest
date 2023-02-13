namespace Betway.Service.Web.Api.Helpers
{
    public class SingleResult<TResult> : BaseResult
    {
        #region Fields
        private TResult _result;
        #endregion

        #region Propeties
        public TResult Result
        {
            get { return _result; }
            set { _result = value; }
        }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public SingleResult(
            string message,
            TResult result,
            bool isSuccess = true)
            : base(message, isSuccess)
        {
            _result = result;
        }

        public SingleResult()
        {

        }
        #endregion
    }
}
