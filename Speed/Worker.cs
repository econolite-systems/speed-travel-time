// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Monitoring.Events.Extensions;
using Econolite.Ode.Monitoring.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Speed
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Worker(IHttpClientFactory httpClientFactory, IMetricsFactory metricsFactory, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _httpClientFactory = httpClientFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var client = _httpClientFactory.CreateClient(Consts.ACYCLICA_HTTP_CLIENT);
        }
    }
}
