using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethods.Put.ToString() };
    public static Delegate Handle => Action;
    
    public static IResult Action([FromRoute] Guid Id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var categories = context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        categories.Name = categoryRequest.Name;
        categories.Active = categoryRequest.Active;
        categories.EditeddBy = "Editado";
        categories.EditeddOn = DateTime.Now;
    
        context.SaveChanges();

        return Results.Created($"/categories/{categories.Id}", categories.Id);
    }
}
