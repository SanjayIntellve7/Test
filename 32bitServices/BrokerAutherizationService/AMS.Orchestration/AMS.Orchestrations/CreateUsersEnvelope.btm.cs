namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse", typeof(global::AMS.Orchestrations.UsersService__x32020_ams.GetUsersListByAlertGroupResponse))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.CustomersListEnvelope", typeof(global::AMS.Orchestrations.CustomersListEnvelope))]
    public sealed class CreateUsersEnvelope : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 s1"" version=""1.0"" xmlns:ns0=""http://2020.AMS"" xmlns:s0=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" xmlns:ns1=""http://AMS.Orchestrations.CustomersListEnvelope"" xmlns:s1=""http://schemas.microsoft.com/2003/10/Serialization/"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/ns0:GetUsersListByAlertGroupResponse"" />
  </xsl:template>
  <xsl:template match=""/ns0:GetUsersListByAlertGroupResponse"">
    <ns1:Users>
      <xsl:for-each select=""ns0:GetUsersListByAlertGroupResult"">
        <xsl:for-each select=""s0:UsersCollection"">
          <xsl:for-each select=""s0:UserContactInformation"">
            <ns0:User>
              <xsl:if test=""s0:Username"">
                <Username>
                  <xsl:value-of select=""s0:Username/text()"" />
                </Username>
              </xsl:if>
              <ContactMethodsCollection>
                <xsl:for-each select=""s0:ContactMethodsCollection"">
                  <xsl:for-each select=""s0:ContactMethod"">
                    <ContactMethod>
                      <xsl:if test=""s0:Name"">
                        <xsl:attribute name=""Name"">
                          <xsl:value-of select=""s0:Name/text()"" />
                        </xsl:attribute>
                      </xsl:if>
                      <xsl:if test=""s0:Value"">
                        <xsl:attribute name=""Value"">
                          <xsl:value-of select=""s0:Value/text()"" />
                        </xsl:attribute>
                      </xsl:if>
                      <xsl:value-of select=""./text()"" />
                    </ContactMethod>
                  </xsl:for-each>
                </xsl:for-each>
              </ContactMethodsCollection>
              <xsl:value-of select=""./text()"" />
            </ns0:User>
          </xsl:for-each>
        </xsl:for-each>
      </xsl:for-each>
      <xsl:if test=""ns0:GetUsersListByAlertGroupResult/s0:UsersCollection"">
        <xsl:value-of select=""ns0:GetUsersListByAlertGroupResult/s0:UsersCollection/text()"" />
      </xsl:if>
    </ns1:Users>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse";
        
        private const string _strTrgSchemasList0 = @"AMS.Orchestrations.CustomersListEnvelope";
        
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
                _SrcSchemas[0] = @"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"AMS.Orchestrations.CustomersListEnvelope";
                return _TrgSchemas;
            }
        }
    }
}
