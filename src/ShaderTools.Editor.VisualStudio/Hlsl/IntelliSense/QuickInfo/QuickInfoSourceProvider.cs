﻿using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using ShaderTools.Editor.VisualStudio.Core.Glyphs;
using ShaderTools.Editor.VisualStudio.Hlsl.Tagging.Classification;

namespace ShaderTools.Editor.VisualStudio.Hlsl.IntelliSense.QuickInfo
{
    [Export(typeof(IQuickInfoSourceProvider))]
    [Name("QuickInfoSourceProvider")]
    [ContentType(HlslConstants.ContentTypeName)]
    internal sealed class QuickInfoSourceProvider : IQuickInfoSourceProvider
    {
        [Import]
        public IClassificationFormatMapService ClassificationFormatMapService { get; set; }

        [Import]
        public HlslClassificationService ClassificationService { get; set; }

        [Import]
        public DispatcherGlyphService DispatcherGlyphService { get; set; }

        public IQuickInfoSource TryCreateQuickInfoSource(ITextBuffer textBuffer)
        {
            return new QuickInfoSource(ClassificationFormatMapService, ClassificationService, DispatcherGlyphService);
        }
    }
}