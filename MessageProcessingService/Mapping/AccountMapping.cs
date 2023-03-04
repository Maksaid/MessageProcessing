using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Mapping;

public static class AccountMapping
{
    public static AccountDto AsDto(this Account account) =>
         new AccountDto(account.Id, account.EmployeeId, account.Login, GetRole(account));

    private static string GetRole(Account account)
    {
        return account.AllowChangeSystem ? "admin" :
            account.AllowCreateReports ? "manager" :
            account.AllowCheckMessages ? "employee" : "no role";
    }
}