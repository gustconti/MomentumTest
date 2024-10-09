using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MomentumTest.Data
{
    public static class MockMenuData
    {
        public static List<MenuItemDTO> GetMenuItems()
        {
            return
            [
                new () { Text = "Cadastros", SubItems = [
                    new MenuItemDTO { Text = "Chalés" },
                    new MenuItemDTO { Text = "Reservas", Controller = "Home", Action = "Index" }
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
