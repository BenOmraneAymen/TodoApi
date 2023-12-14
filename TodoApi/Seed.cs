using System.Diagnostics.Metrics;
using TodoApi.Data;
using TodoApi.Models;

namespace TododoApi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                var Users = new List<User>()
                {
                    new User()
                    {
                        Userame="aymen",
                        Email="aymen@gmail.com",
                        Password="Password",
                        Todos =
                        {
                            new Todo()
                            {
                                Title="todo1",
                                Description="description todo 1"
                            },
                            new Todo()
                            {
                                Title="todo2",
                                Description="description todo 2"
                            }
                        }
                    },
                    new User()
                    {
                       Userame="hama",
                        Email="hama@gmail.com",
                        Password="Password",
                        Todos =
                        {
                            new Todo()
                            {
                                Title="todo3",
                                Description="description todo 3"
                            },
                            new Todo()
                            {
                                Title="todo4",
                                Description="description todo 4"
                            }
                        }
                    }
                };
                dataContext.Users.AddRange(Users);
                dataContext.SaveChanges();
            }
        }
    }
}