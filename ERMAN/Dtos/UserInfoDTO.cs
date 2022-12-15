namespace ERMAN.Dtos
{
    public class UserInfoDTO
    {
        public string userType { get; set; }
        public string email { get; set; } = null!;
        public int authId { get; set; }

        public int? coordinatorID { get; set; }

        public string? coordinatorName { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? bilkentID { get; set; }
        public string? department { get; set; }
        public string? faculty { get; set; }
        public string? applicationStatus { get; set; }
        public string? university { get; set; }
        public string? durationPreffered { get; set; }
        public string? program { get; set; }
    }
}
