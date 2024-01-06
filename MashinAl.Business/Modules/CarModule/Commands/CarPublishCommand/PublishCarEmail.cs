
namespace MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand
{
    internal class PublishCarEmail
    {
        internal static string PublishCarMessage(string name, string markaName, string modelName, int carId)
        {
            return $@"
<html dir=""ltr"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""AZ"">
<head>
    <meta charset=""UTF-8"">
    <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
</head>
<body style=""width:100%;font-family:arial, 'helvetica neue', helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
    <div dir=""ltr"" class=""es-wrapper-color"" lang=""AZ"" style=""background-color:#FAFAFA"">
        <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FAFAFA"">
            <tr>
                <td valign=""top"" style=""padding:0;Margin:0"">
                    <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                        <tr>
                            <td class=""es-info-area"" align=""center"" style=""padding:0;Margin:0"">
                                <table class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px"" bgcolor=""#FFFFFF"">
                                    <tr>
                                        <td align=""left"" style=""padding:20px;Margin:0"">
                                            <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                                <tr>
                                                    <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                                            <tr>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                        <tr>
                            <td align=""center"" style=""padding:0;Margin:0"">
                                <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                    <tr>
                                        <td align=""left"" style=""Margin:0;padding-bottom:5px;padding-left:20px;padding-right:20px;padding-top:30px"">
                                            <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                                <tr>
                                                    <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                                            <tr>
                                                                <td align=""center"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px"">
                                                                    <img src=""https://twuwxb.stripocdn.email/content/guids/CABINET_1572a756bdccb924025a8f106a34f9a51dc443960817a09038cf27f861f72c05/images/logo_blue.png"" alt style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" width=""235"">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align=""center"" class=""es-m-txt-c"" style=""padding:0;Margin:0;padding-bottom:10px"">
                                                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:lato, 'helvetica neue', helvetica, arial, sans-serif;line-height:35px;color:#333333;font-size:23px"">Elan Təsdiqi</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align=""center"" class=""es-m-p0r es-m-p0l"" style=""Margin:0;padding-top:5px;padding-bottom:5px;padding-left:40px;padding-right:40px"">
                                                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px"">
                                                                        <strong>Salam {name},</strong> <br>
                                                                    </p>
                                                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px"">
                                                                        Sizin {markaName}, {modelName} | {carId} nömrəli avtomobil elanı təsdiq olunmuşdur! Saytda elanınızı görə bilərsiniz!
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" bgcolor=""#fff"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px;background-color:#ffffff"">
                                            <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                                <tr>
                                                    <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                                            <tr>
                                                                <td align=""center"" bgcolor=""#fdfcfc"" style=""padding:0;Margin:0"">
                                                                    <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px"">
                                                                        <em><strong>Əgər bu müraciət sizin tərəfinizdən edilməmişdirsə, xaiş edirik bu emaili diqqətli şəkildə nəzarət edin.</strong></em>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>";
        }

        internal static string PublishMessage(string name, string markaName, string modelName, int carId)
        {
            throw new NotImplementedException();
        }
    }

}
