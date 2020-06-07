using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using DAL.EF;

namespace DAL.Tests {
    class TestUserRepository
            : BaseRepository<User> {
        public TestUserRepository(DbContext context)
            : base(context) {

        }
    }
    public class BaseRepositoryUnitTests {
        [Fact]

        public void Create_InputUserInstance_CalledAddMethodOfDBSetWithUserInstance() {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PoliclinicContext>()
                .Options;
            var mockContext = new Mock<PoliclinicContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            mockContext
               .Setup(context =>
                    context.Set<User>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestUserRepository(mockContext.Object);
            User expectedUser = new Mock<User>().Object;
            //Act
            repository.Create(expectedUser);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedUser
                    ), Times.Once());
        }

		[Fact]
		public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId() {

			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<PoliclinicContext>()
				.Options;
			var mockContext = new Mock<PoliclinicContext>(opt);
			var mockDbSet = new Mock<DbSet<User>>();
			mockContext
				.Setup(context =>
					context.Set<User>(
						))
				.Returns(mockDbSet.Object);

			User expectedUserr = new User() { UserId = 1 };
			mockDbSet.Setup(mock => mock.Find(expectedUserr.UserId))
					.Returns(expectedUserr);
			var repository = new TestUserRepository(mockContext.Object);

			//Act
			var actualUser = repository.Get(expectedUserr.UserId);

			// Assert
			mockDbSet.Verify(
				dbSet => dbSet.Find(
					expectedUserr.UserId
					), Times.Once());
			Assert.Equal(expectedUserr, actualUser);
		}

		[Fact]
		public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg() {
			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<PoliclinicContext>()
				.Options;
			var mockContext = new Mock<PoliclinicContext>(opt);
			var mockDbSet = new Mock<DbSet<User>>();
			mockContext
				.Setup(context =>
					context.Set<User>(
						))
				.Returns(mockDbSet.Object);
			var repository = new TestUserRepository(mockContext.Object);

			User expectedUser = new User() { UserId = 1 };
			mockDbSet.Setup(mock => mock.Find(expectedUser.UserId)).Returns(expectedUser);

			//Act
			repository.Delete(expectedUser.UserId);

			// Assert
			mockDbSet.Verify(
				dbSet => dbSet.Find(
					expectedUser.UserId
					), Times.Once());
			mockDbSet.Verify(
				dbSet => dbSet.Remove(
					expectedUser
					), Times.Once());
		}

	}
}
