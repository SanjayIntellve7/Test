using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Web.Security;
using AMS.Broker.Contracts.DTO;
using NLog;
using PostSharp.Aspects;
using System;

namespace AMS.Broker.AutherizationService.Helpers
{
    [Serializable]
    public sealed class UniqueConstraintHandlerAttribute : OnMethodBoundaryAspect
    {
        public string Name { get; set; }

        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception is DbUpdateException)
            {
                var updateException = (args.Exception as DbUpdateException).InnerException as UpdateException;

                if (updateException != null)
                {
                    var sqlException = updateException.InnerException as SqlException;

                    if (sqlException != null && sqlException.Errors.OfType<SqlError>()
                                                            .Any(se => se.Number == 2601 || se.Number == 2627 || se.Number == 50001))
                    {
                        var uniqueFault = new UniqueFault();
                        IList<string> fieldNames = (from error in sqlException.Errors.OfType<SqlError>()
                                                    let regEx =
                                                        new System.Text.RegularExpressions.Regex(@"IX_Unique[\w]+\b")
                                                    select regEx.Match(error.Message)
                                                    into match
                                                    select match.Value).Where(el => !string.IsNullOrEmpty(el)).ToList();


                        var allFields = fieldNames.Where(el => !string.IsNullOrEmpty(el)).Aggregate(string.Empty,
                                                                                                    (current, fieldName)
                                                                                                    =>
                                                                                                    current + fieldName +
                                                                                                    ";");

                        throw new FaultException<UniqueFault>(new UniqueFault {FieldNames = fieldNames},
                                                              new FaultReason(allFields));
                    }
                }
            }
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
