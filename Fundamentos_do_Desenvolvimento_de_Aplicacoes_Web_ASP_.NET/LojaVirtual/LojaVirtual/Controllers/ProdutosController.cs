﻿using LojaVirtual.Models;
using LojaVirtual.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class ProdutosController : Controller
    {
        static List<Produto> produtos = new List<Produto>();

        [HttpGet]
        [Route("produtos/cadastrar")]
        [Route("prod/cadastrar")]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProdutoCadastrado()
        {
            return View();
        }

        [HttpGet]
        [Route("produtos/buscar")]
        [Route("prod/buscar")]
        public ActionResult Buscar()
        {
            return View();
        }
         
        [HttpGet]
        [Route("produtos/listar")]
        public ActionResult Listar(string pesquisa, string ordenarpelonome)
        {

            var conexao = new ProdutoService();
            produtos = conexao.BuscarListaProdutos();

            if (pesquisa != null)
            {
                var produtosPesquisados = produtos.Where(x => x.NM_NOME == pesquisa).ToList();
                return View(produtosPesquisados);

            }

            if (ordenarpelonome == "asc")
            {
                return View(produtos.OrderBy(produto => produto.NM_NOME).ToList());
            }


            return View(produtos);
        }

        [HttpPost]
        public ActionResult ExecutarCadastroDeProduto(string nome, string preco, int quantidade)
        {
            var conexao = new ProdutoService();
            conexao.CadastrarProduto(nome, preco, quantidade);

            return Redirect("/produtos/listar");
        }

        [HttpPost]
        [Route("produtos/BuscarProdutos")]
        public IActionResult BuscarProdutos(string nome)
        {
            var conexao = new ProdutoService();
            var produto = conexao.BuscaProdutoNome(nome);
            return View("Buscar", produto);
        }

        [HttpGet]
        [Route("produtos/editar")]
        public ActionResult Editar(int id)
        {
            var conexao = new ProdutoService();
            Produto produto = conexao.BuscarProdutoId(id);
            return View(produto);
        }

        [HttpPost]
        [Route("produtos/editar")]
        [Route("prod/editar")]
        public ActionResult Editar(int id, string nome, string preco, int quantidade)
        {
            var conexao = new ProdutoService();
            Produto produto = new Produto();
            produto.NM_NOME = nome;
            produto.NR_PRECO = preco;
            produto.NR_QUANTIDADE = quantidade;
            conexao.AlterarProduto(produto);

            return Redirect("/produtos/listar");
        }

        [HttpGet]
        [Route("produtos/excluir")]
        public ActionResult ExcluirGet(int id)
        {
            var conexao = new ProdutoService();
            Produto produto = conexao.BuscarProdutoId(id);
            return View("Excluir", produto);
        }

        [HttpPost]
        [Route("produtos/excluir")]
        public ActionResult ExcluirPost(int id)
        {
            var conexao = new ProdutoService();

            conexao.RemoverProduto(id);

            return Redirect("/produtos/listar");
        }
    }

}
