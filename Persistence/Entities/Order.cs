using System;
using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.Persistence.Entities
{
    public class Order : Entity
    {
        public string Description { get; set; }
        public long OrderNumber { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<OrderTrack> OrderTracks { get; set; }
        public void SetId(string id)
        {
            Id = id;
        }

        public void AddTrack()
        {
            var orderTracks = new List<OrderTrack>()
            {
                new OrderTrack() {
                    OrderId = Id,
                    TrackingDate=DateTime.Now,
                    OrderStatusId=OrderStatusId,
                }
            };

            OrderTracks = orderTracks;
        }

        public void MakeOrderCreated()
        {

            OrderStatusId = (int)OrderStatuses.Created;
            AddTrack();

        }
        public void MakeOrderPacking()
        {
            switch (OrderStatusId)
            {

                case (int)OrderStatuses.Packing:
                    throw new UseCaseException("Can't Packing Already Packing Order");
                case (int)OrderStatuses.Shipped:
                    throw new UseCaseException("Can't Packing Shipped  Order");
                case (int)OrderStatuses.Delivered:
                    throw new UseCaseException("Can't Packing Delivered Order");
                default:
                    OrderStatusId = (int)OrderStatuses.Packing;
                    AddTrack();
                    break;
            }
        }
        public void MakeOrderShipped()
        {
            switch (OrderStatusId)
            {
                case (int)OrderStatuses.Shipped:
                    throw new UseCaseException("Can't Packing Shipped  Order");
                case (int)OrderStatuses.Delivered:
                    throw new UseCaseException("Can't Packing Delivered Order");
                default:
                    OrderStatusId = (int)OrderStatuses.Shipped;
                    AddTrack();
                    break;
            }
        }
        public void MakeOrderDelivered()
        {
            switch (OrderStatusId)
            {
                case (int)OrderStatuses.Delivered:
                    throw new UseCaseException("Can't Packing Delivered Order");
                default:
                    OrderStatusId = (int)OrderStatuses.Delivered;
                    AddTrack();
                    break;
            }
        }
    }
}