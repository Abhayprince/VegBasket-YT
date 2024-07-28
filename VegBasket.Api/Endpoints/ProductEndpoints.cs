using Microsoft.EntityFrameworkCore;
using VegBasket.Api.Data;

namespace VegBasket.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products", async (DataContext context) =>
            Results.Ok(
                await context.Products
                .AsNoTracking()
                .Select(p => p.ToDto())
                .ToListAsync()));
        return app;
    }
}
