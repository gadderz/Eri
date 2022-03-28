using Eri.Core.Models;
using Eri.MongoDB;
using System.Diagnostics.CodeAnalysis;

namespace Eri.Database;

public class Context : ContextBase
{
    public Context([NotNull] string connectionString, [NotNull] string databaseName) : base(connectionString, databaseName)
    {
    }

    public DbSet<Anime> Anime { get => GetDbSet<Anime>("animes"); }

}
