using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class SdkZoneDataDTO
    {
        public string Description { get; set; }
        public string ExternalData { get; set; }
        public int Id { get; set; }
        public bool Isolated { get; set; }
        public string Name { get; set; }
        public List<SensorSectionDto> SensorSections { get; set; }
    }
    public class SensorSectionDto
    {
        //public SensorSectionDto(SensorSectionDto that);
        //public SensorSectionDto(int sectionId, int sensorId, double cableStart, double cableEnd, double perimeterStart, double perimeterEnd, int sensorStartIdx, int sensorEndIdx, List<CoordinateDto> points);
        //public SensorSectionDto(int sectionId, int sensorId, double cableStart, double cableEnd, double perimeterStart, double perimeterEnd, int sensorStartIdx, int sensorEndIdx, List<CoordinateDto> points, bool opposite);

        public double CableEnd { get; set; }
        public double CableStart { get; set; }
        public bool Opposite { get; set; }
        public double PerimeterEnd { get; set; }
        public double PerimeterStart { get; set; }
        public List<CoordinateDto> Points { get; set; }
        public bool Reversed { get; set; }
        public int SectionId { get; set; }
        public int SensorEndIdx { get; set; }
        public int SensorId { get; set; }
        public int SensorStartIdx { get; set; }
        public int ServerId { get; set; }

        //public bool CableDistanceInSection(double cablePos);
        //public override string ToString();
    }
    public struct CoordinateDto
    {
        public static readonly CoordinateDto Empty;

        //public CoordinateDto(CoordinateDto that);
        //public CoordinateDto(string coordinate);
        //public CoordinateDto(double latitude, double longitude);
        //public CoordinateDto(double latitude, double longitude, double altitude);

        //public static CoordinateDiffDto operator -(CoordinateDto coord1, CoordinateDto coord2);

        public double Alt { get; set; }
        public bool IsEmpty { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        //public double Azimuth(CoordinateDto toCoord);
        //public double Distance(CoordinateDto toCoord);
        //public override bool Equals(object obj);
        //public double FlatDistance(CoordinateDto toCoord);
        //public static bool FromString(out CoordinateDto coord, string coordinate);
        //public override int GetHashCode();
        //public CoordinateDto Move(double distInMeters, double azimuthDegrees);
        //public CoordinateDto Move(double distInMeters, MoveDirection direction);
        //public static CoordinateDto Parse(string coordinate);
        //public override string ToString();
        //public string ToString(LatLongFormat format);
        //public string ToString(LatLongFormat format, MeasurementUnits measurementUnit);
        //public string ToString(LatLongFormat format, MeasurementUnits measurementUnit, bool showAltitude);
        //public string ToString(ProjectionType projectionType, LatLongFormat format, GeoProjectionConverter geoConverter);
        //public string ToString(ProjectionType projectionType, LatLongFormat format, GeoProjectionConverter geoConverter, MeasurementUnits measurementUnit);
    }

    public struct CoordinateDiffDto
    {
        public static readonly CoordinateDiffDto Empty;
        public static readonly CoordinateDiffDto Zero;

        //public CoordinateDiffDto(CoordinateDto coord1, CoordinateDto coord2);
        //public CoordinateDiffDto(double latDiff, double longDiff);
        //public CoordinateDiffDto(double latDiff, double longDiff, double altDiff);

        public double AltDiff { get; set; }
        public double Distance { get; set; }
        public double FlatDistance { get; set; }
        public bool IsEmpty { get; set; }
        public double LatDiff { get; set; }
        public double LongDiff { get; set; }
    }

    public enum MoveDirection
    {
        North = 0,
        Shouth = 1,
        East = 2,
        West = 3,
        NE = 4,
        NW = 5,
        SE = 6,
        SW = 7,
    }
    public enum LatLongFormat
    {
        DecimalDegrees = 0,
        DegMinSec = 1,
    }
    public enum MeasurementUnits
    {
        Meters = 0,
        Feet = 1,
        Yards = 2,
    }
    public enum ProjectionType
    {
        LatLong = 0,
        UTM = 1,
    }
    public class GeoProjectionConverter
    {
        //public GeoProjectionConverter();

        public EllipsoidId Datum { get; set; }
        public EllipsoidId EllipsoidId { get; set; }
        public string EllipsoidName { get; set; }
        public List<ReferenceEllipsoid> Ellipsoids { get; set; }
        public bool HasProjection { get; set; }
        public string ProjectionName { get; set; }

        //public void ComputeLccParameters();
        //public void ComputeTmParameters();
        //public string GetAltitudeUnitDescription(bool abrev);
        //public string GetCoordinateUnitDescription(bool abrev);
        //public bool LCCtoLL(double LCCEastingMeter, double LCCNorthingMeter, ref double LatDegree, ref double LongDegree);
        //public bool LLtoLCC(double LatDegree, double LongDegree, ref double LCCEastingMeter, ref double LCCNorthingMeter);
        //public bool LLtoTM(double LatDegree, double LongDegree, ref double TMEastingMeter, ref double TMNorthingMeter);
        //public bool LLtoUTM(double LatDegree, double LongDegree, ref double UtmEastingMeter, ref double UtmNorthingMeter, ref string UtmZone, ref bool northernHem);
        //public void PrintAllStatePlaneNad27Lcc();
        //public void PrintAllStatePlaneNad27Tm();
        //public void PrintAllStatePlaneNad83Lcc();
        //public void PrintAllStatePlaneNad83Tm();
        //public void SetAltitudeInFeet();
        //public void SetAltitudeInMeter();
        //public void SetCoordinatesInFeet();
        //public void SetCoordinatesInMeter();
        //public void SetCoordinatesInSurveyFeet();
        //public bool SetLambertConformalConicProjection(double falseEastingMeter, double falseNorthingMeter, double latOriginDegree, double longMeridianDegree, double firstStdParallelDegree, double secondStdParallelDegree, string description);
        //public bool SetReferenceEllipsoid(EllipsoidId id);
        //public bool SetReferenceEllipsoid(string name);
        //public bool SetStatePlaneNad27Lcc(string zone, string description);
        //public bool SetStatePlaneNad27Tm(string zone, string description);
        //public bool SetStatePlaneNad83Lcc(string zone, string description);
        //public bool SetStatePlaneNad83Tm(string zone, string description);
        //public bool SetTransverseMercatorProjection(double falseEastingMeter, double falseNorthingMeter, double latOriginDegree, double longMeridianDegree, double scaleFactor, string description);
        //public bool TMtoLL(double TMEastingMeter, double TMNorthingMeter, ref double LatDegree, ref double LongDegree);
        //public void ToKmlStyleLatLongAltitude(double[] point, ref double latDeg, ref double longDeg, ref double altitude);
        //public void ToKmlStyleLatLongAltitude(float[] point, ref double latDeg, ref double longDeg, ref double altitude);
        //public void ToKmlStyleLatLongAltitude(int[] point, ref double latDeg, ref double longDeg, ref double altitude);
        //public bool UTMLetterDesignator(double LatDegree, ref char utmLetter);
        //public bool UTMtoLL(double UTMEastingMeter, double UTMNorthingMeter, ref double LatDegree, ref double LongDegree);
    }

    public enum EllipsoidId
    {
        NotSet = 0,
        WGS_60 = 1,
        WGS_66 = 2,
        WGS_72 = 3,
        WGS_84 = 4,
        NAD_27 = 5,
        Clarke_1880 = 6,
        GRS_1967 = 7,
        NAD_83 = 8,
        Australian_National = 9,
        Mercury = 10,
        Fischer_1968 = 11,
        Modified_Fischer_1960 = 12,
        International = 13,
        Krassovsky = 14,
        South_American_1969 = 15,
        Airy = 16,
        Modified_Airy = 17,
        Bessel_1841 = 18,
        Nambia = 19,
        Everest_1830 = 20,
        Modified_Everest = 21,
        Helmert_1906 = 22,
        Hough = 23,
    }
    public class ReferenceEllipsoid
    {
        //public ReferenceEllipsoid(EllipsoidId id, string name, double equatorialRadius, double eccentricitySquared, double inverseFlattening);

        public double eccentricitySquared { get; set; }
        public double equatorialRadius { get; set; }
        public EllipsoidId id { get; set; }
        public double inverseFlattening { get; set; }
        public string name { get; set; }

       // public override string ToString();
    }
}
