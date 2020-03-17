using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwTw.DataLayer.Models;
using TwTw.Domain;
using TwTw.Domain.InterfaceExternalId;
using System.Linq;
using System.Linq.Expressions;

namespace TwTw.DataLayer.Tests
{
    [TestClass]
    public class InterfaceExternalIdRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repository = new EventTypeTemplateRepository();
           
            var eventTemplate = repository.All.FirstOrDefault(e => e.EventTemplateName == "Contact ID");
            var field =  eventTemplate.EventFieldDefinitions.FirstOrDefault();

            var repository2 = new InterfaceExternalIdRepository();
            var interfaceExt = repository2.Find(2);
            interfaceExt.DeviceExternalIdDefinitions.Add(new DeviceExternalIdDefinition
                {
                    EventFieldId = field.EventFieldId,
                    InterfaceId = interfaceExt.InterfaceId
                });
            var field2 = eventTemplate.EventFieldDefinitions.LastOrDefault();
            interfaceExt.DeviceExternalIdDefinitions.Add(new DeviceExternalIdDefinition
                {
                    EventFieldId = field2.EventFieldId,
                    InterfaceId = interfaceExt.InterfaceId
                });
            
            repository2.InsertOrUpdate(interfaceExt);
            repository2.Save();

            var repository3 = new DeviceExternalIdDefinitionRepository();
            foreach (var deviceExternalIdDefinition in interfaceExt.DeviceExternalIdDefinitions)
            {
                repository3.Delete(interfaceExt.InterfaceId, deviceExternalIdDefinition.EventFieldId);
            }

            repository3.Save();
        }
    }
}
