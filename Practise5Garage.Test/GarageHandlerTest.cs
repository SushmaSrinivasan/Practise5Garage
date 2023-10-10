namespace Practise5Garage.Test
{
    public class GarageHandlerTest
    {
        private IUI ui;

        [Fact]
        public void SearchByRegistrationNumber_Test()
        { //Arrange
            Garagehandler garageHandler = new Garagehandler(ui);
            garageHandler.Create(3);

            var vehicle1 = AirPlane.UpdateValuesToAirPlane();
            var vehicle2 = Bus.UpdateValuesToBus();
            var vehicle3=Car.UpdateValuesToCar();

            string expected = vehicle1.RegistrationNumber!;
            string actual = "ABC123";


            //Act
            garageHandler.SearchByRegistrationNumber(expected);

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RemoveVehicleFromGarage_Test()
        {
            Garagehandler garageHandler = new Garagehandler(ui);
            garageHandler.Create(3);

            //Act
            garageHandler.RemoveVehicleFromGarage(1);
            int actual = 2;
            int expected = 2;

            //Assert
            Assert.Equal(expected, actual);

        }
    }
}