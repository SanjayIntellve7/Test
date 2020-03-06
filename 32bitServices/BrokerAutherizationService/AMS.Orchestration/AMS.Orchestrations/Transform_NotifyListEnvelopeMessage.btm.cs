namespace AMS.Orchestrations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService__x32020_ams+GetUsersListByAlertGroupResponse", typeof(global::AMS.Orchestrations.UsersService__x32020_ams.GetUsersListByAlertGroupResponse))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.NotifyListResponseEnvelope", typeof(global::AMS.Orchestrations.NotifyListResponseEnvelope))]
    public sealed class Transform_NotifyListEnvelopeMessage : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
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
              <xsl:for-each select=""ns1:Alert"">
                <ns1:Alert>
                  <xsl:if test=""ns1:Addresses"">
                    <xsl:variable name=""var:v1"" select=""string(ns1:Addresses/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v1)='true'"">
                      <ns1:Addresses>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Addresses>
                    </xsl:if>
                    <xsl:if test=""string($var:v1)='false'"">
                      <ns1:Addresses>
                        <xsl:value-of select=""ns1:Addresses/text()"" />
                      </ns1:Addresses>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:AlertId"">
                    <ns1:AlertId>
                      <xsl:value-of select=""ns1:AlertId/text()"" />
                    </ns1:AlertId>
                  </xsl:if>
                  <xsl:if test=""ns1:AuthToken"">
                    <ns1:AuthToken>
                      <xsl:value-of select=""ns1:AuthToken/text()"" />
                    </ns1:AuthToken>
                  </xsl:if>
                  <xsl:if test=""ns1:Code"">
                    <xsl:variable name=""var:v2"" select=""string(ns1:Code/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v2)='true'"">
                      <ns1:Code>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Code>
                    </xsl:if>
                    <xsl:if test=""string($var:v2)='false'"">
                      <ns1:Code>
                        <xsl:value-of select=""ns1:Code/text()"" />
                      </ns1:Code>
                    </xsl:if>
                  </xsl:if>
                  <xsl:for-each select=""ns1:Device"">
                    <ns1:Device>
                      <xsl:if test=""ns1:Altitude"">
                        <ns1:Altitude>
                          <xsl:value-of select=""ns1:Altitude/text()"" />
                        </ns1:Altitude>
                      </xsl:if>
                      <xsl:if test=""ns1:CameraGUID"">
                        <xsl:variable name=""var:v3"" select=""string(ns1:CameraGUID/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v3)='true'"">
                          <ns1:CameraGUID>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:CameraGUID>
                        </xsl:if>
                        <xsl:if test=""string($var:v3)='false'"">
                          <ns1:CameraGUID>
                            <xsl:value-of select=""ns1:CameraGUID/text()"" />
                          </ns1:CameraGUID>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:Description"">
                        <xsl:variable name=""var:v4"" select=""string(ns1:Description/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v4)='true'"">
                          <ns1:Description>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Description>
                        </xsl:if>
                        <xsl:if test=""string($var:v4)='false'"">
                          <ns1:Description>
                            <xsl:value-of select=""ns1:Description/text()"" />
                          </ns1:Description>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:DeviceId"">
                        <ns1:DeviceId>
                          <xsl:value-of select=""ns1:DeviceId/text()"" />
                        </ns1:DeviceId>
                      </xsl:if>
                      <xsl:if test=""ns1:Lat"">
                        <ns1:Lat>
                          <xsl:value-of select=""ns1:Lat/text()"" />
                        </ns1:Lat>
                      </xsl:if>
                      <xsl:if test=""ns1:LocationDescription"">
                        <xsl:variable name=""var:v5"" select=""string(ns1:LocationDescription/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v5)='true'"">
                          <ns1:LocationDescription>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:LocationDescription>
                        </xsl:if>
                        <xsl:if test=""string($var:v5)='false'"">
                          <ns1:LocationDescription>
                            <xsl:value-of select=""ns1:LocationDescription/text()"" />
                          </ns1:LocationDescription>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:Long"">
                        <ns1:Long>
                          <xsl:value-of select=""ns1:Long/text()"" />
                        </ns1:Long>
                      </xsl:if>
                      <xsl:if test=""ns1:Metadata"">
                        <xsl:variable name=""var:v6"" select=""string(ns1:Metadata/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v6)='true'"">
                          <ns1:Metadata>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Metadata>
                        </xsl:if>
                        <xsl:if test=""string($var:v6)='false'"">
                          <ns1:Metadata>
                            <xsl:value-of select=""ns1:Metadata/text()"" />
                          </ns1:Metadata>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:Type"">
                        <xsl:variable name=""var:v7"" select=""string(ns1:Type/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v7)='true'"">
                          <ns1:Type>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Type>
                        </xsl:if>
                        <xsl:if test=""string($var:v7)='false'"">
                          <ns1:Type>
                            <xsl:value-of select=""ns1:Type/text()"" />
                          </ns1:Type>
                        </xsl:if>
                      </xsl:if>
                      <xsl:value-of select=""./text()"" />
                    </ns1:Device>
                  </xsl:for-each>
                  <xsl:if test=""ns1:Identifier"">
                    <xsl:variable name=""var:v8"" select=""string(ns1:Identifier/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v8)='true'"">
                      <ns1:Identifier>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Identifier>
                    </xsl:if>
                    <xsl:if test=""string($var:v8)='false'"">
                      <ns1:Identifier>
                        <xsl:value-of select=""ns1:Identifier/text()"" />
                      </ns1:Identifier>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:Incidents"">
                    <xsl:variable name=""var:v9"" select=""string(ns1:Incidents/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v9)='true'"">
                      <ns1:Incidents>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Incidents>
                    </xsl:if>
                    <xsl:if test=""string($var:v9)='false'"">
                      <ns1:Incidents>
                        <xsl:value-of select=""ns1:Incidents/text()"" />
                      </ns1:Incidents>
                    </xsl:if>
                  </xsl:if>
                  <ns1:InfoCollection>
                    <ns1:Info>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:AlertId"">
                        <xsl:variable name=""var:v10"" select=""string(ns1:InfoCollection/ns1:Info/ns1:AlertId/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v10)='true'"">
                          <ns1:AlertId>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:AlertId>
                        </xsl:if>
                        <xsl:if test=""string($var:v10)='false'"">
                          <ns1:AlertId>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:AlertId/text()"" />
                          </ns1:AlertId>
                        </xsl:if>
                      </xsl:if>
                      <xsl:for-each select=""ns1:InfoCollection/ns1:Info/ns1:AreasCollection"">
                        <ns1:AreasCollection>
                          <ns1:Area>
                            <xsl:if test=""ns1:Area/ns1:Altitude"">
                              <xsl:variable name=""var:v11"" select=""string(ns1:Area/ns1:Altitude/@xsi:nil) = 'true'"" />
                              <xsl:if test=""string($var:v11)='true'"">
                                <ns1:Altitude>
                                  <xsl:attribute name=""xsi:nil"">
                                    <xsl:value-of select=""'true'"" />
                                  </xsl:attribute>
                                </ns1:Altitude>
                              </xsl:if>
                              <xsl:if test=""string($var:v11)='false'"">
                                <ns1:Altitude>
                                  <xsl:value-of select=""ns1:Area/ns1:Altitude/text()"" />
                                </ns1:Altitude>
                              </xsl:if>
                            </xsl:if>
                            <xsl:if test=""ns1:Area/ns1:AreaId"">
                              <ns1:AreaId>
                                <xsl:value-of select=""ns1:Area/ns1:AreaId/text()"" />
                              </ns1:AreaId>
                            </xsl:if>
                            <xsl:if test=""ns1:Area/ns1:Celing"">
                              <xsl:variable name=""var:v12"" select=""string(ns1:Area/ns1:Celing/@xsi:nil) = 'true'"" />
                              <xsl:if test=""string($var:v12)='true'"">
                                <ns1:Celing>
                                  <xsl:attribute name=""xsi:nil"">
                                    <xsl:value-of select=""'true'"" />
                                  </xsl:attribute>
                                </ns1:Celing>
                              </xsl:if>
                              <xsl:if test=""string($var:v12)='false'"">
                                <ns1:Celing>
                                  <xsl:value-of select=""ns1:Area/ns1:Celing/text()"" />
                                </ns1:Celing>
                              </xsl:if>
                            </xsl:if>
                            <xsl:if test=""ns1:Area/ns1:Description"">
                              <xsl:variable name=""var:v13"" select=""string(ns1:Area/ns1:Description/@xsi:nil) = 'true'"" />
                              <xsl:if test=""string($var:v13)='true'"">
                                <ns1:Description>
                                  <xsl:attribute name=""xsi:nil"">
                                    <xsl:value-of select=""'true'"" />
                                  </xsl:attribute>
                                </ns1:Description>
                              </xsl:if>
                              <xsl:if test=""string($var:v13)='false'"">
                                <ns1:Description>
                                  <xsl:value-of select=""ns1:Area/ns1:Description/text()"" />
                                </ns1:Description>
                              </xsl:if>
                            </xsl:if>
                            <xsl:if test=""ns1:Area/ns1:InfoId"">
                              <ns1:InfoId>
                                <xsl:value-of select=""ns1:Area/ns1:InfoId/text()"" />
                              </ns1:InfoId>
                            </xsl:if>
                            <xsl:if test=""ns1:Area/ns1:Latitude"">
                              <xsl:variable name=""var:v14"" select=""string(ns1:Area/ns1:Latitude/@xsi:nil) = 'true'"" />
                              <xsl:if test=""string($var:v14)='true'"">
                                <ns1:Latitude>
                                  <xsl:attribute name=""xsi:nil"">
                                    <xsl:value-of select=""'true'"" />
                                  </xsl:attribute>
                                </ns1:Latitude>
                              </xsl:if>
                              <xsl:if test=""string($var:v14)='false'"">
                                <ns1:Latitude>
                                  <xsl:value-of select=""ns1:Area/ns1:Latitude/text()"" />
                                </ns1:Latitude>
                              </xsl:if>
                            </xsl:if>
                            <xsl:if test=""ns1:Area/ns1:Longitude"">
                              <xsl:variable name=""var:v15"" select=""string(ns1:Area/ns1:Longitude/@xsi:nil) = 'true'"" />
                              <xsl:if test=""string($var:v15)='true'"">
                                <ns1:Longitude>
                                  <xsl:attribute name=""xsi:nil"">
                                    <xsl:value-of select=""'true'"" />
                                  </xsl:attribute>
                                </ns1:Longitude>
                              </xsl:if>
                              <xsl:if test=""string($var:v15)='false'"">
                                <ns1:Longitude>
                                  <xsl:value-of select=""ns1:Area/ns1:Longitude/text()"" />
                                </ns1:Longitude>
                              </xsl:if>
                            </xsl:if>
                            <xsl:value-of select=""ns1:Area/text()"" />
                          </ns1:Area>
                          <xsl:value-of select=""./text()"" />
                        </ns1:AreasCollection>
                      </xsl:for-each>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Audience"">
                        <xsl:variable name=""var:v16"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Audience/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v16)='true'"">
                          <ns1:Audience>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Audience>
                        </xsl:if>
                        <xsl:if test=""string($var:v16)='false'"">
                          <ns1:Audience>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Audience/text()"" />
                          </ns1:Audience>
                        </xsl:if>
                      </xsl:if>
                      <xsl:for-each select=""ns1:InfoCollection/ns1:Info/ns1:CategoriesCollection"">
                        <ns1:CategoriesCollection>
                          <xsl:for-each select=""ns1:Category"">
                            <ns1:Category>
                              <xsl:value-of select=""./text()"" />
                            </ns1:Category>
                          </xsl:for-each>
                          <xsl:value-of select=""./text()"" />
                        </ns1:CategoriesCollection>
                      </xsl:for-each>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:CertaintyId"">
                        <ns1:CertaintyId>
                          <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:CertaintyId/text()"" />
                        </ns1:CertaintyId>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Contact"">
                        <xsl:variable name=""var:v17"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Contact/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v17)='true'"">
                          <ns1:Contact>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Contact>
                        </xsl:if>
                        <xsl:if test=""string($var:v17)='false'"">
                          <ns1:Contact>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Contact/text()"" />
                          </ns1:Contact>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Description"">
                        <xsl:variable name=""var:v18"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Description/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v18)='true'"">
                          <ns1:Description>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Description>
                        </xsl:if>
                        <xsl:if test=""string($var:v18)='false'"">
                          <ns1:Description>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Description/text()"" />
                          </ns1:Description>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Effective"">
                        <xsl:variable name=""var:v19"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Effective/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v19)='true'"">
                          <ns1:Effective>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Effective>
                        </xsl:if>
                        <xsl:if test=""string($var:v19)='false'"">
                          <ns1:Effective>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Effective/text()"" />
                          </ns1:Effective>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Event"">
                        <xsl:variable name=""var:v20"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Event/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v20)='true'"">
                          <ns1:Event>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Event>
                        </xsl:if>
                        <xsl:if test=""string($var:v20)='false'"">
                          <ns1:Event>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Event/text()"" />
                          </ns1:Event>
                        </xsl:if>
                      </xsl:if>
                      <xsl:for-each select=""ns1:InfoCollection/ns1:Info/ns1:EventCodesCollection"">
                        <ns1:EventCodesCollection>
                          <xsl:for-each select=""ns1:EventCode"">
                            <ns1:EventCode>
                              <xsl:if test=""ns1:Key"">
                                <xsl:variable name=""var:v21"" select=""string(ns1:Key/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v21)='true'"">
                                  <ns1:Key>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Key>
                                </xsl:if>
                                <xsl:if test=""string($var:v21)='false'"">
                                  <ns1:Key>
                                    <xsl:value-of select=""ns1:Key/text()"" />
                                  </ns1:Key>
                                </xsl:if>
                              </xsl:if>
                              <xsl:if test=""ns1:Value"">
                                <xsl:variable name=""var:v22"" select=""string(ns1:Value/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v22)='true'"">
                                  <ns1:Value>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Value>
                                </xsl:if>
                                <xsl:if test=""string($var:v22)='false'"">
                                  <ns1:Value>
                                    <xsl:value-of select=""ns1:Value/text()"" />
                                  </ns1:Value>
                                </xsl:if>
                              </xsl:if>
                              <xsl:value-of select=""./text()"" />
                            </ns1:EventCode>
                          </xsl:for-each>
                          <xsl:value-of select=""./text()"" />
                        </ns1:EventCodesCollection>
                      </xsl:for-each>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Expires"">
                        <xsl:variable name=""var:v23"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Expires/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v23)='true'"">
                          <ns1:Expires>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Expires>
                        </xsl:if>
                        <xsl:if test=""string($var:v23)='false'"">
                          <ns1:Expires>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Expires/text()"" />
                          </ns1:Expires>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Headline"">
                        <xsl:variable name=""var:v24"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Headline/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v24)='true'"">
                          <ns1:Headline>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Headline>
                        </xsl:if>
                        <xsl:if test=""string($var:v24)='false'"">
                          <ns1:Headline>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Headline/text()"" />
                          </ns1:Headline>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:InfoId"">
                        <ns1:InfoId>
                          <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:InfoId/text()"" />
                        </ns1:InfoId>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Instruction"">
                        <xsl:variable name=""var:v25"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Instruction/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v25)='true'"">
                          <ns1:Instruction>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Instruction>
                        </xsl:if>
                        <xsl:if test=""string($var:v25)='false'"">
                          <ns1:Instruction>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Instruction/text()"" />
                          </ns1:Instruction>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Language"">
                        <xsl:variable name=""var:v26"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Language/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v26)='true'"">
                          <ns1:Language>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Language>
                        </xsl:if>
                        <xsl:if test=""string($var:v26)='false'"">
                          <ns1:Language>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Language/text()"" />
                          </ns1:Language>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:OnSet"">
                        <xsl:variable name=""var:v27"" select=""string(ns1:InfoCollection/ns1:Info/ns1:OnSet/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v27)='true'"">
                          <ns1:OnSet>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:OnSet>
                        </xsl:if>
                        <xsl:if test=""string($var:v27)='false'"">
                          <ns1:OnSet>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:OnSet/text()"" />
                          </ns1:OnSet>
                        </xsl:if>
                      </xsl:if>
                      <xsl:for-each select=""ns1:InfoCollection/ns1:Info/ns1:ParametersCollection"">
                        <ns1:ParametersCollection>
                          <xsl:for-each select=""ns1:Parameter"">
                            <ns1:Parameter>
                              <xsl:if test=""ns1:Key"">
                                <xsl:variable name=""var:v28"" select=""string(ns1:Key/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v28)='true'"">
                                  <ns1:Key>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Key>
                                </xsl:if>
                                <xsl:if test=""string($var:v28)='false'"">
                                  <ns1:Key>
                                    <xsl:value-of select=""ns1:Key/text()"" />
                                  </ns1:Key>
                                </xsl:if>
                              </xsl:if>
                              <xsl:if test=""ns1:Value"">
                                <xsl:variable name=""var:v29"" select=""string(ns1:Value/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v29)='true'"">
                                  <ns1:Value>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Value>
                                </xsl:if>
                                <xsl:if test=""string($var:v29)='false'"">
                                  <ns1:Value>
                                    <xsl:value-of select=""ns1:Value/text()"" />
                                  </ns1:Value>
                                </xsl:if>
                              </xsl:if>
                              <xsl:value-of select=""./text()"" />
                            </ns1:Parameter>
                          </xsl:for-each>
                          <xsl:value-of select=""./text()"" />
                        </ns1:ParametersCollection>
                      </xsl:for-each>
                      <xsl:for-each select=""ns1:InfoCollection/ns1:Info/ns1:ResourcesCollection"">
                        <ns1:ResourcesCollection>
                          <xsl:for-each select=""ns1:Resource"">
                            <ns1:Resource>
                              <xsl:if test=""ns1:DerefUri"">
                                <xsl:variable name=""var:v30"" select=""string(ns1:DerefUri/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v30)='true'"">
                                  <ns1:DerefUri>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:DerefUri>
                                </xsl:if>
                                <xsl:if test=""string($var:v30)='false'"">
                                  <ns1:DerefUri>
                                    <xsl:value-of select=""ns1:DerefUri/text()"" />
                                  </ns1:DerefUri>
                                </xsl:if>
                              </xsl:if>
                              <xsl:if test=""ns1:Description"">
                                <xsl:variable name=""var:v31"" select=""string(ns1:Description/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v31)='true'"">
                                  <ns1:Description>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Description>
                                </xsl:if>
                                <xsl:if test=""string($var:v31)='false'"">
                                  <ns1:Description>
                                    <xsl:value-of select=""ns1:Description/text()"" />
                                  </ns1:Description>
                                </xsl:if>
                              </xsl:if>
                              <xsl:if test=""ns1:Digest"">
                                <xsl:variable name=""var:v32"" select=""string(ns1:Digest/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v32)='true'"">
                                  <ns1:Digest>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Digest>
                                </xsl:if>
                                <xsl:if test=""string($var:v32)='false'"">
                                  <ns1:Digest>
                                    <xsl:value-of select=""ns1:Digest/text()"" />
                                  </ns1:Digest>
                                </xsl:if>
                              </xsl:if>
                              <xsl:if test=""ns1:InfoId"">
                                <ns1:InfoId>
                                  <xsl:value-of select=""ns1:InfoId/text()"" />
                                </ns1:InfoId>
                              </xsl:if>
                              <xsl:if test=""ns1:MimeType"">
                                <xsl:variable name=""var:v33"" select=""string(ns1:MimeType/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v33)='true'"">
                                  <ns1:MimeType>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:MimeType>
                                </xsl:if>
                                <xsl:if test=""string($var:v33)='false'"">
                                  <ns1:MimeType>
                                    <xsl:value-of select=""ns1:MimeType/text()"" />
                                  </ns1:MimeType>
                                </xsl:if>
                              </xsl:if>
                              <xsl:if test=""ns1:ResourceId"">
                                <ns1:ResourceId>
                                  <xsl:value-of select=""ns1:ResourceId/text()"" />
                                </ns1:ResourceId>
                              </xsl:if>
                              <xsl:if test=""ns1:Size"">
                                <ns1:Size>
                                  <xsl:value-of select=""ns1:Size/text()"" />
                                </ns1:Size>
                              </xsl:if>
                              <xsl:if test=""ns1:Uri"">
                                <xsl:variable name=""var:v34"" select=""string(ns1:Uri/@xsi:nil) = 'true'"" />
                                <xsl:if test=""string($var:v34)='true'"">
                                  <ns1:Uri>
                                    <xsl:attribute name=""xsi:nil"">
                                      <xsl:value-of select=""'true'"" />
                                    </xsl:attribute>
                                  </ns1:Uri>
                                </xsl:if>
                                <xsl:if test=""string($var:v34)='false'"">
                                  <ns1:Uri>
                                    <xsl:value-of select=""ns1:Uri/text()"" />
                                  </ns1:Uri>
                                </xsl:if>
                              </xsl:if>
                              <xsl:value-of select=""./text()"" />
                            </ns1:Resource>
                          </xsl:for-each>
                          <xsl:value-of select=""./text()"" />
                        </ns1:ResourcesCollection>
                      </xsl:for-each>
                      <xsl:for-each select=""ns1:InfoCollection/ns1:Info/ns1:ResponseTypesCollection"">
                        <ns1:ResponseTypesCollection>
                          <xsl:for-each select=""ns1:ResponseType"">
                            <ns1:ResponseType>
                              <xsl:value-of select=""./text()"" />
                            </ns1:ResponseType>
                          </xsl:for-each>
                          <xsl:value-of select=""./text()"" />
                        </ns1:ResponseTypesCollection>
                      </xsl:for-each>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:SenderName"">
                        <xsl:variable name=""var:v35"" select=""string(ns1:InfoCollection/ns1:Info/ns1:SenderName/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v35)='true'"">
                          <ns1:SenderName>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:SenderName>
                        </xsl:if>
                        <xsl:if test=""string($var:v35)='false'"">
                          <ns1:SenderName>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:SenderName/text()"" />
                          </ns1:SenderName>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:SeverityId"">
                        <ns1:SeverityId>
                          <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:SeverityId/text()"" />
                        </ns1:SeverityId>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:UrgencyId"">
                        <ns1:UrgencyId>
                          <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:UrgencyId/text()"" />
                        </ns1:UrgencyId>
                      </xsl:if>
                      <xsl:if test=""ns1:InfoCollection/ns1:Info/ns1:Web"">
                        <xsl:variable name=""var:v36"" select=""string(ns1:InfoCollection/ns1:Info/ns1:Web/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v36)='true'"">
                          <ns1:Web>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Web>
                        </xsl:if>
                        <xsl:if test=""string($var:v36)='false'"">
                          <ns1:Web>
                            <xsl:value-of select=""ns1:InfoCollection/ns1:Info/ns1:Web/text()"" />
                          </ns1:Web>
                        </xsl:if>
                      </xsl:if>
                      <xsl:value-of select=""ns1:InfoCollection/ns1:Info/text()"" />
                    </ns1:Info>
                    <xsl:value-of select=""ns1:InfoCollection/text()"" />
                  </ns1:InfoCollection>
                  <xsl:if test=""ns1:MessageTypeId"">
                    <ns1:MessageTypeId>
                      <xsl:value-of select=""ns1:MessageTypeId/text()"" />
                    </ns1:MessageTypeId>
                  </xsl:if>
                  <xsl:if test=""ns1:Note"">
                    <xsl:variable name=""var:v37"" select=""string(ns1:Note/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v37)='true'"">
                      <ns1:Note>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Note>
                    </xsl:if>
                    <xsl:if test=""string($var:v37)='false'"">
                      <ns1:Note>
                        <xsl:value-of select=""ns1:Note/text()"" />
                      </ns1:Note>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:References"">
                    <xsl:variable name=""var:v38"" select=""string(ns1:References/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v38)='true'"">
                      <ns1:References>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:References>
                    </xsl:if>
                    <xsl:if test=""string($var:v38)='false'"">
                      <ns1:References>
                        <xsl:value-of select=""ns1:References/text()"" />
                      </ns1:References>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:Restriction"">
                    <xsl:variable name=""var:v39"" select=""string(ns1:Restriction/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v39)='true'"">
                      <ns1:Restriction>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Restriction>
                    </xsl:if>
                    <xsl:if test=""string($var:v39)='false'"">
                      <ns1:Restriction>
                        <xsl:value-of select=""ns1:Restriction/text()"" />
                      </ns1:Restriction>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:ScopeId"">
                    <ns1:ScopeId>
                      <xsl:value-of select=""ns1:ScopeId/text()"" />
                    </ns1:ScopeId>
                  </xsl:if>
                  <xsl:if test=""ns1:Sender"">
                    <xsl:variable name=""var:v40"" select=""string(ns1:Sender/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v40)='true'"">
                      <ns1:Sender>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Sender>
                    </xsl:if>
                    <xsl:if test=""string($var:v40)='false'"">
                      <ns1:Sender>
                        <xsl:value-of select=""ns1:Sender/text()"" />
                      </ns1:Sender>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:SentAsString"">
                    <xsl:variable name=""var:v41"" select=""string(ns1:SentAsString/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v41)='true'"">
                      <ns1:SentAsString>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:SentAsString>
                    </xsl:if>
                    <xsl:if test=""string($var:v41)='false'"">
                      <ns1:SentAsString>
                        <xsl:value-of select=""ns1:SentAsString/text()"" />
                      </ns1:SentAsString>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:Source"">
                    <xsl:variable name=""var:v42"" select=""string(ns1:Source/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v42)='true'"">
                      <ns1:Source>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:Source>
                    </xsl:if>
                    <xsl:if test=""string($var:v42)='false'"">
                      <ns1:Source>
                        <xsl:value-of select=""ns1:Source/text()"" />
                      </ns1:Source>
                    </xsl:if>
                  </xsl:if>
                  <xsl:if test=""ns1:StatusId"">
                    <ns1:StatusId>
                      <xsl:value-of select=""ns1:StatusId/text()"" />
                    </ns1:StatusId>
                  </xsl:if>
                  <xsl:if test=""ns1:WorkflowStatus"">
                    <xsl:variable name=""var:v43"" select=""string(ns1:WorkflowStatus/@xsi:nil) = 'true'"" />
                    <xsl:if test=""string($var:v43)='true'"">
                      <ns1:WorkflowStatus>
                        <xsl:attribute name=""xsi:nil"">
                          <xsl:value-of select=""'true'"" />
                        </xsl:attribute>
                      </ns1:WorkflowStatus>
                    </xsl:if>
                    <xsl:if test=""string($var:v43)='false'"">
                      <ns1:WorkflowStatus>
                        <xsl:value-of select=""ns1:WorkflowStatus/text()"" />
                      </ns1:WorkflowStatus>
                    </xsl:if>
                  </xsl:if>
                  <xsl:value-of select=""./text()"" />
                </ns1:Alert>
              </xsl:for-each>
              <xsl:for-each select=""ns1:ContactMethodsCollection"">
                <ns1:ContactMethodsCollection>
                  <xsl:for-each select=""ns1:ContactMethod"">
                    <ns1:ContactMethod>
                      <xsl:if test=""ns1:Name"">
                        <xsl:variable name=""var:v44"" select=""string(ns1:Name/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v44)='true'"">
                          <ns1:Name>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Name>
                        </xsl:if>
                        <xsl:if test=""string($var:v44)='false'"">
                          <ns1:Name>
                            <xsl:value-of select=""ns1:Name/text()"" />
                          </ns1:Name>
                        </xsl:if>
                      </xsl:if>
                      <xsl:if test=""ns1:Value"">
                        <xsl:variable name=""var:v45"" select=""string(ns1:Value/@xsi:nil) = 'true'"" />
                        <xsl:if test=""string($var:v45)='true'"">
                          <ns1:Value>
                            <xsl:attribute name=""xsi:nil"">
                              <xsl:value-of select=""'true'"" />
                            </xsl:attribute>
                          </ns1:Value>
                        </xsl:if>
                        <xsl:if test=""string($var:v45)='false'"">
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
                <xsl:variable name=""var:v46"" select=""string(ns1:Username/@xsi:nil) = 'true'"" />
                <xsl:if test=""string($var:v46)='true'"">
                  <ns1:Username>
                    <xsl:attribute name=""xsi:nil"">
                      <xsl:value-of select=""'true'"" />
                    </xsl:attribute>
                  </ns1:Username>
                </xsl:if>
                <xsl:if test=""string($var:v46)='false'"">
                  <ns1:Username>
                    <xsl:value-of select=""ns1:Username/text()"" />
                  </ns1:Username>
                </xsl:if>
              </xsl:if>
              <xsl:value-of select=""./text()"" />
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
