using Microsoft.EntityFrameworkCore;

public class VehiculoDbContext(DbContextOptions<VehiculoDbContext> options) : DbContext(options)
{
    public DbSet<relacionesMVC_ASP.net.Models.Vehiculo> Vehiculo { get; set; } = default!;
}
