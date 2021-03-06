﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BadASBusiness.Authenticate {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AltinnFault", Namespace="http://www.altinn.no/services/common/fault/2009/10")]
    [System.SerializableAttribute()]
    public partial class AltinnFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AltinnErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AltinnExtendedErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AltinnLocalizedErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AltinnErrorMessage {
            get {
                return this.AltinnErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.AltinnErrorMessageField, value) != true)) {
                    this.AltinnErrorMessageField = value;
                    this.RaisePropertyChanged("AltinnErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AltinnExtendedErrorMessage {
            get {
                return this.AltinnExtendedErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.AltinnExtendedErrorMessageField, value) != true)) {
                    this.AltinnExtendedErrorMessageField = value;
                    this.RaisePropertyChanged("AltinnExtendedErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AltinnLocalizedErrorMessage {
            get {
                return this.AltinnLocalizedErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.AltinnLocalizedErrorMessageField, value) != true)) {
                    this.AltinnLocalizedErrorMessageField = value;
                    this.RaisePropertyChanged("AltinnLocalizedErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorGuid {
            get {
                return this.ErrorGuidField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorGuidField, value) != true)) {
                    this.ErrorGuidField = value;
                    this.RaisePropertyChanged("ErrorGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorID {
            get {
                return this.ErrorIDField;
            }
            set {
                if ((this.ErrorIDField.Equals(value) != true)) {
                    this.ErrorIDField = value;
                    this.RaisePropertyChanged("ErrorID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserGuid {
            get {
                return this.UserGuidField;
            }
            set {
                if ((object.ReferenceEquals(this.UserGuidField, value) != true)) {
                    this.UserGuidField = value;
                    this.RaisePropertyChanged("UserGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationChallengeRequestBE", Namespace="http://schemas.altinn.no/services/Authentication/2009/10")]
    [System.SerializableAttribute()]
    public partial class AuthenticationChallengeRequestBE : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthMethodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SystemUserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserSSNField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthMethod {
            get {
                return this.AuthMethodField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthMethodField, value) != true)) {
                    this.AuthMethodField = value;
                    this.RaisePropertyChanged("AuthMethod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SystemUserName {
            get {
                return this.SystemUserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SystemUserNameField, value) != true)) {
                    this.SystemUserNameField = value;
                    this.RaisePropertyChanged("SystemUserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserPassword {
            get {
                return this.UserPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.UserPasswordField, value) != true)) {
                    this.UserPasswordField = value;
                    this.RaisePropertyChanged("UserPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserSSN {
            get {
                return this.UserSSNField;
            }
            set {
                if ((object.ReferenceEquals(this.UserSSNField, value) != true)) {
                    this.UserSSNField = value;
                    this.RaisePropertyChanged("UserSSN");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationChallengeBE", Namespace="http://schemas.altinn.no/services/Authentication/2009/10")]
    [System.SerializableAttribute()]
    public partial class AuthenticationChallengeBE : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BadASBusiness.Authenticate.ChallengeRequestResult StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ValidFromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ValidToField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BadASBusiness.Authenticate.ChallengeRequestResult Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ValidFrom {
            get {
                return this.ValidFromField;
            }
            set {
                if ((this.ValidFromField.Equals(value) != true)) {
                    this.ValidFromField = value;
                    this.RaisePropertyChanged("ValidFrom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ValidTo {
            get {
                return this.ValidToField;
            }
            set {
                if ((this.ValidToField.Equals(value) != true)) {
                    this.ValidToField = value;
                    this.RaisePropertyChanged("ValidTo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChallengeRequestResult", Namespace="http://schemas.altinn.no/services/Authentication/2009/10")]
    public enum ChallengeRequestResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ok = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidCredentials = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NoPinFound = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NoPhoneNumber = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserLockedOut = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidPinType = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        StatusDead = 6,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10", ConfigurationName="Authenticate.ISystemAuthenticationExternal")]
    public interface ISystemAuthenticationExternal {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://www.altinn.no/services/2009/10) of message TestRequest does not match the default value (http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.altinn.no/services/2009/10/IAltinnContractBase/Test", ReplyAction="http://www.altinn.no/services/2009/10/IAltinnContractBase/TestResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(BadASBusiness.Authenticate.AltinnFault), Action="http://www.altinn.no/services/2009/10/IAltinnContractBase/TestAltinnFaultFault", Name="AltinnFault", Namespace="http://www.altinn.no/services/common/fault/2009/10")]
        BadASBusiness.Authenticate.TestResponse Test(BadASBusiness.Authenticate.TestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.altinn.no/services/2009/10/IAltinnContractBase/Test", ReplyAction="http://www.altinn.no/services/2009/10/IAltinnContractBase/TestResponse")]
        System.Threading.Tasks.Task<BadASBusiness.Authenticate.TestResponse> TestAsync(BadASBusiness.Authenticate.TestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10/ISystem" +
            "AuthenticationExternal/GetAuthenticationChallenge", ReplyAction="http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10/ISystem" +
            "AuthenticationExternal/GetAuthenticationChallengeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(BadASBusiness.Authenticate.AltinnFault), Action="http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10/ISystem" +
            "AuthenticationExternal/GetAuthenticationChallengeAltinnFaultFault", Name="AltinnFault", Namespace="http://www.altinn.no/services/common/fault/2009/10")]
        BadASBusiness.Authenticate.AuthenticationChallengeBE GetAuthenticationChallenge(BadASBusiness.Authenticate.AuthenticationChallengeRequestBE challengeRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10/ISystem" +
            "AuthenticationExternal/GetAuthenticationChallenge", ReplyAction="http://www.altinn.no/services/Authentication/SystemAuthentication/2009/10/ISystem" +
            "AuthenticationExternal/GetAuthenticationChallengeResponse")]
        System.Threading.Tasks.Task<BadASBusiness.Authenticate.AuthenticationChallengeBE> GetAuthenticationChallengeAsync(BadASBusiness.Authenticate.AuthenticationChallengeRequestBE challengeRequest);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Test", WrapperNamespace="http://www.altinn.no/services/2009/10", IsWrapped=true)]
    public partial class TestRequest {
        
        public TestRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TestResponse", WrapperNamespace="http://www.altinn.no/services/2009/10", IsWrapped=true)]
    public partial class TestResponse {
        
        public TestResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISystemAuthenticationExternalChannel : BadASBusiness.Authenticate.ISystemAuthenticationExternal, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SystemAuthenticationExternalClient : System.ServiceModel.ClientBase<BadASBusiness.Authenticate.ISystemAuthenticationExternal>, BadASBusiness.Authenticate.ISystemAuthenticationExternal {
        
        public SystemAuthenticationExternalClient() {
        }
        
        public SystemAuthenticationExternalClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SystemAuthenticationExternalClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SystemAuthenticationExternalClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SystemAuthenticationExternalClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BadASBusiness.Authenticate.TestResponse BadASBusiness.Authenticate.ISystemAuthenticationExternal.Test(BadASBusiness.Authenticate.TestRequest request) {
            return base.Channel.Test(request);
        }
        
        public void Test() {
            BadASBusiness.Authenticate.TestRequest inValue = new BadASBusiness.Authenticate.TestRequest();
            BadASBusiness.Authenticate.TestResponse retVal = ((BadASBusiness.Authenticate.ISystemAuthenticationExternal)(this)).Test(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<BadASBusiness.Authenticate.TestResponse> BadASBusiness.Authenticate.ISystemAuthenticationExternal.TestAsync(BadASBusiness.Authenticate.TestRequest request) {
            return base.Channel.TestAsync(request);
        }
        
        public System.Threading.Tasks.Task<BadASBusiness.Authenticate.TestResponse> TestAsync() {
            BadASBusiness.Authenticate.TestRequest inValue = new BadASBusiness.Authenticate.TestRequest();
            return ((BadASBusiness.Authenticate.ISystemAuthenticationExternal)(this)).TestAsync(inValue);
        }
        
        public BadASBusiness.Authenticate.AuthenticationChallengeBE GetAuthenticationChallenge(BadASBusiness.Authenticate.AuthenticationChallengeRequestBE challengeRequest) {
            return base.Channel.GetAuthenticationChallenge(challengeRequest);
        }
        
        public System.Threading.Tasks.Task<BadASBusiness.Authenticate.AuthenticationChallengeBE> GetAuthenticationChallengeAsync(BadASBusiness.Authenticate.AuthenticationChallengeRequestBE challengeRequest) {
            return base.Channel.GetAuthenticationChallengeAsync(challengeRequest);
        }
    }
}
