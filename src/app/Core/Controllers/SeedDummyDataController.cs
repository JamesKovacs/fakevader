using System;
using System.Transactions;
using System.Web.Mvc;
using FakeVader.Core.Domain;
using FakeVader.Core.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Linq;

namespace FakeVader.Core.Controllers {
    public class SeedDummyDataController : Controller {
        public SeedDummyDataController(Configuration cfg, IRepository<Post> repository) {
            this.cfg = cfg;
            this.repository = repository;
        }

        public ActionResult Index() {
            CreateDatabaseSchema(cfg);

            using(var scope = new TransactionScope()) {
                foreach(var quote in quotes) {
                    var title = string.Join(" ", quote.Split(' ').Take(5).ToArray());
                    var post = new Post(title, quote, DateTime.Now.AddMilliseconds(-Math.Abs(quote.GetHashCode())));
                    repository.Save(post);
                }
                scope.Complete();
            }
            return View();
        }

        private static void CreateDatabaseSchema(Configuration cfg) {
            new SchemaExport(cfg).Execute(true, true, false);
        }

        private readonly Configuration cfg;
        private readonly IRepository<Post> repository;
        private readonly string[] quotes = {
                                               "I find your lack of faith disturbing.",
                                               "You don't know the power of the dark side!",
                                               "Luke, I am your father!.",
                                               "Today will be a day long remembered. It has seen the death of Kenobi, and soon the fall of the rebellion.",
                                               "The force is strong with this one.",
                                               "I sense something, a presence I've not felt since.......",
                                               "You should not have come back!",
                                               "The ability to destroy a planet is insignificant next to the power of the force.",
                                               "Just for once, let me look at your face with my own eyes.",
                                               "I've been waiting for you, Obi-wan. We meet again at last. The circle is now complete. When I left you I was but the learner. Now I am the master.",
                                               "Perhaps I can find new ways to motivate them.",
                                               "Obi-Wan has taught you well.",
                                               "Obi-Wan once thought as you do. You don't know the power of the Dark Side, I must obey my master.",
                                               "It is too late for me, son. The Emperor will show you the true nature of the Force. He is your master now.",
                                               "You are unwise to lower your defenses!",
                                               "As you wish.",
                                               "No. Leave them to me. I will deal with them myself.",
                                               "My son is with them.",
                                               "You cannot hide forever, Luke.",
                                               "Don't fail me again, Admiral.",
                                               "Asteroids do not concern me, Admiral. I want that ship, not excuses.",
                                               "He will join us or die, my master.",
                                               "Alert all commands. Calculate every possible destination along their last known trajectory.",
                                               "Impressive. Most impressive. Obi-Wan has taught you well. You have controlled your fear. Now, release your anger. Only your hatred can destroy me.",
                                               "The force is with you, young Skywalker, but you are not a Jedi yet.",
                                               "What is thy bidding, my master?",
                                               "When I left you I was but the learner. Now I am the master."
                                           };
    }
}