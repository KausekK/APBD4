using System;

namespace LegacyApp.Interfaces;

public interface ICreditLimitService
{
    int GetCreditLimit(string lastName, DateTime birthdate);
    void SetCreditLimit(User user, Client client);

}