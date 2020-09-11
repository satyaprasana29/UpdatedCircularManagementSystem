using CircularManagementSystem.DAL;
using CircularManagementSystem.Entity;
using System.Collections.Generic;

namespace CircularManagementSystem.BL
{
    public interface ICircularBL
    {
        void AddCircular(Circular circular);
        List<Circular> ViewCircular();
    }
    public class CircularBL:ICircularBL
    {
        public void AddCircular(Circular circular)
        {
            CircularRepository circularRepository = new CircularRepository();
            circularRepository.AddCircular(circular);
        }
        public List<Circular> ViewCircular()
        {
            CircularRepository circularRepository = new CircularRepository();
            return circularRepository.GetCirculars();
        }
    }
}
