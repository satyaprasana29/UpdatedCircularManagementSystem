using CircularManagementSystem.DAL;
using CircularManagementSystem.Entity;
using System.Collections.Generic;

namespace CircularManagementSystem.BL
{
    public class CircularBL:ICircularBL
    {
        /// <summary>
        /// Class :CircularBL
        /// Business layer Circular class inherites the Interface ICircularBL
        /// This class is used to connect with repository layer
        /// This class has methods to Add Circular, Download Circular and View Circulars
        /// </summary>
        /// <param name="circular"></param>
        CircularRepository circularRepository;
        public CircularBL()
        {
            circularRepository = new CircularRepository();
        }
        public void AddCircular(Circular circular)          //Add the Circular to database
        {
            circularRepository.AddCircular(circular);
        }
        public List<Circular> ViewCircular()                //View The circulars from database
        { 
            return circularRepository.GetCirculars();
        }
        public Circular GetCircular(int circularId)         //Get Circular using circularId
        {
            return circularRepository.GetCircular(circularId);
        }
        public bool AddCircularDepartments(List<int> Departments, int CircularId)       //Adding circular with many to many relationship
        {
            return circularRepository.AddCircularDepartments(Departments, CircularId);
        }
        public int GetCircularId(string filename)                   //Download the circular from database
        { 
            return circularRepository.GetCircularId(filename);
        }
    }
}
