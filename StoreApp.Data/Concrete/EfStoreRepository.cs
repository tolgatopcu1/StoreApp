using StoreApp.Data.Abstract;

namespace StoreApp.Data.Concrete;

public class EfStoreRepository : IStoreRepository
{
    private readonly StoreDbContext _context;
    public EfStoreRepository(StoreDbContext storeDbContext)
    {
        _context = storeDbContext;
    }
    public IQueryable<Product> Products => _context.Products;

    public void CreateProduct(Product entity)
    {
        throw new NotImplementedException();
    }
}