using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using TeamManager.Models.ResourceData;

namespace TeamManager.Utilities
{
    public static class Utility
    {
        private static readonly ILog Log = Logger.GetLogger();


        /// <summary>
        /// Check if contains one of the numbers.
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
        /// Checks to see if the tuple contains an item that is null genericly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="tuple"></param>
        /// <returns>bool</returns>
        public static bool ContainsNull<T, U>(this Tuple<T, U> tuple) 
            where T : class
            where U : class
        {
            return tuple.Item1 == null 
                || tuple.Item2 == null;
        }


        /// <summary>
        /// Accepts a task and set timeout in miliseconds. 
        /// If timeout limit reaches, TimeoutException will be thrown.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public static async Task TimeoutAfter(this Task task, int millisecondsTimeout)
        {
            if (task == await Task.WhenAny(task, Task.Delay(millisecondsTimeout)))
                await task;
            else
            {
                Log.Error("Received time out for the requested task.");
                throw new TimeoutException();
            }
        }


        /// <summary>
        /// Casts object to Team. Useful when working with ObjectCollection.
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
        /// Casts object to Player. Useful when working with ObjectCollection.
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
        /// If collection is null, the result would be 0.
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
