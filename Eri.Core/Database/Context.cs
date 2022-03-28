using Eri.Core.Models;
using Eri.MongoDB;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eri.Core.Database;

public class Context : ContextBase
{
    public Context([NotNull] string connectionString, [NotNull] string databaseName) : base(connectionString, databaseName)
    {
    }

    public DbSet<Anime> Anime { get => GetDbSet<Anime>("animes"); }

}
