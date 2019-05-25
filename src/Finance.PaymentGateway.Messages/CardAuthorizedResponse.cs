﻿using System;

namespace Finance.PaymentGateway.Messages
{
    public class CardAuthorizedResponse
    {
        public Guid ReservationId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
