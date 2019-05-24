﻿using Finance.PaymentGateway.Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Finance.Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceName = typeof(Program).Namespace;
            Console.Title = serviceName;

            var config = new EndpointConfiguration(serviceName);
            config.ApplyCommonConfiguration(configureRouting: routing =>
            {
                routing.RouteToEndpoint(typeof(AuthorizeCard), "Finance.PaymentGateway");
            });

            var endpointInstance = await Endpoint.Start(config);

            Console.WriteLine($"{serviceName} started. Press any key to stop.");
            Console.ReadLine();

            await endpointInstance.Stop();
        }
    }
}
