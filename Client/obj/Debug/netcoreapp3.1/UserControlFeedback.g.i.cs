﻿#pragma checksum "..\..\..\UserControlFeedback.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60C79C5DAB1E8B5BCA83B774B808584D5EBD9EDE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Client;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Client {
    
    
    /// <summary>
    /// UserControlFeedback
    /// </summary>
    public partial class UserControlFeedback : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\UserControlFeedback.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nullMessage;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControlFeedback.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox questionsList;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UserControlFeedback.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonUpdate;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControlFeedback.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddQuestion;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;V1.0.0.0;component/usercontrolfeedback.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlFeedback.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nullMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.questionsList = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\..\UserControlFeedback.xaml"
            this.questionsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.questionsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\UserControlFeedback.xaml"
            this.buttonUpdate.Click += new System.Windows.RoutedEventHandler(this.buttonUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonAddQuestion = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\UserControlFeedback.xaml"
            this.buttonAddQuestion.Click += new System.Windows.RoutedEventHandler(this.buttonAddQuestion_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
