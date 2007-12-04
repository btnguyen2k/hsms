namespace HSMS.Bo.User
{
    public class PermissionConstants
    {
        public static HSMSPermission PERMISSION_ADMIN =
            new HSMSPermission("ADMIN_PERMISSION",
                               "General admin permission, allows user to access administrative sections");

        public static HSMSPermission PERMISSION_PARENT =
            new HSMSPermission("PARENT_PERMISSION", "General parent permission, allows user to access parental sections");

        public static HSMSPermission PERMISSION_PUPIL =
            new HSMSPermission("PUPIL_PERMISSION", "General pupil permission, allows user to access pupil's sections");

        public static HSMSPermission PERMISSION_TEACHER =
            new HSMSPermission("TEACHER_PERMISSION",
                               "General teacher permission, allows user to access teacher's sections");
    }
}