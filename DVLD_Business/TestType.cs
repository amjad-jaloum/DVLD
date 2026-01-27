using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class TestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public TestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static bool UpdateTestType(TestType test)
        {
            return TestTypesData.UpdateTestType(test.TestTypeID, test.TestTypeTitle, test.TestTypeDescription, test.TestTypeFees);
        }

        public static DataTable GetTestTypes()
        {
            return TestTypesData.GetTestTypesTypes();
        }

    }
}
