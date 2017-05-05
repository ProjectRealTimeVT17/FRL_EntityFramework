using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;

namespace DataAccessLayer
{
    public class DbCalls
    {
        /// <summary>
        /// NOT FOR USE EVER!!!
        /// </summary>
        public void ExempleCalls()
        {

            var db = new ZooDataContext();

            //Ett zoo om det finns något annars crash (kombinera med try catch)
            var zoo0 = db.Zoos.First();

            //Ett zoo om det finns något annars NULL
            var zoo1 = db.Zoos.FirstOrDefault();
            
            //Hämtar zoo baserat på kriterier
            var zoo2 = db.Zoos.FirstOrDefault(x => x.Name == "Zoot");

            //Hämtar ett zoo om det finns baserat på ID; om det går så hämtar den ur minnet från tidigare anrop och sparar dig DB resa
            var zoo3 = db.Zoos.Find(2);

            //Hämtar ett zoo om det bara finns 1 annars crash (kombinera med try catch)
            var zoo4 = db.Zoos.Single(x => x.Name == "Zoot");

            //Hämtar ett zoo om det bara finns 1 annars NULL 
            var zoo5 = db.Zoos.SingleOrDefault(x => x.Name == "Zoot");

            //En Lista av de befintliga zoo som finns i databasen, Tom om det inte finns några
            var zoos = db.Zoos.ToList();

            //En Lista av de befintliga zoo som finns i databasen baserat på kriterer, Tom om det inte finns några
            var zoos1 = db.Zoos.Where(x => x.Name.Contains("zoo")).ToList();

            //Eager loading
            var zoos2 = db.Zoos.Include(x => x.Manager).ToList();

            //Lazy loading (sätt virtual på property i classen)
            //Ingen kod här..

            //Explicit loading
            var zoo6 = db.Zoos.Find(1);
            db.Entry(zoo6).Reference(x=>x.Manager).Load();
            db.Entry(zoo6).Collection(x => x.Employees).Load();
        }
        public Zoo GetZoo()
        {
            Zoo result = null;
            using (var db = new ZooDataContext())
            {
               result = db.Zoos.Include(x=>x.Manager).FirstOrDefault();
            }
            return result;
        }

        public List<Employee> GetListEmployee(Zoo zoo)
        {
            List<Employee> result = new List<Employee>();
            using (var db = new ZooDataContext())
            {
                // samma resultat som nedan med mindre kod genom att definera referensen (property i employee)
                result = db.Employees.Where(x => x.Zoo == zoo).ToList();

                //var zoo = db.Zoos.FirstOrDefault(x => x == zoo);
                //if (zoo != null)
                //    result = o.Employees.ToList();
            }

            return result;

        }
    }
}
