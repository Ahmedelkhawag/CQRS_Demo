using CQRS_Library.CQRS.Queries;
using CQRS_Library.Data;
using CQRS_Library.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.CQRS.Handelrs
{
    public class GetItemsListHandler : IRequestHandler<GetAllItems, List<Item>>
    {
        private readonly ApplicationDbContext _context;

        public GetItemsListHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> Handle(GetAllItems request, CancellationToken cancellationToken)
        {
            return await _context.Items.ToListAsync(cancellationToken);
        }
    }
}
