using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using KPOCOS.Domain.DTOs.Resquest;

namespace KPCOS.Api.Validators.Order
{
    public class OrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public OrderRequestValidator()
        {

        }
    }

}