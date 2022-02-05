using AutoMapper;
using Budjet.Application.Budjet.Commands.CreateIncome;
using Budjet.Application.Common.Mappings;
using System;

namespace Budjet.WebApi.Models
{
    public class CreateTransactionDto: IMapWith<CreateIncomeCommand>
    {
        public Guid ListTransactionId { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTransactionDto, CreateIncomeCommand>()
            .ForMember(transactionCommand => transactionCommand.ListTransactionId,
                opt => opt.MapFrom(transactionDto => transactionDto.ListTransactionId))
            .ForMember(transactionCommand => transactionCommand.Value,
                opt => opt.MapFrom(transactionDto => transactionDto.Value))
            .ForMember(transactionCommand => transactionCommand.Name,
                opt => opt.MapFrom(transactionDto => transactionDto.Name));
        }
    }
}
