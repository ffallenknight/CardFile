using CardFileDAL.Context;
using CardFileDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Repositories
{
    public class ArticleRepository
    {
        private readonly CardContext _cardContext;
        public ArticleRepository(CardContext cardContext)
        {
            _cardContext = cardContext;
        }
        public async Task<Article> CreateAsync(Article article)
        {
            _cardContext.Articles.Add(article);

            await _cardContext.SaveChangesAsync();

            return article;
        }
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _cardContext.Articles.ToListAsync();
        }
    }
}
