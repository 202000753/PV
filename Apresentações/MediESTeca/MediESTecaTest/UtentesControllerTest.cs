using MediESTeca.Areas.Identity.Data;
using MediESTeca.Controllers;
using MediESTeca.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MediESTecaTest
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AsAsyncQueryable<T>(this IEnumerable<T> input)
        {
            return new NotInDbSet<T>(input);
        }
    }

    public class NotInDbSet<T> : IQueryable<T>, IAsyncEnumerable<T>, IEnumerable<T>, IEnumerable
    {
        private readonly List<T> _innerCollection;

        public NotInDbSet(IEnumerable<T> innerCollection)
        {
            _innerCollection = innerCollection.ToList();
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return new AsyncEnumerator(GetEnumerator());
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public class AsyncEnumerator : IAsyncEnumerator<T>
        {
            private readonly IEnumerator<T> _enumerator;
            public AsyncEnumerator(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
            }

            public ValueTask DisposeAsync()
            {
                return new ValueTask();
            }

            public ValueTask<bool> MoveNextAsync()
            {
                return new ValueTask<bool>(_enumerator.MoveNext());
            }

            public T Current => _enumerator.Current;
        }

        public Type ElementType => typeof(T);
        public Expression Expression => Expression.Empty();
        public IQueryProvider Provider => new EnumerableQuery<T>(Expression);
    }
    public class UtentesControllerTest
    {
        [Fact]
        public async Task Index_CanLoadFromContext()
        {
            var options = new DbContextOptionsBuilder<MediESTecaComIdentityContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;
            var context = new MediESTecaComIdentityContext(options);

            var mockUserManager = new Mock<UserManager<Utente>>(new Mock<IUserStore<Utente>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<Utente>>().Object,
                new IUserValidator<Utente>[0],
                new IPasswordValidator<Utente>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<Utente>>>().Object);

            IList<Utente> listaUtentes = new List<Utente>
            {
                new Utente()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Joao",
                    Email = "joao@ip.pt"
                },
                new Utente()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Ana",
                    Email = "ana@ips.pt"
                },
                new Utente()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Elsa",
                    Email = "elsanunes95@gmail.com"
                }
            };

            var utentes = listaUtentes.AsAsyncQueryable();
            mockUserManager.Setup(u => u.Users)
                .Returns(utentes);


            var controller = new UtentesController(context, mockUserManager.Object);
            mockUserManager.Setup(u => u.GetUserAsync(controller.User)).ReturnsAsync(listaUtentes[0]);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Utente>>(
                viewResult.ViewData.Model);
            Assert.NotNull(model);
            Assert.Equal(3, model.Count());
        }
    }
}
