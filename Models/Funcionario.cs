using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilhaNetAzureDesafio.Models
{
    public class Funcionario
    {
        public Funcionario() { }

        public Funcionario(int id, string nome, string endereco, string ramal, string emailProfissional, string departamento, decimal salario, DateTimeOffset? dataAdmissao)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Ramal = ramal;
            EmailProfissional = emailProfissional;
            Departamento = departamento;
            Salario = salario;
            DataAdmissao = dataAdmissao;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public string EmailProfissional { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateTimeOffset? DataAdmissao { get; set; }
        
    }
}