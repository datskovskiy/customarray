using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private int _length;

        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First { get; private set; }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last => First + Length - 1;

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length
        {
            get => _length;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Length cant be smaller than 0.");

                this._length = value;
            }
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array { get; }


        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>         
        public CustomArray(int first, int length)
        {
            First = first;
            Length = length;

            Array = new T[length];
        }


        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            var e = new NullReferenceException("List cant be null.");
            if (list is null) throw e;

            Array = list.ToArray();

            if (!Array.Any())
                throw new ArgumentException("Count cant be smaller than 0.");

            First = first;
            Length = Array.Length;
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list), "List cant be null.");

            if (!list.Any())
                throw new ArgumentException("List cant be without elements.");

            Length = list.Length;
            Array = list;
            First = first;
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item < First)
                    throw new ArgumentException($"Index cant be smaller than {First}.");

                if (item > Last)
                    throw new ArgumentException($"Index cant be bigger than {Last}.");

                return Array[item - First];
            }
            set
            {
                if (item < First)
                    throw new ArgumentException($"Index cant be smaller than {First}.");

                if (item > Last)
                    throw new ArgumentException($"Index cant be bigger than {Last}.");

                if (value is null)
                    throw new ArgumentNullException(nameof(value), "Value cant be null.");

                Array[item - First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) Array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
