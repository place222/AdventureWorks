using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Identity
{
    public class UserStore :
        IUserPasswordStore<User>,
        IUserPhoneNumberStore<User>,
        IUserTwoFactorStore<User>,
        IUserLoginStore<User>
        //IUserClaimStore<User>
    {
        public UserStore(IOptions<ConnectionOptions> connectionOptions)
        {
            this._connectionOptions = connectionOptions;
        }

        private readonly IOptions<ConnectionOptions> _connectionOptions;
        private bool _disposed;
        public void Dispose()
        {
            _disposed = true;
        }
        /// <summary>
        /// Throws if this class has been disposed.
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        #region userstore
        public virtual Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Id.ToString());
        }

        public virtual Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Email);
        }

        public virtual async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            string sql = "update Person.Person set LastName=@username where BusinessEntityID=@id";
            var p = new DynamicParameters();
            p.Add("@username", userName, DbType.String);
            p.Add("@id", user.Id, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                int result = await conn.ExecuteAsync(sql, p);
            }
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            //TODO::规范化的用户名
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return Task.FromResult(user.Email);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            //TODO::规范化的用户名
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            user.Email = normalizedName;
            return Task.FromResult(0);
        }

        public virtual Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            string sql = @" INSERT INTO Person.BusinessEntity(rowguid) VALUES(NEWID());";
            sql += "SELECT @ID=SCOPE_IDENTITY();";
            sql +=
         "INSERT INTO Person.Person (BusinessEntityID,PersonType,NameStyle,Title,FirstName,MiddleName,LastName,Suffix,EmailPromotion) VALUES(@ID,@PersonType,@NameStyle,@Title,@FirstName,@MiddleName,@LastName,@Suffix,@EmailPromotion);";
            sql += "INSERT INTO Person.Password(BusinessEntityID,PasswordHash,PasswordSalt) VALUES(@ID,@Password,'123');";
            sql += "INSERT INTO Person.EmailAddress(BusinessEntityID,EmailAddress) VALUES(@ID,@Email);";
            sql += "INSERT INTO Person.PersonPhone(BusinessEntityID,PhoneNumber,PhoneNumberTypeID) VALUES(@Id, @PhoneNumber, 1);";

            var p = new DynamicParameters();
            p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Password", user.Password, DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", user.Email, DbType.String, direction: ParameterDirection.Input);
            p.Add("@FirstName", user.FirstName, DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastName", user.LastName, DbType.String, direction: ParameterDirection.Input);
            p.Add("@MiddleName", user.MiddleName, DbType.String, direction: ParameterDirection.Input);
            p.Add("@NameStyle", user.NameStyle, DbType.Boolean, direction: ParameterDirection.Input);
            p.Add("@Suffix", user.Suffix, DbType.String, direction: ParameterDirection.Input);
            p.Add("@PersonType", user.PersonType, DbType.String, direction: ParameterDirection.Input);
            p.Add("@EmailPromotion", user.EmailPromotion, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Title", user.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("@PhoneNumber", user.PhoneNumber, DbType.String, direction: ParameterDirection.Input);

            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                var i = conn.Execute(sql, p, tran);
                tran.Commit();
                user.Id = p.Get<int>("@ID");
            }
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            //TODO::UpdateAsync
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                int r = conn.Execute("");
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            string sql = @"SELECT  
                            Person.BusinessEntityID AS Id,
                            PersonType,
                            NameStyle,
                            Title,
                            FirstName,
                            MiddleName,
                            LastName,
                            Suffix,
                            EmailPromotion,
                            EmailAddress as Email,
                            PasswordHash AS Password,
                            PhoneNumber
                        FROM Person.Person JOIN Person.EmailAddress ON EmailAddress.BusinessEntityID = Person.BusinessEntityID
                        JOIN Person.Password ON Password.BusinessEntityID = Person.BusinessEntityID
                        JOIN Person.PersonPhone ON PersonPhone.BusinessEntityID = Person.BusinessEntityID 
                        WHERE Person.Person.BusinessEntityID = @id";
            User user = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                user = conn.QueryFirstOrDefault<User>(sql, new { id = userId });
            }

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            User user = null;
            var sql = @"SELECT  
                            Person.BusinessEntityID as Id,
                            PersonType,
                            EmailPromotion,
                            EmailAddress as Email,
                            FirstName,
                            LastName,
                            MiddleName,
                            NameStyle,
                            Suffix,
                            Title,
			                PasswordHash as Password,
                            PhoneNumber
                        FROM Person.BusinessEntity JOIN Person.Person ON Person.BusinessEntityID = BusinessEntity.BusinessEntityID
                        JOIN Person.Password ON Password.BusinessEntityID = Person.BusinessEntityID
                        JOIN Person.EmailAddress ON EmailAddress.BusinessEntityID = Person.BusinessEntityID
                        JOIN Person.PersonPhone ON PersonPhone.BusinessEntityID = Person.BusinessEntityID 
                        WHERE EmailAddress = @Email";
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                user = conn.QueryFirstOrDefault<User>(sql, new { Email = normalizedUserName });
            }

            return Task.FromResult(user);
        }
        #endregion

        #region userpasswordstore

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Password != null);
        }
        #endregion

        #region userphonenumberstore
        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            string sql = "UPDATE Person.PersonPhone SET PhoneNumber = @PhoneNumber WHERE BusinessEntityID = @Id AND PhoneNumberTypeID = 1";
            var p = new DynamicParameters();
            p.Add("@Id", user.Id, DbType.Int32);
            p.Add("@PhoneNumber", phoneNumber, DbType.String);

            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                var result = conn.Execute(sql, p);
            }
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            //TODO::没有做手机确认逻辑
            return Task.FromResult(true);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            //TODO::没有做手机确认逻辑
            return Task.FromResult(0);
        }
        #endregion

        #region usertwofactorstore
        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            //TODO::SetTwoFactorEnabledAsync
            return Task.FromResult(true);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return Task.FromResult(false);
        }
        #endregion

        #region userloginstore
        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            IList<UserLoginInfo> list = new List<UserLoginInfo>();
            return Task.FromResult(list);
        }

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return Task.FromResult(new User());
        }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return Task.FromResult(0);
        }
        #endregion userloginstore

        #region userclaimstore
        public Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
