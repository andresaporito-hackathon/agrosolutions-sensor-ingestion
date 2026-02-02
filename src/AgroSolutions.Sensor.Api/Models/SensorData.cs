namespace AgroSolutions.Sensor.Api.Models;

public class SensorData
{
    public Guid TalhaoId { get; set; }
    public double UmidadeSolo { get; set; }
    public double Temperatura { get; set; }
    public double Precipitacao { get; set; }
    public DateTime Timestamp { get; set; }
}
