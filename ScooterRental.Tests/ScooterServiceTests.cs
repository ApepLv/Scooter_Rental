using FluentAssertions;
using ScooterRental.Exceptions;

namespace ScooterRental.Tests
{
    [TestClass]
    public class ScooterServiceTests
    {
        private ScooterService _scooterService;
        private List<Scooter> _scooters;
        private const string _defaultScooterId = "1";

        [TestInitialize]

        public void Setup()
        {
            _scooters = new List<Scooter>();
            _scooterService = new ScooterService(_scooters);
        }

        [TestMethod]

        public void AddScooter_Valid_Data_Provided_ScooterAdded()
        {
            //Act
            _scooterService.AddScooter(_defaultScooterId, 0.1m);

            //Assert
            _scooters.Count.Should().Be(1);
        }

        [TestMethod]
        public void AddScooter_Invalid_Price_Provided_InvalidPriceException_Expected()
        {
            //Act
            Action action = () => _scooterService.AddScooter(_defaultScooterId, 0.0m);

            //Assert
            action.Should().Throw<InvalidPriceException>();
        }

        [TestMethod]
        public void AddScooter_Invalid_Id_Provided_InvalidPriceException_Expected()
        {
            //Act
            Action action = () => _scooterService.AddScooter("", 0.0m);

            //Assert
            action.Should().Throw<InvalidIdException>();
        }

        [TestMethod]
        public void AddScooter_Add_Duplicate_Scooter_DuplicatedScooterException_Expected()
        {
            //Arrange 
            _scooters.Add(new Scooter(_defaultScooterId, 0.05m));

            //Act
            Action action = () => _scooterService.AddScooter(_defaultScooterId, 0.5m);

            //Assert
            action.Should().Throw<DuplicatedScooterException>();
        }

        [TestMethod]
        public void RemoveScooter_Existing_ScooterId_Provided_Scooter_Removed()
        {
            //Arrange 
            _scooters.Add(new Scooter(_defaultScooterId, 0.05m));

            //Act
            Action action = () => _scooterService.RemoveScooter(_defaultScooterId);

            //Assert
            action.Should().NotThrow();
            _scooters.Count.Should().Be(0);
        }

        [TestMethod]
        public void RemoveScooter_NonExisting_ScooterId_Provided_ScooterNotFoundException_Expected()
        {
            //Act
            Action action = () => _scooterService.RemoveScooter(_defaultScooterId);

            //Assert
            action.Should().Throw<ScooterNotFoundException>();
        }

        [TestMethod]
        public void GetScooterById_ScooterFound_ReturnsScooter()
        {
            // Arrange
            var scooterId = "existingId";
            var expectedScooter = new Scooter(scooterId, 0.05m);
            _scooters.Add(expectedScooter);

            // Act
            var result = _scooterService.GetScooterById(scooterId);

            // Assert
            result.Should().Be(expectedScooter);
        }

        [TestMethod]
        public void GetScooterById_ScooterNotFound_ThrowsScooterNotFoundException()
        {
            // Arrange
            Action action = () => _scooterService.GetScooterById("");

            //Assert
            action.Should().Throw<ScooterNotFoundException>();
        }

        [TestMethod]
        public void GetScooters_ListNotEmpty_ReturnsScooters()
        {
            // Arrange
            var expectedScooters = new List<Scooter>
            {
                new Scooter("id1", 0.05m),
                new Scooter("id2", 0.1m),
            };

            _scooters.AddRange(expectedScooters);

            // Act
            var result = _scooterService.GetScooters();

            // Assert
            result.Should().BeEquivalentTo(expectedScooters);
        }

        [TestMethod]
        public void GetScooters_ListEmpty_ThrowsEmptyScooterListException()
        {
            // Arrange
            _scooters.Clear();

            // Act & Assert
            Assert.ThrowsException<EmptyScooterListException>(() => _scooterService.GetScooters());
        }
    }
}
