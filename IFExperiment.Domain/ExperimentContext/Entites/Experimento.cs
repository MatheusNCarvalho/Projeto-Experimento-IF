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

        private readonly IList<Planta> _plantas;
        private readonly IList<AreaExperimento> _areaExperimentos;

        public Experimento(Nome nome, int qtdRepeticao)
        {
            Nome = nome;
            DataInicio = DateTime.Now;
            QtdRepeticao = qtdRepeticao;
            Status = EExperimentoStatus.Aberto;
            _plantas = new List<Planta>();
            _areaExperimentos = new List<AreaExperimento>();

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(QtdRepeticao, "QtdRepeticao", "Quantidade Repeticao e obrigatoria")
            );
        }

        public Nome Nome { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataConclusao { get; protected set; }
        public int QtdRepeticao { get; protected set; }
        public EExperimentoStatus Status { get; protected set; }
        public IReadOnlyCollection<Planta> Plantas => _plantas.ToArray();
        public IReadOnlyCollection<AreaExperimento> AreaExperimentos => _areaExperimentos.ToArray();

        public void AddPlanta(Planta planta)
        {

            _plantas.Add(planta);
        }

        public void RemovePlanta(Planta planta)
        {
            _plantas.Remove(planta);
        }

        public void GerarAreaExperimento()
        {
            var area = new AreaExperimento(this);
            for (int qtd = 0; qtd < QtdRepeticao; qtd++)
            {
                var bloco = new Bloco("B" + qtd + 1);
                int count = 1;
                foreach (var planta in _plantas)
                {
                    //Aqui aonde faz o sorteio
                    int seq = GerarSequencia(_plantas.Count);
                    while (checarSequencia(seq, bloco))
                    {
                        seq = GerarSequencia(_plantas.Count);
                    }

                    var blocoPlanta = new BlocoPlanta("V" + seq, bloco, planta);
                    bloco.AddPlanta(seq, blocoPlanta);
                    count++;
                }
                area.AddBloco(bloco);
            }

            _areaExperimentos.Add(area);


        }

        private bool checarSequencia(int valor, Bloco bloco)
        {
            if (bloco.BlocoPlantas.Any(item => item.Nome.Equals("V" + valor)))
                return true;
            return false;
        }
        private int GerarSequencia(int tamnhoArray)
        {
            Random rdn = new Random();
            int valor;
            valor = rdn.Next(1, tamnhoArray + 1);
            return valor;
        }

        public override bool Validated()
        {
            AddNotifications(Nome.Notifications);
            if (_plantas.Count == 0)
                AddNotification("Plantas", "Experimento deve conter pelos uma Planta");

            return Valid;
        }


    }


}
