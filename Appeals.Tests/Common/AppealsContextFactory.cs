using System;
using Microsoft.EntityFrameworkCore;
using Appeals.Persistence;
using Appeals.Domain;

namespace Appeals.Tests.Common
{
    public class AppealsContextFactory
    {
        public static Guid AppealIdForDelete = Guid.NewGuid();

        public static AppealsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppealsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppealsDbContext(options);
            context.Database.EnsureCreated();

            var appealTypeA = new AppealType { Id = Guid.NewGuid(), Name = "A" };
            var appealTypeB = new AppealType { Id = Guid.NewGuid(), Name = "B" };

            context.AddRange(
                appealTypeA,
                appealTypeB,
                new Appeal
                {
                    Id = Guid.Parse("AC0E21CA-1F3F-4860-806B-37509CC9D21C"),
                    CreationDate = DateTime.Today,
                    Type = appealTypeA,
                    Message = "Message1",
                    Email = "Email1",
                    PhoneNumber = "Number1"
                },
                new Appeal
                {
                    Id = AppealIdForDelete,
                    CreationDate = DateTime.Today,
                    Type = appealTypeB,
                    Message = "Message2",
                    Email = "Email2",
                    PhoneNumber = "Number2"
                }, 
                new Appeal
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Today,
                    Type = appealTypeA,
                    Message = "Message3",
                    Email = "Email3",
                    PhoneNumber = "Number3"
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(AppealsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
