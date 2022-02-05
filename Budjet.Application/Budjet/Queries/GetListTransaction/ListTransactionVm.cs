using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Budjet.Application.Common.Mappings;
using Budjet.Domain;

namespace Budjet.Application.Budjet.Queries.GetListTransaction
{
    public class ListTransactionVm : IMapWith<ListTransaction>
    {
        public Guid ListTransactionId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<GetTransactionVm> Income { get; set; }
        public IList<GetTransactionVm> Expenses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListTransaction, ListTransactionVm>()
                .ForMember(listTransactionVm => listTransactionVm.Name,
                    opt => opt.MapFrom(listTransaction => listTransaction.Name))
                .ForMember(listTransactionVm => listTransactionVm.ListTransactionId,
                    opt => opt.MapFrom(listTransaction => listTransaction.ListTransactionId))
                .ForMember(listTransactionVm => listTransactionVm.DateCreated,
                    opt => opt.MapFrom(listTransaction => listTransaction.DateCreated))
                .ForMember(listTransactionVm => listTransactionVm.Income,
                    opt => opt.MapFrom(listTransaction => listTransaction.Transaction.Where(c => c.TypeTransaction == "income")))
                .ForMember(listTransactionVm => listTransactionVm.Expenses,
                    opt => opt.MapFrom(listTransaction => listTransaction.Transaction.Where(c => c.TypeTransaction == "expenses")));

        }
    }
}
