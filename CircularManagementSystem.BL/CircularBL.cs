using CircularManagementSystem.DAL;
using CircularManagementSystem.Entity;
using System.Collections.Generic;

namespace CircularManagementSystem.BL
{
    public interface ICircularBL
    {
        void AddCircular(Circular circular);
        List<Circular> ViewCircular();
        Circular GetCircular(int circularId);
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
        public Circular GetCircular(int circularId)
        {
            CircularRepository circularRepository = new CircularRepository();
            return circularRepository.GetCircular(circularId);
        }
    }
}
