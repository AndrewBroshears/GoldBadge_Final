using Cafe.POCO;
using Cafe.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RepositoryPattern.Test
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _repo;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _menu = new Menu(1, "Nasty", "It's not great", "nothing good", 12.50m);
            _repo.AddToMenu(_menu);
        }
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            Menu item = new Menu();
            item.MealNum = 1;
            MenuRepository repository = new MenuRepository();
            repository.AddToMenu(item);
            Menu itemFromDirectory = repository.GetMenuItemsByNum(1);
            Assert.IsNotNull(itemFromDirectory);
        }
        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveItemFromMenu(_menu.MealNum);
            Assert.IsTrue(deleteResult);
        }
    }
}
