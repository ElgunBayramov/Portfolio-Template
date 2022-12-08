using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Domain.Business.SpecialityModule
{
    public class SpecialityEditCommand:IRequest<Speciality>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public class SpecialityEditCommandHandler : IRequestHandler<SpecialityEditCommand, Speciality>
        {
            private readonly PortfolioDbContext db;

            public SpecialityEditCommandHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<Speciality> Handle(SpecialityEditCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Specialities.FirstOrDefaultAsync(s => s.Id == request.Id && s.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }
                data.Name = request.Name;
                data.Bio = request.Bio;

                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
