namespace DCMS.Application.Utilities
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
