using Core.Entities;
using Microsoft.AspNetCore.Authentication;
using ProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	using Core.Interfaces;
	using Core.Enums;
	using Microsoft.Extensions.Configuration;
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	public class AccountService : IAccountService<User, RegisterModel>
    {
		private List<User> _users;

		public AccountService()
		{
			_users = new List<User>();
		}

		public string Add(RegisterModel model)
		{
			var user = new User()
			{
				Login = model.Login,
				Password = model.Password.GetHashCode(),
				Role = model.Login.Contains("su") ? Role.Admin : Role.User
			};

			return _users.Select(x => x.Login).SingleOrDefault(login => login == user.Login);
		}

		public IEnumerable<User> GetAll()
		{
			return _users;
		}

		public User GetById(int id)
		{
			return _users.SingleOrDefault(u => u.Id == id);
		}
	}
}
