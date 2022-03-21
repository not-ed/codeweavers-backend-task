using KanbanConsoleApp.Features.Tasks;

namespace KanbanConsoleApp.Tests
{
    public static class _1
    {
        public static void AbilityToGetATaskById_ThenTheCorrectTaskIsRetrieved()
        {
            var engine = new TaskEngine();
            engine.SaveTask(new Task { Description = "Ability to login to the order system.", Id = "1" });
            engine.SaveTask(new Task { Description = "Ability to logout of the order system.", Id = "2" });

            var result = engine.RetrieveTaskById("2");
            Assert.AreEqual(result.Description, "Ability to logout of the order system.");
        }
    }
}