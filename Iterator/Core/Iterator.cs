
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestartorIterator.Core
{

    public class Context
    {
        private Iterator _input;

        // Constructor
        public Context(Iterator input)
        {
            this._input = input;
        }

        // Gets or sets input
        public Iterator Input
        {
            get { return _input; }
            set { _input = value; }
        }
    }

    public class Item
    {
        private string _code;

        // Constructor
        public Item(string code)
        {
            this._code = code;
        }

        // Gets name
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
    }

    public class Collection : IAbstractCollection
    {
        private ArrayList _items = new ArrayList();

        public Collection(string code)
        {
            string[] result = code.Split(new[] { '\r', '\n' });
            int collectionindex = 0;
            foreach (string codeline in result)
            {
                this[collectionindex++] = new Item(codeline);
            }
        }

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }

    public class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;

        // Constructor
        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        // Gets first item
        public Item First()
        {
            _current = 0;
            return _collection[_current] as Item;
        }

        // Gets next item
        public Item Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as Item;
            else
                return null;
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets current iterator item
        public Item CurrentItem
        {
            get { return _collection[_current] as Item; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
    
}
