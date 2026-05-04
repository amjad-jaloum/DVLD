using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { AddNew, Update}
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public enum enApplicationType
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService,
            ReplacementForLostDrivingLicense,
            ReplacementForDamagedDrivingLicense,
            ReleaseDetainedDrivingLicense,
            NewInternationalLicense
        }
        public clsApplicationType()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }

        public clsApplicationType(int appID, string appTitle, float appFees)
        {
            ID = appID;
            Title = appTitle;
            Fees = appFees;
            Mode = enMode.Update;
        }
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ID = clsApplicationTypeData.AddNewApplicationType(this.Title, this.Fees);


            return (this.ID != -1);
        }

        public static bool UpdateAppType(clsApplicationType application)
        {
            return DVLD_DataAccess.clsApplicationTypeData.UpdateAppType(application.ID, application.Title, application.Fees);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return DVLD_DataAccess.clsApplicationTypeData.GetAllApplicationTypes();
        }

        public static int GetFees(enApplicationType ApplicationTypeID)
        {
            return DVLD_DataAccess.clsApplicationTypeData.GetFees((int) ApplicationTypeID);
        }
        public static clsApplicationType Find(int ID)
        {
            string Title = ""; float Fees = 0;

            if (clsApplicationTypeData.GetApplicationTypeInfoByID((int)ID, ref Title, ref Fees))

                return new clsApplicationType(ID, Title, Fees);
            else
                return null;

        }
        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationTypeData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }

    }
}

