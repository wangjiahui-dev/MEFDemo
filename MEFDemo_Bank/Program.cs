using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo_Bank
{
    /// <summary>
    /// Bank main class
    /// Only added BankInterface as a reference. BankOfChina binary is not added.
    /// This can run succeed after BankOfChina binary dll copied into "Cards" folder under debug
    /// </summary>
    class Program
    {
        [ImportMany(typeof(ICard))]
        public IEnumerable<ICard> cards { get; set; }

        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if(pro.cards != null)
            {
                foreach(var c in pro.cards)
                {
                    Console.WriteLine(c.GetCountInfo());
                }
            }
            Console.ReadLine();
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog("Cards"); // Manual created the "Cards" folder?
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
