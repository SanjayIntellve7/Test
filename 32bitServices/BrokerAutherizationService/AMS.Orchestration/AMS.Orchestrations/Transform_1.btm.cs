namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse", typeof(global::AMS.Orchestrations.UsersService__x32020_ams.GetUsersListByAlertGroupResponse))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.NotifyListResponseEnvelope", typeof(global::AMS.Orchestrations.NotifyListResponseEnvelope))]
    public sealed class Transform_1 : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var"" version=""1.0"" xmlns:ns2=""http://AMS.Orchestrations.NotifyListResponseEnvelope"" xmlns:ns0=""http://2020.AMS"" xmlns:ns1=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" xmlns:ns3=""http://schemas.microsoft.com/2003/10/Serialization/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/ns0:GetUsersListByAlertGroupResponse"" />
  </xsl:template>
  <xsl:template match=""/ns0:GetUsersListByAlertGroupResponse"">
    <ns2:UsersCollection>
      <xsl:for-each select=""ns0:GetUsersListByAlertGroupResult"">
        <xsl:for-each select=""ns1:UsersCollection"">
          <xsl:for-each select=""ns1:UserContactInformation"">
            <ns1:UserContactInformation>
              <xsl:for-each select=""ns1:ContactMethodsCollection"">
                <ns1:ContactMethodsCollection>
                  <xsl:for-each select=""ns1:ContactMethod"">
                    <ns1:ContactMethod>
                      <xsl:if test=""ns1:Name"">
                        <xsl:variable name=""var:v1"" select=""string(ns1:Name/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v1)='true'"">
                          <ns1:Name>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Name>
                        </xsl:if>
                        <xsl:if test=""string($var:v1)='false'"">
                          <ns1:Name>
                            <xsl:value-of select=""ns1:Name/text()"" />
                          </ns1:Name>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:Value"">
                        <xsl:variable name=""var:v2"" select=""string(ns1:Value/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v2)='true'"">
                          <ns1:Value>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Value>
                        </xsl:if>
                        <xsl:if test=""string($var:v2)='false'"">
                          <ns1:Value>
                            <xsl:value-of select=""ns1:Value/text()"" />
                          </ns1:Value>
                        </xsl:if>
                      </xsl:if>
                      <xsl:value-of select=""./text()"" />
                    </ns1:ContactMethod>
                  </xsl:for-each>
                  <xsl:value-of select=""./text()"" />
                </ns1:ContactMethodsCollection>
              </xsl:for-each>
              <xsl:if test=""ns1:Username"">
                <xsl:variable name=""var:v3"" select=""string(ns1:Username/@xsi:nil) = 'true'"" />
                <xsl:if test=""string($var:v3)='true'"">
                  <ns1:Username>
                    <xsl:attribute name=""xsi:nil"">
                      <xsl:value-of select=""'true'"" />
                    </xsl:attribute>
                  </ns1:Username>
                </xsl:if>
                <xsl:if test=""string($var:v3)='false'"">
                  <ns1:Username>
                    <xsl:value-of select=""ns1:Username/text()"" />
                  </ns1:Username>
                </xsl:if>
              </xsl:if>
            </ns1:UserContactInformation>
          </xsl:for-each>
        </xsl:for-each>
      </xsl:for-each>
    </ns2:UsersCollection>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse";
        
        private const string _strTrgSchemasList0 = @"AMS.Orchestrations.NotifyListResponseEnvelope";
        
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
                _TrgSchemas[0] = @"AMS.Orchestrations.NotifyListResponseEnvelope";
                return _TrgSchemas;
            }
        }
    }
}
