using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Identity
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>
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
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                await conn.ExecuteAsync("update Person.Person set LastName=@username where BusinessEntityID=@id",
                    new { username = userName, id = user.Id });
            }
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return Task.FromResult(user.Email);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            user.Email = normalizedName;
            return Task.FromResult(0);
        }

        public virtual Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            string sql = @" DECLARE @Id INT
                            INSERT INTO Person.BusinessEntity(rowguid) VALUES(NEWID());
                            SELECT @id = @@IDENTITY;
                            INSERT INTO Person.Person
                                    ( BusinessEntityID ,
                                      PersonType ,
                                      NameStyle ,
                                      Title ,
                                      FirstName ,
                                      MiddleName ,
                                      LastName ,
                                      Suffix ,
                                      EmailPromotion ,
                                      ModifiedDate
                                    )
                            VALUES  ( @Id , -- BusinessEntityID - int
                                      N'IN' , -- PersonType - nchar(2)
                                      @NameStyle , -- NameStyle - NameStyle
                                      @Title , -- Title - nvarchar(8)
                                      @FirstName , -- FirstName - Name
                                      @MiddleName , -- MiddleName - Name
                                      @LastName , -- LastName - Name
                                      @Suffix , -- Suffix - nvarchar(10)
                                      1 , -- EmailPromotion - int
                                      GETDATE()  -- ModifiedDate - datetime
                                    );
                            INSERT INTO Person.Password
                            ( BusinessEntityID ,
                              PasswordHash ,
                              PasswordSalt ,
                              ModifiedDate
                            )
                            VALUES  ( @id , -- BusinessEntityID - int
                                      @Password , -- PasswordHash - varchar(128)
                                      '123' , -- PasswordSalt - varchar(10)
                                      GETDATE()  -- ModifiedDate - datetime
                                    );
                            INSERT INTO Person.EmailAddress
                                    ( BusinessEntityID ,
                                      EmailAddress ,
                                      ModifiedDate
                                    )
                            VALUES  ( @id , -- BusinessEntityID - int
                                      @Email , -- EmailAddress - nvarchar(50)
                                      GETDATE()  -- ModifiedDate - datetime
                                    )
";

            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                var i = conn.Execute(sql, new {user.Password, user.Email,user.FirstName,user.LastName,user.MiddleName,user.NameStyle,user.Title,user.Suffix}, tran);
                tran.Commit();
            }
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var result = new IdentityResult();
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
            User user = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                user = conn.QueryFirstOrDefault<User>("Select * from Person.Person where BusinessEntityID=@id",
                    new { id = userId });
            }

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            User user = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                user = conn.QueryFirstOrDefault<User>(@"SELECT  Person.BusinessEntityID ,
                        EmailAddress as Email,
                        FirstName,
                        LastName,
                        MiddleName,
                        NameStyle,
                        Suffix,
                        Title,
			            PasswordHash as Password
                FROM Person.BusinessEntity JOIN Person.Person ON Person.BusinessEntityID = BusinessEntity.BusinessEntityID
                JOIN Person.Password ON Password.BusinessEntityID = Person.BusinessEntityID
                JOIN Person.EmailAddress ON EmailAddress.BusinessEntityID = Person.BusinessEntityID
                WHERE EmailAddress = @Email",
                    new { Email = normalizedUserName });
            }

            return Task.FromResult(user);
        }


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
    }
}
