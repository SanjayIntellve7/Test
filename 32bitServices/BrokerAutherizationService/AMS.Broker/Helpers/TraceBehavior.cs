using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using Microsoft.Practices.Unity.InterceptionExtension;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace AMS.Broker.AutherizationService.Helpers
{
    class TraceBehavior : IInterceptionBehavior, IDisposable
    {
        private Logger _logger;
        private bool _willExecute;

        public TraceBehavior(Logger source)
        {
            try
            {
                if (source == null)
                    throw new ArgumentNullException("source");
                this._logger = source;
            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {            
            // BEFORE the target method execution
            this._logger.Info("Invoking {0}", input.MethodBase.ToString());

            // Yield to the next module in the pipeline  
            var methodReturn = getNext().Invoke(input, getNext);

            // AFTER the target method execution
            if (methodReturn.Exception == null)
            {
                if (this._logger.IsTraceEnabled)
                {
                    this._logger.Trace("Parameters \n {0}", SerializeParameters(input));
                }
                this._logger.Info("Successfully finished {0}", input.MethodBase.ToString());
            }
            else
            {
                this._logger.Error("Parameters \n {0}", SerializeParameters(input));
                this._logger.ErrorException(
                    string.Format("Finished {0} with exception\n", input.MethodBase.ToString()), methodReturn.Exception);
                if (methodReturn.Exception is FaultException<UniqueFault>)
                {
                    _willExecute = false;
                }
            }
            return methodReturn;
        }

        public bool WillExecute
        {
            get
            {
                return _willExecute;
            }
        }

        public void Dispose()
        {
        }

        private string SerializeParameters(IMethodInvocation invocation)
        {
            using (var serializationStream = new MemoryStream())
            {
                foreach (var argument in invocation.Arguments)
                {
                    if (argument != null)
                    {
                        var serializer = new DataContractSerializer(argument.GetType());
                        serializer.WriteObject(serializationStream, argument);
                    }
                }
                serializationStream.Seek(0, SeekOrigin.Begin);

                var streamReader = new StreamReader(serializationStream);
                return streamReader.ReadToEnd();
            }
        }
    }
}
