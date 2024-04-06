namespace ScooterRental.Exceptions;

public class DuplicatedScooterException : Exception
{
    public DuplicatedScooterException() : base("Scooter with provided id already exists!")
    {

    }
}