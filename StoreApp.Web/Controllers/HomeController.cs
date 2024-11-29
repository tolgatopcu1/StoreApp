using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class HomeController : Controller
{
    public int pageSize = 3;
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    public HomeController(IStoreRepository storeRepository,IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    public IActionResult Index(string category,int page = 1)
    {
        var query = _storeRepository.Products;
        if (!string.IsNullOrEmpty(category))
        {
            query = query.Include(p=>p.Categories).Where(a=>a.Categories.Any(d=>d.Url == category));
        }
        query = query.Skip((page -1)*pageSize);
        var products =query
                                    .Select(p=>_mapper.Map<ProductViewModel>(p))
                                    .Take(pageSize);

        var pageInfo = new PageInfo{
            TotalItems = category==null ? _storeRepository.Products.Count():_storeRepository.Products.Include(p=>p.Categories).Where(a=>a.Categories.Any(d=>d.Url == category)).Count(),
            ItemsPerPage = pageSize,
            CurrentPage = page
        };
        return View(new ProductListViewModel{
            Products = products,
            PageInfo = pageInfo,
        });
    }
}