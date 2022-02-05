using AutoMapper;
using Budjet.Application.Budjet.Commands.UpdateListTransaction;
using Budjet.Application.Common.Mappings;
using System;

namespace Budjet.WebApi.Models
{
    public class UpdateListTransactionDto: IMapWith<UpdateListTransactionCommand>
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateListTransactionDto, UpdateListTransactionCommand>()
                .ForMember(listTransactionCommand => listTransactionCommand.Name,
                    opt => opt.MapFrom(listTransactionDto => listTransactionDto.Name))
                .ForMember(listTransactionCommand => listTransactionCommand.ListTransactionId,
                    opt => opt.MapFrom(listTransactionDto => listTransactionDto.Id));
        }
    }
}
