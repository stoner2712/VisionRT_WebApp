using DataLibrary.DataAccess;
using DataLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class PatientProcessor
    {
        public static int CreatePatient(string firstName, string lastName, DateTime dateOfBirth, string gender)
        {
            DataPatientModel data = new DataPatientModel
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender
            };

            string sql = @"insert into dbo.Patient (FirstName, LastName, DateOfBirth, Gender)
                            values (@FirstName, @LastName, @DateOfBirth, @Gender);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<DataPatientModel> LoadPatients()
        {
            string sql = @"select FirstName, LastName, DateOfBirth, Gender
                            from dbo.Patient;";

            return SqlDataAccess.LoadData<DataPatientModel>(sql);
        }
    }
}
