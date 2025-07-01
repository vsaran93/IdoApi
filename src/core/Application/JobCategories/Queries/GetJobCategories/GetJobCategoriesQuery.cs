using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.JobCategories.Queries.GetJobCategories
{
    public record GetJobCategoriesQuery : IRequest<List<JobCategory>>
    {
        public string Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetJobCategoriesQueryHandler: IRequestHandler<GetJobCategoriesQuery, List<JobCategory>>
    {
        private readonly IApplicationDbContext _context;

        public GetJobCategoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobCategory>> Handle(GetJobCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.JobCategories.ToListAsync();
        }
    }
}