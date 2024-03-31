using System;
using LegacyApp.Interfaces;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditLimitService;
        private Validator validator;
        
        [Obsolete]
        public UserService() 
        {
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
            validator = new Validator();
        }

        public UserService(IClientRepository clientRepository, ICreditLimitService creditLimitService)
        {
            _clientRepository = clientRepository;
            _creditLimitService = creditLimitService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
          
            validator.validateName(firstName, lastName);
            validator.validateMail(email);
            validator.validateDateOfBirth(dateOfBirth);

            var client = _clientRepository.GetById(clientId);
            
            var user = User.CreateUser(client, dateOfBirth, email, firstName, lastName);

            _creditLimitService.SetCreditLimit(user, client);

            if (user.CheckCreditLimit())
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
