using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal interface ITasksHolder : IRequestHandler
    {
        Task RunTasks();
        IEnumerable<Task> Tasks { get; }
    }



}
