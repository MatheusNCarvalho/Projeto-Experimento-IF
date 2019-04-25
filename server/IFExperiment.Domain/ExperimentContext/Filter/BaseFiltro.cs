using System;
using System.Linq.Expressions;

namespace IFExperiment.Domain.ExperimentContext.Filter
{
    public abstract class BaseFiltro<T> where T: class 
    {

        public int Offset { get; set; }
        public int Limit { get; set; }

        public abstract Expression<Func<T, bool>> MountExpression();
    }
}
