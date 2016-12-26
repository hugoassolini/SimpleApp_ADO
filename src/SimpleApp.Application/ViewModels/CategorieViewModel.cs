using System.ComponentModel.DataAnnotations;

namespace SimpleApp.Application.ViewModels
{
	public class CategorieViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		[StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Nome deve ter entre 5 e 100 caracteres")]
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		[StringLength(200, MinimumLength = 5, ErrorMessage = "O campo Descrição deve ter entre 5 e 200 caracteres")]
		[Display(Name = "Descrição")]
		public string Description { get; set; }
	}
}
