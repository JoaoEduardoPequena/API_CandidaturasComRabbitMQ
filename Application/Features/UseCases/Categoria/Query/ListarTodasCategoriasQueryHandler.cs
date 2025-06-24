using Application.DTO;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.UseCases.Categoria.Query
{
    public class ListarTodasCategoriasQueryHandler: IRequestHandler<ListarTodasCategoriasQuery, List<CategoriaDTO>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public ListarTodasCategoriasQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<List<CategoriaDTO>> Handle(ListarTodasCategoriasQuery request, CancellationToken cancellationToken)
        {
            var litCategoria = await _categoriaRepository.GetAllCategorias();
            var listCategorias = litCategoria.Adapt<List<CategoriaDTO>>();
            return listCategorias;
        }
    }
}
