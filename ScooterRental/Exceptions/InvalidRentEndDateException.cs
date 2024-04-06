namespace ScooterRental.Exceptions
{
    public class InvalidRentEndDateException : Exception
    {
        public InvalidRentEndDateException() : base("Invalid rental end date.")
        {

        }
    }
}
