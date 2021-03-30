using Broadway.BugTracker.Model;
using Broadway.BugTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.BugTracker.Service
{
    public class WorkItemService
    {
        private BugTrackerContext db = new BugTrackerContext();

        public (bool, string) CreateWorkItem(WorkItems item)
        {
            try
            {
                db.WorkItem.Add(item);
                db.SaveChanges();
                return (true, "WorkItem Created Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public List<WorkItemViewModel> GetAll()
        {
            var workitems = db.WorkItem.ToList();

            #region type1
            //// type 1:
            //var list = new List<WorkItemViewModel>();
            //foreach (var item in workitems)
            //{
            //    var workitemviewmodel = new WorkItemViewModel();
            //    workitemviewmodel.Id = item.Id;
            //    workitemviewmodel.Title = item.Title;
            //    if (item.Asignee==null)
            //    {
            //        workitemviewmodel.AssigneeName = "";
            //    }
            //    else
            //    {
            //        workitemviewmodel.AssigneeName = item.Asignee.UserName;
            //    }

            //    workitemviewmodel.AssigneeName = item.Asignee == null ? "" : item.Asignee.UserName;

            //    workitemviewmodel.ReporterName = item.Reporter == null ? "" : item.Reporter.UserName;
            //    list.Add(workitemviewmodel);
            //}
            //// type1: end
            #endregion

            #region Type2

            ////type 2 : linq query
            //var listofworkItemViewModel = (from item in workitems select new WorkItemViewModel {
            //    Id=item.Id,
            //     AssigneeName = item.Asignee==null ? "" : item.Asignee.UserName,
            //      ReporterName= item.Reporter==null? "": item.Reporter.UserName,
            //      Title=item.Title
            //}).ToList();
            ////type2 end
            #endregion

            #region Type 3

            //type 3
            var listworkitems = workitems.Select(p => new WorkItemViewModel { 
                Id=p.Id,
                AssigneeName=p.Asignee==null? "": p.Asignee.UserName,
                ReporterName=p.Reporter==null? "" : p.Reporter.UserName,
                Title=p.Title,
                Status=p.Status
            }).ToList();
            return listworkitems;
            //type 3 end
            #endregion

            //return db.WorkItem.ToList().Select(p => new WorkItemViewModel { 
            //     Id=p.Id,
            //     Title=p.Title,
            //     AssigneeName=p.Asignee==null?"":p.Asignee.UserName, 
            //     ReporterName= p.Reporter==null?"":p.Reporter.UserName
            //}).ToList();
        }
        public WorkItems GetbyId(int id)
        {
            return db.WorkItem.Find(id);
        }

        public (bool, string) ChangeStateofWorkItem(int id, WorkItemStatus status)
        {
            try
            {
                var item = db.WorkItem.Find(id);
                if (item==null)
                {
                    return (false, "Item not found");
                }
                else
                {
                    item.Status = status;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return (true, "item updated");
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
