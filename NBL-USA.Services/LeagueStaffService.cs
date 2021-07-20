using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Services
{
    public class LeagueStaffService
    {
        private readonly Guid _userId;

        public LeagueStaffService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLeagueStaff(LeagueStaff model)
        {
            var entity =
                new LeagueStaff()
                {
                    OwnerId = _userId,
                    LeagueStaffName = model.LeagueStaffName,
                    LeagueStaffPosition = model.LeagueStaffPosition,
                    LeagueStaffStillWorking = model.LeagueStaffStillWorking
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LeagueStaffs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeagueStaffListItem> GetLeagueStaffs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .LeagueStaffs
                        .Where(e => e.OwnerId == _userId)
                        .Select(e => new LeagueStaffListItem
                        {
                            LeagueStaffId = e.LeagueStaffId,
                            LeagueStaffName = e.LeagueStaffName,
                            LeagueStaffPosition = e.LeagueStaffPosition
                        });
                return query.ToArray();
            }
        }

        public LeagueStaffDetail GetLeagueStaffById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LeagueStaffs
                        .Single(e => e.LeagueStaffId == id && e.OwnerId == _userId);
                return
                    new LeagueStaffDetail
                    {
                        LeagueStaffId = entity.LeagueStaffId,
                        LeagueStaffName = entity.LeagueStaffName,
                        LeagueStaffPosition = entity.LeagueStaffPosition
                    };
            }
        }            
       
        public bool UpdateLeagueStaff(LeagueStaffEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LeagueStaffs
                        .Single(e => e.LeagueStaffId == model.LeagueStaffId && e.OwnerId == _userId);
                entity.LeagueStaffName = model.LeagueStaffName;
                entity.LeagueStaffPosition = model.LeagueStaffPosition;

                return ctx.SaveChanges() == 1;
            }
        }

    }   
}
