using Microsoft.AspNetCore.Routing;

namespace GateCloApi.UintTests;

public class EmployeeTests
{
    private readonly HttpClient _client;

    public EmployeeTests()
    {
        _client = new GateCLOWebApplication().CreateClient();
    }
    [Fact]
    public void CreateEmployee()
    {
        //Arrange (GateCloWebapplication)

        //Act
        //_client.GetAsync()
        //Assert
    }

    [Fact]
    public void GetEmployeeByName()
    {

    }
    [Fact]
    public void GetEmployeeList()
    {

    }
} 