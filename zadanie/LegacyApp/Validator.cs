using System;

namespace LegacyApp;

public class Validator
{
    public bool validateName(string fName, string lName)
    {
        if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
        {
            return false;
        }

        return true;
    }

    public bool validateMail(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }
        return true;
    }

    public bool validateDateOfBirth(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < 21)
        {
            return false;
        }

        return true;
    }
}