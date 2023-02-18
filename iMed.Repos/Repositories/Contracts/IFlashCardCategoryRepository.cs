using iMed.Domain.Dtos.LargDtos;

namespace iMed.Repos.Repositories.Contracts;

public interface IFlashCardCategoryRepository : IWriteRepository<FlashCardCategory>,IReadRepository<FlashCardCategory>,IScopedDependency
{
    Task<FlashCardCategoryLDto> GetLDtoAsync(int id);
    Task<bool> ChangeActiveStatusAsync(int id, bool isActive);
}