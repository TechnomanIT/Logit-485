﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=IT-PC2\\SQLEXPRESS;Initial Catalog=PlotterDA;Persist Security Info=Tru" +
            "e;User ID=sa")]
        public string PlotterDAConnectionString {
            get {
                return ((string)(this["PlotterDAConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=IT-PC2\\SQLEXPRESS;Initial Catalog=PlotterDA;Integrated Security=True")]
        public string PlotterDAConnectionString1 {
            get {
                return ((string)(this["PlotterDAConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=IT-PC2\\SQLEXPRESS;Initial Catalog=PlotterDA;User ID=sa;Password=micro" +
            "soft")]
        public string PlotterDAConnectionString2 {
            get {
                return ((string)(this["PlotterDAConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-3103HF3;Initial Catalog=PlotterRS485;Integrated Security=True" +
            "")]
        public string PlotterRS485ConnectionString {
            get {
                return ((string)(this["PlotterRS485ConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-3103HF3;Initial Catalog=PlotterDA;User ID=sa;Password=microso" +
            "ft;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True")]
        public string PlotterDAConnectionString3 {
            get {
                return ((string)(this["PlotterDAConnectionString3"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-3103HF3;Initial Catalog=PlotterRS485;User ID=sa;Password=micr" +
            "osoft;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True")]
        public string PlotterRS485ConnectionString1 {
            get {
                return ((string)(this["PlotterRS485ConnectionString1"]));
            }
        }
    }
}
