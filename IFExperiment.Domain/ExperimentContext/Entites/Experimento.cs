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

        private readonly IList<ExperimentoPlanta> _experimentoPlantas;

        public Experimento(Nome nome, int qtdRepeticao)
        {
            Nome = nome;
            DataInicio = DateTime.Now;
            QtdRepeticao = qtdRepeticao;
            _experimentoPlantas = new List<ExperimentoPlanta>();

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(QtdRepeticao, "QtdRepeticao", "Quantidade Repeticao e obrigatoria")
            );
        }

        public Nome Nome { get; protected set; }
        public string Codigo { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataConclusao { get; protected set; }
        public int QtdRepeticao { get; protected set; }
        public EExperimentoStatus Status { get; protected set; }
        public IReadOnlyCollection<ExperimentoPlanta> Plantas => _experimentoPlantas.ToArray();
        public AreaExperimento AreaExperimento { get; protected set; }

        public void AddPlanta(ExperimentoPlanta planta)
        {
            _experimentoPlantas.Add(planta);
        }

        public void RemovePlanta(ExperimentoPlanta planta)
        {
            _experimentoPlantas.Remove(planta);
        }

        public void AddAreaExperimento(AreaExperimento area)
        {
            if (area == null)
                AddNotification("AreaExperimento", "Area Experimento, é obrigatorio");

            AreaExperimento = area;
        }

        public void Arquivar()
        {
            Status = EExperimentoStatus.Aberto;
        }

        public void Gerar()
        {
            if (_experimentoPlantas.Count == 0)
            {
                AddNotification("Plantas", "Experimento deve conter pelos uma Planta");
                return;
            }

            Status = EExperimentoStatus.EmAdamento;
            Codigo = Id + "-" + QtdRepeticao + "-" + _experimentoPlantas.Count;
            GerarAreaExperimento();
        }

        public void Cancelar()
        {
            Status = EExperimentoStatus.Cancelado;
            AreaExperimento.Cancelar();
        }

        public void Concluir()
        {
            Status = EExperimentoStatus.Concluido;
            DataConclusao = DateTime.Now;
        }

        public void GerarAreaExperimento()
        {
            var area = new AreaExperimento(this);
            for (int qtd = 0; qtd < QtdRepeticao; qtd++)
            {
                var bloco = new Bloco("B" + qtd + 1);
                int count = 1;
                foreach (var planta in _experimentoPlantas)
                {
                    //Aqui aonde faz o sorteio
                    int seq = GerarSequencia(_experimentoPlantas.Count);
                    while (checarSequencia(seq, bloco))
                    {
                        seq = GerarSequencia(_experimentoPlantas.Count);
                    }

                    var blocoPlanta = new BlocoPlanta("V" + seq, bloco, planta.Planta);
                    bloco.AddPlanta(blocoPlanta);
                    count++;
                }
                area.AddBloco(bloco);
            }
            AddAreaExperimento(area);
        }


        private bool checarSequencia(int valor, Bloco bloco)
        {
            return bloco.BlocoPlantas.Any(item => item.NomeLinha.Equals("V" + valor));
        }
        private int GerarSequencia(int tamnhoArray)
        {
            Random rdn = new Random();
            var valor = rdn.Next(1, tamnhoArray + 1);
            return valor;
        }

        public override bool Validated()
        {
            AddNotifications(Nome.Notifications);
            if (_experimentoPlantas.Count == 0)
                AddNotification("Plantas", "Experimento deve conter pelos uma Planta");

            return Valid;
        }


    }


}
