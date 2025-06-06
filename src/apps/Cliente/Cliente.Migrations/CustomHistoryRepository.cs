using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;


namespace  Cliente.Migrations
{
    public class CustomHistoryRepository : NpgsqlHistoryRepository
    {
        public CustomHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
        {
        }

        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            history.ToTable("__EFMigrationsHistory");
            history.HasKey(h => h.MigrationId);
            history.Property(h => h.MigrationId).HasColumnName("MigrationId");
            history.Property(h => h.ProductVersion).HasColumnName("ProductVersion");
        }
    }
}