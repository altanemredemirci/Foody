using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.CORE.Entities
{
    public class Contact:BaseEntity
    {
        public string Address { get; set; }
        public string Map { get; set; }

        public List<SocialMedia> SocialMedias { get; set; }
    }

    public class SocialMedia
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
