using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using To_doProject.Business;
using To_doProject.Business.Entitites;

namespace To_doProject.Controllers
{
    [Route("api/ToDoLists")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        public IToDoListManager todo = null;




        public ToDoListsController(IToDoListManager todo)
        {
            this.todo = todo;
        }

        //GET : ToDoList 
        [HttpGet]
        public IList<ToDoList> GetToDoList()
        {
            return todo.GetToDoList();
        }

        //POST : ToDoList values
        [HttpPost]

        public HttpResponseMessage CreateToDoList()
        {
            ToDoList todoList =
                new ToDoList() { Id = 1, SerialNo = 1, Title = "CreateRecord", Description = "Create new records", CreatedDate = DateTime.Today };
                //new ToDoList() {Id =2, SerialNo = 2, Title = "UpdateRecord", Description = "Update records" , CreatedDate = DateTime.Today } ,
                //new ToDoList() {Id =3, SerialNo = 3, Title = "DeleteRecord", Description = "Delete records" , CreatedDate = DateTime.Today } ,
            //};

            if (todoList == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            //foreach (var item in todoList)
            //{
                todo.CreateToDoList(todoList);
            //}

            return new HttpResponseMessage(HttpStatusCode.Created);

        }

        [HttpPut]
        public HttpResponseMessage UpdateToDoList(int id, ToDoList toDoList)
        {

            if (id == 0 && toDoList == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            todo.UpdateToDoList(id, toDoList);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int id)
        {
            if (id == 0)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            todo.DeleteToDoList(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
