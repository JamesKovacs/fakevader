using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace FakeVader.Core.Mapping {
    public class HasManyConvention : IHasManyConvention {
        public void Apply(IOneToManyCollectionInstance target)
        {
            target.Cascade.AllDeleteOrphan();
            target.Inverse();
        }
    }
}