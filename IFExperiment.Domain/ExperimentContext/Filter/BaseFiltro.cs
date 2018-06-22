using System;
using System.Linq.Expressions;

namespace IFExperiment.Domain.ExperimentContext.Filter
{
    public abstract class BaseFiltro<T> where T: class 
    {
        public int ItemPerPage { get; set; }
        public int Page { get; set; }

        public abstract Expression<Func<T, bool>> MountExpression();
    }
}
