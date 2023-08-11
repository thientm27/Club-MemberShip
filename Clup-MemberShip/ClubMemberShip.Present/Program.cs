using ClubMemberShip.Repo.UnitOfWork.Implement;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddScoped<IClubServices, ClubService>();
builder.Services.AddScoped<IClubActivityService, ClubActivityService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IMajorService, MajorService>();
builder.Services.AddRazorPages(options => { options.Conventions.AddPageRoute("/Login", ""); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();