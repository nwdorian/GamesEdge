using Application.Emails;
using Application.Notifications;

namespace Infrastructure.Notifications;

public class EmailNotificationService(IEmailService emailService) : IEmailNotificationService
{
    public async Task SendPasswordResetEmail(PasswordResetEmail passwordResetEmail)
    {
        EmailRequest emailRequest = new(
            passwordResetEmail.EmailTo,
            "Reset password link",
            $"Please reset your password by <a href='{passwordResetEmail.CallbackUrl!}'>clicking here</a>."
        );

        await emailService.SendEmail(emailRequest);
    }
}
