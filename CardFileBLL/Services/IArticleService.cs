using CardFileDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileBLL.Services
{
    public interface IArticleService
    {
        Task<Article> CreateAsync(Article article);
        Task<IEnumerable<Article>> GetAllAsync();
    }
}
