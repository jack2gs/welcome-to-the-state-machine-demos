﻿using System;

namespace Finance.Messages.Events
{
    public interface IPaymentAuthorized
    {
        Guid ReservationId { get; }
    }
}
