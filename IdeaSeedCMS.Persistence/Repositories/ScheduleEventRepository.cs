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
    public class ScheduleEventRepository : BaseRepository<ScheduleEvent, int>
    {
        public IList<ScheduleEvent> GetByFilters(string name, DateTime? startTime, DateTime? endTime, int? staffID, int? eventTypeID)
        {
            var list = new List<SearchCriterion>();
            if (!string.IsNullOrEmpty(name))
                list.Add(new SearchCriterion("Name", Operators.EQUALS, name));
            if (startTime != null)
                list.Add(new SearchCriterion("StartTime", Operators.GREATER_THAN, startTime));
            if (endTime != null)
                list.Add(new SearchCriterion("EndTime", Operators.GREATER_THAN, endTime));
            if (staffID != null)
                list.Add(new SearchCriterion("StaffID", Operators.EQUALS, staffID));
            if (eventTypeID != null)
                list.Add(new SearchCriterion("EventTypeID", Operators.EQUALS, eventTypeID));
            ICriteria query = Session.CreateCriteria<ScheduleEvent>();
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
            return query.List<ScheduleEvent>();
        }
    }
}
