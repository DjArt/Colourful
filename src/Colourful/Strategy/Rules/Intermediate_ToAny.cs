﻿using static Colourful.Strategy.ConversionRulePriorities;
using static Colourful.Strategy.Rules.ConversionRuleUtils;

namespace Colourful.Strategy.Rules
{
    /// <summary>
    /// If the conversion is to arbitrary type, adds an intermediate node.
    /// </summary>
    /// <typeparam name="TSource">Source color type</typeparam>
    /// <typeparam name="TIntermediate">Intermediate color type</typeparam>
    public class Intermediate_ToAny<TSource, TIntermediate> : IConversionRule
        where TSource : struct
        where TIntermediate : struct
    {
        /// <inheritdoc />
        public int Priority => IntermediateToAny;

        /// <inheritdoc />
        public bool TryApplyRule(in IConversionMetadata sourceNode, in IConversionMetadata targetNode, out IConversionMetadata[] replacementNodes, out object conversion)
        {
            replacementNodes = new IConversionMetadata[] { };
            conversion = null;

            if (!sourceNode.HasColorType<TSource>())
                return false;

            var intermediateNode = sourceNode.CloneWithColorType<TIntermediate>();
            replacementNodes = new[] { sourceNode, intermediateNode, targetNode };
            return true;
        }
    }
}