using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;
namespace CircularManagementSystem.DAL
{
    public class CircularRepository
    {
        public void AddCircular(Circular circular)
        {
            using(ContextClass contextClass=new ContextClass())
            {
                contextClass.Circulars.Add(circular);
                contextClass.SaveChanges();
            }
        }
        public List<Circular> GetCirculars()
        {
            using (ContextClass contextClass = new ContextClass())
                return contextClass.Circulars.ToList();
        }
        public Circular GetCircular(int circularId)
        {
            using (ContextClass contextClass = new ContextClass())
                return contextClass.Circulars.Where(x => x.CircularId == circularId).SingleOrDefault();
        }
    }
}
