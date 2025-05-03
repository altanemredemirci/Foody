using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.CORE.Entities
{
    public class About: BaseEntity
    {
        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        [DisplayName("1.Özellik")]
        public string Property1 { get; set; }

        [DisplayName("2.Özellik")]
        public string Property2 { get; set; }

        [DisplayName("3.Özellik")]
        public string Property3 { get; set; }
    }
}
