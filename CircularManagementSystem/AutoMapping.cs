using AutoMapper;
using CircularManagementSystem.Entity;
using CircularManagementSystem.Models;

namespace CircularManagementSystem
{
    public class AutoMapping
    {
        public static  void MapValues()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeModel, Employee>();
                config.CreateMap<Employee,EmployeeModel>();
            });
        }
    }
}