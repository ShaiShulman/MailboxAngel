﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilingHelper.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class AddinSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static AddinSettings defaultInstance = ((AddinSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AddinSettings())));
        
        public static AddinSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string EmailSignatureInternalName {
            get {
                return ((string)(this["EmailSignatureInternalName"]));
            }
            set {
                this["EmailSignatureInternalName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string InternalDomainNames {
            get {
                return ((string)(this["InternalDomainNames"]));
            }
            set {
                this["InternalDomainNames"] = value;
            }
        }
    }
}
