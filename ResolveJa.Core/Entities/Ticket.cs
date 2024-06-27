﻿using ResolveJa.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public string Titulo { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public TicketStatusEnum Status { get; private set; }
        public string Conteudo { get; private set; }
        public string Resposta { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataFechamento { get; private set; }

    }
}
