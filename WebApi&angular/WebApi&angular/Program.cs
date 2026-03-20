using Bll;
using Dal;
using IDal;
using IBll;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//טיפול בסיסי בהרשאות, 
//הפקודה הבאה מוסיפה פוליסת הרשאות 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
            builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
});


// הפונקציה מקבלת 2 פרמטרים
//1. שם ממשק שאליו אמורים להזריק מחלקה המממשת אותו - ITransaction
//2. שם מחלקה המממשת את הממשק אותו יזריקו בפועל-DalRepository
//sql אנחנו נזריק את המחלקה המתקשרת עם 
builder.Services.AddScoped(typeof(ITransaction), typeof(DalRepository));

builder.Services.AddScoped(typeof(IBllServecis), typeof(BllServices));




builder.Services.AddDbContext<Dal.models.FingerFoodStoreContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//קביעת פוליסת ההרשאות בה נרצה להשתמש
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
