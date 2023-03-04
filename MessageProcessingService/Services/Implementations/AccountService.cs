using System.Security.Cryptography;
using System.Text;
using MessageProcessingService.DAL;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Exceptions;
using MessageProcessingService.Extentions;
using MessageProcessingService.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingService.Services.Implementations;

public class AccountService : IAccountService
{
    private DatabaseContext _context;

    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<AccountDto?> FindAccount(string login, string password)
    {
        ArgumentNullException.ThrowIfNull(login, nameof(login));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        string passwordHash = GetPasswordHash(password);

        Account? account = await _context.Accounts
            .SingleOrDefaultAsync(x => x.Login == login && x.Password == passwordHash);

        return account?.AsDto();
    }

    public async Task<AccountDto> GiveEmployeeRights(Guid accountId, CancellationToken cancellationToken)
    {
        Account account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
        if (account.AllowCreateReports)
        {
            throw new RoleCollisionException(accountId);
        }

        account.AllowCheckMessages = true;
        await _context.SaveChangesAsync(cancellationToken);
        return account.AsDto();
    }

    public async Task<AccountDto> GiveAdminRights(Guid accountId, CancellationToken cancellationToken)
    {
        Account account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
        account.AllowCheckMessages = true;
        account.AllowCreateReports = true;
        account.AllowChangeSystem = true;
        await _context.SaveChangesAsync(cancellationToken);
        return account.AsDto();
    }

    public async Task<AccountDto> GiveManagerRights(Guid accountId, CancellationToken cancellationToken)
    {
        Account account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
        if (account.AllowCheckMessages)
        {
            throw new RoleCollisionException(accountId);
        }
        account.AllowCreateReports = true;
        await _context.SaveChangesAsync(cancellationToken);
        return account.AsDto();
    }

    private static string GetPasswordHash(string password)
    {
        using var hashingAlgorithm = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return BitConverter.ToString(hashingAlgorithm.ComputeHash(passwordBytes));
    }
}