namespace MomentumTest.Data
{
    public static class MockUserData
    {
        public static UserDTO GetUserData()
        {
            return
                new()
                {
                    Name = "Administrador",
                    Company = "SMN",
                    AvatarUrl = "/assets/circle-avatar.svg"
                };
        }
    }

    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
