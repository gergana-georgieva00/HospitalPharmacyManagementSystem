﻿namespace HospitalPharmacyManagementSystem.Common
{
    public static class GeneralAppConstants
    {
        public const int ReleaseYear = 2023;
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;
        public const string AdminRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "admin@gmail.com";
        public const string AdminAreaName = "Admin";
        public const string UsersCacheKey = "UsersCache";
        public const string PrescriptionsCacheKey = "PrescriptionsCache";
        public const string OnlineUsersCookieName = "IsOnline";
        public const int LastActivityBeforeOfflineMinutes = 10;
        public const int UsersCacheDurationMinutes = 5;
    }
}