using PlatformService.DTOs;

namespace PlatformService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublicNewPlatform(PlatformPublishedDto platformPublishedDto);
    }
}
