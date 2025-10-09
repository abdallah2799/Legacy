using Common.Enums;
using Core.Interfaces.Repositories;
using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ApplicantRepository : IApplicantRepository
{
    private readonly LegacyDbContext _context;

    public ApplicantRepository(LegacyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Applicant entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _context.Applicants.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var applicant = await _context.Applicants.FindAsync(id);
        if (applicant == null)
            throw new InvalidOperationException($"Applicant with ID {id} not found.");

        _context.Applicants.Remove(applicant);
    }

    public async Task DeleteAsync(Applicant entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Applicants.Remove(entity);
    }
    public async Task<IEnumerable<Applicant>> FindAsync(Expression<Func<Applicant, bool>> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return await _context.Applicants.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<Applicant>> GetAllAsync()
    {
        return await _context.Applicants.ToListAsync();
    }

    public async Task<Applicant> GetByIdAsync(int id)
    {
        return await _context.Applicants.FindAsync(id);
    }

    public async Task<IEnumerable<Applicant>> GetByStatusAsync(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Status cannot be null or empty.", nameof(status));
        if (!Enum.TryParse<ApplicationStatus>(status, true, out var parsedStatus))
            throw new ArgumentException($"Invalid status value: {status}", nameof(status));

        return await _context.Applicants
            .Where(a => a.Status == parsedStatus)
            .ToListAsync();
    }

    public async Task<IEnumerable<Applicant>> GetByStatusAsync(ApplicationStatus status)
    {
        return await _context.Applicants
            .Where(a => a.Status == status)
            .ToListAsync();
    }
    public async Task<IEnumerable<Applicant>> GetPendingApplicationsAsync()
    {
        return await _context.Applicants
            .Where(a => a.Status == ApplicationStatus.Pending)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Applicant entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

         _context.Applicants.Update(entity);
    }
    }
}