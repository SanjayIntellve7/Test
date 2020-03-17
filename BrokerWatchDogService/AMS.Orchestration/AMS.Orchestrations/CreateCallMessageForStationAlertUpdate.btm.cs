namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.Alert", typeof(global::AMS.Orchestrations.Alert))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.StationsService.StationsService__x32020_ams+SentAlertToStation", typeof(global::AMS.Orchestrations.StationsService.StationsService__x32020_ams.SentAlertToStation))]
    public sealed class CreateCallMessageForStationAlertUpdate : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0"" version=""1.0"" xmlns:s0=""http://2020imaging.com/schema/BizTalk"" xmlns:ns0=""http://2020.AMS"" xmlns:ns1=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" xmlns:ns2=""http://schemas.microsoft.com/2003/10/Serialization/"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:Alert"" />
  </xsl:template>
  <xsl:template match=""/s0:Alert"">
    <ns0:SentAlertToStation>
      <ns0:alert>
        <ns1:Addresses>
          <xsl:value-of select=""s0:Addresses/text()"" />
        </ns1:Addresses>
        <ns1:AlertId>
          <xsl:value-of select=""s0:AlertId/text()"" />
        </ns1:AlertId>
        <ns1:AuthToken>
          <xsl:value-of select=""s0:AuthToken/text()"" />
        </ns1:AuthToken>
        <ns1:Code>
          <xsl:value-of select=""s0:Code/text()"" />
        </ns1:Code>
        <ns1:Identifier>
          <xsl:value-of select=""s0:Identifier/text()"" />
        </ns1:Identifier>
        <ns1:Incidents>
          <xsl:value-of select=""s0:Incidents/text()"" />
        </ns1:Incidents>
        <ns1:InfoCollection>
          <xsl:for-each select=""s0:InfoCollection/s0:Info"">
            <ns1:Info>
              <ns1:AlertId>
                <xsl:value-of select=""s0:AlertId/text()"" />
              </ns1:AlertId>
              <ns1:AreasCollection>
                <xsl:for-each select=""s0:AreasCollection/s0:Area"">
                  <ns1:Area>
                    <ns1:Altitude>
                      <xsl:value-of select=""s0:Altitude/text()"" />
                    </ns1:Altitude>
                    <ns1:AreaId>
                      <xsl:value-of select=""s0:AreaId/text()"" />
                    </ns1:AreaId>
                    <ns1:Celing>
                      <xsl:value-of select=""s0:Celing/text()"" />
                    </ns1:Celing>
                    <ns1:Description>
                      <xsl:value-of select=""s0:Description/text()"" />
                    </ns1:Description>
                    <ns1:InfoId>
                      <xsl:value-of select=""s0:InfoId/text()"" />
                    </ns1:InfoId>
                    <ns1:Latitude>
                      <xsl:value-of select=""s0:Latitude/text()"" />
                    </ns1:Latitude>
                    <ns1:Longitude>
                      <xsl:value-of select=""s0:Longitude/text()"" />
                    </ns1:Longitude>
                    <xsl:value-of select=""./text()"" />
                  </ns1:Area>
                </xsl:for-each>
                <xsl:value-of select=""s0:AreasCollection/text()"" />
              </ns1:AreasCollection>
              <ns1:Audience>
                <xsl:value-of select=""s0:Audience/text()"" />
              </ns1:Audience>
              <ns1:CategoriesCollection>
                <xsl:for-each select=""s0:CategoriesCollection/s0:Category"">
                  <ns1:Category>
                    <xsl:value-of select=""./text()"" />
                  </ns1:Category>
                </xsl:for-each>
                <xsl:value-of select=""s0:CategoriesCollection/text()"" />
              </ns1:CategoriesCollection>
              <ns1:CertaintyId>
                <xsl:value-of select=""s0:CertaintyId/text()"" />
              </ns1:CertaintyId>
              <ns1:Contact>
                <xsl:value-of select=""s0:Contact/text()"" />
              </ns1:Contact>
              <ns1:Description>
                <xsl:value-of select=""s0:Description/text()"" />
              </ns1:Description>
              <ns1:Effective>
                <xsl:value-of select=""s0:Effective/text()"" />
              </ns1:Effective>
              <ns1:Event>
                <xsl:value-of select=""s0:Event/text()"" />
              </ns1:Event>
              <ns1:EventCodesCollection>
                <xsl:for-each select=""s0:EventCodesCollection/s0:EventCode"">
                  <ns1:EventCode>
                    <ns1:Key>
                      <xsl:value-of select=""s0:Key/text()"" />
                    </ns1:Key>
                    <ns1:Value>
                      <xsl:value-of select=""s0:Value/text()"" />
                    </ns1:Value>
                    <xsl:value-of select=""./text()"" />
                  </ns1:EventCode>
                </xsl:for-each>
                <xsl:value-of select=""s0:EventCodesCollection/text()"" />
              </ns1:EventCodesCollection>
              <ns1:Expires>
                <xsl:value-of select=""s0:Expires/text()"" />
              </ns1:Expires>
              <ns1:Headline>
                <xsl:value-of select=""s0:Headline/text()"" />
              </ns1:Headline>
              <ns1:InfoId>
                <xsl:value-of select=""s0:InfoId/text()"" />
              </ns1:InfoId>
              <ns1:Instruction>
                <xsl:value-of select=""s0:Instruction/text()"" />
              </ns1:Instruction>
              <ns1:Language>
                <xsl:value-of select=""s0:Language/text()"" />
              </ns1:Language>
              <ns1:OnSet>
                <xsl:value-of select=""s0:OnSet/text()"" />
              </ns1:OnSet>
              <ns1:ParametersCollection>
                <xsl:for-each select=""s0:ParametersCollection/s0:Parameter"">
                  <ns1:Parameter>
                    <ns1:Key>
                      <xsl:value-of select=""s0:Key/text()"" />
                    </ns1:Key>
                    <ns1:Value>
                      <xsl:value-of select=""s0:Value/text()"" />
                    </ns1:Value>
                    <xsl:value-of select=""./text()"" />
                  </ns1:Parameter>
                </xsl:for-each>
                <xsl:value-of select=""s0:ParametersCollection/text()"" />
              </ns1:ParametersCollection>
              <ns1:ResourcesCollection>
                <xsl:for-each select=""s0:ResourcesCollection/s0:Resource"">
                  <ns1:Resource>
                    <ns1:DerefUri>
                      <xsl:value-of select=""s0:DerefUri/text()"" />
                    </ns1:DerefUri>
                    <ns1:Description>
                      <xsl:value-of select=""s0:Description/text()"" />
                    </ns1:Description>
                    <ns1:Digest>
                      <xsl:value-of select=""s0:Digest/text()"" />
                    </ns1:Digest>
                    <ns1:InfoId>
                      <xsl:value-of select=""s0:InfoId/text()"" />
                    </ns1:InfoId>
                    <ns1:MimeType>
                      <xsl:value-of select=""s0:MimeType/text()"" />
                    </ns1:MimeType>
                    <ns1:ResourceId>
                      <xsl:value-of select=""s0:ResourceId/text()"" />
                    </ns1:ResourceId>
                    <ns1:Size>
                      <xsl:value-of select=""s0:Size/text()"" />
                    </ns1:Size>
                    <ns1:Uri>
                      <xsl:value-of select=""s0:Uri/text()"" />
                    </ns1:Uri>
                    <xsl:value-of select=""./text()"" />
                  </ns1:Resource>
                </xsl:for-each>
                <xsl:value-of select=""s0:ResourcesCollection/text()"" />
              </ns1:ResourcesCollection>
              <ns1:ResponseTypesCollection>
                <xsl:for-each select=""s0:ResponseTypesCollection/s0:ResponseType"">
                  <ns1:ResponseType>
                    <xsl:value-of select=""./text()"" />
                  </ns1:ResponseType>
                </xsl:for-each>
                <xsl:value-of select=""s0:ResponseTypesCollection/text()"" />
              </ns1:ResponseTypesCollection>
              <ns1:SenderName>
                <xsl:value-of select=""s0:SenderName/text()"" />
              </ns1:SenderName>
              <ns1:SeverityId>
                <xsl:value-of select=""s0:SeverityId/text()"" />
              </ns1:SeverityId>
              <ns1:UrgencyId>
                <xsl:value-of select=""s0:UrgencyId/text()"" />
              </ns1:UrgencyId>
              <ns1:Web>
                <xsl:value-of select=""s0:Web/text()"" />
              </ns1:Web>
              <xsl:value-of select=""./text()"" />
            </ns1:Info>
          </xsl:for-each>
          <xsl:value-of select=""s0:InfoCollection/text()"" />
        </ns1:InfoCollection>
        <ns1:MessageTypeId>
          <xsl:value-of select=""s0:MessageTypeId/text()"" />
        </ns1:MessageTypeId>
        <ns1:Note>
          <xsl:value-of select=""s0:Note/text()"" />
        </ns1:Note>
        <ns1:References>
          <xsl:value-of select=""s0:References/text()"" />
        </ns1:References>
        <ns1:Restriction>
          <xsl:value-of select=""s0:Restriction/text()"" />
        </ns1:Restriction>
        <ns1:ScopeId>
          <xsl:value-of select=""s0:ScopeId/text()"" />
        </ns1:ScopeId>
        <ns1:Sender>
          <xsl:value-of select=""s0:Sender/text()"" />
        </ns1:Sender>
        <ns1:SentAsString>
          <xsl:value-of select=""s0:SentAsString/text()"" />
        </ns1:SentAsString>
        <ns1:Source>
          <xsl:value-of select=""s0:Source/text()"" />
        </ns1:Source>
        <ns1:StatusId>
          <xsl:value-of select=""s0:StatusId/text()"" />
        </ns1:StatusId>
        <ns1:WorkflowStatus>
          <xsl:value-of select=""s0:WorkflowStatus/text()"" />
        </ns1:WorkflowStatus>
      </ns0:alert>
    </ns0:SentAlertToStation>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.Alert";
        
        private const string _strTrgSchemasList0 = @"AMS.Orchestrations.StationsService.StationsService__x32020_ams+SentAlertToStation";
        
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
                _SrcSchemas[0] = @"AMS.Orchestrations.Alert";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"AMS.Orchestrations.StationsService.StationsService__x32020_ams+SentAlertToStation";
                return _TrgSchemas;
            }
        }
    }
}
