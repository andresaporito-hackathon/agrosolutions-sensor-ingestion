using AgroSolutions.Sensor.Api.Models;
using AgroSolutions.Sensor.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSolutions.Sensor.Api.Controllers;

[ApiController]
[Route("api/sensors")]
[Authorize]
public class SensorController : ControllerBase
{
    private readonly RabbitMqPublisher _publisher = new();

    [HttpPost]
    public IActionResult Send([FromBody] SensorData data)
    {
        _publisher.Publish(data);
        return Ok(new { message = "Dados enviados para a fila" });
    }
}
