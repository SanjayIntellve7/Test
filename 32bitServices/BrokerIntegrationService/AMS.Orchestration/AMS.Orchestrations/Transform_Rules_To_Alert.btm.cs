namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.AlertStatus", typeof(global::AMS.Orchestrations.AlertStatus))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.Alert", typeof(global::AMS.Orchestrations.Alert))]
    public sealed class Transform_Rules_To_Alert : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var"" version=""1.0"" xmlns:ns0=""http://2020imaging.com/schema/BizTalk"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/ns0:AlertStatus"" />
  </xsl:template>
  <xsl:template match=""/ns0:AlertStatus"">
    <ns0:Alert>
      <ns0:Addresses>
        <xsl:value-of select=""Alert/ns0:Addresses/text()"" />
      </ns0:Addresses>
      <ns0:AlertId>
        <xsl:value-of select=""Alert/ns0:AlertId/text()"" />
      </ns0:AlertId>
      <ns0:AuthToken>
        <xsl:value-of select=""Alert/ns0:AuthToken/text()"" />
      </ns0:AuthToken>
      <ns0:Code>
        <xsl:value-of select=""Alert/ns0:Code/text()"" />
      </ns0:Code>
      <ns0:Identifier>
        <xsl:value-of select=""Alert/ns0:Identifier/text()"" />
      </ns0:Identifier>
      <ns0:Incidents>
        <xsl:value-of select=""Alert/ns0:Incidents/text()"" />
      </ns0:Incidents>
      <ns0:WorkflowStatus>
        <xsl:value-of select=""Status/text()"" />
      </ns0:WorkflowStatus>
      <ns0:WorkflowStatus>
        <xsl:value-of select=""Alert/ns0:WorkflowStatus/text()"" />
      </ns0:WorkflowStatus>
      <ns0:InfoCollection>
        <xsl:for-each select=""Alert/ns0:InfoCollection/ns0:Info"">
          <ns0:Info>
            <ns0:AlertId>
              <xsl:value-of select=""ns0:AlertId/text()"" />
            </ns0:AlertId>
            <ns0:AreasCollection>
              <xsl:for-each select=""ns0:AreasCollection/ns0:Area"">
                <ns0:Area>
                  <ns0:Altitude>
                    <xsl:value-of select=""ns0:Altitude/text()"" />
                  </ns0:Altitude>
                  <ns0:AreaId>
                    <xsl:value-of select=""ns0:AreaId/text()"" />
                  </ns0:AreaId>
                  <ns0:Celing>
                    <xsl:value-of select=""ns0:Celing/text()"" />
                  </ns0:Celing>
                  <ns0:Description>
                    <xsl:value-of select=""ns0:Description/text()"" />
                  </ns0:Description>
                  <ns0:InfoId>
                    <xsl:value-of select=""ns0:InfoId/text()"" />
                  </ns0:InfoId>
                  <ns0:Latitude>
                    <xsl:value-of select=""ns0:Latitude/text()"" />
                  </ns0:Latitude>
                  <ns0:Longitude>
                    <xsl:value-of select=""ns0:Longitude/text()"" />
                  </ns0:Longitude>
                  <xsl:value-of select=""./text()"" />
                </ns0:Area>
              </xsl:for-each>
              <xsl:value-of select=""ns0:AreasCollection/text()"" />
            </ns0:AreasCollection>
            <ns0:Audience>
              <xsl:value-of select=""ns0:Audience/text()"" />
            </ns0:Audience>
            <ns0:CategoriesCollection>
              <xsl:for-each select=""ns0:CategoriesCollection/ns0:Category"">
                <ns0:Category>
                  <xsl:value-of select=""./text()"" />
                </ns0:Category>
              </xsl:for-each>
              <xsl:value-of select=""ns0:CategoriesCollection/text()"" />
            </ns0:CategoriesCollection>
            <ns0:CertaintyId>
              <xsl:value-of select=""ns0:CertaintyId/text()"" />
            </ns0:CertaintyId>
            <ns0:Contact>
              <xsl:value-of select=""ns0:Contact/text()"" />
            </ns0:Contact>
            <ns0:Description>
              <xsl:value-of select=""ns0:Description/text()"" />
            </ns0:Description>
            <ns0:Effective>
              <xsl:value-of select=""ns0:Effective/text()"" />
            </ns0:Effective>
            <ns0:Event>
              <xsl:value-of select=""ns0:Event/text()"" />
            </ns0:Event>
            <ns0:EventCodesCollection>
              <xsl:for-each select=""ns0:EventCodesCollection/ns0:EventCode"">
                <ns0:EventCode>
                  <ns0:Key>
                    <xsl:value-of select=""ns0:Key/text()"" />
                  </ns0:Key>
                  <ns0:Value>
                    <xsl:value-of select=""ns0:Value/text()"" />
                  </ns0:Value>
                  <xsl:value-of select=""./text()"" />
                </ns0:EventCode>
              </xsl:for-each>
              <xsl:value-of select=""ns0:EventCodesCollection/text()"" />
            </ns0:EventCodesCollection>
            <ns0:Expires>
              <xsl:value-of select=""ns0:Expires/text()"" />
            </ns0:Expires>
            <ns0:Headline>
              <xsl:value-of select=""ns0:Headline/text()"" />
            </ns0:Headline>
            <ns0:InfoId>
              <xsl:value-of select=""ns0:InfoId/text()"" />
            </ns0:InfoId>
            <ns0:Instruction>
              <xsl:value-of select=""ns0:Instruction/text()"" />
            </ns0:Instruction>
            <ns0:Language>
              <xsl:value-of select=""ns0:Language/text()"" />
            </ns0:Language>
            <ns0:OnSet>
              <xsl:value-of select=""ns0:OnSet/text()"" />
            </ns0:OnSet>
            <ns0:ParametersCollection>
              <xsl:for-each select=""ns0:ParametersCollection/ns0:Parameter"">
                <ns0:Parameter>
                  <ns0:Key>
                    <xsl:value-of select=""ns0:Key/text()"" />
                  </ns0:Key>
                  <ns0:Value>
                    <xsl:value-of select=""ns0:Value/text()"" />
                  </ns0:Value>
                  <xsl:value-of select=""./text()"" />
                </ns0:Parameter>
              </xsl:for-each>
              <xsl:value-of select=""ns0:ParametersCollection/text()"" />
            </ns0:ParametersCollection>
            <ns0:ResourcesCollection>
              <xsl:for-each select=""ns0:ResourcesCollection/ns0:Resource"">
                <ns0:Resource>
                  <ns0:DerefUri>
                    <xsl:value-of select=""ns0:DerefUri/text()"" />
                  </ns0:DerefUri>
                  <ns0:Description>
                    <xsl:value-of select=""ns0:Description/text()"" />
                  </ns0:Description>
                  <ns0:Digest>
                    <xsl:value-of select=""ns0:Digest/text()"" />
                  </ns0:Digest>
                  <ns0:InfoId>
                    <xsl:value-of select=""ns0:InfoId/text()"" />
                  </ns0:InfoId>
                  <ns0:MimeType>
                    <xsl:value-of select=""ns0:MimeType/text()"" />
                  </ns0:MimeType>
                  <ns0:ResourceId>
                    <xsl:value-of select=""ns0:ResourceId/text()"" />
                  </ns0:ResourceId>
                  <ns0:Size>
                    <xsl:value-of select=""ns0:Size/text()"" />
                  </ns0:Size>
                  <ns0:Uri>
                    <xsl:value-of select=""ns0:Uri/text()"" />
                  </ns0:Uri>
                  <xsl:value-of select=""./text()"" />
                </ns0:Resource>
              </xsl:for-each>
              <xsl:value-of select=""ns0:ResourcesCollection/text()"" />
            </ns0:ResourcesCollection>
            <ns0:ResponseTypesCollection>
              <xsl:for-each select=""ns0:ResponseTypesCollection/ns0:ResponseType"">
                <ns0:ResponseType>
                  <xsl:value-of select=""./text()"" />
                </ns0:ResponseType>
              </xsl:for-each>
              <xsl:value-of select=""ns0:ResponseTypesCollection/text()"" />
            </ns0:ResponseTypesCollection>
            <ns0:SenderName>
              <xsl:value-of select=""ns0:SenderName/text()"" />
            </ns0:SenderName>
            <ns0:SeverityId>
              <xsl:value-of select=""ns0:SeverityId/text()"" />
            </ns0:SeverityId>
            <ns0:UrgencyId>
              <xsl:value-of select=""ns0:UrgencyId/text()"" />
            </ns0:UrgencyId>
            <ns0:Web>
              <xsl:value-of select=""ns0:Web/text()"" />
            </ns0:Web>
            <xsl:value-of select=""./text()"" />
          </ns0:Info>
        </xsl:for-each>
        <xsl:value-of select=""Alert/ns0:InfoCollection/text()"" />
      </ns0:InfoCollection>
      <ns0:MessageTypeId>
        <xsl:value-of select=""Alert/ns0:MessageTypeId/text()"" />
      </ns0:MessageTypeId>
      <ns0:Note>
        <xsl:value-of select=""Alert/ns0:Note/text()"" />
      </ns0:Note>
      <ns0:References>
        <xsl:value-of select=""Alert/ns0:References/text()"" />
      </ns0:References>
      <ns0:Restriction>
        <xsl:value-of select=""Alert/ns0:Restriction/text()"" />
      </ns0:Restriction>
      <ns0:ScopeId>
        <xsl:value-of select=""Alert/ns0:ScopeId/text()"" />
      </ns0:ScopeId>
      <ns0:Sender>
        <xsl:value-of select=""Alert/ns0:Sender/text()"" />
      </ns0:Sender>
      <ns0:SentAsString>
        <xsl:value-of select=""Alert/ns0:SentAsString/text()"" />
      </ns0:SentAsString>
      <ns0:Source>
        <xsl:value-of select=""Alert/ns0:Source/text()"" />
      </ns0:Source>
      <ns0:StatusId>
        <xsl:value-of select=""Alert/ns0:StatusId/text()"" />
      </ns0:StatusId>
    </ns0:Alert>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"AMS.Orchestrations.AlertStatus";
        
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
                _SrcSchemas[0] = @"AMS.Orchestrations.AlertStatus";
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
