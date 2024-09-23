using minimals_api.Domain.Entities;

namespace Test.Domain.Entities
{
	[TestClass]
	public class VehicleTest
	{
		[TestMethod]
		public void TestGetSetProps()
		{
			// Arrange
			var vehicle = new Vehicle();

			// Action
			vehicle.Id = 1;
			vehicle.Name = "Test Name";
			vehicle.Brand = "Test Brand";
			vehicle.Year = 2000;

			// Assert
			Assert.AreEqual(1, vehicle.Id);
			Assert.AreEqual("Test Name", vehicle.Name);
			Assert.AreEqual("Test Brand", vehicle.Brand);
			Assert.AreEqual(2000, vehicle.Year);
		}
	}
}