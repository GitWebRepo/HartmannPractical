using System;
using System.ComponentModel.DataAnnotations;

namespace HartmannPractical.Data
{
    [Serializable]
    public class SampleData
    {
        [Order(0)]
        public int Id { get; set; }

        [StringLength(20)]
        [Order(2)]
        public string Name { get; set; }

        [Order(3)]
        public DateTime CreatedOn { get; set; }

        [Order(1)]
        public SampleFlags Features { get; set; }

        public bool Ignore { get; set; }
    }
}
