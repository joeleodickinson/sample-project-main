using System;

namespace BusinessEntities
{
    // Note: creating this class as a separate entity to handle ID and number properties, for cases in which
    // number is a human-readable identifier and id is a system identifier.
    public class IdNumberObject : IdObject
    {
        private string _number;

        public string Number
        {
            get => _number;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Number cannot be null or empty.");
                }
                _number = value;
            }
        }

        public void SetNumber(string number)
        {
            Number = number;
        }
    }
}