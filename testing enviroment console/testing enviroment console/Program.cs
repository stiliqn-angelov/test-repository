using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_enviroment_console
{
    public class Evo
    {
        public Evo(int id,string value)
        {
            this.id = id;
            this.Value = value;
        }
    
        public int id { get; set; }
        public String Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list=new List<int>();
            List<Evo> listEvo = new List<Evo>();
            listEvo.Add(new Evo(1, "DALI"));
            listEvo.Add(new Evo(2, "ILI"));
            listEvo.Add(new Evo(3, "NADALI"));
            list.Add(1);
            list.Add(3);
            list.Add(2);
            var routefileted = list.FindAll(x => listEvo[x].id == 2);
            foreach(int kk in routefileted)
            {
                Console.WriteLine(kk);
            }
           
            Console.Read();
            //routeFilteredTrips = tripsList.FindAll(x => routesList[x.RouteRefId].IntialCity == cityBuffer);
        }
    }
}
