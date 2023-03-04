using MessageProcessingService.Dto;

namespace MessageProcessingService.Services;

public interface IAccountService
{
    Task<AccountDto?> FindAccount(string login, string password);

    Task<AccountDto> GiveEmployeeRights(Guid accountId, CancellationToken cancellationToken);
    Task<AccountDto> GiveAdminRights(Guid accountId, CancellationToken cancellationToken);
    Task<AccountDto> GiveManagerRights(Guid accountId, CancellationToken cancellationToken);

}