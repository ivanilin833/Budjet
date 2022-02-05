using Budjet.Domain;
using Budjet.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Budjet.Backend.Test.Common
{
    public class BudjetContextFactory
    {
        public static Guid ListTransactionAId = Guid.NewGuid();
        public static Guid ListTransactionBId = Guid.NewGuid();
        public static Guid ListTransactionCId = Guid.NewGuid();

        public static Guid UserId = Guid.NewGuid();

        public static Guid TransactionIdForDelete = Guid.NewGuid();
        public static Guid TransactionIdForUpdate = Guid.NewGuid();

        public static DateTime OnDate = DateTime.Parse("12/10/2020");
        public static DateTime StartDate = DateTime.Parse("1/1/2021");
        public static DateTime EndDate = DateTime.Parse("30/1/2021");

        public static BudjetDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BudjetDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BudjetDbContext(options);
            context.Database.EnsureCreated();
            context.ListTransactions.AddRange
                (
                    new ListTransaction
                    {
                        UserId = UserId,
                        DateCreated = DateTime.Parse("1/11/2020"),
                        ListTransactionId = ListTransactionAId,
                        Name = "TestList1"
                    },

                    new ListTransaction
                    {
                        UserId = UserId,
                        DateCreated = DateTime.Parse("10/11/2020"),
                        ListTransactionId = ListTransactionBId,
                        Name = "TestList2"
                    },

                    new ListTransaction
                    {
                        UserId = UserId,
                        DateCreated = DateTime.Parse("10/11/2020"),
                        ListTransactionId = ListTransactionCId,
                        Name = "TestList3"
                    }
                );

            context.Transactions.AddRange
                (
                    new Transaction
                    {
                        TransactionId = TransactionIdForUpdate,
                        ListTransactionId = ListTransactionAId,
                        DateCreated = OnDate,
                        Name = "test1",
                        TypeTransaction = "expenses",
                        Value = 10
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionAId,
                        DateCreated = OnDate,
                        Name = "test2",
                        TypeTransaction = "income",
                        Value = 1000
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionAId,
                        DateCreated = OnDate,
                        Name = "test3",
                        TypeTransaction = "income",
                        Value = 100
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionBId,
                        DateCreated = DateTime.Parse("1/2/2021"),
                        Name = "test4",
                        TypeTransaction = "expenses",
                        Value = 5
                    },

                    new Transaction
                    {
                        TransactionId = TransactionIdForDelete,
                        ListTransactionId = ListTransactionBId,
                        DateCreated = DateTime.Parse("3/2/2021"),
                        Name = "test5",
                        TypeTransaction = "expenses",
                        Value = 5
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionCId,
                        DateCreated = StartDate,
                        Name = "test6",
                        TypeTransaction = "expenses",
                        Value = 500
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionCId,
                        DateCreated = DateTime.Parse("5/1/2021"),
                        Name = "test7",
                        TypeTransaction = "expenses",
                        Value = 55
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionCId,
                        DateCreated = DateTime.Parse("10/1/2021"),
                        Name = "test8",
                        TypeTransaction = "income",
                        Value = 123
                    },

                    new Transaction
                    {
                        TransactionId = Guid.NewGuid(),
                        ListTransactionId = ListTransactionBId,
                        DateCreated = EndDate,
                        Name = "test9",
                        TypeTransaction = "income",
                        Value = 321
                    }
                );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(BudjetDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

