using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Spine
{
	[DebuggerDisplay("Count={Count}")]
	[Serializable]
	public class ExposedList<T> : IEnumerable<T>, IEnumerable
	{
		public ExposedList()
		{
			this.Items = ExposedList<T>.EmptyArray;
		}

		public ExposedList(IEnumerable<T> collection)
		{
			this.CheckCollection(collection);
			ICollection<T> collection2 = collection as ICollection<T>;
			if (collection2 == null)
			{
				this.Items = ExposedList<T>.EmptyArray;
				this.AddEnumerable(collection);
			}
			else
			{
				this.Items = new T[collection2.Count];
				this.AddCollection(collection2);
			}
		}

		public ExposedList(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			this.Items = new T[capacity];
		}

		internal ExposedList(T[] data, int size)
		{
			this.Items = data;
			this.Count = size;
		}

		public void Add(T item)
		{
			if (this.Count == this.Items.Length)
			{
				this.GrowIfNeeded(1);
			}
			this.Items[this.Count++] = item;
			this.version++;
		}

		public void GrowIfNeeded(int newCount)
		{
			int num = this.Count + newCount;
			if (num > this.Items.Length)
			{
				this.Capacity = Math.Max(Math.Max(this.Capacity * 2, 4), num);
			}
		}

		public ExposedList<T> Resize(int newSize)
		{
			if (newSize > this.Items.Length)
			{
				Array.Resize(ref this.Items, newSize);
			}
			this.Count = newSize;
			return this;
		}

		private void CheckRange(int idx, int count)
		{
			if (idx < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (idx + count > this.Count)
			{
				throw new ArgumentException("index and count exceed length of list");
			}
		}

		private void AddCollection(ICollection<T> collection)
		{
			int count = collection.Count;
			if (count == 0)
			{
				return;
			}
			this.GrowIfNeeded(count);
			collection.CopyTo(this.Items, this.Count);
			this.Count += count;
		}

		private void AddEnumerable(IEnumerable<T> enumerable)
		{
			foreach (T item in enumerable)
			{
				this.Add(item);
			}
		}

		public void AddRange(IEnumerable<T> collection)
		{
			this.CheckCollection(collection);
			ICollection<T> collection2 = collection as ICollection<T>;
			if (collection2 != null)
			{
				this.AddCollection(collection2);
			}
			else
			{
				this.AddEnumerable(collection);
			}
			this.version++;
		}

		public int BinarySearch(T item)
		{
			return Array.BinarySearch(this.Items, 0, this.Count, item);
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return Array.BinarySearch(this.Items, 0, this.Count, item, comparer);
		}

		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			this.CheckRange(index, count);
			return Array.BinarySearch(this.Items, index, count, item, comparer);
		}

		public void Clear(bool clearArray = true)
		{
			if (clearArray)
			{
				Array.Clear(this.Items, 0, this.Items.Length);
			}
			this.Count = 0;
			this.version++;
		}

		public bool Contains(T item)
		{
			return Array.IndexOf(this.Items, item, 0, this.Count) != -1;
		}

		public ExposedList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			ExposedList<TOutput> exposedList = new ExposedList<TOutput>(this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				exposedList.Items[i] = converter(this.Items[i]);
			}
			exposedList.Count = this.Count;
			return exposedList;
		}

		public void CopyTo(T[] array)
		{
			Array.Copy(this.Items, 0, array, 0, this.Count);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(this.Items, 0, array, arrayIndex, this.Count);
		}

		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			this.CheckRange(index, count);
			Array.Copy(this.Items, index, array, arrayIndex, count);
		}

		public bool Exists(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.GetIndex(0, this.Count, match) != -1;
		}

		public T Find(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int index = this.GetIndex(0, this.Count, match);
			return (index == -1) ? default(T) : this.Items[index];
		}

		private static void CheckMatch(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
		}

		public ExposedList<T> FindAll(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.FindAllList(match);
		}

		private ExposedList<T> FindAllList(Predicate<T> match)
		{
			ExposedList<T> exposedList = new ExposedList<T>();
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this.Items[i]))
				{
					exposedList.Add(this.Items[i]);
				}
			}
			return exposedList;
		}

		public int FindIndex(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.GetIndex(0, this.Count, match);
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			this.CheckIndex(startIndex);
			return this.GetIndex(startIndex, this.Count - startIndex, match);
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			this.CheckRange(startIndex, count);
			return this.GetIndex(startIndex, count, match);
		}

		private int GetIndex(int startIndex, int count, Predicate<T> match)
		{
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++)
			{
				if (match(this.Items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		public T FindLast(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int lastIndex = this.GetLastIndex(0, this.Count, match);
			return (lastIndex != -1) ? this.Items[lastIndex] : default(T);
		}

		public int FindLastIndex(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.GetLastIndex(0, this.Count, match);
		}

		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			this.CheckIndex(startIndex);
			return this.GetLastIndex(0, startIndex + 1, match);
		}

		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int num = startIndex - count + 1;
			this.CheckRange(num, count);
			return this.GetLastIndex(num, count, match);
		}

		private int GetLastIndex(int startIndex, int count, Predicate<T> match)
		{
			int num = startIndex + count;
			while (num != startIndex)
			{
				if (match(this.Items[--num]))
				{
					return num;
				}
			}
			return -1;
		}

		public void ForEach(Action<T> action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			for (int i = 0; i < this.Count; i++)
			{
				action(this.Items[i]);
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		public ExposedList<T> GetRange(int index, int count)
		{
			this.CheckRange(index, count);
			T[] array = new T[count];
			Array.Copy(this.Items, index, array, 0, count);
			return new ExposedList<T>(array, count);
		}

		public int IndexOf(T item)
		{
			return Array.IndexOf(this.Items, item, 0, this.Count);
		}

		public int IndexOf(T item, int index)
		{
			this.CheckIndex(index);
			return Array.IndexOf(this.Items, item, index, this.Count - index);
		}

		public int IndexOf(T item, int index, int count)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index + count > this.Count)
			{
				throw new ArgumentOutOfRangeException("index and count exceed length of list");
			}
			return Array.IndexOf(this.Items, item, index, count);
		}

		private void Shift(int start, int delta)
		{
			if (delta < 0)
			{
				start -= delta;
			}
			if (start < this.Count)
			{
				Array.Copy(this.Items, start, this.Items, start + delta, this.Count - start);
			}
			this.Count += delta;
			if (delta < 0)
			{
				Array.Clear(this.Items, this.Count, -delta);
			}
		}

		private void CheckIndex(int index)
		{
			if (index < 0 || index > this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
		}

		public void Insert(int index, T item)
		{
			this.CheckIndex(index);
			if (this.Count == this.Items.Length)
			{
				this.GrowIfNeeded(1);
			}
			this.Shift(index, 1);
			this.Items[index] = item;
			this.version++;
		}

		private void CheckCollection(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			this.CheckCollection(collection);
			this.CheckIndex(index);
			if (collection == this)
			{
				T[] array = new T[this.Count];
				this.CopyTo(array, 0);
				this.GrowIfNeeded(this.Count);
				this.Shift(index, array.Length);
				Array.Copy(array, 0, this.Items, index, array.Length);
			}
			else
			{
				ICollection<T> collection2 = collection as ICollection<T>;
				if (collection2 != null)
				{
					this.InsertCollection(index, collection2);
				}
				else
				{
					this.InsertEnumeration(index, collection);
				}
			}
			this.version++;
		}

		private void InsertCollection(int index, ICollection<T> collection)
		{
			int count = collection.Count;
			this.GrowIfNeeded(count);
			this.Shift(index, count);
			collection.CopyTo(this.Items, index);
		}

		private void InsertEnumeration(int index, IEnumerable<T> enumerable)
		{
			foreach (T item in enumerable)
			{
				this.Insert(index++, item);
			}
		}

		public int LastIndexOf(T item)
		{
			return Array.LastIndexOf(this.Items, item, this.Count - 1, this.Count);
		}

		public int LastIndexOf(T item, int index)
		{
			this.CheckIndex(index);
			return Array.LastIndexOf(this.Items, item, index, index + 1);
		}

		public int LastIndexOf(T item, int index, int count)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", index, "index is negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, "count is negative");
			}
			if (index - count + 1 < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, "count is too large");
			}
			return Array.LastIndexOf(this.Items, item, index, count);
		}

		public bool Remove(T item)
		{
			int num = this.IndexOf(item);
			if (num != -1)
			{
				this.RemoveAt(num);
			}
			return num != -1;
		}

		public int RemoveAll(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int i;
			for (i = 0; i < this.Count; i++)
			{
				if (match(this.Items[i]))
				{
					break;
				}
			}
			if (i == this.Count)
			{
				return 0;
			}
			this.version++;
			int j;
			for (j = i + 1; j < this.Count; j++)
			{
				if (!match(this.Items[j]))
				{
					this.Items[i++] = this.Items[j];
				}
			}
			if (j - i > 0)
			{
				Array.Clear(this.Items, i, j - i);
			}
			this.Count = i;
			return j - i;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.Shift(index, -1);
			Array.Clear(this.Items, this.Count, 1);
			this.version++;
		}

		public void RemoveRange(int index, int count)
		{
			this.CheckRange(index, count);
			if (count > 0)
			{
				this.Shift(index, -count);
				Array.Clear(this.Items, this.Count, count);
				this.version++;
			}
		}

		public void Reverse()
		{
			Array.Reverse(this.Items, 0, this.Count);
			this.version++;
		}

		public void Reverse(int index, int count)
		{
			this.CheckRange(index, count);
			Array.Reverse(this.Items, index, count);
			this.version++;
		}

		public void Sort()
		{
			Array.Sort(this.Items, 0, this.Count, Comparer<T>.Default);
			this.version++;
		}

		public void Sort(IComparer<T> comparer)
		{
			Array.Sort(this.Items, 0, this.Count, comparer);
			this.version++;
		}

		public void Sort(Comparison<T> comparison)
		{
			Array.Sort(this.Items, comparison);
			this.version++;
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
			this.CheckRange(index, count);
			Array.Sort(this.Items, index, count, comparer);
			this.version++;
		}

		public T[] ToArray()
		{
			T[] array = new T[this.Count];
			Array.Copy(this.Items, array, this.Count);
			return array;
		}

		public void TrimExcess()
		{
			this.Capacity = this.Count;
		}

		public bool TrueForAll(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			for (int i = 0; i < this.Count; i++)
			{
				if (!match(this.Items[i]))
				{
					return false;
				}
			}
			return true;
		}

		public int Capacity
		{
			get
			{
				return this.Items.Length;
			}
			set
			{
				if (value < this.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				Array.Resize(ref this.Items, value);
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public T[] Items;

		public int Count;

		private const int DefaultCapacity = 4;

		private static readonly T[] EmptyArray = new T[0];

		private int version;

		[Serializable]
		public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			internal Enumerator(ExposedList<T> l)
			{
				this = default(Enumerator);
				this.l = l;
				this.ver = l.version;
			}

			public void Dispose()
			{
				this.l = null;
			}

			private void VerifyState()
			{
				if (this.l == null)
				{
					throw new ObjectDisposedException(base.GetType().FullName);
				}
				if (this.ver != this.l.version)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
			}

			public bool MoveNext()
			{
				this.VerifyState();
				if (this.next < 0)
				{
					return false;
				}
				if (this.next < this.l.Count)
				{
					this.current = this.l.Items[this.next++];
					return true;
				}
				this.next = -1;
				return false;
			}

			public T Current
			{
				get
				{
					return this.current;
				}
			}

			void IEnumerator.Reset()
			{
				this.VerifyState();
				this.next = 0;
			}

			object IEnumerator.Current
			{
				get
				{
					this.VerifyState();
					if (this.next <= 0)
					{
						throw new InvalidOperationException();
					}
					return this.current;
				}
			}

			private ExposedList<T> l;

			private int next;

			private int ver;

			private T current;
		}
	}
}
