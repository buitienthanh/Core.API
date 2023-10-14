﻿using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk region);
        Task<Walk?> UpdateAsync(Guid id, Walk region);
        Task<Walk?> DeleteAsync(Guid id);
    }
}