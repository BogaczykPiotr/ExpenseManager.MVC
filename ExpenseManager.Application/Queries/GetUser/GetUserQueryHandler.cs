using AutoMapper;
using ExpenseManager.Application.DTOS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetUserQueryHandler(UserManager<Domain.Entities.ApplicationUser> userManager,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);


            var dto = _mapper.Map<Domain.Entities.ApplicationUser, UserDto>(currentUser);

            return dto;
        }
    }
}
