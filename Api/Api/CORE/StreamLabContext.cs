using Microsoft.EntityFrameworkCore;

namespace Api.CORE
{
    public class StreamLabContext(DbContextOptions<StreamLabContext> options) : DbContext(options)
    {



    }
}
