namespace iMed.Core.Services.Contracts;

public interface IRateService : IScopedDependency
{
    Task ConfirmRateAsync(int rateId, CancellationToken cancellationToken);
    Task<bool> DeleteRateAsync(int rateId, CancellationToken cancellationToken);
}