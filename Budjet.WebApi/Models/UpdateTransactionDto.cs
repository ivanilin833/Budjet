using AutoMapper;
using Budjet.Application.Budjet.Commands.UpdateTransaction;
using Budjet.Application.Common.Mappings;
using System;

namespace Budjet.WebApi.Models
{
    public class UpdateTransactionDto: IMapWith<UpdateTransactionCommand>
    {
        public Guid ListTransactionId { get; set; }
        public Guid TransactionId { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTransactionDto, UpdateTransactionCommand>()
            .ForMember(transactionCommand => transactionCommand.ListTransactionId,
                opt => opt.MapFrom(transactionDto => transactionDto.ListTransactionId))
            .ForMember(transactionCommand => transactionCommand.TransactionId,
                opt => opt.MapFrom(transactionDto => transactionDto.TransactionId))
            .ForMember(transactionCommand => transactionCommand.Value,
                opt => opt.MapFrom(transactionDto => transactionDto.Value))
            .ForMember(transactionCommand => transactionCommand.Name,
                opt => opt.MapFrom(transactionDto => transactionDto.Name));
        }
    }
}
