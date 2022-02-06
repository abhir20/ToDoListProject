using To_doProject.Business.Entitites;
using To_doProject.DAL;

namespace To_doProject.Business
{
    public class ToDoListManager : IToDoListManager
    {
        ToDoDbContext context = null;

        public ToDoListManager(ToDoDbContext _context)
        {
            this.context = _context;
        }
        public List<ToDoList> GetToDoList()
        {

            var toDoList = context.ToDoLists.OrderBy(t => t.SerialNo).ToList();

            return toDoList;
        }

        public void CreateToDoList(ToDoList toDoList)
        {
            try
            {
                if (toDoList != null)
                {
                    //Serial number added in front end
                    context.Add(toDoList);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex = new Exception(ex.Message);
                throw ex;
            }
        }

        public void UpdateToDoList(int id,ToDoList toDoList)
        {
            try {
                if(id > 0)
                {
                    var itemToUpdate = context.ToDoLists.Where(t => t.Id == id).FirstOrDefault();
                    if (itemToUpdate != null)
                    {
                        itemToUpdate.Title = toDoList.Title;
                        itemToUpdate.Description = toDoList.Description;
                        itemToUpdate.IsCompletedFlag = toDoList.IsCompletedFlag;
                        itemToUpdate.CreatedDate = toDoList.CreatedDate;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ex = new Exception(ex.Message);
                throw ex;
            }

        }
        public void DeleteToDoList(int id)
        {
            try
            {
                if (id > 0)
                {
                    var itemToDelete = context.ToDoLists.Where(t => t.Id == id).FirstOrDefault();
                    if (itemToDelete != null)
                    {
                        int serialNoDeleted = itemToDelete.SerialNo;

                        //Get the other items and update serialNo
                        var toUpdate = context.ToDoLists.Where(t => t.SerialNo > serialNoDeleted).ToList();
                        context.Remove(itemToDelete);

                        if (toUpdate != null && toUpdate.Count >= 1)
                        {
                            foreach (var item in toUpdate)
                            {

                                item.SerialNo = item.SerialNo - 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex = new Exception(ex.Message);
                throw ex;
            }
        }

    }
}
