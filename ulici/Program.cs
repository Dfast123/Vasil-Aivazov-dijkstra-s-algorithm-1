using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ulici
{
    class Program
    {
        static void Main(string[] args)
        {

            List<char> cross = new List<char>();
            cross.Add('a');//0
            cross.Add('b');//1
            cross.Add('c');//2
            cross.Add('d');//3
            cross.Add('e');//4
            cross.Add('f');//5
            cross.Add('g');//6
            cross.Add('h');//7
            cross.Add('i');//8
            cross.Add('j');//9

            int[] length = new int[10];
            int[] fromStart = new int[10];

            IDictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 99990);
            d.Add('b', 999900);
            d.Add('c', 999900);
            d.Add('d', 999900);
            d.Add('e', 999900);
            d.Add('f', 999900);
            d.Add('g', 999900);
            d.Add('h', 999900);
            d.Add('i', 999900);
            d.Add('j', 999900);

            int[] newpath = new int[10]; 

            List<road> roads = new List<road>();                      
            roads.Add(new road(cross[0], cross[1], 20));//a
            roads.Add(new road(cross[0], cross[7], 30));
            roads.Add(new road(cross[1], cross[9], 10));//b
            roads.Add(new road(cross[1], cross[2], 30));
            roads.Add(new road(cross[1], cross[7], 5));
            roads.Add(new road(cross[1], cross[0], 20));
            roads.Add(new road(cross[2], cross[1], 30));//c
            roads.Add(new road(cross[2], cross[9], 15));
            roads.Add(new road(cross[2], cross[5], 10));
            roads.Add(new road(cross[2], cross[4], 15));
            roads.Add(new road(cross[2], cross[7], 25));
            roads.Add(new road(cross[3], cross[5], 15));//d
            roads.Add(new road(cross[3], cross[4], 40));
            roads.Add(new road(cross[3], cross[8], 5));
            roads.Add(new road(cross[4], cross[2], 15));//e
            roads.Add(new road(cross[4], cross[5], 25));
            roads.Add(new road(cross[4], cross[3], 40));
            roads.Add(new road(cross[4], cross[8], 45));
            roads.Add(new road(cross[4], cross[6], 20));
            roads.Add(new road(cross[4], cross[7], 10));
            roads.Add(new road(cross[5], cross[3], 15));//f
            roads.Add(new road(cross[5], cross[4], 25));
            roads.Add(new road(cross[5], cross[2], 10));
            roads.Add(new road(cross[5], cross[9], 30));
            roads.Add(new road(cross[6], cross[7], 25));//g
            roads.Add(new road(cross[6], cross[4], 20));
            roads.Add(new road(cross[6], cross[8], 20));
            roads.Add(new road(cross[7], cross[0], 30));//h
            roads.Add(new road(cross[7], cross[1], 5));
            roads.Add(new road(cross[7], cross[2], 25));
            roads.Add(new road(cross[7], cross[4], 10));
            roads.Add(new road(cross[7], cross[6], 25));
            roads.Add(new road(cross[8], cross[3], 5));//i
            roads.Add(new road(cross[8], cross[6], 20));
            roads.Add(new road(cross[8], cross[4], 45));
            roads.Add(new road(cross[9], cross[5], 30));//j
            roads.Add(new road(cross[9], cross[2], 15));
            roads.Add(new road(cross[9], cross[1], 10));


             

            char start = 'a';  //bukva za start (ot a do j)
            char finish = 'd';  //bukva za final
            
            

            d[start] = 0;
            for (int i = 0; i < 10;i++ )
                foreach (road r in roads)
                {

                    if (d[r.to] > d[r.from] + r.length)
                    {
                        //Console.WriteLine("from {0} to {1} for {2} instead of {3}", r.from, r.to, (d[r.from] + r.length), d[r.to]);
                        d[r.to] = d[r.from] + r.length;

                    }

                }
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("from {0} to {1} for {2} steps",start,cross[i],d[cross[i]]);
            }
            Console.WriteLine("we need from {0} to {1} , which is:",start,finish);
            Console.WriteLine("from {0} to {1} for {2} steps",start,finish,d[finish]);


            //----------------------------------Namirane na putq
            char tracker = finish;
            List<road> track = new List<road>();
            



            for (int i = 0; i < 20; i++)
            {
                int min = 9999;
                road minroad = new road('a', 'c', 99999999);
                foreach (road r in roads)
                {
                    if (r.to == tracker)
                    {
                       if(min > d[r.from]+r.length)
                       {
                           min = d[r.from] + r.length;
                           minroad = r;
                       }
                    }
                }
                track.Add(minroad);
                tracker = minroad.from;
                if (minroad.from == start)
                    break;
            }
            track.Reverse();

            Console.WriteLine("reversed");
            foreach(road t in track)
            {
                Console.WriteLine(t.from+" to "+t.to+" for "+t.length+" for total "+d[t.to]);

            }

        }
    }
    class road
    {
        public char from;
        public char to;
        public int length;

        public road(char from, char to, int l)
        {
            this.from = from;
            this.to = to;
            this.length = l;
        }

    }
}
