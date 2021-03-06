﻿using System.Collections.Immutable;
using System.Linq;
using ShaderTools.Core.Syntax;
using ShaderTools.Hlsl.Compilation;
using ShaderTools.Hlsl.Symbols;
using ShaderTools.Hlsl.Syntax;

namespace ShaderTools.Editor.VisualStudio.Hlsl.IntelliSense.SignatureHelp.SignatureHelpModelProviders
{
    internal abstract class SignatureHelpModelProvider<T> : ISignatureHelpModelProvider
        where T : SyntaxNode
    {
        public SignatureHelpModel GetModel(SemanticModel semanticModel, SourceLocation position)
        {
            var syntaxTree = semanticModel.Compilation.SyntaxTree;
            var token = syntaxTree.Root.FindTokenOnLeft(position);
            var node = token.Parent
                .AncestorsAndSelf()
                .OfType<T>()
                .FirstOrDefault(c => c.IsBetweenParentheses(position));

            return node == null
                ? null
                : GetModel(semanticModel, node, position);
        }

        protected abstract SignatureHelpModel GetModel(SemanticModel semanticModel, T node, SourceLocation position);

        protected SignatureItem GetSelected(
            Symbol currentSymbol, ImmutableArray<SignatureItem> signatures,
            int parameterIndex)
        {
            if (currentSymbol != null)
                return signatures.FirstOrDefault(x => x.Symbol.Equals(currentSymbol));

            return signatures.FirstOrDefault(s => s.Parameters.Length > parameterIndex);
        }
    }
}