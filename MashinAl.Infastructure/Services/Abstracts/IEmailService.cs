﻿namespace MashinAl.Infastructure.Services.Abstracts
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(string to, string subject, string body);
    }
}
