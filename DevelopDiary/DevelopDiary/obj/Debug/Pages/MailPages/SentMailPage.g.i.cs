﻿#pragma checksum "..\..\..\..\Pages\MailPages\SentMailPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1B2BDB26313ADF51EA2A2E9003BF5DC6A598D077150A018757B67DBAABC67819"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevelopDiary.Pages.MailPages;
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


namespace DevelopDiary.Pages.MailPages {
    
    
    /// <summary>
    /// SentMailPage
    /// </summary>
    public partial class SentMailPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbFio;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WriteBtn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IncomingBtn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SentBtn;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewTask;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tbx_serhc;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExistBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/DevelopDiary;component/pages/mailpages/sentmailpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
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
            this.TxbFio = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.WriteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
            this.WriteBtn.Click += new System.Windows.RoutedEventHandler(this.WriteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IncomingBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
            this.IncomingBtn.Click += new System.Windows.RoutedEventHandler(this.IncomingBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SentBtn = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
            this.SentBtn.Click += new System.Windows.RoutedEventHandler(this.SentBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LViewTask = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.Tbx_serhc = ((System.Windows.Controls.TextBox)(target));
            
            #line 112 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
            this.Tbx_serhc.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tbx_serhc_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ExistBtn = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\..\Pages\MailPages\SentMailPage.xaml"
            this.ExistBtn.Click += new System.Windows.RoutedEventHandler(this.ExistBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
