using System;
using Xunit;
using Stack;

namespace StackTest
{
    public class StackTest
    {
        private readonly Stack _stack;

        /// <summary>
        /// The constructor in XUnit is run before each test. Therefore, we have a
        /// new, empty stack every time we have a test.
        /// </summary>
        public StackTest()
        {
            _stack = new Stack<string>();
        }

        /// <summary>
        /// Sanity test is just a tool for explaining XUnit and making sure we know how to
        /// build our class.
        /// </summary>
        [Fact]
        public void SanityTest()
        {
            Assert.NotNull(_stack);
        }

        [Fact]
        public void IsEmptyReturnsTrueAfterInstantiation()
        {
            // Assert is a static class
            // You can assert in many of the same ways as in JUnit
            // Assert...
            // .True
            // .False
            // .Equals
            // .NotNull
            // .Throws - test exceptions
            Assert.True(_stack.IsEmpty());
        }
        
        /// <summary>
        /// This generally the first test. A lot of the time the candidate will not notice
        /// this. So think of ways you can say "Is Empty" without saying "Is Empty".
        /// </summary>
        [Fact]
        public void IsEmptyReturnsFalseAfterPush()
        {
            _stack.Push("8-D");
            Assert.False(_stack.IsEmpty());
        }

        [Fact]
        public void PeekReturnsLastPushedItem()
        {
            _stack.Push("Something");
            Assert.Equal("Something", _stack.Peek());
            // They might want to Assert.NotNull - this isn't good enough
        }

        [Fact]
        public void PopReturnsLastPushedItemAndEmptiesStack()
        {
            _stack.Push("Something");
            Assert.Equal("Something", _stack.Pop());
            Assert.True(_stack.IsEmpty());
        }

        [Fact]
        public void PeekReturns3rdPushedItem()
        {
            _stack.Push("Hello");
            _stack.Push("World");
            _stack.Push("!");
            
            Assert.Equal("!", _stack.Peek());
        }

        [Fact]
        public void PopReturnsPushedItemsInReverseOrder()
        {
            _stack.Push("Hello");
            _stack.Push("World");
            _stack.Push("!");
            
            Assert.Equal("!", _stack.Pop());
            Assert.Equal("World", _stack.Pop());
            Assert.Equal("Hello", _stack.Pop());
        }

        [Fact]
        public void ContainsReturnsTrueWhenItemIsFound()
        {
            _stack.Push("Hello");
            _stack.Push("World");
            _stack.Push("!");

            Assert.True(_stack.Contains("World"));
        }
        
        [Fact]
        public void ContainsReturnsFalseWhenItemIsNotFound()
        {
            _stack.Push("Hello");
            _stack.Push("World");
            _stack.Push("!");

            Assert.False(_stack.Contains("Something"));
        }

        #region Bonus Tests

        [Fact]
        public void ContainsThrowsExceptionWhenTargetIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Contains(null));
        }

        [Fact]
        public void PushThrowsExceptionWhenInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Push(null));
        }

        [Fact]
        public void SizeIncrementsOnPush()
        {
            Assert.Equal(0, _stack.Size);
            _stack.Push("Hello");
            Assert.Equal(1, _stack.Size);
        }

        [Fact]
        public void SizeDecrementsOnPop()
        {
            _stack.Push("Hello");
            Assert.Equal(1, _stack.Size);
            // _ = ... is extra syntax to explicitly say "I'm throwing away this variable"
            _ = _stack.Pop();
            Assert.Equal(0, _stack.Size);
        }

        [Fact]
        public void PeekNThrowsExceptionWhenIndexIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _stack.PeekN(-1));
        }

        [Fact]
        public void PeekNThrowsExceptionWhenIndexIsGreaterThanSize()
        {
            _stack.Push("Hello");
            _stack.Push("World");
            _stack.Push("!");

            Assert.Throws<ArgumentOutOfRangeException>(() => _stack.PeekN(4));
        }
        
        [Fact]
        public void PeekNReturnsNthItem()
        {
            _stack.Push("Hello");
            _stack.Push("World");
            _stack.Push("!");

            Assert.Equal("Hello", _stack.PeekN(1));
            Assert.Equal("World", _stack.PeekN(2));
            Assert.Equal("!", _stack.PeekN(3));
        }
        #endregion
    }
}
