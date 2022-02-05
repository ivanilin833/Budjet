using AutoMapper;
using System;
using Budjet.Application.Common.Mappings;
using Budjet.Domain;

namespace Budjet.Application.Budjet.Queries.GetListTransaction
{
    public class GetTransactionVm : IMapWith<Transaction>
    {
        public Guid TransactionId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime DateCreated { get; set;}
        public string TypeTransaction { get; set;}

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transaction, GetTransactionVm>()
                .ForMember(transaktionVm => transaktionVm.Name,
                    opt => opt.MapFrom(transaction => transaction.Name))
                .ForMember(transaktionVm => transaktionVm.TransactionId,
                    opt => opt.MapFrom(transaction => transaction.TransactionId))
                .ForMember(transaktionVm => transaktionVm.DateCreated,
                    opt => opt.MapFrom(transaction => transaction.DateCreated))
                .ForMember(transaktionVm => transaktionVm.Value,
                    opt => opt.MapFrom(transaction => transaction.Value));
        }
    }
}
