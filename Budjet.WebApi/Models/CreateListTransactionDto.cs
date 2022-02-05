using AutoMapper;
using Budjet.Application.Budjet.Commands.CreateListTransaction;
using Budjet.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Budjet.WebApi.Models
{
    public class CreateListTransactionDto: IMapWith<CreateListTransactionCommand>
    {
        [Required]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateListTransactionDto, CreateListTransactionCommand>()
                .ForMember(listTransactionCommand => listTransactionCommand.Name,
                    opt => opt.MapFrom(listTransactionDto => listTransactionDto.Name));
        }
    }
}
