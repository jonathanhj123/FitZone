using System.Net.Mail;

namespace MongoDBIntroductionProject.Validation
{
    public static class EmailValidator
    {
        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            try
            {
                var addr = new MailAddress(email);

                // MailAddress accepts things like "Anna <anna@x.dk>", so make sure
                // the input was only the address itself
                if (addr.Address != email)
                    return false;

                // Require a dot in the domain part (rejects "anna@localhost")
                var domain = addr.Host;
                return domain.Contains('.') && !domain.StartsWith('.') && !domain.EndsWith('.');
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}