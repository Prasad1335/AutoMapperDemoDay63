

using AutoMapper;
using AutoMapperDemo.Data.Models;
using AutoMapperDemo.DataAccess;
using AutoMapperDemo.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperDemo.Models.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(ApplicationDbContext dbContext, IMapper mapper)
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

        }
        public async Task DeleteAsync(int id)
        {
            var userDelete = await _dbContext.Users.SingleAsync(u => u.Id == id);
            _dbContext.Users.Remove(userDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}
