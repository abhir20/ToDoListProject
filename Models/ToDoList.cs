namespace To_doProject.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string IsCompletedFlag { get; set; }

        public DateTime CreatedDate { get; set; }

        public int SerialNo { get; set; }
    }
}
