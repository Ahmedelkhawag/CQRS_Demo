using CQRS_Library.CQRS.Commands;
using CQRS_Library.Data;
using CQRS_Library.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.CQRS.Handelrs
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, Item>

    {
        private readonly ApplicationDbContext _context;

        public AddItemHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Item> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            await _context.Items.AddAsync(request.Item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Item;
        }
    }
}
