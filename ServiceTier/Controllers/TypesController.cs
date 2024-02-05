using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessTier;
using EntityTier;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;


namespace ServiceTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypes _typeRepository;

        public TypesController(ITypes typeRepository)
        {
            _typeRepository = typeRepository;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Types>>> GetContacttypes()
        {
            return await _typeRepository.GetContacttypes();
        }

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Types>> GetTypes(int id)
        {
            var types = await _typeRepository.GetTypes(id);
            if (types == null)
            {
                return NotFound();
            }
            return types;
        }

        // PUT: api/Types/5        
        [HttpPut("{id}")]
        public async Task<Types> PutTypes(int id, Types types)
        {
            var method = await _typeRepository.PutType(id, types);
            if (method == null)
            {
                return null;
            }
            return await _typeRepository.PutType(id, types);
        }

        // POST: api/Types       
        [HttpPost]
        public async Task<ActionResult<Types>> PostTypes(Types types)
        {
            await _typeRepository.PostType(types);
            return CreatedAtAction("GetTypes", new { id = types.Id }, types);
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            return await _typeRepository.DeleteType(id);
        }


        

        // GET: api/AlphabeticTypesAscending
        [HttpGet]
        [Route("GetAlphabeticTypesAscending")]
        public IEnumerable<Types> GetAlphabeticTypesAscending()
        {
            return AlphabeticTypesAscending();
        }

        private List<Types> AlphabeticTypesAscending()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;
            connetionString = "data source=DESKTOP-44MPC1H\\SQLEXPRESS;Initial Catalog=newdb;integrated security=true;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AlphabeticTypesAscending";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            List<Types> listado = new List<Types>();
            var aux = ds.Tables[0].Rows;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                var xid = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                var xname = ds.Tables[0].Rows[i][1].ToString();
                Types auxiliarType = new Types(xid, xname);
                listado.Add(auxiliarType);
            }

            connection.Close();
            return listado;
        }



    }
}
