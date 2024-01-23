using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetAllAchievements
{
    public class GetAllAchievementsQueryHandler : IRequestHandler<GetAllAchievementsQuery, IEnumerable<AchievementDto>>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public GetAllAchievementsQueryHandler(IExpenseManagerRepository expenseManagerRepository,
            IMapper mapper,
            IUserContext userContext
            )
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        async Task<IEnumerable<AchievementDto>> IRequestHandler<GetAllAchievementsQuery, IEnumerable<AchievementDto>>.Handle(GetAllAchievementsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser()?.Id;
            if (userId == null)
            {
                return Enumerable.Empty<AchievementDto>();
            }
            var Achievements = await _expenseManagerRepository.GetAllAchievements(userId);
            var Dtos = _mapper.Map<IEnumerable<AchievementDto>>(Achievements);

            return Dtos;
        }
    }
}
