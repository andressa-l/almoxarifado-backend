using AlmoxarifadoAPI.Models;

namespace AlmoxarifadoTestes
{
    public class EstoqueTests
    {
        [Fact]
        public void VerificarEstoqueSuficiente_DeveRetornarVerdadeiroQuandoQuantidadeSuficiente()
        {
            // Arrange
            decimal quantidadeNoEstoque = 10;
            decimal quantidadeRequerida = 5;
            var estoque = new Estoque { QtdPro = quantidadeNoEstoque };

            // Act
            var resultado = estoque.VerificarEstoqueSuficiente(quantidadeRequerida);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void VerificarEstoqueSuficiente_DeveRetornarFalsoQuandoQuantidadeInsuficiente()
        {
            // Arrange
            decimal quantidadeNoEstoque = 3;
            decimal quantidadeRequerida = 5;
            var estoque = new Estoque { QtdPro = quantidadeNoEstoque };

            // Act
            var resultado = estoque.VerificarEstoqueSuficiente(quantidadeRequerida);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void RemoverEstoque_DeveRemoverQuantidadeCorreta()
        {
            // Arrange
            decimal quantidadeInicial = 10;
            decimal quantidadeRemovida = 5;
            var estoque = new Estoque { QtdPro = quantidadeInicial };

            // Act
            estoque.RemoverEstoque(quantidadeRemovida);

            // Assert
            Assert.Equal(quantidadeInicial - quantidadeRemovida, estoque.QtdPro);
        }

        [Fact]
        public void AdicionarEstoque_DeveAdicionarQuantidadeCorreta()
        {
            // Arrange
            decimal quantidadeInicial = 10;
            decimal quantidadeAdicionada = 5;
            var estoque = new Estoque { QtdPro = quantidadeInicial };

            // Act
            estoque.AdicionarEstoque(quantidadeAdicionada);

            // Assert
            Assert.Equal(quantidadeInicial + quantidadeAdicionada, estoque.QtdPro);
        }

        [Fact]
        public void VerificarEstoqueMinimo_DeveRetornarTrueQuandoEstoqueIgualAoMinimo()
        {
            // Arrange
            var produto = new Produto { EstoqueMin = 10 };

            // Act
            bool resultado = produto.VerificarEstoqueMinimo(10);

            // Assert
            Assert.True(resultado);
        }

    }

}

