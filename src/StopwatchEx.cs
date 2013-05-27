/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace eda12131190311906
{
    /// <summary>
    /// Provides a set of methods and properties that you can use to accurately measure elapsed time. 
    /// Extended Version
    /// </summary>
    public class StopwatchEx : Stopwatch, IEquatable<StopwatchEx>, IComparable<StopwatchEx>
    {
        /// <summary>
        /// Gets or sets the total elapsed time measured by the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="T:System.TimeSpan"/> representing the total elapsed time measured by the current instance.
        /// </returns>
        public TimeSpan EditableElapsed { get; set; }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in milliseconds.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only double representing the total number of milliseconds measured by the current instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new double ElapsedMilliseconds
        {
            get { return EditableElapsed == TimeSpan.Zero ? Elapsed.TotalMilliseconds : EditableElapsed.TotalMilliseconds; }
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in timer ticks.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only long integer representing the total number of timer ticks measured by the current instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new long ElapsedTicks
        {
            get { return EditableElapsed == TimeSpan.Zero ? Elapsed.Ticks : EditableElapsed.Ticks; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:eda12131190311906.StopwatchEx"/> class.
        /// </summary>
        public StopwatchEx()
        {
            EditableElapsed = TimeSpan.Zero;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:eda12131190311906.StopwatchEx"/> class.
        /// </summary>
        /// <param name="editableElapsed"></param>
        public StopwatchEx(TimeSpan editableElapsed)
        {
            EditableElapsed = editableElapsed;
        }

        /// <summary>
        /// Initializes a new <see cref="T:eda12131190311906.StopwatchEx"/> instance, sets the elapsed time property to zero, and starts measuring elapsed time.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:eda12131190311906.StopwatchEx"/> that has just begun measuring elapsed time.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new static StopwatchEx StartNew()
        {
            var stopwatch = new StopwatchEx();
            stopwatch.Start();
            return stopwatch;
        }

        /// <summary>
        /// Check if this object is equal to other
        /// </summary>
        /// <param name="other">Other object</param>
        /// <returns>True if is equal, otherwise false</returns>
        public bool Equals(StopwatchEx other)
        {
            return ElapsedTicks.Equals(other.ElapsedTicks);
        }

        /// <summary>
        /// Compare this object with other
        /// </summary>
        /// <param name="other">Other object</param>
        /// <returns>-1 if is lower, 0 if equals, 1 if is higher</returns>
        public int CompareTo(StopwatchEx other)
        {
            if (Equals(other))
            {
                return 0;
            }

            if (ElapsedTicks < other.ElapsedTicks)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// Compute average value from a list of values
        /// </summary>
        /// <param name="list">List with all values</param>
        /// <param name="cutLowerHigher">If true the lower and higher values will be cut from calculations</param>
        public static StopwatchEx ComputeAverage(List<StopwatchEx> list, bool cutLowerHigher)
        {
            if (list.Count == 0)
            {
                return new StopwatchEx();
            }
            var stopwatch = new StopwatchEx();
            if (list.Count == 1)
            {
                stopwatch.EditableElapsed = new TimeSpan(list[0].ElapsedTicks);
                return stopwatch;
            }

            list.Sort();
            if (cutLowerHigher && list.Count >= 3)
            {
                list.RemoveAt(list.Count - 1);
                list.RemoveAt(0);
            }

            if (list.Count == 1)
            {
                stopwatch.EditableElapsed = new TimeSpan(list[0].ElapsedTicks);
                return stopwatch;
            }

            long averageTicks = Convert.ToInt64(list.Average(timeSpan => timeSpan.ElapsedTicks));
            stopwatch.EditableElapsed = TimeSpan.FromTicks(averageTicks);

            return stopwatch;
        }
    }
}
