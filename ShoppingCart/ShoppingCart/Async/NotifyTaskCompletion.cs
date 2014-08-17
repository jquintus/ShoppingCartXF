using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingCart.Async
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/magazine/dn605875.aspx
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public sealed class NotifyTaskCompletion<TResult> : INotifyPropertyChanged
    {
        private readonly TResult _defaultResult;
        
        public NotifyTaskCompletion(Task<TResult> task, TResult defaultResult = default(TResult))
        {
            _defaultResult = defaultResult;
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }
     

        public event PropertyChangedEventHandler PropertyChanged;

        public string ErrorMessage
        {
            get
            {
                return (InnerException == null) ?
                    null : InnerException.Message;
            }
        }

        public AggregateException Exception { get { return Task.Exception; } }

        public Exception InnerException
        {
            get
            {
                return (Exception == null) ?
                    null : Exception.InnerException;
            }
        }

        public bool IsCanceled { get { return Task.IsCanceled; } }

        public bool IsCompleted { get { return Task.IsCompleted; } }

        public bool IsFaulted { get { return Task.IsFaulted; } }

        public bool IsNotCompleted { get { return !Task.IsCompleted; } }

        public bool IsSuccessfullyCompleted { get { return Task.Status == TaskStatus.RanToCompletion; } }

        public TResult Result
        {
            get
            {
                return (Task.Status == TaskStatus.RanToCompletion)
                  ? Task.Result
                  : _defaultResult;
            }
        }

        public TaskStatus Status { get { return Task.Status; } }

        public Task<TResult> Task { get; private set; }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            { }

            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs("Status"));
                propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
                propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));

                if (task.IsCanceled)
                {
                    propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
                }
                else if (task.IsFaulted)
                {
                    propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                    propertyChanged(this, new PropertyChangedEventArgs("Exception"));
                    propertyChanged(this, new PropertyChangedEventArgs("InnerException"));
                    propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                }
                else
                {
                    propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                    propertyChanged(this, new PropertyChangedEventArgs("Result"));
                }
            }
        }
    }
}