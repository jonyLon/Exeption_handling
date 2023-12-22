namespace Exeption_handling
{
    internal class Program
    {
        class Account
        {
            private string mail;
            private string password;
            private string EmailValidation(string value)
            {

                if (value.Length >= 4 && value.Length < 50 && value.Contains('@') && value.All(e =>  Char.IsLetterOrDigit(e) || e == '_' || e == '.' || e == '@' ))
                {
                    return value;
                }
                else
                {
                    throw new ArgumentException($"Invalid email address: {value}. Email must be between 4 and 50 characters, contain '@', and only consist of letters, digits, or underscores.");
                }

            }
            private string PasswordValidation(string value)
            {

                if (value.Length >= 6 && value.Any(e => Char.IsDigit(e)) && value.Any(e => Char.IsLetter(e)))
                {
                    return value;
                }
                else
                {
                    throw new ArgumentException($"Invalid password: {value}. Password must be more than 5 characters, contain at least one digit and one letter.");
                }
                     
            }
            public string Email { get => mail; private set { mail = EmailValidation(value); } }
            private string Password { set => password = PasswordValidation(value); }

            public Account(string login, string password)
            {
                Email = login;
                Password = password;
            }

            public override string ToString()
            {
                return Email;
            }
        }


        static void Main(string[] args)
        {
            try
            {
                Account ak = new Account("fkjfj","password");
                Console.WriteLine(ak.ToString() + " account validated");
            }
            catch(ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Account ak1 = new Account("misterjons1254@mail.com", "password");
                Console.WriteLine(ak1.ToString() + " account validated");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Account ak2 = new Account("newmisterjons1254@mail.com", "password12");
                Console.WriteLine(ak2.ToString() + " account validated");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
