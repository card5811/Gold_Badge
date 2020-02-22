using System;
using System.Collections.Generic;
using Badge_Challenege;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badge_Tests
{
    [TestClass]
    public class DoorAccessTest
    {
        private Badge _badge;
        private Badge_Repo _repo;
        [TestMethod]
        public void AddingKeyAndValueToDictionary_ShouldReturnTrue()
        {
            Badge id = new Badge();
            Badge_Repo repo = new Badge_Repo();

            bool addResult = repo.AddToDictionary(id);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllContents_ShouldReturnedAllDictionaryItems()
        {
            
            int id = 1;
            List<string> word = new List<string>();

            _repo = new Badge_Repo();

            _repo.AddToDictionary(id, "A5");

            Dictionary<int, List<string>> contents = _repo.GetAllContent();

            bool dictionaryHasContent = contents.ContainsKey(1);
        }
    public Dictionary<int, List<string>> GetAllContent()
    {
        return _access;
    }

    public List<string> GetContentById(int id)
    {
        _access.TryGetValue(id, out var doors);
        return doors;
    }

    public bool UpdateExistingContent(int originalid, List<string> newId)
    {
        var oldId = GetContentById(originalid);
        if (oldId != null)
        {
            oldId = newId;
            return true;
        }
        return false;
    }

    public bool DeleteExistingContent(int id)
    {
        List<string> foundItem = GetContentById(id);
        bool deletedResult = _access.Remove(id);
        return deletedResult;
    }
}
