using NUnit.Framework;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using daily_stream_cms.Services;
using daily_stream_cms.Models;

namespace daily_stream_cms.Tests
{
    public class RolesTest :BaseTest
    {
        [Test]
        public void getAllRolesShouldReturnAllRoles()
        {
            // Arrange
            SeedRoles();

            // Act
            var roles = _rolesServices.getAllRoles();

            // Assert
            roles.Should().NotBeNull();
            roles.Should().HaveCount(3);
        } 

    }
}
