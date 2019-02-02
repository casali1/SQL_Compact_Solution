using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQL_Compact_Solution.Models;
using SQL_Compact_Solution.Context;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TestCompact
    {
        [Test]
        public void RunSQL_Compact()
        {
            using (DvdContext db = new DvdContext())
            {
                // film generes
                FilmGenere actionGenere = db.FilmGeneres.Where(g => g.Name == "Action").SingleOrDefault();

                FilmGenere scifiGenere = db.FilmGeneres.Where(g => g.Name == "SciFi").SingleOrDefault();

                // find the producer
                Producer jjAbrams = db.Producers.Where(p => p.FullName == "J.J. Abrams").SingleOrDefault();

                // we found the producer

                if (jjAbrams != null)
                {
                    // add some films to that producer

                    FilmTitle film1 = new FilmTitle()
                    {
                        Title = "Mission: Impossible III",

                        Duration = 126,

                        Story = "Ethan Hunt comes face to face with a dangerous and ...",

                        FilmGenere = actionGenere
                    };

                    film1.Producers = new List<Producer>();

                    film1.Producers.Add(jjAbrams);

                    db.FilmTitles.Add(film1);

                    FilmTitle film2 = new FilmTitle()
                    {
                        Title = "Star Trek Into Darkness",

                        Duration = 132,

                        Story = "After the crew of the Enterprise find an unstoppable force  ...",

                        FilmGenere = scifiGenere
                    };

                    film2.Producers = new List<Producer>();

                    film2.Producers.Add(jjAbrams);

                    db.FilmTitles.Add(film2);

                    // add some film roles
                    Role leadRole = db.Roles.Where(r => r.Name == "Lead").SingleOrDefault();

                    Role supportingRole = db.Roles.Where(r => r.Name == "Supporting").SingleOrDefault();

                    // load the actors
                    Actor tom = db.Actors.Where(a => a.Surname == "Cruise").SingleOrDefault();

                    Actor quinto = db.Actors.Where(a => a.Surname == "Quinto").SingleOrDefault();

                    Actor pine = db.Actors.Where(a => a.Surname == "Pine").SingleOrDefault();

                    // add filmroles

                    db.FilmActorRoles.Add(new FilmActorRole()
                    {
                        Actor = tom,

                        Role = leadRole,

                        FilmTitle = film1,

                        Character = "Ethan",

                        Description = "Ethan Hunt comes face to face with a dangerous and sadistic arms dealer while trying to keep his identity secret in order to protect his girlfriend."
                    });

                    db.FilmActorRoles.Add(new FilmActorRole()
                    {
                        Actor = pine,

                        Role = leadRole,

                        FilmTitle = film2,

                        Character = "Kirk",

                        Description = "Captain Kirk"
                    });

                    db.FilmActorRoles.Add(new FilmActorRole()
                    {
                        Actor = quinto,

                        Role = supportingRole,

                        FilmTitle = film2,

                        Character = "Spock",

                        Description = "Spock was born in 2230, in the city of Shi'Kahr on the planet Vulcan"
                    });

                }

                // save data to db

                db.SaveChanges();

                db.Dispose();
            }
        }
    }
}