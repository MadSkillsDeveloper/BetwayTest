using System.ComponentModel.DataAnnotations;

namespace Betway.Service.Web.Api.DataContext
{
    public class User
    {
        #region Fields
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public User()
        {

        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
        #endregion
    }
}
