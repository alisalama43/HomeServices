using HomeServices.Domain.Common;
using HomeServices.Domain.Common.ResultPattern;
using HomeServices.Domain.Enum;
using MechanicShop.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Orders
{
    public class Order : AuditableEntity
    {
        public Guid ServiceRequestId { get;  set; }
        public Guid OfferId { get;  set; }
        public Guid CustomerId { get;  set; }
        public Guid TechnicianId { get;  set; }
        public decimal AgreedPrice { get;  set; } 
        public OrderStatus Status { get;  set; }
        public DateTime CreatedOn { get;  set; }
        public DateTime? CompletedOn { get;  set; }
        private Order() { }
        public Order(Guid id, Guid serviceRequestId, Guid offerId, Guid customerId, Guid technicianId, decimal agreedPrice, OrderStatus status, DateTime createdOn, DateTime? completedOn) : base(id)
        {
            ServiceRequestId = serviceRequestId;
            OfferId = offerId;
            CustomerId = customerId;
            TechnicianId = technicianId;
            AgreedPrice = agreedPrice;
            Status = status;
            CreatedOn = createdOn;
            CompletedOn = completedOn;
        }
        /* Confirmed = 1,
        TechnicianOnWay = 2,
         Completed = 4,
    Cancelled = 5
        */
        public void SatartOrder()
        {            
            Status = OrderStatus.TechnicianOnWay;
        }
        public void CompleteOrder()
        {
            Status = OrderStatus.Completed;
            CompletedOn = DateTime.UtcNow;
        }
        public Result<Order> CancelOrder()
        {
            if (Status == OrderStatus.Completed)
            
               return Ordererror.CompletedOrderCannotBeCancelled;  
            Status = OrderStatus.Cancelled;
            CompletedOn = DateTime.UtcNow;
            return this;
        }
        public Result<Order> ConfirmOrder()
        {
            if (Status == OrderStatus.Cancelled)
                return Ordererror.CompletedOrderCannotBeConfirmed;
            Status = OrderStatus.Confirmed;
            return this;
        }

    }
}
