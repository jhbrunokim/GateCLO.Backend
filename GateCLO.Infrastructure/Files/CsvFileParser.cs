
using CsvHelper;
using GateCLO.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using CsvHelper.Configuration;
using X.PagedList;

namespace GateCLO.Infrastructure.Files;

public class CsvFileParser : ICsvFileParser
{
    public async Task<List<EmployeeVm>> EmployeeCsvReader(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
        };

        using var csv = new CsvReader(reader, config);

        //csv.Context.RegisterClassMap<EmployeeMap>();

        var temp = await csv.GetRecords<EmployeeVm>().ToListAsync();

        return temp;
    }
}