﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShaderTools.Editor.VisualStudio.Core.Util.Extensions
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));
            return sequence.SelectMany(s => s);
        }
    }
}