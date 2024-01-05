using System;
using CasinoSystem.Data.Entities.Base;
namespace CasinoSystem.Data.Entities
{
    public class RefreshToken : BaseEntity,ITrackable
    {
        public int UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;

        public DateTime CreatedAt { get;  set; }
        public DateTime LastUpdateAt { get;  set; }

        protected RefreshToken()
        {
        }

        public RefreshToken(int id, int userId, string token, DateTime createdAt,
            DateTime? revokedAt = null)
        {
            
            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
        }

        public void Revoke(DateTime revokedAt)
        {
            if (Revoked)
            {
                throw new Exception();
            }

            RevokedAt = revokedAt;
        }
    }
}