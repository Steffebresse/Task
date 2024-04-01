using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICountryInfoService
    {
        CountryInfo GetCountryInfo(string countrycode);
    }

    public interface INotificationService
    {
        void SendNotification(string userId, string message);
    }

    

    public class CountryInfo
    {


        public string CountryCode { get; set; }
        public string TravelRestrictions { get; set; }
        public string VeccinationReq { get; set; }
    }

     public class TravelAdvisorService
    {
        private readonly ICountryInfoService _countryInfoService;
        private readonly INotificationService _notificationService;

        public TravelAdvisorService(ICountryInfoService countryInfoService, INotificationService notificationService)
        {
            _countryInfoService = countryInfoService;
            _notificationService = notificationService;
        }

        public void ProvideTravelAdvice(string userId, string countryCode)
        {
            // Get country information
            var countryInfo = _countryInfoService.GetCountryInfo(countryCode);

            // Compose message with country information
            var message = $"Travel Restrictions: {countryInfo.TravelRestrictions}, Vaccination Requirement: {countryInfo.VeccinationReq}";

            // Send notification to user
            _notificationService.SendNotification(userId, message);
        }
    }
   
}
