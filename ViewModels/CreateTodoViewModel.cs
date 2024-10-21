using System.ComponentModel.DataAnnotations;

namespace ToDo_Balta.ViewModels;

public class CreateTodoViewModel
{
    [Required]
    public string Title { get; set; }
}