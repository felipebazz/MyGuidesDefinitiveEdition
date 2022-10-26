using AutoMapper;
using Microsoft.Extensions.Configuration;
using MyGuides.Notifications.Context;
using Steam.Api.Constants;
using Steam.Api.Interfaces;

namespace MyGuides.Application.Services
{
    public class SteamApiService
    {
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;
        private readonly ISteamUserStats _steamApi;
        private readonly IMapper _mapper;

        private string _apiKey = "";

        public SteamApiService(ISteamUserStats steamApi, IMapper mapper, INotificationService notificationService, IConfiguration configuration)
        {
            _notificationService = notificationService;
            _configuration = configuration;
            _steamApi = steamApi;
            _mapper = mapper;
            _apiKey = LoadApiKey();
        }

        public async void GetGameAchievement(string appId)
        {
            try
            {
                if (appId is null)
                {
                    _notificationService.AddNotification("Cadastar");
                    //return default;
                }

                var game = await _steamApi.GetSchemaForGameAsync(_apiKey, appId);


                    
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(ex.Message);
            }
        }

        private string LoadApiKey() => _configuration.GetSection(SteamApiConstants.SteamApiKey).ToString();       
    }
}
