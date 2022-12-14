using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;
    private readonly IMessageBusClient _messageBusClient;

    public PlatformsController(IPlatformRepository repository, IMapper mapper, ICommandDataClient commandDataClient, IMessageBusClient messageBusClient)
    {
        _repository = repository;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
        _messageBusClient = messageBusClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms...");

        var platformItems = _repository.GetAllPlatforms();

        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }

    [HttpGet("{id:int}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        Console.WriteLine("--> Getting Platforms...");

        var platformItem = _repository.GetPlatformById(id);
        if (platformItem != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platform)
    {
        var platformModel = _mapper.Map<Platform>(platform);
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();

        var createdPlatform = _mapper.Map<PlatformReadDto>(platformModel);

        // send sync message
        try
        {
            await _commandDataClient.SendPlatformToCommand(createdPlatform);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not send synchronuously: {ex.Message}");
        }

        // send async message
        try
        {
            var platformPublishedDto = _mapper.Map<PlatformPublishedDto>(createdPlatform);
            platformPublishedDto.Event = "Platform_Published";
            _messageBusClient.PublicNewPlatform(platformPublishedDto);
        }
        catch (Exception ex)
        {

            Console.WriteLine($"--> Could not send asynchronuously: {ex.Message}");
        }

        return CreatedAtRoute(nameof(GetPlatformById), new { Id = createdPlatform.Id }, createdPlatform);
    }
}