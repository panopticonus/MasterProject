namespace MasterProject.Core.Interfaces.Repositories
{
    using System;

    public interface IErrorLogsRepository
    {
        void LogError<T>(T ex, string message = null) where T : Exception;
    }
}
