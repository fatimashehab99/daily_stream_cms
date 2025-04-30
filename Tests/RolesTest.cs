using NUnit.Framework;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using daily_stream_cms.Services;
using daily_stream_cms.Models;
using System.Data;

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

        [Test]
        public void GetRoleById_ShouldReturnNull_WhenRoleDoesNotExist()
        {
            // Arrange 
            Role role = new Role() { Name="Admin"};
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Act
            var result = _rolesServices.getRoleById(100);

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void GetRoleByIdShouldReturnCorrectRole()
        {
            // Arrange 
            Role role = new Role() { Name = "Admin" };
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Act
            var result = _rolesServices.getRoleById(role.Id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(role.Id);
            result.Name.Should().Be(role.Name);
        }

        [Test]
        public void UpdateRole_ShouldUpdateRole_WhenRoleExists()
        {
            // Arrange 
            Role role = new Role() { Name = "Admin" };
            _context.Roles.Add(role);  
            _context.SaveChanges();

            role.Name = "Author";

            // Act 
            var result=_rolesServices.UpdateRole(role);

            // Assert 
            result.Should().NotBeNull();
            result.Id.Should().Be(role.Id);
            result.Name.Should().Be("Author");

        }

        [Test]
        public void DeleteRole_ShouldReturnFalse_WhenRoleDoesNotExist()
        {
            // Arrange 
            Role role = new Role() { Name = "Admin" };
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Act 
            var result = _rolesServices.DeleteRole(3100);

            // Assert 
            result.Should().BeFalse();
        }

    }
}
