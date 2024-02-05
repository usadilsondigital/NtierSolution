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
    public interface IContacts
    {
        Task<ActionResult<IEnumerable<Contact>>> GetContacts();

        Task<ActionResult<Contact>> GetContact(int id);

        Task<Contact> PutContact(int id, Contact contact);

        Task<Contact> PostContact(Contact contact);

        Task<Contact> DeleteContact(int id);
    }
}
