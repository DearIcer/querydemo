using EF.Context;
using EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF.Service.UserinfoRepository;

public class UserinfoRepository : BaseRepository<IceDbEfContext>
{
    public UserinfoRepository(IceDbEfContext dbContext) : base(dbContext)
    {
    }

    public async Task<Userinfo> GetUserinfoAsync(int id)
    {
        return await DbContext.Userinfo.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Userinfo> AddAsync(Userinfo userinfo)
    {
        await DbContext.Userinfo.AddAsync(userinfo);
        return await DbContext.SaveChangesAsync() > 0 ? userinfo : null;
    }
}