using Microsoft.AspNetCore.Identity;

namespace AuthServer.Domain
{
    public class Account : IdentityUser
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }

        private Account() { }

        internal Account(Email email) : base()
        {
            Email = email.Value;
            UserName = email.GenerateUserName();
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            IsDeleted = false;
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new AccountNotFoundException();

            IsDeleted = true;
            UpdatedAt = DeletedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateEmail(Email email)
        {
            if (IsDeleted)
                throw new AccountNotFoundException();

            Email = email.Value;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateUserName(UserName userName)
        {
            if (IsDeleted)
                throw new AccountNotFoundException();

            UserName = userName.Value;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

    }
}
