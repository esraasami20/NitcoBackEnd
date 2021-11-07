using NitcoBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitcoBackEnd.Services
{
    public class AccountChartService
    {
        private fCarePlusContext _db;

        public AccountChartService(fCarePlusContext db )
        {
            _db = db;
        }

        //get all data
        public List<AccountsChart> GetAccounts()
        {
            return _db.AccountsCharts.Where(a=>a.IsActive==true).ToList();
        }
        //get account by id
        public AccountsChart GetAccountById(Guid id)
        {
            AccountsChart accountsChart = _db.AccountsCharts.FirstOrDefault(a => a.Id == id && a.IsActive==true);
            return accountsChart;
        }

        //get data by name 
        public List<AccountsChart> GetAccountsBySearchName(string name)
        {
            return _db.AccountsCharts.Where(a => a.IsActive == true &&( a.NameAr.Contains(name) || a.NameEn.Contains(name) || a.Number.Contains(name))).ToList();
        }
        

        //edit account
        public bool EditAccountData(Guid id,AccountsChart accounts)
        {
            AccountsChart accountsChart = _db.AccountsCharts.FirstOrDefault(a => a.Id == id && a.IsActive == true);
            if (accountsChart != null)
            {
                accountsChart.NameAr = accounts.NameAr;
                accountsChart.NameEn = accounts.NameEn;
                accountsChart.Number = accounts.Number;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        //add new account
        public AccountsChart addAccount(AccountsChart accounts)
        {
            if (accounts != null)
            {
                _db.AccountsCharts.Add(accounts);
                _db.SaveChanges();
            }
            return accounts;
        }

        //delete account
        public bool deleteAccounr(Guid id)
        {

            AccountsChart accountsChart = GetAccountById(id);
            if (accountsChart != null)
            {
                accountsChart.IsActive = false;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
