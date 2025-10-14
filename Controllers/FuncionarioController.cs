using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using TrilhaNetAzureDesafio.Context;
using TrilhaNetAzureDesafio.Models;

namespace TrilhaNetAzureDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {

        private readonly RHContext _context;
        private readonly string _connectionString;
        private readonly string _tableName;

        public FuncionarioController(RHContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetValue<string>("ConnectionStrings:SAConnectionString") ?? string.Empty;
            _tableName = configuration.GetValue<string>("ConnectionStrings:AzureTableName") ?? "FuncionarioLogs";
        }

        private TableClient? GetTableClient()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                return null;

            try
            {
                var serviceClient = new TableServiceClient(_connectionString);
                var tableClient = serviceClient.GetTableClient(_tableName);
                tableClient.CreateIfNotExists();
                return tableClient;
            }
            catch
            {
                // Se algo falhar (ex: connectionString inválida), retornamos null para não quebrar a API local
                return null;
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
                return NotFound();
            return Ok(funcionario);
        }

        [HttpPost]
        public IActionResult Criar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges(); // salva no SQL

            // criar log
            var tableClient = GetTableClient();
            var partitionKey = funcionario.Departamento ?? "Geral";
            var rowKey = Guid.NewGuid().ToString();
            var funcionarioLog = new FuncionarioLog(funcionario, TipoAcao.Inclusao, partitionKey, rowKey);

            if (tableClient != null)
            {
                try
                {
                    tableClient.UpsertEntity(funcionarioLog, TableUpdateMode.Merge);
                }
                catch
                {
                    // não propagar exceção para o cliente se Table Storage não estiver configurado
                }
            }

            return CreatedAtAction(nameof(ObterPorId), new { id = funcionario.Id }, funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(id);
            if (funcionarioBanco == null)
                return NotFound();

            // Atualiza todas as propriedades
            funcionarioBanco.Nome = funcionario.Nome;
            funcionarioBanco.Endereco = funcionario.Endereco;
            funcionarioBanco.Ramal = funcionario.Ramal;
            funcionarioBanco.EmailProfissional = funcionario.EmailProfissional;
            funcionarioBanco.Departamento = funcionario.Departamento;
            funcionarioBanco.Salario = funcionario.Salario;
            funcionarioBanco.DataAdmissao = funcionario.DataAdmissao;

            _context.Funcionarios.Update(funcionarioBanco);
            _context.SaveChanges();

            // salvar log
            var tableClient = GetTableClient();
            var partitionKey = funcionarioBanco.Departamento ?? "Geral";
            var rowKey = Guid.NewGuid().ToString();
            var funcionarioLog = new FuncionarioLog(funcionarioBanco, TipoAcao.Atualizacao, partitionKey, rowKey);

            if (tableClient != null)
            {
                try
                {
                    tableClient.UpsertEntity(funcionarioLog, TableUpdateMode.Merge);
                }
                catch
                {
                    // ignora falha de Table Storage
                }
            }

            return Ok(funcionarioBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var funcionarioBanco = _context.Funcionarios.Find(id);
            if (funcionarioBanco == null)
                return NotFound();

            _context.Funcionarios.Remove(funcionarioBanco);
            _context.SaveChanges();

            var tableClient = GetTableClient();
            var partitionKey = funcionarioBanco.Departamento ?? "Geral";
            var rowKey = Guid.NewGuid().ToString();
            var funcionarioLog = new FuncionarioLog(funcionarioBanco, TipoAcao.Remocao, partitionKey, rowKey);

            if (tableClient != null)
            {
                try
                {
                    tableClient.UpsertEntity(funcionarioLog, TableUpdateMode.Merge);
                }
                catch
                {
                    // ignora falha
                }
            }

            return NoContent();

        }
    }
}