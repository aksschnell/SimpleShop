using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class OrdreStatus
    {
        public int OrdreStatusId { get; set; }
        public string OrdreStatusNavn { get; set; }

        public OrdreStatus(int id, string name)
        {
            OrdreStatusId = id;
            OrdreStatusNavn = name;

        }
    }
}
