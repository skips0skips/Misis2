using Misis2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Misis2.ModelView
{
    public class OnePageModel
    {
        public OnePageModel()
        {
            Products = GetProducts();
            Disciplines = GetDisciplines();
        }
        /// <summary>
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
        private ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>
            {
                new Product { Name = "Hilfi Watch", Price = 789.99f, Model = "Model 2011", Rating = 4.5, Views = 4.5, Description = "Occaecat qui sit quis labore reprehenderit nulla. Amet pariatur voluptate laboris ipsum veniam exercitation est do duis quis laborum reprehenderit aute."},
                new Product { Name = "Gold Watch", Price = 697.99f,  Model = "Model 2009", Rating = 4.5, Views = 4.5, Description = "Occaecat qui sit quis labore reprehenderit nulla. Amet pariatur voluptate laboris ipsum veniam exercitation est do duis quis laborum reprehenderit aute."},
                new Product { Name = "Pierre LD Watch", Price = 897.99f,  Model = "Model 2070", Rating = 4.5, Views = 4.5, Description = "Occaecat qui sit quis labore reprehenderit nulla. Amet pariatur voluptate laboris ipsum veniam exercitation est do duis quis laborum reprehenderit aute."},
                new Product { Name = "Omega RD Watch", Price = 567.99f,  Model = "Model 1997", Rating = 4.5, Views = 4.5, Description = "Occaecat qui sit quis labore reprehenderit nulla. Amet pariatur voluptate laboris ipsum veniam exercitation est do duis quis laborum reprehenderit aute."},
            };
        }
        /// </summary>
        private ObservableCollection<Discipline> disciplines;
        public ObservableCollection<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }
        private ObservableCollection<Discipline> GetDisciplines()
        {
            return new ObservableCollection<Discipline>
            {
                new Discipline { Name = "Математика"},
                new Discipline { Name = "Алгебра"},
                new Discipline { Name = "Физика"},
                new Discipline { Name = "История"},
            };
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Rating { get; set; }
        public double Views { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
