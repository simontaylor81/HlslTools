using System.Collections.Immutable;
using ShaderTools.Hlsl.Symbols;

namespace ShaderTools.Hlsl.Binding.BoundNodes
{
    internal sealed class BoundNamespace : BoundNode
    {
        public NamespaceSymbol NamespaceSymbol { get; }
        public ImmutableArray<BoundNode> Declarations { get; }

        public BoundNamespace(NamespaceSymbol namespaceSymbol, ImmutableArray<BoundNode> declarations)
            : base(BoundNodeKind.Namespace)
        {
            NamespaceSymbol = namespaceSymbol;
            Declarations = declarations;
        }
    }
}