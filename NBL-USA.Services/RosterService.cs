using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Services
{
    public class RosterService
    {
        public bool CreateRoster(Roster model)
        {
            var entity =
                new Roster()
                {
                    CoachName = model.CoachName,
                    AssistantCoachName = model.AssistantCoachName,
                    StillActive = model.StillActive
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Rosters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RosterListItem> GetRosters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rosters
                        .Select(
                        e =>
                        new RosterListItem
                        {
                            RosterId = e.RosterId,
                            CoachName = e.CoachName,
                            AssistantCoachName = e.AssistantCoachName
                        });
                return query.ToArray();
            }
        }

        public RosterDetail GetRosterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rosters
                        .Single(e => e.RosterId == id);
                return
                    new RosterDetail
                    {
                        RosterId = entity.RosterId,
                        CoachName = entity.CoachName,
                        AssistantCoachName = entity.AssistantCoachName,
                        StillActive = entity.StillActive
                    };
            }
        }

        public bool UpdateRoster(RosterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rosters
                        .Single(e => e.RosterId == model.RosterId);
                entity.CoachName = model.CoachName;
                entity.AssistantCoachName = model.AssistantCoachName;
                entity.StillActive = model.StillActive;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoster(int rosterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Rosters
                    .Single(e => e.RosterId == rosterId);
                ctx.Rosters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
