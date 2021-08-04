using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Services
{
   public class PlayersService
    {
        public bool CreatePlayers(PlayersCreate model)
        {
            var entity =
                new Players()
                {
                    PlayerName = model.PlayerName,
                    PlayerNumber = model.PlayerNumber,
                    PlayerPosition = model.PlayerPosition,
                    PlayerHeight = model.PlayerHeight,
                    PlayerWeight = model.PlayerWeight,
                    RosterId = model.RosterId
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayersListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Players
                    .Select(
                        e =>
                        new PlayersListItem
                        {
                            PlayerId = e.PlayerId,
                            PlayerName = e.PlayerName,
                            PlayerNumber = e.PlayerNumber,
                            PlayerPosition = e.PlayerPosition,
                            PlayerHeight = e.PlayerHeight,
                            PlayerWeight = e.PlayerWeight,
                            RosterId = e.RosterId
                        });
                return query.ToArray();
            }
        }

        public PlayersDetail GetPlayersById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == id);
                return
                    new PlayersDetail
                    {
                        PlayerId = entity.PlayerId,
                        PlayerName = entity.PlayerName,
                        PlayerNumber = entity.PlayerNumber,
                        PlayerPosition = entity.PlayerPosition,
                        PlayerHeight = entity.PlayerHeight,
                        PlayerWeight = entity.PlayerWeight,
                        RosterId = entity.RosterId
                    };
            }
        }

        public bool UpdatePlayers(PlayersEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId);
                entity.PlayerId = model.PlayerId;
                entity.PlayerName = model.PlayerName;
                entity.PlayerNumber = model.PlayerNumber;
                entity.PlayerPosition = model.PlayerPosition;
                entity.PlayerHeight = model.PlayerHeight;
                entity.PlayerWeight = model.PlayerWeight;
                entity.RosterId = model.RosterId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayers (int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Players
                    .Single(e => e.PlayerId == playerId);
                ctx.Players.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
   }
}
