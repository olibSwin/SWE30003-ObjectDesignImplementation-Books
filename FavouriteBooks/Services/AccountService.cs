using FavouriteBooks.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FavouriteBooks.Services
{
    public class AccountService
    {
        private List<CustomerAccount> _accounts = new();
        private static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "accounts.json");

        public AccountService()
        {
            Load();
            //SeedData(); // Uncomment this line to add a test account on first run
        }
        public CustomerAccount Login(string email, string password)
        {
            var account = FindByEmail(email);

            if (account == null)
                return null;

            if (account.IsLocked)
                throw new InvalidOperationException("Account is locked.");

            if (!account.VerifyPassword(password))
            {
                account.RegisterFailedLogin();
                Save();
                return null;
            }

            account.ResetLoginAttempts();
            Save();
            return account;
        }

        public CustomerAccount Register(string name, string email, string password, string phone, string address)
        {
            if (_accounts.Any(a =>
                a.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Account already exists.");
            }

            var newAccount = new CustomerAccount(name, email, password, phone, address)
            {
                Id = _accounts.Count > 0 ? _accounts.Max(a => a.Id) + 1 : 1
            };
            _accounts.Add(newAccount);
            Save();

            return newAccount;
        }

        public CustomerAccount FindByEmail(string email)
        {
            return _accounts.Find(a =>
                a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void Save()
        {
            JsonStorageService.Save(FilePath, _accounts);
            System.Diagnostics.Debug.WriteLine("Saved to: " + FilePath);
        }

        public void Load()
        {
            var loaded = JsonStorageService.Load<List<CustomerAccount>>(FilePath);
            _accounts = loaded ?? new List<CustomerAccount>();
        }

        public List<CustomerAccount> GetAll() => _accounts;

        private void SeedData()
        {
            if (_accounts.Count > 0)
                return;

            var user = new CustomerAccount("Test User", "test@test.com", "1234", "000", "Test Address");

            user.OrderHistory.Add(new Order(user)
            {
                Items = new List<OrderItem>
        {
            new OrderItem(new Book("1984", "George Orwell", "123", 10m, 5), 2, 10m)
        }
            });

            _accounts.Add(user);
            Save();
        }
    }
}