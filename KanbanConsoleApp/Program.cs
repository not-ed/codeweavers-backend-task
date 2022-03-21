using System;
using KanbanConsoleApp.Tests;

namespace KanbanConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            _1.AbilityToGetATaskById_ThenTheCorrectTaskIsRetrieved();
            _2.AbilityToStoreClients();
            _3.WhenRetrievingAListOfClients_ThenTheListIsReturnedAlphabetically();
            _4.AbilityToDeleteAClient();
            _5.AbilityToGetAllTasksAssociatedWithAClient();
            _6.WhenAddingATaskForAClientThatDoesNotExist_ThenAnExceptionIsThrown();
            _7.AbilityToReorderTasks();

            Console.WriteLine("All tests pass!");
            Console.ReadLine();
        }
    }
}
