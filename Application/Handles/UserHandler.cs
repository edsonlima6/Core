using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Handles
{
    public class UserHandler(IUserRepository _repositoryBaseEF, IOutboxMessageRepository outboxMessageRepository, IUnitOfWork unitOfWork) : IUserHandler
    {
        private readonly IUserRepository repositoryBaseEF = _repositoryBaseEF ?? throw new ArgumentNullException(nameof(repositoryBaseEF));
        private readonly IOutboxMessageRepository _outboxMessageRepository = outboxMessageRepository ?? throw new ArgumentNullException(nameof(outboxMessageRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<int> AddAsync(CreateUserDto dto)
        {
            var strategy = _unitOfWork.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                var user = new User(dto.Name, dto.Email, dto.LastName)
                {
                    CreatedON = DateTime.Now,
                    Password = dto.Password
                };

                var (valid, message) = user.IsValid();
                if (!valid)
                    throw new ArgumentException(message);

                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    await repositoryBaseEF.InsertAsync(user);
                    await _outboxMessageRepository.AddAsync(new OutboxMessage
                    {
                        CreatedAt = DateTime.UtcNow,
                        Type = nameof(User),
                        Payload = System.Text.Json.JsonSerializer.Serialize(user),
                        ProcessedAt = null
                    });

                    await _unitOfWork.CommitAsync();
                    return user.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
            });
        }

        public IEnumerable<UserDto> GetAll()
        {
            return repositoryBaseEF.GetAll().Select(MapToDto);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await repositoryBaseEF.GetAllAsync();
            return users.Select(MapToDto);
        }

        public async Task<int> RemoveAsync(int id) => await repositoryBaseEF.RemoveAsync(id);

        public bool UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                GuidId = user.GuidId,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
