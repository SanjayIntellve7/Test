﻿/* <comment>
 * <author>UICENTRIC\UICAdmin</author>
 * <date>8/23/2012 4:32:33 PM</date>
 * <purpose>
 * SimpleQueryAdapter ==> Streaming Query Provider
 * </purpose>
 * </comment>
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Logica.RealTimeDataMgmt.Common;
using Logica.RealTimeDataMgmt.Common.Configuration;
using Logica.RealTimeDataMgmt.DataTypes;
using Logica.RealTimeDataMgmt.Queries;
using Logica.RealTimeDataMgmt.Services.WcfDuplex;
using Microsoft.ComplexEventProcessing;
using Microsoft.ComplexEventProcessing.Linq;
using Logica.RealTimeDataMgmt.Adapters.DataGenerator;
using System.Linq;

namespace AMS.Broker.WatchDogService.StreamInsight.Queries
{

    /// <summary>
    /// Provide a summary of this query provider
    /// </summary>
    /// <remarks>
    /// This query provider requires the following input adapters:
    /// <list type="table">
    /// <listheader>
    ///     <term>Configuration Name</term>
    ///     <description>Description</description>
    /// </listheader>
    /// <item>
    ///     <term>AdapterName</term>
    ///     <description>Adapter that gets some data.</description>
    /// </item>
    /// </list>
    /// This provider creates and registers the following queries for filtering: 
    /// <list type="table">
    /// <listheader>
    ///     <term>Query Base Name</term>
    ///     <description>Description</description>
    /// </listheader>
    /// <item>
    ///     <term>Source</term>
    ///     <description>
    ///         [DataValueItem&lt;double&gt;]: Source data for all derived queries
    ///     </description>
    /// </item>
    /// </list>
    /// Pre-registered output adapters should have names matching the name of the query. 
    /// </remarks>
    //Add all input adapters as attributes. 
    [ConfigurationClass(typeof(AlarmAboveLevelQueryAdapterBooleanConfig))]
    [InputAdapter(Source, "Adaper that gets some data.")] //Example Input Adapter Attribute
    //Add all published queries as attributes. Please review the additional properties. 
    [PublishedQuery(Output, typeof(DataValueItem<double>), EventShape.Point)] //Example Published Query Attribute. 
    public class AlarmWhenOutOfRangeQueryAdapterInt32Query : StreamingQueryProvider<AlarmWhenOutOfRangeQueryAdapterConfig>
    {
        private const string Source = "Source";
        private const string ReferenceSource = "ReferenceSource";
        private const string Output = "Output";
        private const string RefOutput = "ReferenceOutput";
        private const string SourceStream = "SourceStream";
        private const string ReferenceStream = "ReferenceStream";

        #region Overrides of StreamingQueryProvider<SimpleQueryAdapterQueryProviderConfig>

        /// <summary> 
        /// Loads the set of queries created by this provider.
        /// </summary>
        /// <param name="cepApplication">Current CEP Application</param>
        /// <remarks>
        /// Inheriting classes should handle state change to started and then to started in this implementation.
        /// </remarks>
        protected override void Load(
                Application cepApplication)
        {
            var inputStream = CreateSourceStream<Int32>(Source);
            var referenceStream = CreateReferenceStream<DeviceDataItem>(
                GetFullQueryName(Source) + "Stream",
                ReferenceStream,
                ReferenceSource,
                (x, y) => x.DeviceId == y.DeviceId);

            var query =
                from item in inputStream
                from refItem in referenceStream
                where (item.Value < Configuration.MinLevel || item.Value > Configuration.MaxLevel) && item.ItemId == refItem.StreamInsightId
                select new
                {
                    Name = item.ItemId,
                    AdapterName = item.Adapter,
                    Value = item.Value,
                    DeviceId = refItem.DeviceId,
                    DeviceType = refItem.DeviceType, 
                    Description = refItem.Description,
                    Lat = refItem.Lat,
                    Long = refItem.Long,
                    Altitude = refItem.Altitude,
                    ZonesList = refItem.ZonesList
                };

            base.RegisterStreamAsQuery(query, Output, "", EventShape.Point, StreamEventOrder.ChainOrdered, StreamRegistrationOptions.AutoStart);
        }

        /// <summary>
        /// Adds a filter to an existing query
        /// </summary>
        /// <param name="filterDefinition">Filter definition for matches</param>
        /// <param name="filteredQueryName">Name for the new filtered query</param>
        /// <param name="outputAdapterFactoryType">Factory for the target output adapter.</param>
        /// <param name="outputAdapterSettings">Settings for the target output adapter.</param>
        public override Query AddQueryFilter(QueryFilterDefinition filterDefinition, string filteredQueryName, Type outputAdapterFactoryType, object outputAdapterSettings)
        {
            //TODO: Provide code to create dynamic filters for any queries that are available for runtime, adhoc filters. 
            /**  SAMPLE 
            string queryName = filterDefinition.QueryName;
            string queryBaseName = queryName.Substring(queryName.IndexOf(":") + 1);
            switch (queryBaseName)
            {
                case "Source":
                    return CreateFilteredQuery<DataValueItem<double>>(
                         filterDefinition, filteredQueryName,
                        outputAdapterFactoryType, outputAdapterSettings);

                case "Averages":
                    return CreateFilteredQuery<AggregateValueItem<double>>(
                        filterDefinition, filteredQueryName,
                        outputAdapterFactoryType, outputAdapterSettings);

                case "Deltas":
                    return CreateFilteredQuery<DeltaValueItem<double>>(
                         filterDefinition, filteredQueryName,
                        outputAdapterFactoryType, outputAdapterSettings);
                case "Current":
                    filterDefinition.QueryName = this.Configuration.Name + ":Source";
                    return CreateFilteredQuery<DataValueItem<double>>(
                        filterDefinition, filteredQueryName,
                        outputAdapterFactoryType, outputAdapterSettings);

                default:
                    throw new ArgumentException("Query name specified ({0}) is not value", queryBaseName);
             * **/
            throw new NotImplementedException();
        }

        #endregion

        public object GenericDataItem { get; set; }
    }
    /// <summary>
    /// Configuration class for <see cref="SimpleQueryAdapterQueryProvider"/>
    /// </summary>
    public class AlarmWhenOutOfRangeQueryAdapterConfig : QueryProviderConfigurationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleQueryAdapterQueryProviderConfig"/> class.
        /// </summary>
        public AlarmWhenOutOfRangeQueryAdapterConfig() : base() { }

        public override void Initialize(PlugInConfigurationElement configurationElement)
        {
            //NOTE: base class initialize sets all the common properties.
            base.Initialize(configurationElement);
            //TODO: Any custom initialization required.
            MaxLevel = configurationElement.GetSettingAsInt("MaxLevel", 100, true);
            MinLevel = configurationElement.GetSettingAsInt("MinLevel", 0, true);
        }

        [Category("AlarmAboveLevelQueryAdapterInt32QueryConfig")]
        [Description("Settign the level above which alarm is going to be triggered.")]
        public Int32 MaxLevel { get; set; }
        public Int32 MinLevel { get; set; }
    }


}