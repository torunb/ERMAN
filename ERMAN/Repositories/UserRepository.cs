﻿using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class UserRepository : IGeneralInterface<User, UserDto>
    {
        private readonly ErmanDbContext _dbContext;

        public UserRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserDto user)
        {
            var userNew = new User
            {
                UserType = user.UserType,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BilkentId = user.BilkentId,
                Department = user.Department,
                Faculty = user.Faculty,
                University = user.University,
                DurationPreffered = user.DurationPreffered,
                Program = user.Program,
            };

            _dbContext.UserTable.Add(userNew);
            _dbContext.SaveChanges();
        }

        public User Remove(int id)
        {
            User toBeDeleted = _dbContext.UserTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.UserTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public User Get(int id)
        {
            User toBeFind = _dbContext.UserTable.Find(id);
            return toBeFind;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
