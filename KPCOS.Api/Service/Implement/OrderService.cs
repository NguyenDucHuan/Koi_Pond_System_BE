using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Enums;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KPCOS.Api.Service.Implement
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IPondRepository _pondRepository;
        private readonly IPondComponentRepository _pondComponentRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IPondRepository pondRepository, IPondComponentRepository pondComponentRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _pondRepository = pondRepository;
            _pondComponentRepository = pondComponentRepository;
        }
        public async Task<string> CreateOrder(CreateOrderRequest orderRequest)
        {
            var order = orderRequest.ToOrder();
            var pondCreate = await _pondRepository.AddPondAsync(order.Item3);
            foreach (var item in order.Item4)
            {
                item.PondId = pondCreate.Id;
                await _pondComponentRepository.AddPondComponentAsync(item);
            }
            order.Item1.DiscouId = null;
            var orderCreate = await _orderRepository.AddOrderAsync(order.Item1);
            foreach (var item in order.Item2)
            {
                item.PondId = pondCreate.Id;
                item.OrderId = orderCreate.Id;
                await _orderItemRepository.AddOrderItemAsync(item);
            }
            return "Create order success";

        }

        public async Task<GetCurrentPondDashboardResponse> GetDashboardPondsRes(DateTime dateTimestart, DateTime dateTimeEnd, int curentPage, int numpage)
        {
            var orders = await _orderRepository.GetOrdersAsync();
            var orderInTime = orders.Where(c => c.CreateOn >= dateTimestart && c.CreateOn <= dateTimeEnd);
            if (orderInTime.Count() > numpage)
            {

            }
            throw new NotImplementedException();
        }

        public Task<RevenueDahboardResponse> GetDashboardRevenueRes(DateTime dateTimestart, DateTime dateTimeEnd)
        {

            var orders = _orderRepository.GetOrdersAsync().Result;
            var orderInTime = orders.Where(c => c.CreateOn >= dateTimestart && c.CreateOn <= dateTimeEnd);

            // Calculate the interval duration
            var totalDuration = dateTimeEnd - dateTimestart;
            var intervalDuration = TimeSpan.FromTicks(totalDuration.Ticks / 7);

            var dashboardData = new List<DashboardCol>();

            for (int i = 0; i < 7; i++)
            {
                var intervalStart = dateTimestart.AddTicks(intervalDuration.Ticks * i);
                var intervalEnd = intervalStart.AddTicks(intervalDuration.Ticks);

                var totalMoneyInInterval = orderInTime
                    .Where(order => order.CreateOn >= intervalStart && order.CreateOn < intervalEnd)
                    .Sum(order => order.TotalMoney);

                dashboardData.Add(new DashboardCol
                {
                    Time = $"{intervalStart:yyyy-MM-dd} to {intervalEnd:yyyy-MM-dd}",
                    Money = totalMoneyInInterval
                });
            }

            return Task.FromResult(new RevenueDahboardResponse
            {
                dashboards = dashboardData
            });
        }

        public Task<GetDashboardStatsResponse> GetDashboardStatsResponse(DateTime dateTimestart, DateTime dateTimeEnd)
        {
            var orders = _orderRepository.GetOrdersAsync().Result;

            Console.WriteLine(orders.Count());
            if (orders == null)
            {
                return Task.FromResult(new GetDashboardStatsResponse
                {
                    CompletedProjects = 0,
                    TotalProjects = 0,
                    TotalRevenue = 0,
                    OngoingProjects = 0,
                    TimeFillterStart = dateTimestart,
                    TimeFillterEnd = dateTimeEnd
                });
            }
            else
            {
                var orderInTime = orders.Where(c => c.CreateOn >= dateTimestart && c.CreateOn <= dateTimeEnd);
                var TotalProjects = orderInTime.Count();
                var TotalComplete = orderInTime.Count(s => s.Status == OrderEnum.Complete.ToString());
                var TotalOrderOnGoing = orderInTime.Count(s => s.Status != OrderEnum.Complete.ToString());
                var totalMoney = orderInTime.Sum(s => s.TotalMoney);
                var otalRevenue = (double)totalMoney;
                return Task.FromResult(new GetDashboardStatsResponse
                {
                    CompletedProjects = TotalComplete,
                    TotalProjects = TotalProjects,
                    TotalRevenue = otalRevenue,
                    OngoingProjects = TotalOrderOnGoing,
                    TimeFillterStart = dateTimestart,
                    TimeFillterEnd = dateTimeEnd
                });
            }
        }

        public async Task<GetOrderDetailResponse> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            var orderdetail = order.ToGetOrderDetailResponse();
            return orderdetail;
        }

        public async Task<List<GetOrderDetailResponse>> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            var response = new List<GetOrderDetailResponse>();
            foreach (var item in orders)
            {
                var orderdetail = item.ToGetOrderDetailResponse();
                response.Add(orderdetail);
            }
            return response;
        }

        public async Task<string> UpdateOrderStatus(int orderId, string status)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException("order ko tồn tại");
            }
            order.Status = status;
            await _orderRepository.UpdateOrderAsync(order);
            return "cập nhật thành công";
        }
    }
}
