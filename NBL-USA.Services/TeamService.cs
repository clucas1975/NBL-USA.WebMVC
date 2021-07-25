using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Services
{
    public class TeamService
    {
        public bool CreateTeam(Team model)
        {
            var entity =
                new Team()
                {
                    TeamOwner = model.TeamOwner,
                    TeamName = model.TeamName,
                    TeamLocation = model.TeamLocation,
                    TeamArena = model.TeamArena
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                        .Teams
                        .Select(
                           e =>
                           new TeamListItem
                           {
                               TeamId = e.TeamId,
                               TeamOwner = e.TeamOwner,
                               TeamName = e.TeamName,
                               TeamLocation = e.TeamLocation,
                               TeamArena = e.TeamArena
                           });
                return query.ToArray();
            }

        }

        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamOwner = entity.TeamOwner,
                        TeamName = entity.TeamName,
                        TeamLocation = entity.TeamLocation,
                        TeamArena = entity.TeamArena
                    };
            }
        }

        public bool UpdateTeam (TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId);
                entity.TeamOwner = model.TeamOwner;
                entity.TeamName = model.TeamName;
                entity.TeamLocation = model.TeamLocation;
                entity.TeamArena = model.TeamArena;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteTeam (int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Teams
                    .Single(e => e.TeamId == teamId);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

               

        }
    }
}
