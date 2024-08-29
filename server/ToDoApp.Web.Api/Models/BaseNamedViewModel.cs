namespace ToDoApp.Web.Api.Models
{
    /// <summary>
    /// Representation of the default entity with name and id
    /// </summary>
    public class BaseNamedViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
