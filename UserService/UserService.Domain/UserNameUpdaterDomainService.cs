namespace UserService.Domain
{
    public class UserNameUpdaterDomainService(IUserRepository userRepository)
    {
        public async Task UpdateAsync(User user, UserName userName, CancellationToken cancellationToken)
        {
            if (await userRepository.ExistAsync(userName, cancellationToken))
                throw new UserNameAlreadyTakenException();
            user.UpdateUserName(userName);
        }
    }
}
