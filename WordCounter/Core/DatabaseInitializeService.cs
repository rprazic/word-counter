using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordCounter.Infrastructure;

namespace WordCounter.Core
{
    public class DatabaseInitializeService : IDatabaseInitializeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly WordCountDbContext _context;

        public DatabaseInitializeService(IUnitOfWork unitOfWork, WordCountDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (await _unitOfWork.TextData.AnyAsync())
                return;

            var texts = new List<TextData>()
            {
                new TextData
                {
                    Text = @"If we do discover a complete theory, it should in time be understandable in broad principle by everyone, not just a few scientists. 
                             Then we shall all, philosophers, scientists, and just ordinary people, be able to take part in the discussion of the question of why it is that we and the universe exist. 
                             If we find the answer to that, it would be the ultimate triumph of human reason-for then we would know the mind of God. - Stephen Hawking"
                },
                new TextData
                {
                    Text = @"I cannot fix on the hour, or the spot, or the look or the words, which laid the foundation. 
                             It is too long ago. I was in the middle before I knew that I had begun. ― Jane Austen"
                },
                new TextData
                {
                    Text = @"There is a loneliness that can be rocked. 
                             Arms crossed, knees drawn up, holding, holding on, this motion, unlike a ship's, smooths and contains the rocker. 
                             It's an inside kind — wrapped tight like skin. Then there is the loneliness that roams. 
                             No rocking can hold it down. It is alive. On its own. 
                             A dry and spreading thing that makes the sound of one's own feet going seem to come from a far-off place. - Toni Morrison"
                },
            };
            _unitOfWork.TextData.AddRange(texts);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
