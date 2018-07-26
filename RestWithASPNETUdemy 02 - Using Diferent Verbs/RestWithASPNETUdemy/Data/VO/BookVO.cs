using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Relational;
using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Data.VO
{
    // ReSharper disable once InconsistentNaming
    //Contrato entre os atributos e a estrutura da tabela
    [DataContract]
    public class BookVO 
    {
        [DataMember(Order = 1, Name = "id")]
        public long? Id { get; set; }

        [DataMember(Order = 3, Name = "title")]
        public string Title { get; set; }

        [DataMember(Order = 2, Name = "author")]
        public string Author { get; set; }

        [DataMember(Order = 4, Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Order = 5, Name = "launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
