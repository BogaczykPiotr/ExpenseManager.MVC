namespace ExpenseManager.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if(user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var Id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            return new CurrentUser(Id);
        }

    }
}
