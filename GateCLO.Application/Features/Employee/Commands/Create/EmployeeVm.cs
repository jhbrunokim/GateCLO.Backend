using System.Runtime.CompilerServices;
using CsvHelper.Configuration.Attributes;

public class EmployeeVm
{
    [Index(0)]
    public string Name { get; set; }
    [Index(1)]
    public string Email { get; set; }
    [Index(2)]
    public string Tel { get; set; }
    [Index(3)]
    public DateTime Joined { get; set; }
}