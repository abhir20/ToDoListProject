

using To_doProject.Business.Entitites;

namespace To_doProject.Business
{
    public interface IToDoListManager
    {
        //CRUD 
        public List<ToDoList> GetToDoList();

        public void CreateToDoList(ToDoList toDoList);

        public void UpdateToDoList(int id,ToDoList toDoList);

        public void DeleteToDoList(int id);
    }
}
