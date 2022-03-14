using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMobile.DAL.Interfaces.Models
{
    public interface IEntityWithId
    {
        public int Id { get; set; }
    }
}
