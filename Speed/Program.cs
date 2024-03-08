// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Common.Extensions;
using Econolite.Ode.Monitoring.Metrics.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Econolite.Ode.Monitoring.Events.Extensions;
using Speed;
using System;

var source = "Speed";

await Host.CreateDefaultBuilder(args)
    .AddODELogging()
    .ConfigureServices((builderContext, services) =>
    {
        services.AddMetrics(builderContext.Configuration, source)
        .AddUserEventSupport(builderContext.Configuration, _ =>
        {
            _.DefaultSource = source;
            _.DefaultLogName = Econolite.Ode.Monitoring.Events.LogName.SystemEvent;
            _.DefaultCategory = Econolite.Ode.Monitoring.Events.Category.Server;
            _.DefaultTenantId = Guid.Empty;
        })
        .AddHttpClient(Consts.ACYCLICA_HTTP_CLIENT, _ =>
        {
            _.BaseAddress = new Uri("https://who.knows.com");
        });
        services.AddHostedService<Worker>();
    })
    .Build()
    .LogStartup()
    .RunAsync();
