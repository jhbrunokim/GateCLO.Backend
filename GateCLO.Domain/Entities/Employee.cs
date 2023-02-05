namespace GateCLO.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Tel { get; set; }
    public DateTime Joined { get; set; }
}