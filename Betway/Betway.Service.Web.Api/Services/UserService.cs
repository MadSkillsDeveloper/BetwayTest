using AutoMapper;
using Betway.Service.Web.Api.DataContext;
using Betway.Service.Web.Api.DTO;

namespace Betway.Service.Web.Api.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        #endregion

        #region Properties

        #endregion

        #region Methods
        public async Task<bool> Login(UserRequest userLoginRequest)
        {
            if (userLoginRequest == null)
                throw new ArgumentNullException(nameof(userLoginRequest));

            var user = await _userRepository.GetAsync(x => x.Email == userLoginRequest.Email);

            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(userLoginRequest.Password, user.Password);
        }

        public async Task RegisterUser(UserRequest userRegisterRequest)
        {
            if (userRegisterRequest == null)
                throw new ArgumentNullException(nameof(userRegisterRequest));

            var user = _mapper.Map<User>(userRegisterRequest);
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

        }
        #endregion

        #region Constructors
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = _unitOfWork.Repository<User>();
        }

        #endregion
    }
}
