using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITIExaminationSystemEntities context = new ITIExaminationSystemEntities();
            //Try Insert
            instructors instructor = new instructors()
            { first_name = "Ali", last_name = "sayed", email = "ali@iti.com", password = "1223" };
            context.instructors.Add(instructor);
            context.SaveChanges();

            // Try Update
            instructor = context.instructors.FirstOrDefault();
            instructor.email = "mirihan1@iti.com";
            context.SaveChanges();

            // Try Delete 
             instructor = context.instructors.
                Where(d => d.first_name == "Ali").Select(d => d).FirstOrDefault();
            context.instructors.Remove(instructor);
            context.SaveChanges();

            //Try Stored Procedure
            context.usp_addtrack("Cyber Security", "Eng_Ahmed", "456");
            context.SaveChanges();

            // Try Concurrency mode

            ITIExaminationSystemEntities context2 = new ITIExaminationSystemEntities();
            var crs1 = context.courses.FirstOrDefault();
            var crs2 = context2.courses.FirstOrDefault();
            crs1.min_degree -= 5;
            crs2.min_degree -= 10;
            context.SaveChanges();

            bool concrrency = false;

            do
            {
                try
                {
                    context2.SaveChanges();
                    concrrency = true;
                }

                catch (DbUpdateConcurrencyException ex)
                {
                    //get object that fires the exception
                    var Value = ex.Entries.First();
                    Value.Reload(); //get data again from DB 
                                    // Value.OriginalValues.SetValues(Value.GetDatabaseValues());
                    crs2.min_degree -= 10;
                    context2.SaveChanges();
                    concrrency = true;
                }
            }
            while (concrrency == false);
           

        }
    }
}
