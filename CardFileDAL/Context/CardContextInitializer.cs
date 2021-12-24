using CardFileDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Context
{
    class CardContextInitializer : DropCreateDatabaseIfModelChanges<CardContext>
    {
        protected override void Seed(CardContext db)
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Name = "Fiction"
                },
                new Category
                {
                    Name = "Nonfiction"
                }
            };
            db.Categories.AddRange(categories);
            db.SaveChanges();
        }
    }
}
