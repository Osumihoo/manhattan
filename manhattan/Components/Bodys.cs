using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace manhattan.Components
{
    public class Bodys
    {
        [Serializable]
        [DataContract(Name = "Orders", Namespace = "")]
        public class Orders
        {
            public string DocNumPar { get; set; }
            public string SalesPerson { get; set; }
            public string CardCode { get; set; }
            public string DocDueDate { get; set; }
            public string RFCGen { get; set; }
            public string PeyMethod { get; set; }
            public string ShipToCode { get; set; }
            public string Warehouse { get; set; }
            public List<ListItems> DocumentLines { get; set; }
        }
        [Serializable]
        [DataContract(Name = "ListItems", Namespace = "")]
        public class ListItems
        {
            public int LineNum { get; set; }
            public int Cantidad { get; set; }
            public double Precio { get; set; }
            public string ItemCode { get; set; }
            public string Warehouse { get; set; }
            public string TaxCode { get; set; }
        }
    }
}