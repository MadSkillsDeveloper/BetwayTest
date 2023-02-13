using System.Text.Json;

namespace Betway.Service.Web.Api.Models
{
    public class ErrorDetails
    {
        #region Fields
        #endregion

        #region Properties
        public int StatusCode { get; set; }
        public string Message { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        #endregion

        #region Constructors
        #endregion
    }
}
