using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Model
{
    public partial class LoginResp
    {
        [JsonProperty("Principal")]
        public Principal Principal { get; set; }

        [JsonProperty("MiembrosDe")]
        public string[] MiembrosDe { get; set; }
    }

    public partial class Principal
    {
        [JsonProperty("Status")]
        public int Status { get; set; }
        [JsonProperty("GivenName")]
        public string GivenName { get; set; }

        [JsonProperty("MiddleName")]
        public object MiddleName { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("VoiceTelephoneNumber")]
        public string VoiceTelephoneNumber { get; set; }

        [JsonProperty("EmployeeId")]
        public object EmployeeId { get; set; }

        [JsonProperty("AdvancedSearchFilter")]
        public AdvancedSearchFilter AdvancedSearchFilter { get; set; }

        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("AccountLockoutTime")]
        public object AccountLockoutTime { get; set; }

        [JsonProperty("LastLogon")]
        public DateTimeOffset LastLogon { get; set; }

        [JsonProperty("PermittedWorkstations")]
        public object[] PermittedWorkstations { get; set; }

        [JsonProperty("PermittedLogonTimes")]
        public object PermittedLogonTimes { get; set; }

        [JsonProperty("AccountExpirationDate")]
        public object AccountExpirationDate { get; set; }

        [JsonProperty("SmartcardLogonRequired")]
        public bool SmartcardLogonRequired { get; set; }

        [JsonProperty("DelegationPermitted")]
        public bool DelegationPermitted { get; set; }

        [JsonProperty("BadLogonCount")]
        public long BadLogonCount { get; set; }

        [JsonProperty("HomeDirectory")]
        public object HomeDirectory { get; set; }

        [JsonProperty("HomeDrive")]
        public object HomeDrive { get; set; }

        [JsonProperty("ScriptPath")]
        public object ScriptPath { get; set; }

        [JsonProperty("LastPasswordSet")]
        public DateTimeOffset LastPasswordSet { get; set; }

        [JsonProperty("LastBadPasswordAttempt")]
        public DateTimeOffset LastBadPasswordAttempt { get; set; }

        [JsonProperty("PasswordNotRequired")]
        public bool PasswordNotRequired { get; set; }

        [JsonProperty("PasswordNeverExpires")]
        public bool PasswordNeverExpires { get; set; }

        [JsonProperty("UserCannotChangePassword")]
        public bool UserCannotChangePassword { get; set; }

        [JsonProperty("AllowReversiblePasswordEncryption")]
        public bool AllowReversiblePasswordEncryption { get; set; }

        [JsonProperty("Certificates")]
        public Certificate[] Certificates { get; set; }

        [JsonProperty("Context")]
        public Context Context { get; set; }

        [JsonProperty("ContextType")]
        public long ContextType { get; set; }

        [JsonProperty("Description")]
        public object Description { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("SamAccountName")]
        public string SamAccountName { get; set; }

        [JsonProperty("UserPrincipalName")]
        public string UserPrincipalName { get; set; }

        [JsonProperty("Sid")]
        public Sid Sid { get; set; }

        [JsonProperty("Guid")]
        public Guid Guid { get; set; }

        [JsonProperty("DistinguishedName")]
        public string DistinguishedName { get; set; }

        [JsonProperty("StructuralObjectClass")]
        public string StructuralObjectClass { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class AdvancedSearchFilter
    {
    }

    public partial class Certificate
    {
        [JsonProperty("Archived")]
        public bool Archived { get; set; }

        [JsonProperty("Extensions")]
        public Extension[] Extensions { get; set; }

        [JsonProperty("FriendlyName")]
        public string FriendlyName { get; set; }

        [JsonProperty("HasPrivateKey")]
        public bool HasPrivateKey { get; set; }

        [JsonProperty("PrivateKey")]
        public object PrivateKey { get; set; }

        [JsonProperty("IssuerName")]
        public Name IssuerName { get; set; }

        [JsonProperty("NotAfter")]
        public DateTimeOffset NotAfter { get; set; }

        [JsonProperty("NotBefore")]
        public DateTimeOffset NotBefore { get; set; }

        [JsonProperty("PublicKey")]
        public PublicKey PublicKey { get; set; }

        [JsonProperty("RawData")]
        public string RawData { get; set; }

        [JsonProperty("RawDataMemory")]
        public RawDataMemory RawDataMemory { get; set; }

        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("SignatureAlgorithm")]
        public SignatureAlgorithm SignatureAlgorithm { get; set; }

        [JsonProperty("SubjectName")]
        public Name SubjectName { get; set; }

        [JsonProperty("Thumbprint")]
        public string Thumbprint { get; set; }

        [JsonProperty("Version")]
        public long Version { get; set; }

        [JsonProperty("Handle")]
        public Handle Handle { get; set; }

        [JsonProperty("Issuer")]
        public string Issuer { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("SerialNumberBytes")]
        public RawDataMemory SerialNumberBytes { get; set; }
    }

    public partial class Extension
    {
        [JsonProperty("Critical")]
        public bool Critical { get; set; }

        [JsonProperty("Oid")]
        public SignatureAlgorithm Oid { get; set; }

        [JsonProperty("RawData")]
        public string RawData { get; set; }

        [JsonProperty("EnhancedKeyUsages", NullValueHandling = NullValueHandling.Ignore)]
        public SignatureAlgorithm[] EnhancedKeyUsages { get; set; }

        [JsonProperty("KeyUsages", NullValueHandling = NullValueHandling.Ignore)]
        public long? KeyUsages { get; set; }

        [JsonProperty("SubjectKeyIdentifier", NullValueHandling = NullValueHandling.Ignore)]
        public string SubjectKeyIdentifier { get; set; }

        [JsonProperty("SubjectKeyIdentifierBytes", NullValueHandling = NullValueHandling.Ignore)]
        public RawDataMemory SubjectKeyIdentifierBytes { get; set; }

        [JsonProperty("KeyIdentifier", NullValueHandling = NullValueHandling.Ignore)]
        public RawDataMemory KeyIdentifier { get; set; }

        [JsonProperty("NamedIssuer")]
        public object NamedIssuer { get; set; }

        [JsonProperty("RawIssuer")]
        public object RawIssuer { get; set; }

        [JsonProperty("SerialNumber")]
        public object SerialNumber { get; set; }
    }

    public partial class SignatureAlgorithm
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("FriendlyName")]
        public string FriendlyName { get; set; }
    }

    public partial class RawDataMemory
    {
        [JsonProperty("Length")]
        public long Length { get; set; }

        [JsonProperty("IsEmpty")]
        public bool IsEmpty { get; set; }
    }

    public partial class Handle
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("Name")]
        public string NameName { get; set; }

        [JsonProperty("Oid")]
        public SignatureAlgorithm Oid { get; set; }

        [JsonProperty("RawData")]
        public string RawData { get; set; }
    }

    public partial class PublicKey
    {
        [JsonProperty("EncodedKeyValue")]
        public Encoded EncodedKeyValue { get; set; }

        [JsonProperty("EncodedParameters")]
        public Encoded EncodedParameters { get; set; }

        [JsonProperty("Key")]
        public Key Key { get; set; }

        [JsonProperty("Oid")]
        public SignatureAlgorithm Oid { get; set; }
    }

    public partial class Encoded
    {
        [JsonProperty("Oid")]
        public SignatureAlgorithm Oid { get; set; }

        [JsonProperty("RawData")]
        public string RawData { get; set; }
    }

    public partial class Key
    {
        [JsonProperty("LegalKeySizes")]
        public LegalKeySize[] LegalKeySizes { get; set; }

        [JsonProperty("KeyExchangeAlgorithm")]
        public string KeyExchangeAlgorithm { get; set; }

        [JsonProperty("SignatureAlgorithm")]
        public string SignatureAlgorithm { get; set; }

        [JsonProperty("KeySize")]
        public long KeySize { get; set; }
    }

    public partial class LegalKeySize
    {
        [JsonProperty("MinSize")]
        public long MinSize { get; set; }

        [JsonProperty("MaxSize")]
        public long MaxSize { get; set; }

        [JsonProperty("SkipSize")]
        public long SkipSize { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("ContextType")]
        public long ContextType { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Container")]
        public object Container { get; set; }

        [JsonProperty("UserName")]
        public object UserName { get; set; }

        [JsonProperty("Options")]
        public long Options { get; set; }

        [JsonProperty("ConnectedServer")]
        public string ConnectedServer { get; set; }
    }

    public partial class Sid
    {
        [JsonProperty("BinaryLength")]
        public long BinaryLength { get; set; }

        [JsonProperty("AccountDomainSid")]
        public AccountDomainSid AccountDomainSid { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class AccountDomainSid
    {
        [JsonProperty("BinaryLength")]
        public long BinaryLength { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
