using System;
using AutoMapper;
using Appeals.Application.Commons.Mappings;
using Appeals.Application.Interfaces;
using Appeals.Persistence;
using Xunit;

namespace Appeals.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public AppealsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = AppealsContextFactory.Create();
            var configureProvider = new MapperConfiguration(config =>
                config.AddProfile(new AssemblyMappingProfile(typeof(IAppealsDbContext).Assembly)));

            Mapper = configureProvider.CreateMapper();
        }

        public void Dispose()
        {
            AppealsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
