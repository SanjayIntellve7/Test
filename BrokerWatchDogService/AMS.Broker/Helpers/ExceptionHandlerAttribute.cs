using System.Collections;
using System.Collections.Generic;
using NLog;
using PostSharp.Aspects;
using System;

namespace AMS.Broker.WatchDogService.Helpers
{
    [Serializable]
    public sealed class ExceptionHandlerAttribute : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
           LogManager.GetCurrentClassLogger().DebugException("Exception", args.Exception);
           args.FlowBehavior = FlowBehavior.Continue;
          
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            LogManager.GetCurrentClassLogger().Info("------------------------------------");
            LogManager.GetCurrentClassLogger().Info(string.Format("{0}: Invoking {1}", args.Instance.GetType().Name, args.Method.Name));

            // AFTER the target method execution
            //    this._logger.Info("Successfully finished {0}", input.MethodBase.ToString());
            //    this._logger.Error("Parameters \n {0}", SerializeParameters(input));
            //    this._logger.ErrorException(
            //        string.Format("Finished {0} with exception\n", input.MethodBase.ToString()), methodReturn.Exception);
            //}
            //return methodReturn;
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            LogManager.GetCurrentClassLogger()
                      .Info(string.Format("{0}: Successfully finished {1}", args.Instance.GetType().Name,
                                          args.Method.Name));
            if (args.ReturnValue is ICollection)
                LogManager.GetCurrentClassLogger()
                          .Info(string.Format("Count of results: {0}", (args.ReturnValue as ICollection).Count));
            else if (args.ReturnValue == null)
                LogManager.GetCurrentClassLogger()
                          .Info(string.Format("Result is empty"));
            base.OnSuccess(args);
        }
    }
}
