using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Services
{
    public class FrontOfficeStaffService
    {
        public bool CreateFrontOfficeStaff(FrontOfficeStaff model)
        {
            var entity =
                new FrontOfficeStaff()
                {
                    TeamGeneralManagerName = model.TeamGeneralManagerName,
                    AcademicAdvisorName = model.AcademicAdvisorName,
                    DirectorOfBasketballOperationsName = model.DirectorOfBasketballOperationsName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FrontOfficeStaffs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FrontOfficeStaffListItem> GetFrontOfficeStaffs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FrontOfficeStaffs
                    .Select(
                        e => 
                        new FrontOfficeStaffListItem
                        {
                            FrontOfficeStaffId = e.FrontOfficeStaffId,
                            TeamGeneralManagerName = e.TeamGeneralManagerName,
                            AcademicAdvisorName = e.AcademicAdvisorName,
                            DirectorOfBasketballOperationsName = e.DirectorOfBasketballOperationsName
                        }
                        );
                return query.ToArray();

            }
        }

        public FrontOfficeStaffDetail GetFrontOfficeStaffById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FrontOfficeStaffs
                        .Single(e => e.FrontOfficeStaffId == id);
                return
                    new FrontOfficeStaffDetail
                    {
                        FrontOfficeStaffId = entity.FrontOfficeStaffId,
                        TeamGeneralManagerName = entity.TeamGeneralManagerName,
                        AcademicAdvisorName = entity.AcademicAdvisorName,
                        DirectorOfBasketballOperationsName = entity.DirectorOfBasketballOperationsName
                    };
            }
        }

        public bool UpdateFrontOfficeStaff (FrontOfficeStaffEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FrontOfficeStaffs
                        .Single(e => e.FrontOfficeStaffId == model.FrontOfficeStaffId);
                entity.TeamGeneralManagerName = model.TeamGeneralManagerName;
                entity.AcademicAdvisorName = model.AcademicAdvisorName;
                entity.DirectorOfBasketballOperationsName = model.DirectorOfBasketballOperationsName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFrontOfficeStaff (int frontOfficeStaffId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .FrontOfficeStaffs
                    .Single(e => e.FrontOfficeStaffId == frontOfficeStaffId);

                ctx.FrontOfficeStaffs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
