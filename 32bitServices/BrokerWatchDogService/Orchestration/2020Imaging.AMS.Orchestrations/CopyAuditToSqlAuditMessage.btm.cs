namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.Audit", typeof(global::AMS.Orchestrations.Audit))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.SQLService_BizTalk+AuditRequest", typeof(global::AMS.Orchestrations.SQLService_BizTalk.AuditRequest))]
    public sealed class Transform_1 : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0"" version=""1.0"" xmlns:ns0=""http://2020imaging.com/schema/BizTalk"" xmlns:s0=""http://AMS.Orchestrations.Audit"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:Audit"" />
  </xsl:template>
  <xsl:template match=""/s0:Audit"">
    <ns0:AuditRequest>
      <ns0:UpdateAudit>
        <xsl:attribute name=""ActivityDateTime"">
          <xsl:value-of select=""ActivityDateTime/text()"" />
        </xsl:attribute>
        <xsl:attribute name=""AuditType"">
          <xsl:value-of select=""Type/text()"" />
        </xsl:attribute>
        <xsl:attribute name=""Description"">
          <xsl:value-of select=""Description/text()"" />
        </xsl:attribute>
        <xsl:attribute name=""SourceId"">
          <xsl:value-of select=""SourceId/text()"" />
        </xsl:attribute>
        <xsl:attribute name=""SourceType"">
          <xsl:value-of select=""SourceType/text()"" />
        </xsl:attribute>
        <xsl:attribute name=""UserId"">
          <xsl:value-of select=""UserId/text()"" />
        </xsl:attribute>
      </ns0:UpdateAudit>
    </ns0:AuditRequest>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.Audit";
        
        private const string _strTrgSchemasList0 = @"AMS.Orchestrations.SQLService_BizTalk+AuditRequest";
        
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
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"AMS.Orchestrations.Audit";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"AMS.Orchestrations.SQLService_BizTalk+AuditRequest";
                return _TrgSchemas;
            }
        }
    }
}
