namespace StudentAttendance.Classes
{
    public static class LoggedInUser
    {
        public static int UserId { get; set; }
        public static string Fullname { get; set; }
        public static string Email { get; set; }
        public static bool IsAdmin { get; set; }
        public static bool PasswordChanged { get; set; }
        public static bool IsSuperAdmin { get; set; }
    }
}
