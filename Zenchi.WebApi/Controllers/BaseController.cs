using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Zenchi.Domain.ServiceInterfaces;

namespace Zenchi.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public ILoggingService LoggingService { get; set; }

        public BaseController(ILoggingService loggingService)
        {
            if (loggingService == null)
                throw new ArgumentNullException("ILoggingService is null");

            LoggingService = loggingService;

        }
        public virtual IHttpActionResult InternalServerError(Exception ex, string logMessage, string optionalReturnMessage)
        {
            string logid = LoggingService.LogException(ex, logMessage);
            string content = string.Format("LogId:{0} {1}", logid, optionalReturnMessage);

            return new InternalServerErrorResult(content, Request);
        }
    }

    public class InternalServerErrorResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public InternalServerErrorResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}