using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Citas.Services
{
    internal static class EmailService
    {
        // ⚠️ No guardes la API Key directamente en el código.
        // Usa variables de entorno para protegerla (ver explicación abajo).
    private const string ApiKey = "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"; // API Key proporcionada por el usuario

        // 🔹 Enviar correo asíncronamente
        internal static async Task SendEmailAsync(string toEmail, string subject, string bodyHtml)
        {
            try
            {
                if (string.IsNullOrEmpty(ApiKey))
                    throw new InvalidOperationException("❌ La clave de SendGrid (SENDGRID_API_KEY) no está configurada.");

                if (string.IsNullOrEmpty(toEmail))
                    throw new ArgumentException("El correo del destinatario no puede estar vacío.", nameof(toEmail));

                // Crear cliente SendGrid
                var client = new SendGridClient(ApiKey);

                // Dirección del remitente
                var from = new EmailAddress("andrestolozatejeda@gmail.com", "Hospital San Vicente");

                // Dirección del destinatario
                var to = new EmailAddress(toEmail);

                // Puedes usar el mismo contenido para texto plano y HTML
                var plainTextContent = System.Text.RegularExpressions.Regex.Replace(bodyHtml, "<.*?>", ""); // quitar etiquetas
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, bodyHtml);

                // Enviar correo
                var response = await client.SendEmailAsync(msg);

                var responseBody = await response.Body.ReadAsStringAsync();
                Console.WriteLine($"📡 Código de respuesta: {response.StatusCode}");
                Console.WriteLine($"📝 Respuesta de SendGrid: {responseBody}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al enviar correo: {ex.Message}");
            }
        }
    }
}
