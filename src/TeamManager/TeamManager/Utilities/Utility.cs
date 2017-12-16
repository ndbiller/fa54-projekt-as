using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Utilities
{
    public static class Utility
    {
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
                throw new TimeoutException();
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
            Debug.WriteLine($"[{callerName}] - Team cast resulted as null.");
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
            Debug.WriteLine($"[{callerName}] - Player cast resulted as null.");
            return null;
        }

    }
}
