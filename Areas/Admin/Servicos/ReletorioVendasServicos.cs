using LivroEC_V2.Data;
using LivroEC_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroEC_V2.Areas.Admin.Servicos
{
    public class ReletorioVendasServicos
    {
        private readonly BancoContext _bancoContext;

        public ReletorioVendasServicos(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _bancoContext.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if(maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                .Include(x => x.PedidosItens)
                .ThenInclude(x => x.Livro)
                .OrderBy(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}
