using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest, StreetTest }
        public enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestType()
        {
            ID = enTestType.VisionTest;
            Title = string.Empty;
            Description = string.Empty;
            Fees = 0;
            Mode = enMode.AddNew;
        }

        public clsTestType(enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.ID = TestTypeID;
            this.Title = TestTypeTitle;
            this.Description = TestTypeDescription;
            this.Fees = TestTypeFees;
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            ID = (enTestType)clsTestTypeData.AddNewTestType(this.Title, this.Description, this.Fees);

            return (ID != (enTestType)(-1));
        }

        public bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)ID, Title, Description, Fees);
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;

            if (clsTestTypeData.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))

                return new clsTestType(TestTypeID, Title, Description, Fees);
            else
                return null;

        }

        public static DataTable GetAllTestTypes()
        {
            return DVLD_DataAccess.clsTestTypeData.GetAllTestTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestType();

                default:
                    return false;
            }
        }
    }
}
