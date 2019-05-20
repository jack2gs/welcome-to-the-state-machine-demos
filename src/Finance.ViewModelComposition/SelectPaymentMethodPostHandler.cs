﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Finance.Data;
using Finance.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using NServiceBus;
using ServiceComposer.AspNetCore;

namespace Finance.ViewModelComposition
{
    class SelectPaymentMethodPostHandler : IHandleRequests
    {
        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            var controller = (string)routeData.Values["controller"];
            var action = (string)routeData.Values["action"];

            return HttpMethods.IsPost(httpVerb)
                   && controller.ToLowerInvariant() == "finance"
                   && action.ToLowerInvariant() == "selectpaymentmethod";
        }

        public Task Handle(string requestId, dynamic vm, RouteData routeData, HttpRequest request)
        {
            var response = request.HttpContext.Response;
            response.Cookies.Append("reservation-payment-method-id", request.Form["PaymentMethod"]);

            return Task.CompletedTask;
        }
    }
}
