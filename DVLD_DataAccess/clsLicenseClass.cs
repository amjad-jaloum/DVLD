using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public clsLicenseClassData(int licenseClassID, string className, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
        }

        public static bool GetLicenseClassInfoByClassName(string className, ref int licenseClassID, ref string classDescription, ref byte minimumAllowedAge, ref byte defaultValidityLength, ref float classFees)
        {
            throw new NotImplementedException();
        }

        public static bool GetLicenseClassInfoByID(int licenseClassID, ref string className, ref string classDescription, ref byte minimumAllowedAge, ref byte defaultValidityLength, ref float classFees)
        {
            throw new NotImplementedException();
        }
    }
}
