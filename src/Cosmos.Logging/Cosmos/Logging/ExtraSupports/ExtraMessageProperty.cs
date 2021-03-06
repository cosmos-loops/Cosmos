﻿using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.ExtraSupports {
    /// <summary>
    /// Extra message property
    /// </summary>
    public class ExtraMessageProperty : IMessageProperty {
        /// <summary>
        /// Create a new instance of <see cref="ExtraMessageProperty"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ExtraMessageProperty(string name, MessagePropertyValue value) {
            CheckParams(name, value);
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Create a new instance of <see cref="ExtraMessageProperty"/>.
        /// </summary>
        /// <param name="property"></param>
        public ExtraMessageProperty(MessageProperty property) {
            CheckParams(property);
            Name = property.Name;
            Value = property.Value;
        }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public MessagePropertyValue Value { get; }

        private static void CheckParams(MessageProperty property) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            CheckParams(property.Name, property.Value);
        }

        private static void CheckParams(string name, MessagePropertyValue value) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
        }

        /// <inheritdoc />
        public override string ToString() {
            return $"{Name}: {Value.ToString()}";
        }
    }
}