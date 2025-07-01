using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<JobCategory> JobCategories { get; }
        DbSet<JobSubCategory> JobSubCategories { get; }
    }
}