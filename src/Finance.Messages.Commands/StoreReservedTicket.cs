﻿using System;

namespace Finance.Messages.Commands
{
    public class StoreReservedTicket
    {
        public int TicketId { get; set; }
        public Guid ReservationId { get; set; }
    }
}
