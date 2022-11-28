using Microsoft.EntityFrameworkCore;
using ToDoListApplication.Models;
using ToDoListApplication.Service;
using ToDoListDomainEntities;

/*
using (ApplicationDBContext context = new ApplicationDBContext())
{
    var list = new ToDoList
    {
        Name = "Test List"
    };

    var todo = new ToDoItem
    {
        Title = "Finish this Project",
        CreationDate = DateTime.Now,
        DueDate = DateTime.Parse("11/30/2022"),
        Description = "No Description",
        Status = "In Progress",
    };

    list.Items.Add(todo);
    context.ToDoLists.Add(list);
    context.ToDoItems.Add(todo);
    context.SaveChanges();
}
*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDoList}/{action=Index}/{id?}");

app.Run();
