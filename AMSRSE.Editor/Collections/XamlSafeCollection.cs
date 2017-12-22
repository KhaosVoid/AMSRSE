using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.Editor.Collections
{
    /// <summary>
    /// Provides the base class for a generic collection. Copied from referencesource.
    /// 
    /// For whatever reason, the definition in mscorlib will throw an ArgumentException
    /// when the collection has changed. This breaks the WPF designer and has no effect
    /// at run-time.
    /// 
    /// Use or derive from this class to prevent the WPF designer from displaying
    /// incorrect errors when using collections.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class XamlSafeCollection<T> : IList<T>, IList, IReadOnlyList<T>
    {
        #region Properties

        /// <summary>Gets the number of elements actually contained in the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <returns>The number of elements actually contained in the <see cref="XamlSafeCollection{T}" />.</returns>
        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>Gets a <see cref="IList{T}" /> wrapper around the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <returns>A <see cref="IList{T}" /> wrapper around the <see cref="XamlSafeCollection{T}" />.</returns>
        protected IList<T> Items
        {
            get { return items; }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return items.IsReadOnly; }
        }

        /// <summary>Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).</summary>
        /// <returns>true if access to the <see cref="ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="XamlSafeCollection{T}" />, this property always returns false.</returns>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
        /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.  In the default implementation of <see cref="XamlSafeCollection{T}" />, this property always returns the current instance.</returns>
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    ICollection c = items as ICollection;

                    if (c != null)
                        _syncRoot = c.SyncRoot;

                    else
                        System.Threading.Interlocked.CompareExchange<Object>(ref _syncRoot, new object(), null);
                }

                return _syncRoot;
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="IList" /> is read-only.</summary>
        /// <returns>true if the <see cref="IList" /> is read-only; otherwise, false.  In the default implementation of <see cref="XamlSafeCollection{T}" />, this property always returns false.</returns>
        bool IList.IsReadOnly
        {
            get { return items.IsReadOnly; }
        }

        /// <summary>Gets a value indicating whether the <see cref="IList" /> has a fixed size.</summary>
        /// <returns>true if the <see cref="IList" /> has a fixed size; otherwise, false.  In the default implementation of <see cref="XamlSafeCollection{T}" />, this property always returns false.</returns>
        bool IList.IsFixedSize
        {
            get
            {
                // There is no IList<T>.IsFixedSize, so we must assume that only
                // readonly collections are fixed size, if our internal item 
                // collection does not implement IList.  Note that Array implements
                // IList, and therefore T[] and U[] will be fixed-size.
                IList list = items as IList;

                if (list != null)
                    return list.IsFixedSize;

                return items.IsReadOnly;
            }
        }

        #endregion Properties

        #region Members

        IList<T> items;

        [NonSerialized]
        private Object _syncRoot;

        #endregion Members

        #region Indexer

        /// <summary>Gets or sets the element at the specified index.</summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.-or-<paramref name="index" /> is equal to or greater than <see cref="XamlSafeCollection{T}.Count" />.</exception>
        public T this[int index]
        {
            get { return items[index]; }
            set
            {
                if (items.IsReadOnly)
                    throw new NotSupportedException();

                if (index < 0 || index >= items.Count)
                    throw new ArgumentOutOfRangeException("index");

                SetItem(index, value);
            }
        }

        /// <summary>Gets or sets the element at the specified index.</summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is not a valid index in the <see cref="IList" />.</exception>
        /// <exception cref="ArgumentException">The property is set and <paramref name="value" /> is of a type that is not assignable to the <see cref="IList" />.</exception>
        object IList.this[int index]
        {
            get { return items[index]; }
            set
            {
                // Allow nulls for reference types and Nullable<U>, but not for value types.
                // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
                if (value == null && !(default(T) == null))
                    throw new ArgumentNullException("value");

                try
                {
                    this[index] = (T)value;
                }

                catch (InvalidCastException)
                {
                    throw new ArgumentException("Wrong value type.", "value");
                }
            }
        }

        #endregion Indexer

        #region Ctor

        /// <summary>Initializes a new instance of the <see cref="XamlSafeCollection{T}" /> class that is empty.</summary>
        public XamlSafeCollection()
        {
            items = new List<T>();
        }

        /// <summary>Initializes a new instance of the <see cref="XamlSafeCollection{T}" /> class as a wrapper for the specified list.</summary>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="list" /> is null.</exception>
        public XamlSafeCollection(IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list", "Value cannot be null.");

            items = list;
        }

        #endregion Ctor

        #region Methods

        /// <summary>Adds an object to the end of the <see cref="XamlSafeCollection{T}" />. </summary>
        /// <param name="item">The object to be added to the end of the <see cref="XamlSafeCollection{T}" />. The value can be null for reference types.</param>
        public void Add(T item)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            int index = items.Count;
            InsertItem(index, item);
        }

        /// <summary>Removes all elements from the <see cref="XamlSafeCollection{T}" />.</summary>
        public void Clear()
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            ClearItems();
        }

        /// <summary>Copies the entire <see cref="XamlSafeCollection{T}" /> to a compatible one-dimensional <see cref="Array" />, starting at the specified index of the target array.</summary>
        /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="XamlSafeCollection{T}" />. The <see cref="Array" /> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source <see cref="XamlSafeCollection{T}" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
        public void CopyTo(T[] array, int index)
        {
            items.CopyTo(array, index);
        }

        /// <summary>Determines whether an element is in the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <param name="item">The object to locate in the <see cref="XamlSafeCollection{T}" />. The value can be null for reference types.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="XamlSafeCollection{T}" />; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        /// <summary>Returns an enumerator that iterates through the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <returns>An <see cref="IEnumerator{T}" /> for the <see cref="XamlSafeCollection{T}" />.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="XamlSafeCollection{T}" />.</summary>
        /// <param name="item">The object to locate in the <see cref="List{T}" />. The value can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="item" /> within the entire <see cref="XamlSafeCollection{T}" />, if found; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        /// <summary>Inserts an element into the <see cref="XamlSafeCollection{T}" /> at the specified index.</summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.-or-<paramref name="index" /> is greater than <see cref="XamlSafeCollection{T}.Count" />.</exception>
        public void Insert(int index, T item)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            if (index < 0 || index > items.Count)
                throw new ArgumentOutOfRangeException("index");

            InsertItem(index, item);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <param name="item">The object to remove from the <see cref="XamlSafeCollection{T}" />. The value can be null for reference types.</param>
        /// <returns>true if <paramref name="item" /> is successfully removed; otherwise, false.  This method also returns false if <paramref name="item" /> was not found in the original <see cref="XamlSafeCollection{T}" />.</returns>
        public bool Remove(T item)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            int index = items.IndexOf(item);

            if (index < 0)
                return false;

            RemoveItem(index);

            return true;
        }

        /// <summary>Removes the element at the specified index of the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.-or-<paramref name="index" /> is equal to or greater than <see cref="XamlSafeCollection{T}.Count" />.</exception>
        public void RemoveAt(int index)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            if (index < 0 || index >= items.Count)
                throw new ArgumentOutOfRangeException("index");

            RemoveItem(index);
        }

        /// <summary>Removes all elements from the <see cref="XamlSafeCollection{T}" />.</summary>
        protected virtual void ClearItems()
        {
            items.Clear();
        }

        /// <summary>Inserts an element into the <see cref="XamlSafeCollection{T}" /> at the specified index.</summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.-or-<paramref name="index" /> is greater than <see cref="XamlSafeCollection{T}.Count" />.</exception>
        protected virtual void InsertItem(int index, T item)
        {
            items.Insert(index, item);
        }

        /// <summary>Removes the element at the specified index of the <see cref="XamlSafeCollection{T}" />.</summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.-or-<paramref name="index" /> is equal to or greater than <see cref="XamlSafeCollection{T}.Count" />.</exception>
        protected virtual void RemoveItem(int index)
        {
            items.RemoveAt(index);
        }

        /// <summary>Replaces the element at the specified index.</summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">The new value for the element at the specified index. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero.-or-<paramref name="index" /> is greater than <see cref="XamlSafeCollection{T}.Count" />.</exception>
        protected virtual void SetItem(int index, T item)
        {
            items[index] = item;
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }

        /// <summary>Copies the elements of the <see cref="ICollection" /> to an <see cref="Array" />, starting at a particular <see cref="Array" /> index.</summary>
        /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="ICollection" />. The <see cref="Array" /> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="array" /> is null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than zero. </exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="array" /> is multidimensional.-or-<paramref name="array" /> does not have zero-based indexing.-or-The number of elements in the source <see cref="ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.-or-The type of the source <see cref="ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("Value cannot be null.", "array");

            if (array.Rank != 1)
                throw new ArgumentException("Multi dimensional arrays are not supported.", "array");

            if (array.GetLowerBound(0) != 0)
                throw new ArgumentException("Array is non-zero lower bound.", "array");

            if (index < 0)
                throw new ArgumentOutOfRangeException("index");

            if (array.Length - index < Count)
                throw new ArgumentException("Array plus off too small.", "array");

            T[] tArray = array as T[];

            if (tArray != null)
                items.CopyTo(tArray, index);

            else
            {
                //
                // Catch the obvious case assignment will fail.
                // We can found all possible problems by doing the check though.
                // For example, if the element type of the Array is derived from T,
                // we can't figure out if we can successfully copy the element beforehand.
                //
                Type targetType = array.GetType().GetElementType();
                Type sourceType = typeof(T);

                if (!(targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType)))
                    throw new ArgumentException("Invalid array type.", "array");

                //
                // We can't cast array of value type to object[], so we don't support 
                // widening of primitive types here.
                //
                object[] objects = array as object[];

                if (objects == null)
                    throw new ArgumentException("Invalid array type.", "array");

                int count = items.Count;

                try
                {
                    for (int i = 0; i < count; i++)
                        objects[index++] = items[i];
                }

                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("Invalid array type.", "array");
                }
            }
        }

        /// <summary>Adds an item to the <see cref="IList" />.</summary>
        /// <param name="value">The <see cref="Object" /> to add to the <see cref="IList" />.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        /// <exception cref="ArgumentException">
        ///   <paramref name="value" /> is of a type that is not assignable to the <see cref="IList" />.</exception>
        int IList.Add(object value)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            // Allow nulls for reference types and Nullable<U>, but not for value types.
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
            if (value == null && !(default(T) == null))
                throw new ArgumentNullException("value");

            try
            {
                Add((T)value);
            }

            catch (InvalidCastException)
            {
                throw new ArgumentException("Wrong value type.", "value");
            }

            return this.Count - 1;
        }

        /// <summary>Determines whether the <see cref="IList" /> contains a specific value.</summary>
        /// <param name="value">The <see cref="Object" /> to locate in the <see cref="IList" />.</param>
        /// <returns>true if the <see cref="Object" /> is found in the <see cref="IList" />; otherwise, false.</returns>
        /// <exception cref="ArgumentException">
        ///   <paramref name="value" /> is of a type that is not assignable to the <see cref="IList" />.</exception>
        bool IList.Contains(object value)
        {
            if (IsCompatibleObject(value))
                return Contains((T)value);

            return false;
        }

        /// <summary>Determines the index of a specific item in the <see cref="IList" />.</summary>
        /// <param name="value">The <see cref="Object" /> to locate in the <see cref="IList" />.</param>
        /// <returns>The index of <paramref name="value" /> if found in the list; otherwise, -1.</returns>
        /// <exception cref="ArgumentException">
        ///   <paramref name="value" /> is of a type that is not assignable to the <see cref="IList" />.</exception>
        int IList.IndexOf(object value)
        {
            if (IsCompatibleObject(value))
                return IndexOf((T)value);

            return -1;
        }

        /// <summary>Inserts an item into the <see cref="IList" /> at the specified index.</summary>
        /// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
        /// <param name="value">The <see cref="Object" /> to insert into the <see cref="IList" />.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is not a valid index in the <see cref="IList" />. </exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="value" /> is of a type that is not assignable to the <see cref="IList" />.</exception>
        void IList.Insert(int index, object value)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            // Allow nulls for reference types and Nullable<U>, but not for value types.
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
            if (value == null && !(default(T) == null))
                throw new ArgumentNullException("value");

            try
            {
                Insert(index, (T)value);
            }

            catch (InvalidCastException)
            {
                throw new ArgumentException("Wrong value type.", "value");
            }

        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="IList" />.</summary>
        /// <param name="value">The <see cref="Object" /> to remove from the <see cref="IList" />.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="value" /> is of a type that is not assignable to the <see cref="IList" />.</exception>
        void IList.Remove(object value)
        {
            if (items.IsReadOnly)
                throw new NotSupportedException();

            if (IsCompatibleObject(value))
                Remove((T)value);
        }

        private static bool IsCompatibleObject(object value)
        {
            // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>. 
            return ((value is T) || (value == null && default(T) == null));
        }

        #endregion Methods
    }
}
