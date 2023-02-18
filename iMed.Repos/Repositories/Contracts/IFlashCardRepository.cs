namespace iMed.Repos.Repositories.Contracts;

public interface IFlashCardRepository : IWriteRepository<FlashCard>, IReadRepository<FlashCard>, IScopedDependency
{
    
}