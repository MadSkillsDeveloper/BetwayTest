namespace Betway.Service.Web.Api.Helpers
{
    public class MultipleResult<TResult> : BaseResult
    {
        #region Fields
        private IList<TResult> _results;
        #endregion

        #region Propeties
        public IList<TResult> Results
        {
            get { return _results; }
            set { _results = value; }
        }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public MultipleResult()
        {
            _results = new List<TResult>();
        }

        public MultipleResult(
            IList<TResult> results,
            string message,
            bool isSuccess = true)
           : base(message, isSuccess)
        {
            _results = results;
        }
        #endregion
    }
}
