using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwTw.DataLayer.Models;
using TwTw.Domain.ObjectsAssociations;

namespace TwTw.DataLayer.Tests
{
    [TestClass]
    public class ObjectsAssociationRepositoryTests
    {
        ObjectType _objectType = null;
        [TestInitialize]
        public void Init()
        {
            using (var objectAssociationType = new ObjectTypeRepository())
            {
                objectAssociationType.InsertOrUpdate(new ObjectType { Name = "Type" });
                objectAssociationType.Save();
                _objectType = objectAssociationType.All.FirstOrDefault(ot => ot.Name == "Type");
            }
        }

        [TestCleanup]
        public void CleanUp()
        {

            using (var objectAssociationType = new ObjectTypeRepository())
            {
                _objectType = objectAssociationType.All.FirstOrDefault(ot => ot.Name == "Type");
                if (_objectType != null) objectAssociationType.Delete(_objectType.ObjectTypeId);
                objectAssociationType.Save();
            }
        }

        [TestMethod]
        public void InsertNewObjectAssociationNoException()
         {
             using (var objectAssociation = new ObjectsAssociationRepository())
             {
                 objectAssociation.InsertOrUpdate(new ObjectsAssociation
                     {
                         Object1Identity = int.MaxValue,
                         Object2Identity = int.MaxValue -1,
                         ObjectTypeId = _objectType.ObjectTypeId
                     });
                 objectAssociation.Save();
             }

             using (var objectAssociationRep = new ObjectsAssociationRepository())
             {
                var objectAssociation = objectAssociationRep.All.FirstOrDefault(oa => oa.Object1Identity == int.MaxValue &&
                                                            oa.Object2Identity == int.MaxValue - 1);
                 objectAssociationRep.Delete(objectAssociation.ObjectsAssociationId);
                 objectAssociationRep.Save();
             }
         }
    }
}
