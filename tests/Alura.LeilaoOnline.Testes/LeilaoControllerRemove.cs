using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Controllers;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoControllerRemove
    {
        IAdminService _service;
        IProdutoService _produtoService;

        public LeilaoControllerRemove(IAdminService service, IProdutoService produtoService)
        {
            _service = service;
            _produtoService = produtoService;
        }

        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; // preciso entrar no banco para saber qual é inexistente!! teste deixa de ser automático...
            var actionResultEsperado = typeof(NotFoundResult);
            var controller = new LeilaoController(_service, _produtoService);

            // act
            var result = controller.Remove(idLeilaoInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmPregaoEntaoRetorna405()
        {
            // arrange
            var idLeilaoEmPregao = 11232; // qual leilao está em pregão???!! 
            var actionResultEsperado = typeof(StatusCodeResult);
            var controller = new LeilaoController(_service, _produtoService);

            // act
            var result = controller.Remove(idLeilaoEmPregao);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idLeilaoEmRascunho = 11232; // qual leilao está em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);
            var controller = new LeilaoController(_service, _produtoService);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }
    }
}
