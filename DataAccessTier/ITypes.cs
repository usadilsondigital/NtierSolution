using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccessTier
{
    public interface ITypes
    {
        Task<ActionResult<IEnumerable<Types>>> GetContacttypes();

        Task<ActionResult<Types>> GetTypes(int id);

        Task<Types> PutType(int id, Types types);

        Task<Types> PostType(Types types);

        Task<IActionResult> DeleteType(int id);
    }
}
