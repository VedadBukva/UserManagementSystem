using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces.Permission;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<PermissionRepository> _logger;

        public PermissionRepository(DBContext dbContext, ILogger<PermissionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<PermissionModel>> Get()
        {
            try
            {
                return await _dbContext.Permission.Select(p => new PermissionModel { Id = p.Id, Code = p.Code, Description = p.Description }).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "PermissionRepository-Get");
                return null;
            }
        }

    }
}