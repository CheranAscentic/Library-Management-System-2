﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Book
    {

        private string title;
        private string author;
        private int publicationYear;
        private string category;
        public bool Available { get; set; }

        public Book(string title, string author, int year, string category)
        {
            Title = title;
            Author = author;
            PublicationYear = year;
            Category = category;
            Available = true;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Title cannot be empty.");
                }
                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Author cannot be empty.");
                }
                author = value;
            }
        }

        public int PublicationYear
        {
            get { return publicationYear; }
            set
            {
                if (value < 1100 || value > 2025)
                {
                    throw new Exception("Publication year must be recent or not in the future");
                }
                publicationYear = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Category cannot be empty.");
                }
                category = value;
            }
        }
    }
}
