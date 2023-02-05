using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncKeyedLock;
using SharedKernel.Application.System.Threading;

namespace SharedKernel.Infrastructure.System.Threading
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomSemaphore : ISemaphore
    {
        private readonly AsyncKeyedLocker<string> _asyncKeyedLocker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncKeyedLocker"></param>
        public CustomSemaphore(AsyncKeyedLocker<string> asyncKeyedLocker)
        {
            _asyncKeyedLocker = asyncKeyedLocker;
        }

        /// <summary>
        /// Create a SemaphoreSlim per key an block threads from given key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="funcion"></param>
        /// <returns></returns>
        public async Task<T> RunOneAtATimeFromGivenKey<T>(string key, Func<T> funcion)
        {
            using (await _asyncKeyedLocker.LockAsync(key).ConfigureAwait(false))
            {
                return funcion();
            }
        }

        /// <summary>
        /// Create a SemaphoreSlim per key an block threads from given key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="funcion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> RunOneAtATimeFromGivenKey<T>(string key, Func<Task<T>> funcion, CancellationToken cancellationToken)
        {
            using (await _asyncKeyedLocker.LockAsync(key, cancellationToken).ConfigureAwait(false))
            {
                return await funcion();
            }
        }
    }
}
