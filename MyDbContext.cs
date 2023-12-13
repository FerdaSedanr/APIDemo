using APIDemo.Controllers.model;
using Microsoft.EntityFrameworkCore;

namespace APIDemo;

public class MyDbContex :DbContext
{
    public MyDbContex( DbContextOptions<MyDbContex> context):base(context)
    {
        
    }

    public DbSet<Students> Students { get; set; }
}
