using System.ComponentModel.DataAnnotations;

string creditCardNumber = Environment.GetCommandLineArgs()[1];
Console.WriteLine(creditCardNumber);

try
{
    var validator = new CreditCardValidator.CreditCardValidator(creditCardNumber);
    Console.WriteLine("Credit Card Type: {0}", validator.Validate());
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();
