namespace iMed.Core.Services.Contracts;

public interface IWalletService : IScopedDependency
{
    Task<IncreaseInventoryResponseDto> IncreaseInventoryAsync(int amount);
}