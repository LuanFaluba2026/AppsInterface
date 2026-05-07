using System.Net;
using System.Net.Mail;

public class EmailService
{
    public static async Task SendEmailAsync(string to, string subject, string body)
    {
        var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("luanfaluba@gmail.com", "orao mdat cyqq ojgy"),
            EnableSsl = true
        };
        var mail = new MailMessage
        {
            From = new MailAddress("luanfaluba@gmail.com"),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        mail.To.Add(to);
        mail.CC.Add("luan@cgccontabilidade.com.br");
        await smtp.SendMailAsync(mail);
    }
}