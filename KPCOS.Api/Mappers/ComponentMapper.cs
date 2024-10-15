using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Response.Componant;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class ComponentMapper
    {
        public static GetComponentTypesResponse MapToGetComponentsResponse(this List<ComponentType> componentTypes, List<Component> components)
        {
            return new GetComponentTypesResponse
            {
                ComponentTypes = componentTypes.Select(ct => new GetComponentsResponse
                {
                    Id = ct.Id,
                    Name = ct.Name,
                    Components = components.Where(c => c.ComponentTypeId == ct.Id).Select(c => new GetComponentResponse
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Decription = c.Decription,
                        PricePerItem = c.PricePerItem,
                        Image = c.Image,
                        Unit = c.Unit
                    }).ToList()
                }).ToList()
            };
        }
        public static Component ToCreateComponentRequest(this CreateComponentRequest request)
        {
            return new Component
            {
                Name = request.Name,
                Decription = request.Decription,
                PricePerItem = request.PricePerItem,
                ComponentTypeId = request.ComponentTypeId,
                Image = request.Image,
                Unit = request.Unit
            };
        }
    }
}