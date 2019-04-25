using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator.Validation;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class Experimento : EntityBase
    {

        private readonly IList<ExperimentoTramento> _experimentoPlantas;
        private readonly IList<Bloco> _blocos;
        private Random _getrandom = new Random();

        public Experimento(Nome nome, int qtdRepeticao)
        {
            Nome = nome;
            DataInicio = DateTime.Now;
            QtdRepeticao = qtdRepeticao;
            _experimentoPlantas = new List<ExperimentoTramento>();
            _blocos = new List<Bloco>();

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(QtdRepeticao, "QtdRepeticao", "Quantidade Repeticao e obrigatoria")
            );
        }

        //Para o EF
        protected Experimento()
        {
            _experimentoPlantas = new List<ExperimentoTramento>();
            _blocos = new List<Bloco>();
        }

        public Nome Nome { get; protected set; }
        public string Codigo { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime? DataConclusao { get; protected set; }
        public int QtdRepeticao { get; protected set; }
        public EExperimentoStatus Status { get; protected set; }
        public ICollection<ExperimentoTramento> ExperimentoTramentos => _experimentoPlantas.ToArray();
        //public AreaExperimento AreaExperimento { get; protected set; }
        public ICollection<Bloco> Blocos => _blocos.ToArray();

        public void AddTratamento(ExperimentoTramento tramento)
        {
            _experimentoPlantas.Add(tramento);
        }

        public void RemoveTratamento(ExperimentoTramento tramento)
        {
            _experimentoPlantas.Remove(tramento);
        }

        public void AddBloco(Bloco bloco)
        {
            _blocos.Add(bloco);
        }
        public void RemoveBloco(Bloco bloco)
        {
            _blocos.Remove(bloco);
        }

        public void Arquivar()
        {
            Status = EExperimentoStatus.Aberto;
            Codigo = "0";
        }

        public void Gerar()
        {
            if (_experimentoPlantas.Count == 0)
            {
                AddNotification("Plantas", "Experimento deve conter pelos uma Tratamento");
                return;
            }

            Status = EExperimentoStatus.EmAdamento;
            Codigo = Id + "-" + QtdRepeticao + "-" + _experimentoPlantas.Count;
            GerarAreaExperimento();
        }

        public void Cancelar()
        {
            Status = EExperimentoStatus.Cancelado;
        }

        public void Concluir()
        {
            Status = EExperimentoStatus.Concluido;
            DataConclusao = DateTime.Now;
        }

        public void GerarAreaExperimento()
        {
            // var area = new AreaExperimento(this);
            for (int qtd = 0; qtd < QtdRepeticao; qtd++)
            {
                var bloco = new Bloco("B" + (qtd + 1), this);
                int count = 1;
                foreach (var planta in _experimentoPlantas)
                {
                    //Aqui aonde faz o sorteio
                    int seq = GerarSequencia(_experimentoPlantas.Count);
                    //Nesse laço verifica se com o sorteio não há um tratamento já na lista
                    while (checarSequencia(seq, bloco))
                    {
                        seq = GerarSequencia(_experimentoPlantas.Count);
                    }

                    var blocoPlanta = new BlocoTratamento("P" + seq, bloco, _experimentoPlantas[seq - 1].Tratamento, count);
                    bloco.AddPlanta(blocoPlanta);
                    count++;
                }
                AddBloco(bloco);
                ReiniciarSorteio();
                //area.AddBloco(bloco);
            }
            // AddAreaExperimento(area);
        }


        private bool checarSequencia(int valor, Bloco bloco)
        {
            return bloco.BlocoTratamentos.Any(item => item.NomeParcela.Equals("P" + valor));
        }

        private void ReiniciarSorteio()
        {
            _getrandom = new Random();
        }

        private int GerarSequencia(int tamnhoArray)
        {
            lock (_getrandom) // synchronize
            {
                return _getrandom.Next(1, tamnhoArray + 1);
            }
        }

        public override bool Validated()
        {
            AddNotifications(Nome.Notifications);
            if (_experimentoPlantas.Count == 0)
                AddNotification("Plantas", "Experimento deve conter pelos uma Tratamento");

            return Valid;
        }


    }


}
