using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PID { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var presons = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                presons.Add(new Person
                {
                    ID = i,
                    Name = $"Bob{i}",
                    PID = (i == 0 || i == 1) ? -1 : i % 2 == 0 ? 0 : 1
                }); ;
            }
            foreach (var item in GetPersons(0, presons))
            {
                System.Console.WriteLine($"大家好，我是{item.Name}，我的PID是{item.PID}");
            }

        }


        static IEnumerable<Person> GetPersons(int pid, IEnumerable<Person> people)
        {
            var peoples = people.Where(p => p.PID == pid);

            //大批量递归需要额外处理时使用yield会快很多
            //foreach (var item in peoples)
            //{
            //    yield return item;
            //    foreach (var child in GetPersons(item.ID, peoples))
            //    {
            //        yield return child;
            //    }
            //}

            //无需二次处理的递归数据就用这个；
            //concat本质也是yield 但是他是同步返回
            return peoples.Concat(peoples.SelectMany(p => GetPersons(p.ID, peoples)));
        }
    }
}
