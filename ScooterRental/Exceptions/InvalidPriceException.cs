namespace ScooterRental.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException() : base("Provide price is not valid")
        {

        }
    }
}
