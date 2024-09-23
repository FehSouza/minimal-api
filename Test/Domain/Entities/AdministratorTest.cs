using minimals_api.Domain.Entities;

namespace Test.Domain.Entities
{
	[TestClass]
	public class AdministratorTest
	{
		[TestMethod]
		public void TestGetSetProps()
		{
			// Arrange
			var administrator = new Administrator();

			// Action
			administrator.Id = 1;
			administrator.Email = "test@test.com";
			administrator.Password = "test";
			administrator.Profile = "Admin";

			// Asset
			Assert.AreEqual(1, administrator.Id);
			Assert.AreEqual("test@test.com", administrator.Email);
			Assert.AreEqual("test", administrator.Password);
			Assert.AreEqual("Admin", administrator.Profile);
		}
	}
}