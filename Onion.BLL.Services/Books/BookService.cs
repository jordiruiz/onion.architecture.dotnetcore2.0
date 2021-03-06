﻿using Onion.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Onion.DAL.Entities.Books;
using Onion.BLL.IServices.Books;

namespace Onion.BLL.Services.Books
{
    public class BookService : IBookService
    {
        public Book GetById(int Id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var book = context.Book
                    .Include(b => b.BookCategories)
                        .ThenInclude(bc => bc.Category)
                    .Where(b => b.Id == Id)
                    .FirstOrDefault();
                return book;
            }
        }
    }
}
