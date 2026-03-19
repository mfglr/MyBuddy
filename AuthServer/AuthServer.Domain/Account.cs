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
        public Name? Name { get; private set; }

        private Account() { }

        internal Account(Email email) : base()
        {
            Id = Guid.CreateVersion7().ToString();
            Email = email.Value;
            UserName = email.Value;
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

        public void UpdateName(Name name)
        {
            if (IsDeleted)
                throw new AccountNotFoundException();

            Name = name;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}
