using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UtilizadorData
    {
        private readonly ISqlDataAccess db;

        public UtilizadorData(ISqlDataAccess db)
        {
            this.db = db;
        }

        public Task<List<Utilizador>> GetUtilizadores()
        {
            string sql = "select * from db.Utilizador";

            return db.LoadData<Utilizador, dynamic>(sql, new { });
        }

    }
}
