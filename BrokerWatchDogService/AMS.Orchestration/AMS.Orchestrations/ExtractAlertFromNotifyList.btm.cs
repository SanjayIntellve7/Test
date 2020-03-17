namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse", typeof(global::AMS.Orchestrations.UsersService__x32020_ams.GetUsersListByAlertGroupResponse))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.Alert", typeof(global::AMS.Orchestrations.Alert))]
    public sealed class ExtractAlertFromNotifyList : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s1 s0 s2"" version=""1.0"" xmlns:s2=""http://schemas.microsoft.com/2003/10/Serialization/"" xmlns:s1=""http://2020.AMS"" xmlns:ns0=""http://2020imaging.com/schema/BizTalk"" xmlns:s0=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s1:GetUsersListByAlertGroupResponse"" />
  </xsl:template>
  <xsl:template match=""/s1:GetUsersListByAlertGroupResponse"">
    <ns0:Alert>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Addresses"">
        <ns0:Addresses>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Addresses/text()"" />
        </ns0:Addresses>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:AlertId"">
        <ns0:AlertId>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:AlertId/text()"" />
        </ns0:AlertId>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:AuthToken"">
        <ns0:AuthToken>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:AuthToken/text()"" />
        </ns0:AuthToken>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Code"">
        <ns0:Code>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Code/text()"" />
        </ns0:Code>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Identifier"">
        <ns0:Identifier>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Identifier/text()"" />
        </ns0:Identifier>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Incidents"">
        <ns0:Incidents>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Incidents/text()"" />
        </ns0:Incidents>
      </xsl:if>
      <xsl:for-each select=""s1:GetUsersListByAlertGroupResult"">
        <xsl:for-each select=""s0:Alert"">
          <ns0:InfoCollection>
            <ns0:Info>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:AlertId"">
                <ns0:AlertId>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:AlertId/text()"" />
                </ns0:AlertId>
              </xsl:if>
              <xsl:for-each select=""s0:InfoCollection/s0:Info/s0:AreasCollection"">
                <ns0:AreasCollection>
                  <ns0:Area>
                    <xsl:if test=""s0:Area/s0:Altitude"">
                      <ns0:Altitude>
                        <xsl:value-of select=""s0:Area/s0:Altitude/text()"" />
                      </ns0:Altitude>
                    </xsl:if>
                    <xsl:if test=""s0:Area/s0:AreaId"">
                      <ns0:AreaId>
                        <xsl:value-of select=""s0:Area/s0:AreaId/text()"" />
                      </ns0:AreaId>
                    </xsl:if>
                    <xsl:if test=""s0:Area/s0:Celing"">
                      <ns0:Celing>
                        <xsl:value-of select=""s0:Area/s0:Celing/text()"" />
                      </ns0:Celing>
                    </xsl:if>
                    <xsl:if test=""s0:Area/s0:Description"">
                      <ns0:Description>
                        <xsl:value-of select=""s0:Area/s0:Description/text()"" />
                      </ns0:Description>
                    </xsl:if>
                    <xsl:if test=""s0:Area/s0:InfoId"">
                      <ns0:InfoId>
                        <xsl:value-of select=""s0:Area/s0:InfoId/text()"" />
                      </ns0:InfoId>
                    </xsl:if>
                    <xsl:if test=""s0:Area/s0:Latitude"">
                      <ns0:Latitude>
                        <xsl:value-of select=""s0:Area/s0:Latitude/text()"" />
                      </ns0:Latitude>
                    </xsl:if>
                    <xsl:if test=""s0:Area/s0:Longitude"">
                      <ns0:Longitude>
                        <xsl:value-of select=""s0:Area/s0:Longitude/text()"" />
                      </ns0:Longitude>
                    </xsl:if>
                    <xsl:value-of select=""s0:Area/text()"" />
                  </ns0:Area>
                  <xsl:value-of select=""./text()"" />
                </ns0:AreasCollection>
              </xsl:for-each>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Audience"">
                <ns0:Audience>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Audience/text()"" />
                </ns0:Audience>
              </xsl:if>
              <xsl:for-each select=""s0:InfoCollection/s0:Info/s0:CategoriesCollection"">
                <ns0:CategoriesCollection>
                  <xsl:for-each select=""s0:Category"">
                    <ns0:Category>
                      <xsl:value-of select=""./text()"" />
                    </ns0:Category>
                  </xsl:for-each>
                  <xsl:value-of select=""./text()"" />
                </ns0:CategoriesCollection>
              </xsl:for-each>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:CertaintyId"">
                <ns0:CertaintyId>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:CertaintyId/text()"" />
                </ns0:CertaintyId>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Contact"">
                <ns0:Contact>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Contact/text()"" />
                </ns0:Contact>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Description"">
                <ns0:Description>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Description/text()"" />
                </ns0:Description>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Effective"">
                <ns0:Effective>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Effective/text()"" />
                </ns0:Effective>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Event"">
                <ns0:Event>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Event/text()"" />
                </ns0:Event>
              </xsl:if>
              <xsl:for-each select=""s0:InfoCollection/s0:Info/s0:EventCodesCollection"">
                <ns0:EventCodesCollection>
                  <xsl:for-each select=""s0:EventCode"">
                    <ns0:EventCode>
                      <xsl:if test=""s0:Key"">
                        <ns0:Key>
                          <xsl:value-of select=""s0:Key/text()"" />
                        </ns0:Key>
                      </xsl:if>
                      <xsl:if test=""s0:Value"">
                        <ns0:Value>
                          <xsl:value-of select=""s0:Value/text()"" />
                        </ns0:Value>
                      </xsl:if>
                      <xsl:value-of select=""./text()"" />
                    </ns0:EventCode>
                  </xsl:for-each>
                  <xsl:value-of select=""./text()"" />
                </ns0:EventCodesCollection>
              </xsl:for-each>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Expires"">
                <ns0:Expires>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Expires/text()"" />
                </ns0:Expires>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Headline"">
                <ns0:Headline>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Headline/text()"" />
                </ns0:Headline>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:InfoId"">
                <ns0:InfoId>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:InfoId/text()"" />
                </ns0:InfoId>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Instruction"">
                <ns0:Instruction>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Instruction/text()"" />
                </ns0:Instruction>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Language"">
                <ns0:Language>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Language/text()"" />
                </ns0:Language>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:OnSet"">
                <ns0:OnSet>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:OnSet/text()"" />
                </ns0:OnSet>
              </xsl:if>
              <xsl:for-each select=""s0:InfoCollection/s0:Info/s0:ParametersCollection"">
                <ns0:ParametersCollection>
                  <xsl:for-each select=""s0:Parameter"">
                    <ns0:Parameter>
                      <xsl:if test=""s0:Key"">
                        <ns0:Key>
                          <xsl:value-of select=""s0:Key/text()"" />
                        </ns0:Key>
                      </xsl:if>
                      <xsl:if test=""s0:Value"">
                        <ns0:Value>
                          <xsl:value-of select=""s0:Value/text()"" />
                        </ns0:Value>
                      </xsl:if>
                      <xsl:value-of select=""./text()"" />
                    </ns0:Parameter>
                  </xsl:for-each>
                  <xsl:value-of select=""./text()"" />
                </ns0:ParametersCollection>
              </xsl:for-each>
              <xsl:for-each select=""s0:InfoCollection/s0:Info/s0:ResourcesCollection"">
                <ns0:ResourcesCollection>
                  <xsl:for-each select=""s0:Resource"">
                    <ns0:Resource>
                      <xsl:if test=""s0:DerefUri"">
                        <ns0:DerefUri>
                          <xsl:value-of select=""s0:DerefUri/text()"" />
                        </ns0:DerefUri>
                      </xsl:if>
                      <xsl:if test=""s0:Description"">
                        <ns0:Description>
                          <xsl:value-of select=""s0:Description/text()"" />
                        </ns0:Description>
                      </xsl:if>
                      <xsl:if test=""s0:Digest"">
                        <ns0:Digest>
                          <xsl:value-of select=""s0:Digest/text()"" />
                        </ns0:Digest>
                      </xsl:if>
                      <xsl:if test=""s0:InfoId"">
                        <ns0:InfoId>
                          <xsl:value-of select=""s0:InfoId/text()"" />
                        </ns0:InfoId>
                      </xsl:if>
                      <xsl:if test=""s0:MimeType"">
                        <ns0:MimeType>
                          <xsl:value-of select=""s0:MimeType/text()"" />
                        </ns0:MimeType>
                      </xsl:if>
                      <xsl:if test=""s0:ResourceId"">
                        <ns0:ResourceId>
                          <xsl:value-of select=""s0:ResourceId/text()"" />
                        </ns0:ResourceId>
                      </xsl:if>
                      <xsl:if test=""s0:Size"">
                        <ns0:Size>
                          <xsl:value-of select=""s0:Size/text()"" />
                        </ns0:Size>
                      </xsl:if>
                      <xsl:if test=""s0:Uri"">
                        <ns0:Uri>
                          <xsl:value-of select=""s0:Uri/text()"" />
                        </ns0:Uri>
                      </xsl:if>
                      <xsl:value-of select=""./text()"" />
                    </ns0:Resource>
                  </xsl:for-each>
                  <xsl:value-of select=""./text()"" />
                </ns0:ResourcesCollection>
              </xsl:for-each>
              <xsl:for-each select=""s0:InfoCollection/s0:Info/s0:ResponseTypesCollection"">
                <ns0:ResponseTypesCollection>
                  <xsl:for-each select=""s0:ResponseType"">
                    <ns0:ResponseType>
                      <xsl:value-of select=""./text()"" />
                    </ns0:ResponseType>
                  </xsl:for-each>
                  <xsl:value-of select=""./text()"" />
                </ns0:ResponseTypesCollection>
              </xsl:for-each>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:SenderName"">
                <ns0:SenderName>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:SenderName/text()"" />
                </ns0:SenderName>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:SeverityId"">
                <ns0:SeverityId>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:SeverityId/text()"" />
                </ns0:SeverityId>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:UrgencyId"">
                <ns0:UrgencyId>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:UrgencyId/text()"" />
                </ns0:UrgencyId>
              </xsl:if>
              <xsl:if test=""s0:InfoCollection/s0:Info/s0:Web"">
                <ns0:Web>
                  <xsl:value-of select=""s0:InfoCollection/s0:Info/s0:Web/text()"" />
                </ns0:Web>
              </xsl:if>
              <xsl:value-of select=""s0:InfoCollection/s0:Info/text()"" />
            </ns0:Info>
            <xsl:value-of select=""s0:InfoCollection/text()"" />
          </ns0:InfoCollection>
        </xsl:for-each>
      </xsl:for-each>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:MessageTypeId"">
        <ns0:MessageTypeId>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:MessageTypeId/text()"" />
        </ns0:MessageTypeId>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Note"">
        <ns0:Note>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Note/text()"" />
        </ns0:Note>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:References"">
        <ns0:References>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:References/text()"" />
        </ns0:References>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Restriction"">
        <ns0:Restriction>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Restriction/text()"" />
        </ns0:Restriction>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:ScopeId"">
        <ns0:ScopeId>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:ScopeId/text()"" />
        </ns0:ScopeId>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Sender"">
        <ns0:Sender>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Sender/text()"" />
        </ns0:Sender>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:SentAsString"">
        <ns0:SentAsString>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:SentAsString/text()"" />
        </ns0:SentAsString>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Source"">
        <ns0:Source>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:Source/text()"" />
        </ns0:Source>
      </xsl:if>
      <xsl:if test=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:StatusId"">
        <ns0:StatusId>
          <xsl:value-of select=""s1:GetUsersListByAlertGroupResult/s0:Alert/s0:StatusId/text()"" />
        </ns0:StatusId>
      </xsl:if>
    </ns0:Alert>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse";
        
        private const string _strTrgSchemasList0 = @"AMS.Orchestrations.Alert";
        
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
                _TrgSchemas[0] = @"AMS.Orchestrations.Alert";
                return _TrgSchemas;
            }
        }
    }
}
