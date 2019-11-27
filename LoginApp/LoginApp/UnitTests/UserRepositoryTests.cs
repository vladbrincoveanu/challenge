using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Domain.Models;
using LoginApp.Domain.Repository;
using Moq;
using NUnit.Framework;
using Xunit;

namespace LoginApp.UnitTests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private readonly Mock<ironmountainEntities> _context = new Mock<ironmountainEntities>();
        private readonly Mock<DbSet<User>> _dbSetMock = new Mock<DbSet<User>>();
        private List<User> _usersInMemoryDatabase;

        public UserRepositoryTests()
        {
            var _usersInMemoryDatabase = new List<User>
            {
                new User() {Name = "wow", Password = "daa"},
                new User() {Name = "das", Password = "Book2"},
                new User() {Name = "bb", Password = "Book3"}
            };
        }

        [TestCase]
        public void AddUserMethodPassed_ProperMethodCalled()
        {
            //Arrange 
            var test = new User(){Name = "hello",Password = "dadad"};
            _context.Setup(x => x.Users).Returns(_dbSetMock.Object);
            _dbSetMock.Setup(x => x.Add(It.IsAny<User>())).Returns(test);

            //Act
            var rep = new UserRepository(_context.Object);
            rep.InsertUser(test);
            //Assert
            _context.Verify(x=>x.Set<User>());
            _dbSetMock.Verify(x=>x.Add(It.Is<User>(y=>y == test)));
        }

        [TestCase]
        public void DeleteUserMethodPassed_ProperMethodCalled()
        {
            //Arrange 
            var test = new User() { Name = "hello", Password = "dadad" };
            _context.Setup(x => x.Users).Returns(_dbSetMock.Object);
            _dbSetMock.Setup(x => x.Remove(It.IsAny<User>())).Returns(test);
            _dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(test);

            //Act
            var rep = new UserRepository(_context.Object);
            rep.DeleteUser(1);
            //Assert
            _context.Verify(x => x.Set<User>());
            _dbSetMock.Verify(x => x.Remove(It.Is<User>(y => y == test)));
        }
    }
}
