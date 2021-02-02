using Domain.Entities;
using Domain.Entities.Survey;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IOhcDbContext
    {
        DbSet<Position> Positions { get; set; }
        DbSet<Factor> Factors { get; set; }
        DbSet<FactorPosition> FactorPositions { get; set; }
        DbSet<Survey> Surveys { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
