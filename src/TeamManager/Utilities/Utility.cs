using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TeamManager.Models.ResourceData;

namespace TeamManager.Utilities
{
    /// <summary>
    /// <see cref="Utility"/> class used mostly for extensions methods in order to simplify code.
    /// </summary>
    public static class Utility
    {
        /// <summary> Logger instance of the class <see cref="Utility"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();



        /// <summary>
        /// Invokes an action with the specified callback in a thread safe manner in order to avoid cross-thread exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control">The <see cref="Control"/> or all members that inherits Control that the action will be used on. </param>
        /// <param name="action">Callback operation on the <see cref="Control"/> that gets invoked. </param>
        public static void InvokeSafe<T>(this T control, Action action)
            where T : Control, ISynchronizeInvoke
        {
            if (control.InvokeRequired)
                control.Invoke(action);
        }


        /// <summary>
        /// Begin invoke an action with the specified callback in a thread safe manner in order to avoid cross-thread exception.
        /// For better performance, this would be a better option, but note that the calling thread, won't wait for completion 
        /// comparing to <see cref="InvokeSafe{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control">The <see cref="Control"/> or all members that inherits Control that the action will be used on. </param>
        /// <param name="action">Callback operation on the <see cref="Control"/> that gets invoked. </param>
        public static void BeginInvokeSafe<T>(this T control, Action action)
            where T : Control, ISynchronizeInvoke
        {
            if (control.InvokeRequired)
                control.BeginInvoke(action);
        }


        /// <summary>
        /// Checks if contains one of the numbers.
        /// Works the same as in SQL: "WHERE column_name IN (1, 2, 3, 4)".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool In<T>(this T obj, params T[] args) 
            where T : struct
        {
            return args.Contains(obj);
        }


        /// <summary>
        /// Checks to see if the <see cref="Tuple"/> contains an item that is null genericly.
        /// </summary>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <param name="tuple"></param>
        /// <returns>bool</returns>
        public static bool ContainsNull<TA, TB>(this Tuple<TA, TB> tuple) 
            where TA : class
            where TB : class
        {
            return tuple.Item1 == null 
                || tuple.Item2 == null;
        }


        /// <summary>
        /// Accepts a <see cref="Task"/> and set timeout in miliseconds. 
        /// If timeout limit reaches, <see cref="TimeoutException"/> will be thrown.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <param name="callerClass"></param>
        /// <param name="callerMethod"></param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns><see cref="Task"/></returns>
        public static async Task TimeoutAfter(this Task task, int millisecondsTimeout, 
            [CallerFilePath] string callerClass = "",
            [CallerMemberName] string callerMethod = "")
        {
            if (task == await Task.WhenAny(task, Task.Delay(millisecondsTimeout)))
                await task;
            else
            {
                Log.Error($"Received time out in [{callerClass}][{callerMethod}] for the requested task.");
                throw new TimeoutException();
            }
        }


        /// <summary>
        /// Casts object to <see cref="Team"/>. Useful when working with ObjectCollection.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callerName">The method name that is calling for debugging purposes. 
        /// When not defined, default would be the caller name.</param>
        /// <returns></returns>
        public static Team ToTeam(this object obj, [CallerMemberName] string callerName = "")
        {
            Team team = obj as Team;
            if (team != null) return team;
            Log.Warn($"[{callerName}] - Team cast resulted as null.");
            return null;
        }


        /// <summary>
        /// Casts object to <see cref="Player"/>. Useful when working with ObjectCollection.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callerName">The method name that is calling for debugging purposes. 
        /// When not defined, default would be the caller name.</param>
        /// <returns></returns>
        public static Player ToPlayer(this object obj, [CallerMemberName] string callerName = "")
        {
            Player player = obj as Player;
            if (player != null) return player;
            Log.Warn($"[{callerName}] - Player cast resulted as null.");
            return null;
        }


        /// <summary>
        /// Returning the count result of the collection in a safer manner.
        /// If collection is null, the result will be 0.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int InternalCount(this IEnumerable<object> obj)
        {
            return obj?.Count() ?? 0;
        }


        /// <summary>
        /// Determines whether the collection is null or contains any elements.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this IEnumerable<object> obj)
        {
            return obj == null || !obj.Any();
        }
    }
}
