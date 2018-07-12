namespace MasterProject.Persistence.Repositories
{
    using Core.Interfaces.Repositories;
    using System;
    using System.Data.Entity.Validation;
    using System.Text;
    using Core;
    using Core.Models;

    public class ErrorLogsRepository : IErrorLogsRepository
    {
        private readonly IHospitalContext _context;

        public ErrorLogsRepository(IHospitalContext context)
        {
            _context = context;
        }

        public void LogError<T>(T ex, string message = null) where T : Exception
        {
            if (typeof(T) == typeof(DbEntityValidationException))
            {
                LogDbEntityValidationException(ex as DbEntityValidationException);
                return;
            }

            if (!string.IsNullOrWhiteSpace(message))
            {
                LogException(new Exception(message, ex));
            }

            LogException(ex);
        }

        private void LogException(Exception ex)
        {
            if (ex != null)
            {
                try
                {
                    var exceptionId = 0;
                    var log = new ErrorLogs
                    {
                        Message = ex.Message,
                        CallStack = ex.StackTrace ?? "",
                        Date = DateTime.Now,
                        Source = ex.Source,
                        ParentErrorId = null
                    };

                    _context.ErrorLogs.Add(log);
                    _context.SaveChanges();

                    exceptionId = log.Id;

                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        var childrenLog = new ErrorLogs
                        {
                            Message = ex.Message,
                            CallStack = ex.StackTrace,
                            Date = DateTime.Now,
                            Source = ex.Source,
                            ParentErrorId = exceptionId
                        };

                        _context.ErrorLogs.Add(childrenLog);
                        _context.SaveChanges();

                        exceptionId = childrenLog.Id;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void LogDbEntityValidationException(DbEntityValidationException ex)
        {
            var errorMessage = new StringBuilder();
            foreach (var entityValidationError in ex.EntityValidationErrors)
            {
                errorMessage.AppendLine(
                    $"Entity of type \"{entityValidationError.Entry.Entity.GetType().Name}\" in state \"{entityValidationError.Entry.State}\" has the following validation errors:");
                foreach (var ve in entityValidationError.ValidationErrors)
                {
                    errorMessage.AppendLine(
                        $" - Property: \"{ve.PropertyName}\", Value: \"{entityValidationError.Entry.CurrentValues.GetValue<object>(ve.PropertyName)}\", Error: \"{ve.ErrorMessage}\"");
                }
            }

            var log = new ErrorLogs
            {
                Message = errorMessage.ToString(),
                CallStack = ex.StackTrace,
                Date = DateTime.Now,
                Source = ex.Source
            };

            _context.ErrorLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
