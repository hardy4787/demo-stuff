using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTOs;

public record PlatformCreateDto([Required] string Name, [Required] string Publisher, [Required] string Cost);