using System;
using System.Collections.Generic;
using Cafe_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Test
{
    //all methods should work for side options.
    [TestClass]
    public class CafeTests
    {
     
        private MainFood _main;
        private Main_Repository _repo;

        [TestMethod]
        public void SetTitle_ShouldSetCorrectString()
        {
            MainFood content = new MainFood()
            {
                MainFoodName = "burger"
            };

            string expected = "burger";
            string actual = content.MainFoodName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCurrentCollection()
        {
            MainFood content = new MainFood();
            Main_Repository repo = new Main_Repository();

            repo.AddContentToMainFood(content);

            List<MainFood> contents = repo.GetAllContent();

            bool directoryHasContent = contents.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }


        [TestInitialize]
        public void Arrange()
        {
            _repo = new Main_Repository();
            _main = new MainFood("Double CheeseBurger", "Two flambroiled patties with cheese on each pattie layed on a charred brioche bun. Then topped with pickles, ketchup, and mustard.", "Two flamebroiled patties, 1 brioche bun, pickles, 1Tbl of mayo, 1Tbl ketchup", 6.95, 1);

            _repo.AddContentToMainFood(_main);
        }


        [TestMethod]
        public void GetItemByName_ShouldReturnCorrectItem()
        {
            MainFood searchResult = _repo.GetFoodByName("Double CheeseBurger");

            Assert.AreEqual(_main, searchResult);
        }

        [TestMethod]
        public void GetItemByNumber_ShouldReturnCorrectItem()
        {
            MainFood searchResult = _repo.GetFoodByNumber(1);

            Assert.AreEqual(_main, searchResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            bool removeItem = _repo.DeleteExistingContent("Double CheeseBurger");
            Assert.IsTrue(removeItem);
        }

    }
}
