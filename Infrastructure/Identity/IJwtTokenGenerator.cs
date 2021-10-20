namespace SimpleMusicStore.Infrastructure.Identity
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
