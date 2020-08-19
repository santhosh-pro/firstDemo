namespace firstDemo.Common.Abstractions
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string TenantId { get; set; }
        bool IsAuthenticated { get; set; }
    }
}