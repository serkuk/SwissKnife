﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ByteBee.Core.Exceptions;
using ByteBee.Core.GuardClause;

namespace ByteBee.Core.Enums
{
    public abstract class BeeEnum<TEnum, TValue> where TEnum : BeeEnum<TEnum, TValue>
    {
        private static readonly Lazy<TEnum[]> _allMembersLazy = new Lazy<TEnum[]>(() =>
        {
            Type t = typeof(TEnum);
            BindingFlags publicStatic = BindingFlags.Public | BindingFlags.Static;

            IEnumerable<TEnum> ofProp = t.GetProperties(publicStatic)
                .Where(p => t.IsAssignableFrom(p.PropertyType))
                .Select(i => (TEnum)i.GetValue(null));

            IEnumerable<TEnum> ofField = t.GetFields(publicStatic)
                .Where(f => t.IsAssignableFrom(f.FieldType))
                .Select(i => (TEnum)i.GetValue(null));

            return ofProp.Union(ofField).OrderBy(e => e.Value).ToArray();
        });

        public static TEnum[] GetAll() => _allMembersLazy.Value;

        public string Name { get; set; }
        public TValue Value { get; set; }

        protected BeeEnum(TValue value, string name)
        {
            Name = name;
            Value = value;
        }

        public static TEnum ByName(string name)
        {
            Bee.Guard.NullOrEmpty(name, nameof(name));

            TEnum result = GetAll().SingleOrDefault(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
            if (result == null)
            {
                throw new EnumNotFoundException($"No {typeof(TEnum).Name} with name \"{name}\" found.");
            }
            return result;
        }

        public static TEnum ByValue(TValue value)
        {
            TEnum result = GetAll().SingleOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));
            if (result == null)
            {
                throw new EnumNotFoundException($"No {typeof(TEnum).Name} with value {value} found.");
            }
            return result;
        }

        public static TEnum ByValue(TValue value, TEnum defaultValue)
        {
            TEnum result = GetAll().SingleOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));
            if (result == null)
            {
                result = defaultValue;
            }
            return result;
        }

        public override string ToString() => $"{Name} ({Value})";

        public static implicit operator TValue(BeeEnum<TEnum, TValue> @enum) => @enum.Value;
        public static explicit operator BeeEnum<TEnum, TValue>(TValue value) => ByValue(value);
    }
}
