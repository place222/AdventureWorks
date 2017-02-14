using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class UserStore : IUserStore<User>
    {
        private bool _disposed;
        private readonly string connstr =
            "Server=LIUYANG;Database=AdventureWorks2012;Trusted_Connection=True;MultipleActiveResultSets=true";
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
            return Task.FromResult(user.UserName);
        }

        public virtual async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            using (var conn = new SqlConnection(connstr))
            {
                await conn.ExecuteAsync("update Person.Person set LastName=@username where BusinessEntityID=@id",
                    new { username = userName, id = user.Id });
            }
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
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
                                      AdditionalContactInfo ,
                                      Demographics ,
                                      rowguid ,
                                      ModifiedDate
                                    )
                            VALUES  ( @Id , -- BusinessEntityID - int
                                      @personType , -- PersonType - nchar(2)
                                      @nameStyle , -- NameStyle - NameStyle
                                      @title , -- Title - nvarchar(8)
                                      @firstName' , -- FirstName - Name
                                      @middleName , -- MiddleName - Name
                                      @lastName , -- LastName - Name
                                      @suffix , -- Suffix - nvarchar(10)
                                      @emailPromotion , -- EmailPromotion - int
                                      NULL , -- AdditionalContactInfo - xml
                                      NULL , -- Demographics - xml
                                      NEWID() , -- rowguid - uniqueidentifier
                                      GETDATE()  -- ModifiedDate - datetime
                                    )";
            using (var conn = new SqlConnection(connstr))
            {
                await conn.ExecuteAsync(sql,new {});
            }
            return new IdentityResult();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
