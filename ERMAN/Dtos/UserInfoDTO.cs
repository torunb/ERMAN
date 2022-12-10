namespace ERMAN.Dtos
{
    public class UserInfoDTO
    {
        public UserType userType { get; set; }
        public string email { get; set; } = null!;
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? bilkentID { get; set; }
        public string? department { get; set; }
        public string? faculty { get; set; }
        public string? applicationStatus { get; set; }
        public string? university { get; set; }
        public DurationPreffered? durationPreffered { get; set; }
        public AppliedProgram? program { get; set; }
    }
}
