using MudBlazor;
using Web.DAL.Models;

namespace Web.DAL.Data
{
    public static class SeedData
    {
        public static List<Data_NavLink> GetNavigations()
        {
            var navigations = new List<Data_NavLink>
            {
				// Home Navigation
				new() {
                    NavLinkId = 1,
                    Title = "Home",
                            Icon = Icons.Material.Filled.Home,
                            Href = " ",
                            OrderById = 0,
                },

				// Inverted Index
						new() {
                            NavLinkId = 2,
                            Title = "Inverted Index",
                            Icon = Icons.Material.Filled.VerifiedUser,
                            Href = "",
                            OrderById = 1,
                },

				// Projects Page
						new() {
                            NavLinkId = 4,
                            Title = "Return to GitHub",
                            Icon = Icons.Material.Filled.KeyboardReturn,
                            OrderById = 99,
                },
                        new() {
                            NavLinkId = 5,
                            Title = "Mega Project List",
                            Href = "https://github.com/karan/Projects",
                            IsNewWindow = true,
                            OrderById = 0,
                            ParentId = 4
                },
                        new() {
                            NavLinkId = 6,
                            Title = "Mega Solution List",
                            Href = "https://github.com/karan/Projects-Solutions",
                            IsNewWindow = true,
                            OrderById = 1,
                            ParentId = 4
                },
                // Admin
                        new() {
                            NavLinkId = 7,
                            Title = "Admin",
                            Role = "adminrole",
                            Icon = Icons.Material.Filled.AdminPanelSettings,
                            OrderById = 98,
                },
                        new() {
                            NavLinkId= 8,
                            Title = "Navigation",
                            Href = "managenav",
                            Role = "adminrole",
                            OrderById = 0,
                            ParentId = 7,
                },
                // Document Upload
                        new()
                        {
                            NavLinkId = 3,
                            Title = "Upload Documents",
                            ParentId = 2,
                            Href="docupload",
                            OrderById=0,
                },
                // Search
                        new()
                        {
                            NavLinkId = 9,
                            Title = "Search Documents",
                            ParentId = 2,
                            Href="docsearch",
                            OrderById=1,
                },
                // View
                        new()
                        {
                            NavLinkId = 10,
                            Title = "View Index",
                            ParentId = 2,
                            Href="viewidx",
                            OrderById=2,
                },
                // Error Logs
                        new()
                        {
                            NavLinkId = 11,
                            Title = "View Error Log",
                            ParentId = 7,
                            Href="viewerror",
                            OrderById=1,
                },
            };
            // Generate 10 levels of hierarchy
            int currentId = 32;
            int parentId = 31;

            for (int i = 1; i <= 10; i++)
            {
                var newLevel = new Data_NavLink
                {
                    NavLinkId = currentId,
                    Icon = i == 1 ? Icons.Material.Filled.FormatListNumbered : null,
                    Title = i == 1 ? "Hierarchy Nav" : $"Level {i - 1}",
                    ParentId = parentId == 31 ? null : parentId,
                    OrderById = i == 1 ? 97 : i - 1,
                };

                navigations.Add(newLevel);
                parentId = currentId;
                currentId++;
            }
            return [.. navigations.OrderBy(x => x.NavLinkId)];
        }

        public static List<ErrorStatus> GetErrorStatuses()
        {
            return
            [
                new ErrorStatus { ErrorStatusId = 1, ErrorStatusText = "New" },
                new ErrorStatus { ErrorStatusId = 2, ErrorStatusText = "Acknowledged" },
                new ErrorStatus { ErrorStatusId = 3, ErrorStatusText = "Resolved" },
            ];
        }
    }
}
