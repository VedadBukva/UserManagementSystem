using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DBContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<PaginationDto<UserModel>> Get(UserModel userModel, PaginationQueryDto paginationQueryDto)
        {
            var paginationDto = new PaginationDto<UserModel>();

            var query = _dbContext.User.AsQueryable();
            try
            {
                if(paginationQueryDto.SortBy != null)
                {
                    query = paginationQueryDto.OrderBy == "ASC" ?
                        query.OrderBy(el => EF.Property<object>(el, paginationQueryDto.SortBy)) : query.OrderByDescending(el => EF.Property<object>(el, paginationQueryDto.SortBy));
                }
                else
                {
                    query = query.OrderBy(el => el.FirstName);
                }

                paginationDto.TotalItems = query.ToList().Count();

                paginationDto.ModelList = await query.Select(u => new UserModel
                                                    {
                                                        Id = u.Id,
                                                        FirstName = u.FirstName,
                                                        LastName = u.LastName,
                                                        Username = u.Username,
                                                        Password = u.Password,
                                                        Email = u.Email,
                                                        Status = u.Status,
                                                        CreatedOn = u.CreatedOn,
                                                        ModifiedOn = u.ModifiedOn
                                                    })
                                                    .Where(u => u.FirstName.Contains(userModel.FirstName) &&
                                                                u.LastName.Contains(userModel.LastName) &&
                                                                u.Username.Contains(userModel.Username) &&
                                                                u.Password.Contains(userModel.Password) &&
                                                                u.Email.Contains(userModel.Email) &&
                                                                userModel.Status == "" ? u.Status.Contains(userModel.Status) : u.Status.Equals(userModel.Status))
                                                    .Skip(paginationQueryDto.Page * paginationQueryDto.PageSize)
                                                    .Take(paginationQueryDto.PageSize)
                                                    .ToListAsync();

                if(paginationDto.ModelList.Count() < paginationQueryDto.PageSize && paginationQueryDto.Page == 0)
                {
                    paginationDto.Page = 0;
                    paginationDto.Pages = 1;
                }
                else
                {
                    paginationDto.Page = paginationQueryDto.Page;
                    paginationDto.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(paginationDto.TotalItems) / Convert.ToDouble(paginationQueryDto.PageSize)));
                }

                return paginationDto;
            }
            catch(Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserRepository-Get");
                return null;
            }
        }

        public async Task<UserModel> GetUser(Guid guid)
        {
            try
            {
                var userModel = await _dbContext.User.Where(u => u.Id == guid).Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Password = u.Password,
                    Email = u.Email,
                    Status = u.Status,
                    CreatedOn = u.CreatedOn,
                    ModifiedOn = u.ModifiedOn
                }).FirstOrDefaultAsync();
                return userModel;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserRepository-GetUser");
                return null;
            }
        }
        public async Task<UserModel> Add(UserModel userModel)
        {
            try
            {
                await _dbContext.User.AddAsync(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Username = userModel.Username,
                    Password = userModel.Password,
                    Email = userModel.Email,
                    Status = userModel.Status,
                    CreatedOn = DateTime.Now
                });
                _dbContext.SaveChanges();
                return userModel;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserRepository-Add");
                return null;
            }
        }

        public async Task<bool> Delete(UserModel userModel)
        {
            try
            {
                var entity = await _dbContext.User.FirstOrDefaultAsync(a => a.Id == userModel.Id);
                if (entity != null)
                {
                    _dbContext.User.Remove(entity);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserRepository-Delete");
            }
            return false;
        }

        public async Task<bool> Update(UserModel userModel)
        {
            try
            {
                var entity = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userModel.Id);
                if(entity != null)
                {
                    entity.Id = userModel.Id;
                    entity.FirstName = userModel.FirstName;
                    entity.LastName = userModel.LastName;
                    entity.Username = userModel.Username;
                    entity.Password = userModel.Password;
                    entity.Email = userModel.Email;
                    entity.Status = userModel.Status;
                    entity.CreatedOn = userModel.CreatedOn;
                    entity.ModifiedOn = DateTime.Now;
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(new EventId(), ex, "UserRepository-Add");
            }
            return false;
        }

    }
}