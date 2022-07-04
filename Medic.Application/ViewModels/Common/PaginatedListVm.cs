using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Medic.Services.ViewModels.Common;

public class PaginatedListVm<TViewModel>
{
    public List<TViewModel> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PaginatedListVm(List<TViewModel> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    private static async Task<PaginatedListVm<TViewModel>> CreateAsyncWithMappingsHelper<TSource>(
        IMapper mapper, IQueryable<TSource> source, int pageIndex, int pageSize
    )
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Select(ufc => mapper.Map<TSource, TViewModel>(ufc))
            .ToListAsync();
        
        return new PaginatedListVm<TViewModel>(items, count, pageIndex, pageSize);
    }
    
    public static async Task<PaginatedListVm<TViewModel>> CreateAsyncWithMapping<TSource>(
        IMapper mapper, IQueryable<TSource> items, int pageNumber, int pageSize
    )
    {
        return await CreateAsyncWithMappingsHelper(mapper, items, pageNumber, pageSize);
    }

    public static async Task<PaginatedListVm<TViewModel>> CreateAsync(
        IQueryable<TViewModel> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PaginatedListVm<TViewModel>(items, count, pageIndex, pageSize);
    }
}