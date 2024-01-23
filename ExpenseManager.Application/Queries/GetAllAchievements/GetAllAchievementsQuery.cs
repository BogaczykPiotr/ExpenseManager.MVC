
using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetAllAchievements
{
    public class GetAllAchievementsQuery : IRequest<IEnumerable<AchievementDto>>
    {
    }
}
