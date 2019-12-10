using System;

namespace Microsoft.VisualStudio.Shared.VSCodeDebugProtocol.Serialization
{
    internal class NullableEnumValue<T> : EnumValueBase<T> where T : struct, Enum
    {
        private T? _value;

        public T? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnValueChanged();
            }
        }

        public override bool ShouldSerialize => Value.HasValue;

        protected override bool TryGetValue(out T value)
        {
            value = Value.GetValueOrDefault();
            return Value.HasValue;
        }

        protected override void SetValue(T value, bool isNull)
        {
            _value = (isNull ? null : new T?(value));
        }
    }
}