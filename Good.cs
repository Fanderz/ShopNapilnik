using System;

namespace Store
{
    public struct Good
    {
        public Good(string name)
        {
            if (name == string.Empty)
                throw new ArgumentNullException();

            Name = name;
        }

        public string Name { get; private set; }
    }
}
