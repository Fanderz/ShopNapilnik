using System;

namespace Store
{
    public struct Good
    {
        public string Name { get; private set; }

        public Good(string name)
        {
            if (name == string.Empty)
                throw new ArgumentNullException();

            Name = name;
        }
    }
}
