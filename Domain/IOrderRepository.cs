﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IOrderRepository
    {
        decimal GetTotalAmountSpent(string userId);
    }

    public class LoyaltyService
    {
        private readonly IOrderRepository _orderRepository;
        private const decimal LoyaltyPointRate = 0.1m;

        public LoyaltyService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public decimal CalculateLoyaltyPoints(string userId)
        {
            decimal totalAmountSpent = _orderRepository.GetTotalAmountSpent(userId);
            return totalAmountSpent * LoyaltyPointRate;
        }
    }
}
