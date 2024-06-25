using order.Models;

namespace order.Mock
{
    public interface IMenuService
    {
        void AddMenu(MenuModel menu);
        List<MenuModel> GetMenus();
        MenuModel? GetMenuById(int id);
    }

    public class MenuService : IMenuService
    {
        private List<MenuModel> _menus;
        private readonly ICategoryService _categoryService;

        public MenuService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _menus = new List<MenuModel>
            {
                new () { DishID = 1, DishName = "主餐1", CategoryID = 1, Price = 400 },
                new () { DishID = 2, DishName = "點心2", CategoryID = 2, Price = 300 },
                new () { DishID = 3, DishName = "飲料3", CategoryID = 3, Price = 200 },
                new () { DishID = 4, DishName = "湯品4", CategoryID = 4, Price = 100 },
            };

            foreach (var menu in _menus)
            {
                menu.Category = _categoryService.GetCategoryById(menu.CategoryID);
            }
        }

        public void AddMenu(MenuModel menu)
        {
            menu.DishID = _menus.Count + 1;
            menu.Category = _categoryService.GetCategoryById(menu.CategoryID);
            _menus.Add(menu);
        }

        public List<MenuModel> GetMenus()
        {
            foreach (var menu in _menus)
            {
                menu.Category = _categoryService.GetCategoryById(menu.CategoryID);
            }
            return _menus;
        }

        public MenuModel? GetMenuById(int id)
        {
            var menu = _menus.FirstOrDefault(o => o.DishID == id);
            if (menu != null)
            {
                menu.Category = _categoryService.GetCategoryById(menu.CategoryID);
            }
            return menu;
        }
    }
}
