using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication2.Infrastructure;
using WebApplication2.Models;
/*using System.Web.Mvc;*/

namespace WebApplication2.Services
{
    public class AddService : IAddService
    {
        private PersonDBContext _db;
        public AddService(PersonDBContext db)
        {
            _db = db;
        }
        public void add(PersonModel person)
        {
            /*throw new NotImplementedException();*/
            _db.Add(person);
            _db.SaveChanges();
        }
    }
}
