namespace MomentumTest.Data
{
    public static class MockMenuData
    {
        public static List<MenuItemDTO> GetMenuItems()
        {
            return
            [
                new () { Text = "Cadastros", SubItems = [
                    new() { Text = "Chalés" },
                    new() { Text = "Reservas", Controller = "Home", Action = "Index", Url = "/" }
                ]}
            ];
        }
    }

    public class MenuItemDTO
    {
        public string? Text { get; set; }
        public string? Url { get; set; }
        public List<MenuItemDTO> SubItems { get; set; } = [];
        public string? Controller { get; set; }
        public string? Action { get; set; }
    }
}
