﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class OnlineBatchReceipt {
    
    private OnlineBatchReceiptResult resultField;
    
    /// <remarks/>
    public OnlineBatchReceiptResult Result {
        get {
            return this.resultField;
        }
        set {
            this.resultField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class OnlineBatchReceiptResult {
    
    private resultCodeType resultCodeField;
    
    private bool resultCodeFieldSpecified;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public resultCodeType resultCode {
        get {
            return this.resultCodeField;
        }
        set {
            this.resultCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool resultCodeSpecified {
        get {
            return this.resultCodeFieldSpecified;
        }
        set {
            this.resultCodeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
public enum resultCodeType {
    
    /// <remarks/>
    OK,
    
    /// <remarks/>
    FAILED,
    
    /// <remarks/>
    FAILED_DO_NOT_RETRY,
}
