namespace PrimitivesPro.MeshCutting
{
    /// <summary>
    /// high performance dictionary with integer keys in range 0 .. Size
    /// </summary>
    /// <typeparam name="T">item of dictionary</typeparam>
    class ArrayDictionary<T>
    {
        public int Count;

        public int Size;

        private readonly DicItem[] dictionary;

        struct DicItem
        {
            public T data;
            public bool valid;
        }

        public ArrayDictionary(int size)
        {
            dictionary = new DicItem[size];
            this.Size = size;
        }

        public bool ContainsKey(int key)
        {
            if (key < Size)
            {
                return dictionary[key].valid;
            }

            return false;
        }

        public T this[int key]
        {
            get
            {
                MeshUtils.Assert(key < Size, "Key index out of range! " + key + " maxSize: " + Size);
                MeshUtils.Assert(dictionary[key].valid == true, "Key does not exists!");
                return dictionary[key].data;
            }

            set
            {
                MeshUtils.Assert(dictionary[key].valid == true, "Key does not exists!");
                dictionary[key].data = value;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Size; i++)
            {
                dictionary[i].data = default(T);
                dictionary[i].valid = false;
            }

            Count = 0;
        }

        public void Add(int key, T data)
        {
            MeshUtils.Assert(key < Size, "Key index out of range! " + key + " maxSize: " + Size);
            MeshUtils.Assert(dictionary[key].valid == false, "Key already exists!");

            dictionary[key].valid = true;
            dictionary[key].data = data;

            Count++;
        }

        public void Remove(int key)
        {
            MeshUtils.Assert(key < Size, "Key index out of range! " + key + " maxSize: " + Size);
            MeshUtils.Assert(dictionary[key].valid == true, "Key does not exists!");
            dictionary[key].valid = false;

            Count--;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var idx = 0;

            for (int i = 0; i < Size; i++)
            {
                if (dictionary[i].valid)
                {
                    array[idx++] = dictionary[i].data;

                    if (idx == Count)
                    {
                        return array;
                    }
                }
            }

            MeshUtils.Assert(false, "ToArray failed, Count is wrong!");
            return null;
        }

        public bool TryGetValue(int key, out T value)
        {
            MeshUtils.Assert(key < Size, "Key index out of range! " + key + " maxSize: " + Size);

            var item = dictionary[key];

            if (item.valid)
            {
                value = item.data;
                return true;
            }

            value = default(T);
            return false;
        }

        public T GetFirstValue()
        {
            for (int i = 0; i < Size; i++)
            {
                var item = dictionary[i];

                if (item.valid)
                {
                    return item.data;
                }
            }

            MeshUtils.Assert(false, "No valid key!");
            return default(T);
        }
    }
}
