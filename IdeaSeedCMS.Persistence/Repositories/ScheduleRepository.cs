using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Persistence.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule, int>
    {
        public IList<Schedule> GetByFilters(string name, int? eventID)
        {
            var list = new List<SearchCriterion>();
            if (!string.IsNullOrEmpty(name))
                list.Add(new SearchCriterion("Name", Operators.EQUALS, name));
            if (eventID != null)
                list.Add(new SearchCriterion("ScheduleEventID", Operators.EQUALS, eventID));
            ICriteria query = Session.CreateCriteria<Schedule>();
            foreach (var l in list)
            {
                switch (l.Operator)
                {
                    case Operators.EQUALS:
                        query.Add(Restrictions.Eq(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.GREATER_THAN:
                        query.Add(Restrictions.Ge(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.LESS_THAN:
                        query.Add(Restrictions.Le(l.SearchColumn, l.SearchCriteria));
                        break;
                }
            }
            return query.List<Schedule>();
        }
    }
}
