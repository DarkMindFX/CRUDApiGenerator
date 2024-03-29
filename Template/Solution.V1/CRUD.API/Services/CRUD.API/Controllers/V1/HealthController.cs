﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CRUD.Interfaces;
using CRUD.API.Filters;

namespace CRUD.API.Controllers.V1
{
    [ApiController]
    [UnhandledExceptionFilter]
    [Route("api/v1/[controller]")]
    
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly IConnectionTestDal _dalConnTest;

        public HealthController(ILogger<HealthController> logger,
                                    IConnectionTestDal dalConnTest)
        {
            _logger = logger;
            _dalConnTest = dalConnTest;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dto = new DTO.HealthResponse();
            dto.Timestamp = DateTime.UtcNow;
            dto.Message = "CRUD.API health details";

            dto.Diagnostics = new Dictionary<string, object>();
            dto.Diagnostics["CRUD.API"] = "OK";

            bool canConnectDal = CanConnectDal();
            dto.Diagnostics["DAL"] = canConnectDal ? "OK" : "FAIL";

            IActionResult response = StatusCode(canConnectDal ? (int)HttpStatusCode.OK : (int)HttpStatusCode.PreconditionFailed, dto);

            return response;
        }

        #region Support methods
        public bool CanConnectDal()
        {
            var testResult = _dalConnTest.TestConnection();
            return testResult.Success;
        }
        #endregion
    }
}
