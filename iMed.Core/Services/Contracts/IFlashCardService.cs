namespace iMed.Core.Services.Contracts;

public interface IFlashCardService : IScopedDependency
{

    public Task AddFlashCardAsync(FlashCard ent, CancellationToken cancellationToken);
    public Task RemoveFlashCardAsync(int id, CancellationToken cancellationToken);
}