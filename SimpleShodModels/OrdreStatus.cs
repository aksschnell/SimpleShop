using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class OrdreStatus
    {
        public int OrdreStatusId { get; set; }
        public string StatusBeskrivelse { get; set; }


        [JsonConstructor]
        public OrdreStatus(string statusbeskrivelse)
        {
            StatusBeskrivelse = statusbeskrivelse;
        }


        public OrdreStatus(int ordrestatusid, string statusbeskrivelse)
        {
            OrdreStatusId = ordrestatusid;
            StatusBeskrivelse = statusbeskrivelse;
        }

        public void SetId(int id)
        {
            OrdreStatusId = id;
        }

    }
}
