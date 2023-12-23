using System.Globalization;

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


        public static string ValidateData(string data)
        {
            if (string.IsNullOrWhiteSpace(data) || !data.All(e => Char.IsLetter(e) || ", ''.".ToCharArray().Any(i => i == e)))
            {
                throw new ArgumentException($"Invalid input: data should not be null, empty, or whitespace, and must only contain letters, commas, single quotes, or periods.");
            }
            return data;
        }

        class CardNameExeption : ArgumentException
        {
            public CardNameExeption() : base("Name is invalid. It must only contain letters and spaces, and cannot be empty.", "CreditCard.Name") { }
        }
        class CardNumberExeption : ArgumentException
        {
            public CardNumberExeption() : base("Number is invalid. It must be exactly 16 digits long and cannot contain any letters or special characters.", "CreditCard.Number") { }
        }
        class CardExpirationExeption : ArgumentException
        {
            public CardExpirationExeption() : base("Expiration date is invalid. The date must be in the future.", "CreditCard.Expiration") { }
        }
        class CardCVVExeption : ArgumentException
        {
            public CardCVVExeption() : base("CVV is invalid. It must be exactly 3 digits long.", "CreditCard.CVV") { }
        }
        class CreditCard
        {

            private string name;
            private string number;
            private DateOnly expiration;
            private string cvv;



            private string NameValidation(string name)
            {
                if (!string.IsNullOrWhiteSpace(name) && name.All(l => Char.IsLetter(l) || l == ' ')) {
                    return name;
                }
                throw new CardNameExeption();
            }
            private string NumberValidation(string number)
            {
                if (!string.IsNullOrWhiteSpace(number) && number.All(d => Char.IsDigit(d)) && number.Length == 16)
                {
                    return number;
                }
                throw new CardNumberExeption();
            }
            private DateOnly ExpirationValidation(DateOnly date)
            {
                if (date >= DateOnly.FromDateTime(DateTime.Now))
                {
                    return date;
                }
                throw new CardExpirationExeption();
            }
            private string CVV_Validation(string cvv)
            {
                if (!string.IsNullOrWhiteSpace(cvv) && cvv.All(d => Char.IsDigit(d)) && cvv.Length == 3)
                {
                    return cvv;
                }
                throw new CardCVVExeption();
            }
            public string Name { get { return name; }
                private set {
                    name = NameValidation(value);
                } 
            }
            public string Number
            {
                get { return number; }
                private set
                {
                    number = NumberValidation(value);
                }
            }

            public string CVV
            {
                get { return cvv; }
                private set
                {
                    number = CVV_Validation(value);
                }
            }

            public DateOnly Expiration
            {
                get { return expiration; }
                private set
                {
                    expiration = ExpirationValidation(value);
                }
            }
            public CreditCard(string name, string number, DateOnly expiration, string cvv) 
            {
                Name = name;
                Number = number;
                Expiration = expiration;
                CVV = cvv;

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



            while (true)
            {
                try
                {
                    string line = ValidateData(Console.ReadLine());
                    Console.WriteLine(line);
                    Console.WriteLine("VALID");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.WriteLine();
            try
            {
                //CreditCard first = new CreditCard("Jon Don2", "56565656654", new DateOnly(2023,11,5), "45d");
                //CreditCard second = new CreditCard("Jon Don", "56565656654", new DateOnly(2023, 11, 5), "45d");
                //CreditCard third = new CreditCard("Jon Don", "5656654454518121", new DateOnly(2023, 11, 5), "45d");
                //CreditCard fourth = new CreditCard("Jon Don", "5656654454518121", new DateOnly(2024, 11, 5), "45d");
                CreditCard fifth = new CreditCard("Jon Don", "5656654454518121", new DateOnly(2024, 11, 5), "459");
            }
            catch (CardNameExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (CardNumberExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch(CardExpirationExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (CardCVVExeption ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}
