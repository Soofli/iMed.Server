namespace iMed.Infrastructure.RestServices;

public interface IRestApiWrapper : IScopedDependency
{
    IKaveNegarRestApi KaveNegarRestApi { get; }
    IDPayRestApi IDPayRestApi { get; }
}