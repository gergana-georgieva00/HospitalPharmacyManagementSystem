using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Drug
        {
            public const int BrandNameMinLength = 2;
            public const int BrandNameMaxLength = 150;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "2000";

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Pharmacist
        {
            public const int HospitalIdNumberLength = 8;
        }

        public static class Prescription
        {
            public const int NotesMinLength = 50;
            public const int NotesMaxLength = 500;
            public const int MedicationFrequencyMinLength = 50;
            public const int MedicationFrequencyMaxLength = 50;
        }

        public static class Patient
        {
            public const int NameMinLength = 10;
            public const int NameMaxLength = 50;
        }
    }
}
