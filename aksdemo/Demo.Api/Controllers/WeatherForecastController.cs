// "//-----------------------------------------------------------------------".
// <copyright file="WeatherForecastController.cs" company="Microsoft">
// Copyright (c) 2020 Microsoft Corporation. All rights reserved.
// </copyright>
// "//-----------------------------------------------------------------------".

namespace Demo.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>WeatherForecastController.</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// Reference response.
        /// </summary>
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<WeatherForecastController> logger;

        /// <summary>Initializes a new instance of the <see cref="WeatherForecastController" /> class.
        /// </summary>
        /// <param name="logger">The logger.
        /// </param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets the weather forecast.
        /// </summary>
        /// <returns>List of forecast.</returns>
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var rng = new Random();

            return await Task.Run(() =>
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                APIVersion = "1.0",
            })
            .ToArray()).ConfigureAwait(false);
        }
    }
}
