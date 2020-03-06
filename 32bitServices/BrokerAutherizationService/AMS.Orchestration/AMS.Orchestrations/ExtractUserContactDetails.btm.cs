namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService.UsersService__x32020_ams+GetUsersListByAlertGroupResponse", typeof(global::AMS.Orchestrations.UsersService.UsersService__x32020_ams.GetUsersListByAlertGroupResponse))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.LoopCounter", typeof(global::AMS.Orchestrations.LoopCounter))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.User", typeof(global::AMS.Orchestrations.User))]
    public sealed class ExtractUserContactDetails : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s4 s2 s0 s1 s3"" version=""1.0"" xmlns:s4=""http://schemas.microsoft.com/2003/10/Serialization/"" xmlns:s2=""http://schemas.microsoft.com/BizTalk/2003/aggschema"" xmlns:s0=""http://2020.AMS"" xmlns:s1=""http://AMS.Orchestrations.LoopCounter"" xmlns:s3=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s2:Root"" />
  </xsl:template>
  <xsl:template match=""/s2:Root"">
    <xsl:variable name=""var:v1"" select=""InputMessagePart_1/s1:LoopCounter/Index/text()"" />
    <xsl:variable name=""var:v2"" select=""InputMessagePart_0/s0:GetUsersListByAlertGroupResponse/s0:GetUsersListByAlertGroupResult/s3:UsersCollection/s3:UserContactInformation[number($var:v1)]/s3:Username/text()"" />
    <User>
      <username>
        <xsl:value-of select=""$var:v2"" />
      </username>
    </User>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.UsersService.UsersService__x32020_ams+GetUsersListByAlertGroupResponse";
        
        private const string _strSrcSchemasList1 = @"AMS.Orchestrations.LoopCounter";
        
        private const string _strTrgSchemasList0 = @"AMS.Orchestrations.User";
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [2];
                _SrcSchemas[0] = @"AMS.Orchestrations.UsersService.UsersService__x32020_ams+GetUsersListByAlertGroupResponse";
                _SrcSchemas[1] = @"AMS.Orchestrations.LoopCounter";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"AMS.Orchestrations.User";
                return _TrgSchemas;
            }
        }
    }
}
