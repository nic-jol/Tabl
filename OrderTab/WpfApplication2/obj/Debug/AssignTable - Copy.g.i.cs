﻿#pragma checksum "..\..\AssignTable - Copy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5105CAC74041BAF0B1C2D214F4D69696794A445A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApplication2;


namespace WpfApplication2 {
    
    
    /// <summary>
    /// AssignTable
    /// </summary>
    public partial class AssignTable : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.AssignTable AssignWindow;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AssignGrid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock selectedCount;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock customers;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AssignTable - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication2;component/assigntable%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AssignTable - Copy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AssignWindow = ((WpfApplication2.AssignTable)(target));
            return;
            case 2:
            this.AssignGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.slider = ((System.Windows.Controls.Slider)(target));
            
            #line 10 "..\..\AssignTable - Copy.xaml"
            this.slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.updateCount);
            
            #line default
            #line hidden
            return;
            case 4:
            this.selectedCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.customers = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.okButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\AssignTable - Copy.xaml"
            this.okButton.Click += new System.Windows.RoutedEventHandler(this.buttonOkClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\AssignTable - Copy.xaml"
            this.cancelButton.Click += new System.Windows.RoutedEventHandler(this.buttonCancelClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

