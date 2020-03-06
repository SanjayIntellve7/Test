using System.Runtime.Serialization;
[DataContract]
public class GeoTrackingData
{
    [DataMember]
    public string imei { get; set; }//

    [DataMember]
    public string regno { get; set; }//

    [DataMember]
    public string assetname { get; set; }//member name //

    [DataMember]
    public string username { get; set; }

    [DataMember]
    public string eventtype { get; set; }//error code //

    [DataMember]
    public string eventvalue { get; set; }//

    [DataMember]
    public string datetime { get; set; }//

    [DataMember]
    public string lat { get; set; }//

    [DataMember]
    public string lon { get; set; }//

    [DataMember]
    public string heading { get; set; }//direction      //  

    [DataMember]
    public string location { get; set; }//address    //   


}