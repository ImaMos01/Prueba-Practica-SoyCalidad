using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaASP.Controllers;
using PruebaASP.DTOs;
using PruebaASP.Repository;

namespace TestASP
{
    public class AsignaturaTesting
    {
        private readonly HomeController _controller;
        private readonly IRepository<ProgramaDto, ProgAsigDto> _service;
        public AsignaturaTesting()
        {
            var serviceProvider = new ServiceCollection()
                // Register IRepository<ProgramaDto, ProgAsigDto> with its concrete class (ProgramaRepository)
                .AddTransient<IRepository<ProgramaDto, ProgAsigDto>, ProgramaRepository>()

                // Register IConfiguration for testing (a simple empty configuration for now)
                .AddSingleton<IConfiguration>(new ConfigurationBuilder().Build())

                // Add any other necessary services
                .BuildServiceProvider();

            // Resolve the service from the container
            _service = serviceProvider.GetService<IRepository<ProgramaDto, ProgAsigDto>>();

            _controller = new HomeController(_service);
        }
        
        [Fact]
        public async Task GetProgramas()
        {
            // Act: Call the controller method to get the result
            // Act
            var results = await _controller.GetProgramas();

            // Assert
            Assert.IsType<UnauthorizedResult>(results);

        }
    }
}