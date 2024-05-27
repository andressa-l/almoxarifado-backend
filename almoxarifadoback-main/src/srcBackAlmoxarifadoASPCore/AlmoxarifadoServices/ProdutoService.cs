using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoServices {
    public class ProdutoService {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration mapperConfiguration;

        public ProdutoService(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProdutoPostDTO, ProdutoGetDTO>();
                cfg.CreateMap<ProdutoGetDTO, ProdutoPostDTO>();
                cfg.CreateMap<Produto, ProdutoGetDTO>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<ProdutoGetDTO> Create(ProdutoPostDTO produtoDTO) {
            var produto = _mapper.Map<Produto>(produtoDTO);
            var createdProduto = await _produtoRepository.CriarProduto(produto);
            return _mapper.Map<ProdutoGetDTO>(createdProduto);
        }

        public async Task<ProdutoGetDTO> Delete(int id) {
            var deletedProduto = await _produtoRepository.DeletarProduto(id);
            return _mapper.Map<ProdutoGetDTO>(deletedProduto);
        }

        public async Task<IEnumerable<ProdutoGetDTO>> GetAll() {
            var produtos = await _produtoRepository.GetAll();
            return _mapper.Map<IEnumerable<ProdutoGetDTO>>(produtos);
        }

        public ProdutoGetDTO GetById(int id) {
            var produto = _produtoRepository.ObterProdutoPorId(id);
            return _mapper.Map<ProdutoGetDTO>(produto);
        }

        public async Task<ProdutoGetDTO> Update(int id, ProdutoPostDTO produtoDTO) {
            var produto = _mapper.Map<Produto>(produtoDTO);
            produto.IdPro = id;
            var updatedProduto = await _produtoRepository.AtualizarProduto(produto);
            return _mapper.Map<ProdutoGetDTO>(updatedProduto);
        }
    }
}
