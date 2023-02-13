using Betway.Service.Web.Api.Helpers;

namespace Betway.Service.Web.Api.Extensions
{
    public static class ResultsExtension
    {
        #region Fields
        #endregion

        #region Propeties
        #endregion

        #region Methods
        public static SingleResult<TResult> AsSingleResult<TResult>(
            this TResult result,
            string message,
            bool isSuccess)
        {
            return new SingleResult<TResult>(message, result, isSuccess);
        }

        public static MultipleResult<TResult> AsMultipleResults<TResult>(
            this IList<TResult> results,
            string message,
            bool isSuccess)
        {
            return new MultipleResult<TResult>(results, message, isSuccess);
        }
        #endregion

        #region Constructors
        #endregion
    }
}
