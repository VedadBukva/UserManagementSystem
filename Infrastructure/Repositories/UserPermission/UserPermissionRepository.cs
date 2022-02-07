using ApplicationCore.Entities;
using ApplicationCore.Interfaces.UserPermission;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserPermissionRepository : IUserPermissionRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<UserPermissionRepository> _logger;

        public UserPermissionRepository(DBContext dbContext, ILogger<UserPermissionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<PermissionModel>> GetByUserId(Guid guid)
        {
            try
            {
                var userList = await _dbContext.UserPermission.Where(up => up.UserId == guid)
                    .Include(up => up.Permission)
                    .Select(up => new PermissionModel {
                        Id = up.Permission.Id,
                        Code = up.Permission.Code,
                        Description = up.Permission.Description
                    }).ToListAsync(); 
                _dbContext.SaveChanges();
                return userList;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserPermissionRepository-GetByUserId");
                return null;
            }
        }

        public async Task<IEnumerable<PermissionModel>> GetByPermissionId(Guid guid)
        {
            try
            {
                var userList = await _dbContext.UserPermission.Where(up => up.PermissionId == guid)
                    .Include(up => up.Permission)
                    .Select(up => new PermissionModel
                    {
                        Id = up.Permission.Id,
                        Code = up.Permission.Code,
                        Description = up.Permission.Description
                    }).ToListAsync();
                _dbContext.SaveChanges();
                return userList;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserPermissionRepository-GetByPermissionId");
                return null;
            }
        }

        public async Task<UserPermissionModel> Add(UserPermissionModel model)
        {
            try
            {
                await _dbContext.UserPermission.AddAsync(new UserPermission
                {
                    UserId = model.UserId,
                    PermissionId = model.PermissionId
                });
                _dbContext.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserPermissionRepository-Add");
                return null;
            }
        }

        public async Task<bool> Delete(UserPermissionModel model)
        {
            try
            {
                var entity = await _dbContext.UserPermission.FirstOrDefaultAsync(up => up.UserId == model.UserId && up.PermissionId == model.PermissionId);
                if (entity != null)
                {
                    _dbContext.UserPermission.Remove(entity);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserPermissionRepository-Delete");
            }
            return false;
        }


    }
}