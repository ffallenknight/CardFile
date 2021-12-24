using CardFileDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Context
{
    public class CardContext:DbContext
    {
        static CardContext()
        {
            Database.SetInitializer(new CardContextInitializer());
        }
        public CardContext(string conectionString) : base(conectionString)
        { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
    }
}
