using System.ComponentModel.Composition;
using ShaderTools.Core.Syntax;
using ShaderTools.Hlsl.Compilation;
using ShaderTools.Hlsl.Syntax;

namespace ShaderTools.Editor.VisualStudio.Hlsl.IntelliSense.QuickInfo.QuickInfoModelProviders
{
    [Export(typeof(IQuickInfoModelProvider))]
    internal sealed class ParameterQuickInfoModelProvider : QuickInfoModelProvider<ParameterSyntax>
    {
        protected override QuickInfoModel CreateModel(SemanticModel semanticModel, SourceLocation position, ParameterSyntax node)
        {
            if (!node.Declarator.Identifier.SourceRange.ContainsOrTouches(position))
                return null;

            if (!node.Declarator.Identifier.Span.IsInRootFile)
                return null;

            var symbol = semanticModel.GetDeclaredSymbol(node);
            if (symbol == null)
                return null;

            return QuickInfoModel.ForSymbol(semanticModel, node.Declarator.Identifier.Span, symbol);
        }
    }
}