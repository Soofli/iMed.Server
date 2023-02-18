using iMed.Infrastructure.Models;

namespace iMed.Infrastructure.RestServices;

public class RestApiWrapper : IRestApiWrapper
{
    public IKaveNegarRestApi KaveNegarRestApi { get; } = RestService.For<IKaveNegarRestApi>(RestAddress.BaseKaveNegar);
    public IDPayRestApi IDPayRestApi { get; } = RestService.For<IDPayRestApi>(RestAddress.BaseIDPay);
}