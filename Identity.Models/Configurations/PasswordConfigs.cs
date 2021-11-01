namespace Identity.Models.Configurations
{
    public class PasswordConfigs
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }

        public int PasswordExpiredDays { get; set; }
        public int AccessFailedCount { get; set; }

        public int ResetPasswordTokenExpiredMinute { get; set; }
        public string ResetPasswordUrl { get; set; }
    }
}
