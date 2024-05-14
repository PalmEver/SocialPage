using Domain;
using Persistence;

namespace Api.Seed
{
    public class UserSeed
    {
        public static async Task SeedData(UserContext context)
        {
            if (context.Users.Any()) return;

            string joel = "joel";
            string karl = "karl";
            string mats = "mats";
            string hampus = "hampus";
            string robert = "robert";
            var users = new List<User>
            {
                new User
                {
                    Name = "joel",
                    Email = "joel@joel.com",
                    Password = BCrypt.Net.BCrypt.HashPassword(joel),
                    Posts = new List<Posts>
                    {
                        new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Look I made a post",
                        }
                    },
                     Messages = new List<Messages>
                    {
                        new Messages
                        {
                            MessageId = 3,
                            Message = "owow",
                            Date = DateTime.Now.AddMonths(-1),
                            Name = "Mats"
                        },
                        new Messages
                        {
                            MessageId = 3,
                            Message = "asdfghj",
                            Date = DateTime.Now.AddMonths(-2),
                            Name = "Mats"
                        },
                        new Messages
                        {
                            MessageId = 3,
                            Message = "szdxfcgvhbjk",
                            Date = DateTime.Now.AddMonths(-3),
                            Name = "Mats"
                        }
                    }
                },
                new User
                {
                    Name = "karl",
                    Email = "karl@karl.com",
                    Password = BCrypt.Net.BCrypt.HashPassword(karl),
                    Posts = new List<Posts>
                    {
                        new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Look mommy I made a post",
                        }
                    }
                },
                new User
                {
                    Name = "mats",
                    Email = "mats@mats.com",
                    Password = BCrypt.Net.BCrypt.HashPassword(mats),
                    Posts = new List<Posts>
                    {
                        new Posts
                        {
                            Date = DateTime.Now,
                            Description = "I eAT ProTiEN",
                        }
                    },
                    Followers = new List<Followers>
                    {
                        new Followers
                        {
                            FollowId = 1,
                        },
                        new Followers
                        {
                            FollowId = 2,
                        },
                        new Followers
                        {
                            FollowId = 5,
                        }
                    },
                    Messages = new List<Messages>
                    {
                        new Messages
                        {
                            MessageId = 1,
                            Message = "Dank I send Message to you",
                            Date = DateTime.Now.AddMonths(-1),
                            Name = "Joel"
                        },
                        new Messages
                        {
                            MessageId = 1,
                            Message = "Dank I send Message to you",
                            Date = DateTime.Now.AddMonths(-2),
                            Name = "Joel"
                        },
                        new Messages
                        {
                            MessageId = 1,
                            Message = "Dank I send Message to you",
                            Date = DateTime.Now.AddMonths(-3),
                            Name = "Joel"
                        },
                         new Messages
                        {
                            MessageId = 2,
                            Message = "wadawdawd",
                            Date = DateTime.Now.AddMonths(-1),
                        },
                         new Messages
                        {
                            MessageId = 3,
                            Message = "wadwad",
                            Date = DateTime.Now.AddMonths(-1),
                        },
                         new Messages
                        {
                            MessageId = 4,
                            Message = "dwadawd",
                            Date = DateTime.Now.AddMonths(-1),
                        },
                    }
                },
                new User
                {
                    Name = "hampus",
                    Email = "hampus@hampus.com",
                    Password = BCrypt.Net.BCrypt.HashPassword(hampus),
                    Posts = new List<Posts>
                    {
                        new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Music 'n' Shit",
                        }
                    }
                },
                new User
                {
                    Name = "robert",
                    Email = "robert@robert.com",
                    Password = BCrypt.Net.BCrypt.HashPassword(robert),
                    Posts = new List<Posts>
                    {
                        new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Look I Teach and Stuff",
                        }
                    }
                },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}