﻿namespace ScooterRental.Exceptions
{
    public class EmptyScooterListException : Exception
    {
        public EmptyScooterListException() : base("There are no scooters!")
        {

        }
    }
}
