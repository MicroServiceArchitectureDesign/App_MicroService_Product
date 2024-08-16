using Microsoft.Extensions.Logging;

namespace AppMicroServiceProduct.Infrastructure.CommandPersistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            // if (_context.Database.IsSqlServer())
            // {
            //     await _context.Database.MigrateAsync();
            //     //DoSeed();
            // }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public static void DoSeed()
    {
        //_context.Database.OpenConnection();
        //if (!_context.Brands.Any())
        //{
        //    var brandsData = File.ReadAllText("../Infrastructure/Persistence/SeedData/Brands.json");

        //    var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
        //    if (brands is not null)
        //    {
        //        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Base.Tbl_Brand ON;");
        //        foreach (var item in brands)
        //        {
        //            _context.Brands.Add(item);
        //        }

        //        _context.SaveChanges();
        //        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Base.Tbl_Brand OFF;");
        //    }
        //}


        //// Seed Products Data from json file
        //if (!_context.Users.Any())
        //{
        //    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Acc.Tbl_User ON;");
        //    _context.Users.Add(new User(new FarshadFahimi.Framework.Common.ValueObjects.PersonName
        //    {
        //        FirstName = "Farshad",
        //        LastName = "Fahimi"
        //    }, "admin@admin.com","123")
        //    { Id = 1});

        //    _context.SaveChanges();
        //    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Acc.Tbl_User OFF;");
        //}
        //if (!_context.Categories.Any())
        //{
        //    var categoriesData = File.ReadAllText("../Infrastructure/Persistence/SeedData/Categories.json");

        //    var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
        //    //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Base.Tbl_Category ON;");
        //    if (categories is not null)
        //    {
        //        categories.ForEach(p => p.Id = 0);
        //        foreach (var item in categories)
        //        {
        //            _context.Categories.Add(item);
        //        }

        //        _context.SaveChanges();
        //    }
        //    //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Base.Tbl_Category OFF;");
        //}
        //_context.Database.CloseConnection();

    }
}
