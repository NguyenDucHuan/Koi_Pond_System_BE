using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class OrderMapper
    {
        public static (Order, List<OrderItem>, Pond, List<PondComponent>) ToOrder(this CreateOrderRequest orderRequest)
        {
            var pond = orderRequest.OrderItems.FirstOrDefault().Pond;
            return (new Order
            {
                CreateOn = DateTime.Now,
                Status = orderRequest.Status,
                AccountId = orderRequest.AccountID,
                DiscouId = orderRequest.DiscouId,
                TotalMoney = orderRequest.TotalMoney,
            },
            new List<OrderItem>(
                orderRequest.OrderItems.Select(item => new OrderItem
                {
                    ServiceId = item.ServiceID,
                    TotalPrice = item.TotalPrice
                })
            ), new Pond
            {
                PondName = pond.PondName,
                Decription = pond.Decription,
                PondDepth = pond.PondDepth,
                Area = pond.Area,
                Location = pond.Location,
                Shape = pond.Shape,
                AccountId = orderRequest.AccountID
            }

            , new List<PondComponent>(
                pond.ListComponent.Select(item => new PondComponent
                {
                    ComponentId = item.ComponentId,
                    Amount = item.Amount
                })
            ));
        }
        public static GetOrderDetailResponse ToGetOrderDetailResponse(this Order order)
        {
            return new GetOrderDetailResponse
            {
                Id = order.Id,
                CreateOn = order.CreateOn,
                Status = order.Status,
                TotalMoney = order.TotalMoney,
                OrderItems = order.OrderItems.Select(item => new GetOrderItemResponse
                {
                    Id = item.Id,
                    ServiceId = item.ServiceId,
                    TotalPrice = item.TotalPrice,
                    Status = item.Status
                }).ToList()
            };
        }
    }
}