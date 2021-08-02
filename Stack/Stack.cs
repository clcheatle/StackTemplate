using System;

namespace Stack
{
    class Node<T> where T : class
    {
        public T Data;
        public Node<T> Previous;
    }
    
    public class Stack<T> where T : class
    {
        private Node<T> _last;

        #region Bonus
        // optionally, they can use `uint`, which saves a lot of code
        public int Size { get; private set; }
        #endregion

        public Stack()
        {
            // This will happen by default anyway
            _last = null;
            Size = 0;
        }

        /// <summary>
        /// IsEmpty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty()
        {
            //return _data == null;
            // With the null check operator:
            return _last?.Data == null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            #region Bonus
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
                // Don't do this:
                //  throw new NullReferenceException();
                //  ^ MS doesn't like it if you do this as it represents a system exception.
            }
            #endregion

            Node<T> node = new Node<T>()
            {
                Data = item,
                Previous = _last
            };
            _last = node;
            Size++;
        }

        /// <summary>
        /// Readonly. Returns the last pushed item of the stack.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return _last?.Data;
        }

        /// <summary>
        /// Mutator. Remove and return the last pushed item of the stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }

            var temp = _last.Data;
            _last = _last.Previous;
            Size--;
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Contains(T target)
        {
            #region Bonus
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            #endregion

            if (IsEmpty())
            {
                return false;
            }

            var i = _last;
            while (i.Previous != null)
            {
                // i.Data == target
                // ^ this actually works with strings
                if (i.Data.Equals(target))
                {
                    return true;
                }

                i = i.Previous;
            }

            return false;
        }

        #region Bonus

        public T PeekN(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index > Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            
            var iter = _last;
            var i = Size;
            while (i != index)
            {
                iter = iter.Previous;
                i--;
            }

            return iter.Data;
        }

        #endregion
    }
}
