
using ApiDatatableExample.Utilities;
using DbLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace FileUploadWebApi.Controllers
{
    [ApiController]
    [Route("employees")]
    public class DataTableController : ControllerBase
    {


        private readonly ILogger<DataTableController> _logger;
        private readonly EmployeesContext _dbContext;
        public DataTableController(ILogger<DataTableController> logger,
            EmployeesContext dbContext
            )
        {
            _logger = logger;
            _dbContext = dbContext;

        }
        [HttpPost]

        [Route("employee-list")]
        public IActionResult GetEmployeeList([FromBody] PagingRequest request)
        {

            var filteredResult = GetFilterResult(request);
            return Ok(filteredResult);

        }
        private PagingResponse<UserInfo> GetFilterResult(PagingRequest request)
        {

            // filter can be put based on requirement
            var result = _dbContext.UserInfos.Where(x =>
                !string.IsNullOrEmpty(request.Search.Value) ?
                 (x.EmailId.Contains(request.Search.Value)
                || x.CompanyName.Contains(request.Search.Value)
                || x.UserName.Contains(request.Search.Value)
                || x.MobileNumber.Contains(request.Search.Value)
                || x.Location.Contains(request.Search.Value)) : true);
          
            return PagingDataResult.GetPagingResponse(PagingDataResult.OrderByDynamic(result,
               ((UserInfo.E)request.Order[0].Column).ToString(),
               request.Order[0].Dir == "asc"?false:true), request); 

        }
     



    }
}