using System;
using System.Collections.Specialized;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml.Diagnostics;
using Avalonia.Media;
using Avalonia.Reactive;

namespace Avalonia.Diagnostics.ViewModels
{
    internal abstract class TreeNode : ViewModelBase, IDisposable
    {
        private readonly IDisposable? _classesSubscription;
        private string _classes;
        private XamlSourceInfo? _sourceInfo;

        protected TreeNode(AvaloniaObject avaloniaObject, TreeNode? parent, string? customTypeName = null)
        {
            _classes = string.Empty;
            _sourceInfo = XamlSourceInfo.GetXamlSourceInfo(avaloniaObject);
            Parent = parent;
            Type = customTypeName ?? avaloniaObject.GetType().Name;
            Visual = avaloniaObject;
            FontWeight = IsRoot ? FontWeight.Bold : FontWeight.Normal;

            ElementName = (avaloniaObject as INamed)?.Name;

            if (avaloniaObject is StyledElement { Classes: { } classes })
            {
                _classesSubscription = ((IObservable<object?>)classes.GetWeakCollectionChangedObservable())
                    .StartWith(null)
                    .Subscribe(_ =>
                    {
                        Classes = classes.Count > 0 ? $"({string.Join(" ", classes)})" : string.Empty;
                    });
            }
        }

        private bool IsRoot => Visual is TopLevel or ContextMenu or IPopupHost;

        public FontWeight FontWeight { get; }

        public abstract TreeNodeCollection Children { get; }

        public string Classes
        {
            get => _classes;
            private set => RaiseAndSetIfChanged(ref _classes, value);
        }

        public XamlSourceInfo? SourceInfo
        {
            get => _sourceInfo;
            private set => RaiseAndSetIfChanged(ref _sourceInfo, value);
        }

        public string? ElementName { get; }

        public AvaloniaObject Visual { get; }

        public bool IsExpanded
        {
            get;
            set => RaiseAndSetIfChanged(ref field, value);
        }

        public TreeNode? Parent
        {
            get;
        }

        public string Type
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _classesSubscription?.Dispose();
            Children.Dispose();
        }

        public void NavigateToXamlSource()
        {
            Console.WriteLine($"source info :{_sourceInfo}");
            if (_sourceInfo is null) return;
            RiderXamlHelper.NavigateToXamlSource(_sourceInfo.LineNumber, _sourceInfo.LinePosition, _sourceInfo.SourceUri?.LocalPath);
        }
    }
}
