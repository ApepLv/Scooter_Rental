using System.Runtime.Serialization;

namespace ScooterRental.Exceptions
{
    [Serializable]
    public class ScooterNotFoundException : Exception
    {
        public ScooterNotFoundException() : base ("Scooter with provided Id doesnt exist!") { }
    }
}