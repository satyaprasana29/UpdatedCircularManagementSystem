using CircularManagementSystem.Entity;
using System.Collections.Generic;

namespace CircularManagementSystem.BL
{
    public interface ICircularBL
    {
        void AddCircular(Circular circular);
        List<Circular> ViewCircular();
        Circular GetCircular(int circularId);
        bool AddCircularDepartments(List<int> Departments, int CircularId);
        int GetCircularId(string filename);
    }
}
