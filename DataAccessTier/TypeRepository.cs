using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace DataAccessTier
{
    public class TypeRepository : ITypes
    {
        private readonly AppDbContext _context;
        public TypeRepository(AppDbContext context)
        {
            _context = context;
        }


        async Task<ActionResult<IEnumerable<Types>>> ITypes.GetContacttypes()
        {
            return await _context.Contacttypes.ToListAsync();
        }

        async Task<ActionResult<Types>> ITypes.GetTypes(int id)
        {
            var types = await _context.Contacttypes.FindAsync(id);

            if (types == null)
            {
                return null;
            }

            return types;
        }

        async Task<Types> ITypes.PostType(Types types)
        {
            try
            {
                _context.Contacttypes.Add(types);
                await _context.SaveChangesAsync();
                return types;
            }
            catch (Exception e)
            {
                var message = e.ToString();
                throw;
            }
        }

        async Task<Types> ITypes.PutType(int id, Types types)
        {
            if (id != types.Id)
            {
                return null;
            }

            _context.Entry(types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return types;
        }

        async Task<IActionResult> ITypes.DeleteType(int id)
        {
            var types = await _context.Contacttypes.FindAsync(id);
            if (types == null)
            {
                return null;
            }
            _context.Contacttypes.Remove(types);
            await _context.SaveChangesAsync();

            return null;
        }

        private bool TypesExists(int id)
        {
            return _context.Contacttypes.Any(e => e.Id == id);
        }

    }
}
