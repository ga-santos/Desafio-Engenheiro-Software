﻿using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces.Services
{
    public interface IRabbitService
    {
        void PublicarPedido(Pedido pedido);
    }
}
