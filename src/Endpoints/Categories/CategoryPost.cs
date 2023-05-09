using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethods.Post.ToString() };
    public static Delegate Handle => Action;
    
    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category(categoryRequest.Name)
        {
            CreatedBy = "Teste",
            CreatedOn = DateTime.Now,
            EditeddBy = "Teste",
            EditeddOn = DateTime.Now
        };

        if (!category.IsValid)
            return Results.BadRequest(category.Notifications);

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}
