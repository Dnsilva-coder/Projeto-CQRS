using System.Runtime.Intrinsics.X86;
using System.Web.Mvc;

namespace Eventos.IO.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public SelectList Categorias()
        {
            return new SelectList(ListarCategoria(), "Id", "Nome");
        }

        public List<CategoriaViewModel> ListarCategoria()
        {
            var categoriasList = new List<CategoriaViewModel>()
            {
              new CategoriaViewModel(){ Id =new Guid("ac381b18-c187-482c-a5cb-899ad7176137"), Nome = "Congresso"},
              new CategoriaViewModel(){ Id =new Guid("1bbfa7e9-5a1f-4cef-b209-58954303dfc3"), Nome = "Meetup"},
              new CategoriaViewModel(){ Id =new Guid("d443d7c6-04e5-4d48-8de0-9e6726b4fbc0"), Nome = "Workshop"},

            };
            return categoriasList;
        }

    }
}
