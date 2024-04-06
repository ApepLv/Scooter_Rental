using FluentAssertions;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentedScooterArchiveTests
    {
        [TestMethod]
        public void AddRentedScooter_ShouldAddScooterToArchive()
        {
            // Arrange
            var rentedScooterArchive = new RentedScooterArchive(new List<RentedScooter>());
            var scooter = new RentedScooter("1", DateTime.Now, 0.2m);

            // Act
            rentedScooterArchive.AddRentedScooter(scooter);

            // Assert
            rentedScooterArchive.GetRentedScooters().Should().Contain(scooter);
        }

        [TestMethod]
        public void EndRental_ShouldSetRentEndForSpecifiedScooter()
        {
            // Arrange
            var scooterId = "1";
            var rentEnd = DateTime.Now;
            var rentedScooter = new RentedScooter(scooterId, DateTime.Now, 0.2m);
            var rentedScooterArchive = new RentedScooterArchive(new List<RentedScooter> { rentedScooter });

            // Act
            var result = rentedScooterArchive.EndRental(scooterId, rentEnd);

            // Assert
            result.RentEnd.Should().Be(rentEnd);
        }

        [TestMethod]
        public void GetRentedScooters_ShouldReturnListWithAddedScooter()
        {
            // Arrange
            var rentedScooter = new RentedScooter("1", DateTime.Now, 0.2m);
            var rentedScooterArchive = new RentedScooterArchive(new List<RentedScooter> { rentedScooter });

            // Act
            var result = rentedScooterArchive.GetRentedScooters();

            // Assert
            result.Should().Contain(s => s.ScooterId == rentedScooter.ScooterId);
        }
    }
}