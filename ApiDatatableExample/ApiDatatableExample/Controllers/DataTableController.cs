
using ApiDatatableExample.Utilities;
using DbLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.NetworkInformation;

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

            return PagingDataResult.GetPagingResponse(SortingResult(result, request), request);

        }
        private IEnumerable<UserInfo> SortingResult(IEnumerable<UserInfo> userList, PagingRequest paging)
        {
            var colOrder = paging.Order[0];
            switch (colOrder.Column)
            {
                case 0:
                    userList = colOrder.Dir == "asc" ? userList.OrderBy(x => x.UserId) : userList.OrderByDescending(x => x.UserId);
                    break;
                case 1:
                    userList = colOrder.Dir == "asc" ? userList.OrderBy(x => x.UserName) : userList.OrderByDescending(x => x.UserName);
                    break;
                case 2:
                    userList = colOrder.Dir == "asc" ? userList.OrderBy(x => x.CompanyName) : userList.OrderByDescending(x => x.CompanyName);
                    break;
                    //and so on

            }
            return userList;

        }



    }
}