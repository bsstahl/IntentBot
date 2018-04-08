using IntentBot.Entities;
using System;
using System.Collections.Generic;

namespace IntentBot
{
    public class IntentEntityValuesBuilder : List<IntentEntityValue>
    {
        public IEnumerable<IntentEntityValue> Build()
        {
            return this;
        }

        public IntentEntityValuesBuilder Add(string valueType, string value)
        {
            return Add(valueType, value, string.Empty);
        }

        public IntentEntityValuesBuilder Add(string valueType, string value, string pattern)
        {
            this.Add(new IntentEntityValue()
            {
                ValueType = valueType,
                Value = value,
                Pattern = pattern
            });
            return this;
        }
    }
}
