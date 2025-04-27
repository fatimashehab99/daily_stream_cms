using NUnit.Framework;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using daily_stream_cms.Services;
using daily_stream_cms.Models;


namespace daily_stream_cms.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected AppDbContext _context;
        protected RolesService _rolesServices;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);

            _rolesServices = new RolesService(_context);
        }

        protected void SeedRoles()
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Editor" },
                new Role { Name = "Viewer" }
            };

            _context.Roles.AddRange(roles);
            _context.SaveChanges();
        }
    }
}
