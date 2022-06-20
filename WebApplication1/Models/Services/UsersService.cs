
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApplication1.Models.Data;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManagmentContext _dbContext;
        private readonly IMapper _mapper;

        public IEnumerable Departments { get;set; }

        public UsersService(UserManagmentContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            var usersViewModel = users.Select(U => _mapper.Map<UserViewModel>(U)).ToList();
            return usersViewModel; // list of view model
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var users = await _dbContext.Users.SingleAsync(u => u.Id == id);
            var userViewModel = _mapper.Map<UserViewModel>(users);
            return userViewModel;
        }

        public async Task CreateAsync(UserViewModel userViewModel)
        {
            var addUser = _mapper.Map<User>(userViewModel);
            await _dbContext.Users.AddAsync(addUser);
            await _dbContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(UserViewModel userViewModel)
        {
                var userUpdate = await _dbContext.Users.SingleAsync(d => d.Id == userViewModel.Id);

            userUpdate.FirstName = userViewModel.FirstName;
            userUpdate.LastName = userViewModel.LastName;
            userUpdate.Email = userViewModel.Email;
            userUpdate.MobileNumber = userViewModel.MobileNumber;
            userUpdate.Gender = userViewModel.Gender;
            userUpdate.Pan = userViewModel.Pan;
            userUpdate.Address = userViewModel.Address;
            userUpdate.Comment = userViewModel.Comment;
            userUpdate.DateOfBirth = userViewModel.DateOfBirth;
            userUpdate.DepartmentRef = userViewModel.DepartmentRefId;

            _dbContext.Users.Update(userUpdate);
                await _dbContext.SaveChangesAsync();
            }
            public async Task DeleteAsync(int id)
        {
            var userDelete = await _dbContext.Users.SingleAsync(u => u.Id == id);
            _dbContext.Users.Remove(userDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}

