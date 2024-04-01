using Domain;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MockTest
    {
        [Fact]
        public void Test() 
        {
            var mock = new Mock<IOrderRepository>();

            mock.Setup(repo => repo.GetTotalAmountSpent("user123")).Returns(10);
            mock.Setup(repo => repo.GetTotalAmountSpent("SilentHill")).Returns(100);

            LoyaltyService Loyal = new(mock.Object);

            Assert.Equal(1, Loyal.CalculateLoyaltyPoints("user123"));
            Assert.Equal(10, Loyal.CalculateLoyaltyPoints("SilentHill"));
        }

         [Fact]
        public void ProvideTravelAdvice_Sends_Notification_With_Country_Info()
        {
            // Arrange
            var userId = "user123";
            var countryCode = "Zimbabwe";
            var countryInfo = new CountryInfo { CountryCode = countryCode, TravelRestrictions = "Någon", VeccinationReq = "Mycket" };

            var mockCountryService = new Mock<ICountryInfoService>();
            mockCountryService.Setup(repo => repo.GetCountryInfo(countryCode)).Returns(countryInfo); // Detta är som en IQuueriable

            var mockNotificationService = new Mock<INotificationService>();

            var travelAdvisorService = new TravelAdvisorService(mockCountryService.Object, mockNotificationService.Object);

            // Act
            travelAdvisorService.ProvideTravelAdvice(userId, countryCode);

            // Assert
            mockNotificationService.Verify(
                ns => ns.SendNotification(userId, $"Travel Restrictions: {countryInfo.TravelRestrictions}, Vaccination Requirement: {countryInfo.VeccinationReq}"), 
                Times.Once);
        }
    }
}
