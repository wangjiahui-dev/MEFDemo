using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo
{
    class Program
    {
        // TAG_ONE: import one Class
        //[Import("MusicBook")]
        //public IBookService Service { get; set; }

        // Import many Class
        [ImportMany("MusicBook")]
        public IEnumerable<IBookService> Services {get; set;}

        // Import Properties
        [ImportMany]
        public List<String> InputString { get; set; }
        
        // Import Methods
        [Import]
        public Func<string> methodWithoutPara { get; set; } // without para
        [Import]
        public Func<int, string> methodWithPara { get; set; } // with para

        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if(pro.Services != null)
            {
                // TAG_ONE
                //Console.WriteLine(pro.Service.GetBookName());
                foreach(var s in pro.Services)
                {
                    Console.WriteLine(s.GetBookName());
                    // TAG_TWO: force convert
                    //var ss = (IBookService)s;
                    //Console.WriteLine(ss.GetBookName());
                }
            }

            foreach(var str in pro.InputString)
            {
                Console.WriteLine(str);
            }

            if(pro.methodWithoutPara != null)
            {
                Console.WriteLine(pro.methodWithoutPara());
            }
            if(pro.methodWithPara != null)
            {
                Console.WriteLine(pro.methodWithPara(3000));
            }

            Console.ReadLine();
        }

        private void Compose()
        {
            // Create a assembly catalog, to get all components from the assembly
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            // Create a container
            CompositionContainer container = new CompositionContainer(catalog);
            // execute compose 执行组合
            container.ComposeParts(this);
        }
    }
}
