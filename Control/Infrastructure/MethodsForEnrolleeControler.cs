using Control.Models;
using Control.ViewModels.Functional;
using System.Linq;

namespace Control.Infrastructure
{
    public static class MethodsForEnrolleeControler
    {
        public static void SortEnrollees(ref IQueryable<Enrollee> enrollees, SortState sortList)
        {
            switch (sortList)
            {
                case SortState.NameDesc:
                    enrollees = enrollees.OrderByDescending(a => a.Name);
                    break;

                case SortState.AgeAsc:
                    enrollees = enrollees.OrderBy(a => a.Birthday);
                    break;

                case SortState.AgeDesc:
                    enrollees = enrollees.OrderByDescending(a => a.Birthday);
                    break;

                case SortState.DateDesc:
                    enrollees = enrollees.OrderBy(a => a.Date);
                    break;

                case SortState.DateAsc:
                    enrollees = enrollees.OrderByDescending(a => a.Date);
                    break;

                default:
                    enrollees = enrollees.OrderBy(a => a.Name);
                    break;
            }
        }

        public static void FilterEnrollees(ref IQueryable<Enrollee> enrollees, int? specialityId, string name)
        {
            if (specialityId != null && specialityId != 0)
            {
                enrollees = enrollees.Where(a => a.SpecialtyId == specialityId);
            }
            if (!string.IsNullOrEmpty(name))
            {
                enrollees = enrollees.Where(a => a.Name.Contains(name));
            }
        }
    }
}