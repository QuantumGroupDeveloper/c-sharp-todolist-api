using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ToDoListAPI.DTO;
using ToDoListAPI.Infrastracture.DB.SQLServer;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/todolist")]
    public class ToDoListController : Controller
    {
        private readonly TodolistContext _dbContext;

        public ToDoListController(TodolistContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ListToDoLists()
        {
            FormattableString select = $@"
SELECT
  id
  ,title
  ,detail
  ,place
  ,deadline
  ,remarks
  ,created_at
  ,updated_at
  ,deleted_at 
FROM 
  to_do_list 
WHERE 
  deleted_at is null
";

            IEnumerable<ToDoList> record;
            List<ToDoListResponse> responseData = new List<ToDoListResponse>();

            try
            {
                record = _dbContext.ToDoLists.FromSql(select);
                // EFの機能でSQL使用しない場合
                //record = _dbContext.ToDoLists.Where(todo => todo.DeletedAt == null).ToList();

                record.ToList().ForEach(toDo =>
                {
                    bool isOverdue = false;
                    if (toDo.Deadline.HasValue)
                    {
                        isOverdue = DateTime.Now > toDo.Deadline.Value;
                    }

                    responseData.Add(new ToDoListResponse()
                    {
                        Id = toDo.Id,
                        Title = toDo.Title,
                        Detail = toDo.Detail,
                        Place = toDo.Place,
                        Deadline = toDo.Deadline,
                        Remarks = toDo.Remarks,
                        IsOverdue = isOverdue,
                    });

                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(responseData);

        }

        [HttpGet("{id}")]
        public IActionResult GetToDoList(int id)
        {
            FormattableString select = $@"
SELECT
  id
  ,title
  ,detail
  ,place
  ,deadline
  ,remarks
  ,created_at
  ,updated_at
  ,deleted_at 
FROM 
  to_do_list 
WHERE 
      id = {id}
  AND deleted_at is null
";

            ToDoList? record;
            ToDoListResponse responseData = new ToDoListResponse();
            try
            {
                record = _dbContext.ToDoLists.FromSql(select).FirstOrDefault();
                // EFの機能でSQL使用しない場合
                //record = _dbContext.ToDoLists.Where(todo => todo.Id == id && todo.DeletedAt == null).FirstOrDefault();
                if (record == null)
                {
                    return NotFound();
                }

                responseData.Id = record.Id;
                responseData.Title = record.Title;
                responseData.Detail = record.Detail;
                responseData.Place = record.Place;
                responseData.Deadline = record.Deadline;
                responseData.Remarks = record.Remarks;

                if (record.Deadline.HasValue)
                {
                    responseData.IsOverdue = DateTime.Now > record.Deadline.Value;
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


            return Ok(record);
        }

        [HttpPost]
        public IActionResult CreateToDoList([FromBody] ToDoListRequest param)
        {
            int count;
            try
            {
                ToDoList toDoList = new ToDoList()
                {
                    Title = param.Title,
                    Detail = param.Detail,
                    Place = param.Place,
                    Deadline = param.Deadline,
                    Remarks = param.Remarks,
                    CreatedAt = DateTime.Now
                };

                _dbContext.ToDoLists.Add(toDoList);
                count = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(count);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateToDoList([FromBody] ToDoListRequest param, int id)
        {
            int updateCount = 0;
            try
            {
                var toDoList = _dbContext.ToDoLists.Single(x => x.Id == id);
                toDoList.Title = param.Title;
                toDoList.Detail = param.Detail;
                toDoList.Place = param.Place;
                toDoList.Deadline = param.Deadline;
                toDoList.Remarks = param.Remarks;
                toDoList.UpdatedAt = DateTime.Now;

                updateCount = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(updateCount);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            int deleteCount = 0;
            try
            {
                var toDoList = _dbContext.ToDoLists.Single(x => x.Id == id);
                toDoList.DeletedAt = DateTime.Now;
                // 物理削除の場合
                //_dbContext.ToDoLists.Remove(toDoList);

                deleteCount = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(deleteCount);
        }

        [HttpDelete]
        public IActionResult DeleteToDoList([FromBody] int[] ids)
        {
            int deleteCount = 0;
            try
            {
                deleteCount = _dbContext.ToDoLists.Where(item => ids.Contains(item.Id)).ExecuteUpdate(w => w.SetProperty(x => x.DeletedAt, DateTime.Now));
                // 物理削除の場合
                //var toDoList = _dbContext.ToDoLists.Where(item => ids.Contains(item.Id));
                //_dbContext.ToDoLists.RemoveRange(toDoList);
                //deleteCount = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(deleteCount);
        }
    }
}
