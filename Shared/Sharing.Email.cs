namespace Zebble.Device
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    public partial class Sharing
    {
        public partial class Email
        {
            public static async Task<bool> Share(string subject, string body, bool isHtml = false, FileInfo[] attachments = null)
            {
                var format = isHtml ? EmailBodyFormat.Html : EmailBodyFormat.PlainText;
                var message = new EmailMessage()
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = format
                };

                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        message.Attachments.Add(new EmailAttachment(attachment.FullName));
                    }
                }
                try
                {
                    await Xamarin.Essentials.Email.ComposeAsync(message);
                    return true;
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Email is not supported on this device
                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}