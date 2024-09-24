﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.LimitedList
{
    public class LimitedList<T> : IEnumerable, IEnumerable<T>
    {
        private readonly int capacity;
        protected List<T> list;
        private bool isFull;

        public int Count => list.Count;

        public bool IsFull => capacity <= Count;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2);
            list = new List<T>(this.capacity);
        }

        public virtual bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            if (isFull) return false;
            list.Add(item); return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list)
            {

                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


