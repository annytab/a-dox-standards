using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Annytab.Dox.Standards.V1;

namespace TestProgram
{
    /// <summary>
    /// This class includes methods to create documents
    /// </summary>
    public static class Documents
    {
        /// <summary>
        /// Create meta data according to Annytab Dox Meta v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxMeta()
        {
            // Create meta data
            AnnytabDoxMeta post = new AnnytabDoxMeta();
            post.date_of_sending = DateTime.UtcNow.ToString("yyyy-MM-dd");
            post.file_encoding = "utf-8";
            post.filename = "invoice_D1005.json";
            post.standard_name = "Annytab Dox Trade v1";
            post.language_code = "en";
            post.signatures = new List<Signature>();
            post.signatures.Add(new Signature
            {
                validation_type = "doxservr-v1",
                algorithm = "SHA-256",
                padding = "Pkcs1",
                data = "invoice@annytab.se,2018-10-30,8RkVQp7KTlbTLiBV6wLJag==",
                value = "HK8Cv/KRhvffPna7Eti9Aq7EQbM7L8pUMf3bgsWnzdL2MT43XlBYewNjZlB8cKRIjfjuG/jO+BvDrfXuAv5/3edKgLnMje6MEvsD2XAi+8l6Whp6FvNydJbgUysCchdWWH9r5EdT4Ld0PY09G7iXI/AaP++3JlA35gXzuo5SMfZHug5AlQuo629c9D+okY9goL1e8ClxVzgNdeTWZR8l6gCY6ShojPU6gfaZj8CBRUUCcBqLDW1CrZoduQ5JKLZqy5NAPkxpjLfsPQaVCipjToQ90BUzhIOrmLOaQ+RSA7vZtTsg4cheGWin7bHsMy0/iOiuTmSvOmNVcuj88wCWFA==",
                certificate = "MIIFTzCCAzegAwIBAgIQE3DqUQl18+Z47SMZ81VCJzANBgkqhkiG9w0BAQUFADBWMQswCQYDVQQGEwJTRTEfMB0GA1UECgwWVGVsaWFTb25lcmEgU3ZlcmlnZSBBQjEmMCQGA1UEAwwdVGVsaWEgZS1sZWdpdGltYXRpb24gSFcgQ0EgdjMwHhcNMTcwNzI4MDYxMDAyWhcNMjIwNzI3MjM1ODU5WjB6MQswCQYDVQQGEwJTRTEkMCIGA1UEAwwbRnJlZHJpayBMYXJzIFBldGVyIFN0aWdzc29uMREwDwYDVQQEDAhTdGlnc3NvbjEbMBkGA1UEKgwSRnJlZHJpayBMYXJzIFBldGVyMRUwEwYDVQQFEwwxOTgwMTAwMTI0NTEwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDWI860riKBAMb5lihJk2SowIZcCswiOOery6peCP902ZhHaetxrAJ7l1rWfQwjqzeuUKZKTSVVBCfzymTy43niygzWlcCfiBhitb+Q3f1BU9SJozXENVvvE0xRr1844aISl1hHxe+ds1m85nFuSKEFUWEJ4aAczWU51jh464ITZQlJ1msdEl5w/knDk8g6EJ10rLqV6jEkXvnUvDk05jEWQt+jBACKdCRcQ1yi1AAVxIvaaShyPpzZl9AgEm0MH7LCRcQfyYnHlTsGgjEgU1LON4iRdXVrqRQZn2I9VwRuaTf0Qs0jbtobmYX/fWeGy3EElTkLcOwKnv0aZJsvJlYTAgMBAAGjgfQwgfEwNwYIKwYBBQUHAQEEKzApMCcGCCsGAQUFBzABhhtodHRwOi8vb2NzcC50cnVzdC50ZWxpYS5jb20wHwYGKoVwIgIBBBUTEzk3NTIyNzI2OTg5MDYwNzA1OTMwRQYDVR0gBD4wPDA6BgYqhXAjAQQwMDAuBggrBgEFBQcCARYiaHR0cHM6Ly9yZXBvc2l0b3J5LnRydXN0LnRlbGlhLmNvbTAdBgNVHQ4EFgQUrXd6F/ceW/a6zW4X5brA9kWa03cwHwYDVR0jBBgwFoAUvz5CqyKYvo6CRRyNGQqbQWbifQ0wDgYDVR0PAQH/BAQDAgVAMA0GCSqGSIb3DQEBBQUAA4ICAQBlgAuLuXYEvxYWswV7zhZn0zZap4/bW2n+VVJQn8YEMCXEDyGwc83liDcs01GZxRp+CX1W+AR3TO4g9SIkhy3PsHMIIdMCEziiz6WFmEuM5SOG47DR5zhR4OnsDiM3oORRri6c9T0Wt92ctnBfChgb8XeeNB6bhx/N5oWb93yb1xka0mp7MKq6Ivom4y8eACKqrc/1ulbvaJ/1FG+fdE6t8rD1LCXDXwbys+5mw4krqp/WaFkbk8H3Ddmh6I7QMtFQXx4jwQ00BGx3en6S0hIdCnf5aDVDkOLb/pJaopQ7WwgZZLixCSlZfHiQkXtgnuILbKVI9AskPYdMXh/V1Vl4ctnyXddavQV8keU5n2WB9SemHhDxSR7QeKasqP8AuSlH7uz6OKy8xUnvWqzHCG3N2aNdvWZ0SX9XDqvj6fDYk6caqcPlLJvefDpYsVzUMXHUvl6WJxyN7vZ8brJkYkfsPFuknoipYRO12tB1oZMGUR3liQ4TU61e8psYQSgWw2an/MzwsKkE6p94KDJmbDjsQE9jJopAkghu8qRmwtSj58HqlJCaTVk3xG7Gv7RVP4WBdl5RVd1PwD37MW1inMd1go3zkX7kUrl4xuwWhTtWEMcxTGcADq5K3XWiDCtNE6J3lGQnY4VL+sd3tGUv/HG5wKNmxsXGay7Is8exEmljxw=="
            });
            post.signatures.Add(new Signature
            {
                validation_type = "bankid-v5",
                algorithm = "",
                padding = "",
                data = "fredde@jfsbokforing.se,2018-09-13,Ar/so6msWR4av3nAfw9GcQ==",
                value = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+PFNpZ25hdHVyZSB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyI+PFNpZ25lZEluZm8geG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvMDkveG1sZHNpZyMiPjxDYW5vbmljYWxpemF0aW9uTWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvVFIvMjAwMS9SRUMteG1sLWMxNG4tMjAwMTAzMTUiPjwvQ2Fub25pY2FsaXphdGlvbk1ldGhvZD48U2lnbmF0dXJlTWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS8wNC94bWxkc2lnLW1vcmUjcnNhLXNoYTI1NiI+PC9TaWduYXR1cmVNZXRob2Q+PFJlZmVyZW5jZSBUeXBlPSJodHRwOi8vd3d3LmJhbmtpZC5jb20vc2lnbmF0dXJlL3YxLjAuMC90eXBlcyIgVVJJPSIjYmlkU2lnbmVkRGF0YSI+PFRyYW5zZm9ybXM+PFRyYW5zZm9ybSBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnL1RSLzIwMDEvUkVDLXhtbC1jMTRuLTIwMDEwMzE1Ij48L1RyYW5zZm9ybT48L1RyYW5zZm9ybXM+PERpZ2VzdE1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQveG1sZW5jI3NoYTI1NiI+PC9EaWdlc3RNZXRob2Q+PERpZ2VzdFZhbHVlPnlrdDdjSUEwSUlEV2U0WThlM0JTTk1GWlQwZHBCZzFnYTRKUnNzaU1GTXM9PC9EaWdlc3RWYWx1ZT48L1JlZmVyZW5jZT48UmVmZXJlbmNlIFVSST0iI2JpZEtleUluZm8iPjxUcmFuc2Zvcm1zPjxUcmFuc2Zvcm0gQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy9UUi8yMDAxL1JFQy14bWwtYzE0bi0yMDAxMDMxNSI+PC9UcmFuc2Zvcm0+PC9UcmFuc2Zvcm1zPjxEaWdlc3RNZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGVuYyNzaGEyNTYiPjwvRGlnZXN0TWV0aG9kPjxEaWdlc3RWYWx1ZT4rRlVySVV3a0lHTWJaUHB3a3ZMdjNTa3BaSXpMR0RCeUhXQlpVOGltLzVJPTwvRGlnZXN0VmFsdWU+PC9SZWZlcmVuY2U+PC9TaWduZWRJbmZvPjxTaWduYXR1cmVWYWx1ZT5Qb0N1M0h6WW82NGsrWjFNRlFRNzNSaDhmemg4TXJFWVAwd3lsbXhDRE1XOCtpazE2dWF2SzR2T3dCaklaRzhvTWZ0b0drSmlieEZ6dDc3UUVDcVlWcUJVZ3ZPSWRxOTdZbzNtRVNONmpVTnZZcE5vVTU2bGEydlZwYno3SkE4N0NSYklnRVVUYW9yOXZ4a0QrTEEwUXBIOGExRVYwd05rd3A0TVF4L0w4b09LTkhrWGducnB6Y1p6dHFwbm1ibEJxbFJtVUNwdmVYb3JvcWVDeEdocE5nTFlRTEdDU3d2R2JXUHJZeUVUNXNDQTJmMFJ5dVU4VTAxOFUyQjJYajg5akNBNGVCN3JFN2dzSURKVExWS2FMeU9IVnFyU3V1VzN0bjUrVkh6OWFIR1dYRE05bUQ5WThlT2xMdTFRV3NBSVoxM252WVdIL2Joem05RmZ0QWhhc3c9PTwvU2lnbmF0dXJlVmFsdWU+PEtleUluZm8geG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvMDkveG1sZHNpZyMiIElkPSJiaWRLZXlJbmZvIj48WDUwOURhdGE+PFg1MDlDZXJ0aWZpY2F0ZT5NSUlGWFRDQ0EwV2dBd0lCQWdJSVBMbWx3S211TEJrd0RRWUpLb1pJaHZjTkFRRUxCUUF3ZURFTE1Ba0dBMVVFQmhNQ1UwVXhIVEFiQmdOVkJBb01GRlJsYzNSaVlXNXJJRUVnUVVJZ0tIQjFZbXdwTVJVd0V3WURWUVFGRXd3eE1URXhNVEV4TVRFeE1URXhNekF4QmdOVkJBTU1LbFJsYzNSaVlXNXJJRUVnUTNWemRHOXRaWElnUTBFeElIWXhJR1p2Y2lCQ1lXNXJTVVFnVkdWemREQWVGdzB4T0RBNE1qWXlNakF3TURCYUZ3MHlNREE0TWpZeU1UVTVOVGxhTUlHK01Rc3dDUVlEVlFRR0V3SlRSVEVkTUJzR0ExVUVDZ3dVVkdWemRHSmhibXNnUVNCQlFpQW9jSFZpYkNreEVUQVBCZ05WQkFRTUNGTlVTVWRUVTA5T01SQXdEZ1lEVlFRcURBZEdVa1ZFVWtsTE1SVXdFd1lEVlFRRkV3d3hPVGd3TVRBd01USTBOVEV4T1RBM0JnTlZCQ2tNTUNneE9EQTRNamNnTVRRdU5EUXBJRVpTUlVSU1NVc2dVMVJKUjFOVFQwNGdMU0JDWVc1clNVUWdjTU9sSUdacGJERVpNQmNHQTFVRUF3d1FSbEpGUkZKSlN5QlRWRWxIVTFOUFRqQ0NBU0l3RFFZSktvWklodmNOQVFFQkJRQURnZ0VQQURDQ0FRb0NnZ0VCQUtGeEhFRkRpelkvaklmM1d2cUFPUER0eGU5b0hMVUs2S0tPQzB6MHQrWmJJMnZ3VVFPRlM2eVVsOTlPazNkamdLZUZsV0h2bG1CS2JhOVN2ZUhjWmRBZE1WZWcrbTIyRU12NldDY0Y5aU80NFBia1VkaFJYZXE3OW1wVGI4Mk9YV0sxOXZMVE1JTC9MMDl2WGRSU2hvdXVVNG1WZEx1L282MzRreDU2bFJ1d2ZwSDFJQXFWeEN4eFNZS3U3RmJ4eWxHaWkzWXB2S3M0SllWclh5TndKRWRSQmIxUGZpbHV0VVNTUk9iWS8xV1V0YlBhV2hQNWptdUxTN0JCb0NzTVhQS0k5bUpkTlhObWFnYnBsUGZyQUM5QWJuVmVKOVZ5LzV3K0lOWnhqOXlZOUp0SXBaYnRybjYzLzdnQ0pnalRUekl0cGo3aE42TkRGODR0NjhXL1FROENBd0VBQWFPQm96Q0JvREE3QmdnckJnRUZCUWNCQVFRdk1DMHdLd1lJS3dZQkJRVUhNQUdHSDJoMGRIQTZMeTkwWlhOMExuSmxkbTlqWVhScGIyNXpkR0YwZFhNdWMyVXdFUVlEVlIwZ0JBb3dDREFHQmdRcUF3UUZNQTRHQTFVZER3RUIvd1FFQXdJR1FEQWZCZ05WSFNNRUdEQVdnQlJnZW4ybldZT01uNlN4RitvTlEwT1ZRK2FaL1RBZEJnTlZIUTRFRmdRVURGWGdKcWRTdm41NnJGZUZSemcwTjIxZWF0NHdEUVlKS29aSWh2Y05BUUVMQlFBRGdnSUJBQkZOM0d3K2VzQlhYcll1M0JOMW4vTmtMWnNBdkY1WmlteXJGS0VrV0pYUzhlRXZFR1llYmZWM0wyZ0d3aE5vbDdsOFZZcmlzbUpWU1p5czcwZmVPVjExajhSMGF0K1V1WllITnBFY0UydFlFYjNNelloUWZLZFJHRWdHblJzaFBpaU02SmN2L2U3NW5iR1Y2a2QybUlNUXUxSHhndHBWZ1p6LzNHSEpSRVJRNWdCSi9Rek5ldlFiRXJ5VmVBa0ZTUDJicWFRejdqLzFHb0ZJMkZHVzI1MzN2ZEdJaTE5ZU0zL3g3ditKN21IMEpkU25EWGNCeG12ckVkb3pqUzlqcHcrbWdqWEd5YWRTT0hhelkwY2NLUkR4NTNtV2hXZkk3WFVuVWV6a3pGbElXTGNBaTVIRWRFeFg5RkZLcE9rVlBsZ3FkSUdQQzQ4OHd3ckVTdEU3bnNYWEY5OStXa2ZMcGFuVmZodUlvQkZCR2xNVUhOUEZrWVgvem53b3R0Y21zb1NwT3R1elBLVUVCcnFqalpHR2tybVBITlVCT214cXlESU9iaFV4dXlaNHo1TFFLS3hieE9tYWEzNlc5T1FHWkV4M1QxVzZTOCtCMmZoc3Mzb0pFQWltL2lRUVBWYTRwTk5mdWxlcnYxbktaTHBkUlF5TTFWVGRTTWhOM0dqWHV2Y0RwTGNsM1lFUXc1Vm5DNXB1S2dkUnRzUnJYZDVnS3Y3SWRVV2JoZmYzY3NueXZuZEpNSW02aEc2YnBqd2hHaWVwbk1VMnlzempnekhieUtyYkx0SkdrakxYczlvSHZyYW5LTlk0T0ptMzZESXo2ckRxbkhCdUhQQWJpNjQzeEV2aVIxT285MEZNSVFkb1MwdTJKM2N5NFFsTU1CeEEzVWtVYjBDNE5NZG08L1g1MDlDZXJ0aWZpY2F0ZT48WDUwOUNlcnRpZmljYXRlPk1JSUYzakNDQThhZ0F3SUJBZ0lJRm5aVnllaG1YWXd3RFFZSktvWklodmNOQVFFTkJRQXdiakVMTUFrR0ExVUVCaE1DVTBVeEhUQWJCZ05WQkFvTUZGUmxjM1JpWVc1cklFRWdRVUlnS0hCMVltd3BNUlV3RXdZRFZRUUZFd3d4TVRFeE1URXhNVEV4TVRFeEtUQW5CZ05WQkFNTUlGUmxjM1JpWVc1cklFRWdRMEVnZGpFZ1ptOXlJRUpoYm10SlJDQlVaWE4wTUI0WERURXhNRGt5TWpFME1qRXhORm9YRFRNME1USXdNVEUwTWpFeE5Gb3dlREVMTUFrR0ExVUVCaE1DVTBVeEhUQWJCZ05WQkFvTUZGUmxjM1JpWVc1cklFRWdRVUlnS0hCMVltd3BNUlV3RXdZRFZRUUZFd3d4TVRFeE1URXhNVEV4TVRFeE16QXhCZ05WQkFNTUtsUmxjM1JpWVc1cklFRWdRM1Z6ZEc5dFpYSWdRMEV4SUhZeElHWnZjaUJDWVc1clNVUWdWR1Z6ZERDQ0FpSXdEUVlKS29aSWh2Y05BUUVCQlFBRGdnSVBBRENDQWdvQ2dnSUJBSVcwRFBvcExFaHRhd1ZSd05yRTQzMUdWc2gvSG5XVnNYZGdPanpVc0Q3UUQzMC90Zk9IUk9RaTluTHVEV2tZMWZFVXhaMDZZcTVMdFJPb0Zwa1RRNlNSaTJSZ2lVa3VDTnFNRXdzajJlaWE3S2hZUklrL1hKa2tGcDFCdkU2Mkk2M3Z0VXpaelM2OUhBc01OUGxmZExVMnBJWjJBbmQyUUoyZEMweGltbUZqWTVrNS96Ny9OazNKR0JiYXhMSC9YNnpoY05xT3ByMlNydjlHK2xrK0d2eTdoUUxJbU5MUlYrNEczbWFsSGo2UU0rd0RjUkt2VDRWK2lSZHZ6UDlvODAzL2crR0w1cWl1Zlc2UmRUKzJsd0dpZlAyZDNzdUw3OXVHVzFITzhxYmlpL2k0SFR4RGZ0S2RYRnNsRnJYZlIrK1FVVTRCK3Y2UXliNHJGM3FoRGZlYWtnZkw4dXpmdE10VE1SbG93eEliMDhqeENlaENTYVkwQ01CSFFUUzBMdFgxQy9Wak02VWJicFNhMjgwelNMK3hYbFM3UzcyN3NKQjcyMmZ6V1IzL05TcDNNWlRiRTBRQXFNVEVOWTRwZndjL2xYd1ZuOFR2QU53MUZJeEU3aWt3SUJNRlNvNmVYMlVERHo5YWk2ZHpScllmdEk0NEV0TFR2M0tWNVVEV2NJYnNSQnZsZ0JRcXF1cGhjdVJWdjFhNlhvOXhlSDIrbytCc3Irc291bWlDNnpJRnVVdUJ4QjR1cXNTcWVWUUZrSWFlcGlud2hYNUNKQlpMY09SYU1aRjZJMWtHdkVEWk9WWVhPRXQ5UFdnL1NzU2NHTStzZjI1MTBHejBmMm9tUWpPTDVCZXpkWVlLTkF3eml6OVUxSXIxVnB2emtKRjRTQTNXMDVjbWpqS1pBZ01CQUFHamRqQjBNQjBHQTFVZERnUVdCQlJnZW4ybldZT01uNlN4RitvTlEwT1ZRK2FaL1RBUEJnTlZIUk1CQWY4RUJUQURBUUgvTUI4R0ExVWRJd1FZTUJhQUZLUHllSGtkSzBXS3llSEtsUW5sbm0vT3kwN0ZNQkVHQTFVZElBUUtNQWd3QmdZRUtnTUVCVEFPQmdOVkhROEJBZjhFQkFNQ0FRWXdEUVlKS29aSWh2Y05BUUVOQlFBRGdnSUJBRHhoeXpXU3pva3lHK2hVQ3AzVWc3UVp4Yk1MSys2SVlwKzhhY1J1VFNGZnI1bWFIM01yeWQ4Ny9CMnk5SzNmVytGWFFMcGRoVkhvdktKT0FReXYvdDNDQTYyWkdyemhBWEdxQ2NSOVNuNDRlY0tSSlBFOVpKYnphbG80d3RLUlV2MDRXMlpnRnVuWVRONTVUc05uM2JHemNJaUFkZE1xOVRNS3dJamw2cDVpNm9JakFtdDkvNzVRZjdxUS8xeDIwRVVkc3YrOFFQSXAxdmxCOHZBekF0bys4YlpGQ1JzZE1WTFJSazk2Q29TNTN2NGFEWVlBTXhtc1RiZ3ZMcVZVNS9DTmZWRWdWZVNwRlZTejZmbGJGTUJaZDVMT1BnbGkvbFJKN0ZXZXdRdnJaYUtnZkpnZG1VVXZDcGkwZUQrL0tCbnNFSkxiaGRuSy9CK2lUbzRBNkJ3b1IrOVhoT1F5Tk1UQi9TRHRTWWN6SjM1dkZoWmZLSjUvMHBzcVhTSkgvMjV3QTRwZS8zNEVSelExbWdsYWR0NkpPaG5XZjkySnc1amR3N0JGcHRnN2xtSWtEeVlEVSs2UnlFc0FyQ2liSSsyOHlGNS9mQ1pDdVVkd0R3OWlIcG9vZGYxaDh0MWdmUG5ubWtjd0dUZlBnL2R1VWdrRndLWTk3U3pmWmdSMDJoZDd4eG81cEs3OWN6aW1NRjJHVEZ3OVNXU25sWks3MWZvWTI1RnpTVUhObXVHSGhGekc5OEFGSXQwVkx3aVRqOHRKZVNqVGk0MWlmMjM3dkROdnNlcHQrOC90dDgwL2Y0NUt6UE5mV1VCMDYvRkdyMHdmb1lnWnA0UGk5UlJUWHpEYWZ3ajdxTGR1YWVwUnJMY0VVcFhXQ0dydVNVeWx4eENoZEJUd1Z6Wm48L1g1MDlDZXJ0aWZpY2F0ZT48WDUwOUNlcnRpZmljYXRlPk1JSUYwekNDQTd1Z0F3SUJBZ0lJVVltZmR0cXR5ODB3RFFZSktvWklodmNOQVFFTkJRQXdiVEVrTUNJR0ExVUVDZ3diUm1sdVlXNXphV1ZzYkNCSlJDMVVaV3R1YVdzZ1FrbEVJRUZDTVI4d0hRWURWUVFMREJaQ1lXNXJTVVFnVFdWdFltVnlJRUpoYm10eklFTkJNU1F3SWdZRFZRUUREQnRVWlhOMElFSmhibXRKUkNCU2IyOTBJRU5CSUhZeElGUmxjM1F3SGhjTk1URXdPVEl5TVRReE5UQXpXaGNOTXpReE1qTXhNVFF3TVRNeldqQnVNUXN3Q1FZRFZRUUdFd0pUUlRFZE1Cc0dBMVVFQ2d3VVZHVnpkR0poYm1zZ1FTQkJRaUFvY0hWaWJDa3hGVEFUQmdOVkJBVVREREV4TVRFeE1URXhNVEV4TVRFcE1DY0dBMVVFQXd3Z1ZHVnpkR0poYm1zZ1FTQkRRU0IyTVNCbWIzSWdRbUZ1YTBsRUlGUmxjM1F3Z2dJaU1BMEdDU3FHU0liM0RRRUJBUVVBQTRJQ0R3QXdnZ0lLQW9JQ0FRQ1RxVTd1eGs1UXpiWFM2QXJYSUdUV05lWlh6NjViemRnb3hiNzlMdlloL3A3a2NLMjVtQTJ0ekdwTzNRUzFlS0pKdTg0RzlVTnptNG1NbDZjbmduWGNqeEVUWWlFcXRpanJBNW1mejg2NS9YNlVnT3BYN0Rrb3VROGQ1ZUR5aEo0OVVyRHFscmdvVk14MzIya00wU1o0aGVWZVg4M2UxSVNGaXl4cVpCS3hoMjV5S1lFWkE0RXpJckRqMnRpOENScldQSENUV2FJRnBjZDVUeU1ocFVUUG40RHp3UGhQR1dNUk54Z09BZVA0QlNEQjdSNmF6NHJveDdUUGtkMnNXRzFPRGovMElSUGhKUzFkUTFCN1FpTkhZNThSam5OVGhFUUt3ZFdXTVBNS1B0aFNkK0dFakw5R0RhZll4T3NJcktGWXdsWU5CVzNDNW1iZTNUKzNqK0F4ajZXMkhiZ21KWFBHSXRMdWN4WTFrUHdUOUw3dTVuSXhhUk9taDF1VHdZcXI5cHVHcTZzb0puZ2dFUzNLNFBJaE02a2Ftdm5DQ1BYb3FXQ0NydVNFUFZneUVaRWkwc2h5KzgxUXNlYjFnYzlyWWdWckVuTEJPSXlNcWFUdEV4YUZwcllidjFmL0F3V3RqRlVpMlhpU2ROOGFNcCtrcWJpKzF0S0pVVVBMQytDcmR1OWZGby84bHNsU2RldytTblBWRmVWejVDT0tidDZHVEU0eGNKZVJ6VzV3UTB3N2IrckdMV2hKdndSSnNTNUdYdnFhM0xnOEV5V2lMSnN3dVRGYUV3UFVEdlpCdnlGWkVaZXJ0S2daYlJZdmV6bzkvZ3J3eUIrbW9yVnJMcnl1OWNoWUVZd0U1NTB1enlLdHpYVXp5Z1Y4RnBYZTlEcG1wT1NmR01BVVJRSURBUUFCbzNZd2REQWRCZ05WSFE0RUZnUVVvL0o0ZVIwclJZcko0Y3FWQ2VXZWI4N0xUc1V3RHdZRFZSMFRBUUgvQkFVd0F3RUIvekFmQmdOVkhTTUVHREFXZ0JSSzk2TnFDTm9JT0JjWlV5akkycWJXTk5oYXVqQVJCZ05WSFNBRUNqQUlNQVlHQkNvREJBVXdEZ1lEVlIwUEFRSC9CQVFEQWdFR01BMEdDU3FHU0liM0RRRUJEUVVBQTRJQ0FRRFAxRG94akVqZXlHMjd4ZWFpK21weHhKb3FCMVJEVlRFWTg2UmROeWx1VUtRT0liZktKTW1YK0RYNHZUdVVRUzM1Mzl4ekhLd3BqNmdrK2laVmpGMVVvSnRHcCtxdXJqamFyT2g0NHMrK3MweVdLaUtySkJFbG9KbjhvK1lYRlQ4QzdlMVd0cUpWb2FGZERCQ3ZvaEp5SzIwUEtTNy9uVUc1YjdKNmlxMzUxN1l2amI0RDk0THQwZEhOU2dEMkJJSUhtTmtwU1lXZ3lpMXNlYXZoTjVBanRmSnI0cDEwMXUyU3NOY0xBcjQyQTVmcmFuOXZMMjlIamFNMk1UVThMME94b0lYOGxnY3BVeTl3Y2k3bEhRS09pd2FPY0lLZkNDMXFNN2xPNXowYzRQK28welQ2MTgzeEpWM3JtdzIyR0dZZDQwRUJxVzk3b3FCSzBJaitLbDVzdXljWjRKMnFLMWFWY2lZQlpzQk5sYnRtei9rOEh1Qnh5OVdiRWVQc1kvNjFJNTBmQkxTQWtWay9UZWE0aitOTkhKMWltcDdCbzE4YUxvOHBsYjllMmlaZUlEekgxdTY2bzBSRlliSGRuSkQ4Q25QZUJMVmdTdkVxbUJTMTFmZ0hyODEvdGs1bEp4Y0tlamRzRWZ0ekdReHd1SHcvcGpram9iSWt4cnJvWHBhNmlYb2tWeUg0YmUxNitmL2REYUVraDlSZjhMaDFVRVFQeHhwQ3lJU01pZkg1cEw3OERLaEduaDhWZmk3RWVzVVYxazZZM2VWQ0Z3MkNDS1djdlhzSmI5UXFMRnNEcUlsV1BoNmJCZ000YVhmcGUwYXJEcmdZUmJieDhMNm91aHl4QUh3anR6OWkwbFhleldNWDVmN1FZUkVNVEM1eUJQTlRUUDJmQ05zb3pRPT08L1g1MDlDZXJ0aWZpY2F0ZT48L1g1MDlEYXRhPjwvS2V5SW5mbz48T2JqZWN0PjxiYW5rSWRTaWduZWREYXRhIHhtbG5zPSJodHRwOi8vd3d3LmJhbmtpZC5jb20vc2lnbmF0dXJlL3YxLjAuMC90eXBlcyIgSWQ9ImJpZFNpZ25lZERhdGEiPjx1c3JWaXNpYmxlRGF0YSBjaGFyc2V0PSJVVEYtOCIgdmlzaWJsZT0id3lzaXd5cyI+Wm5KbFpHUmxRR3BtYzJKdmEyWnZjbWx1Wnk1elpTd3lNREU0TFRBNUxURXpMRUZ5TDNOdk5tMXpWMUkwWVhZemJrRm1kemxIWTFFOVBRPT08L3VzclZpc2libGVEYXRhPjxzcnZJbmZvPjxuYW1lPlkyNDlSbEFnVkdWemRHTmxjblFnTWl4dVlXMWxQVlJsYzNRZ1lYWWdRbUZ1YTBsRUxITmxjbWxoYkU1MWJXSmxjajB4TWpNME5UWTNPQ3h2UFZSbGMzUmlZVzVySUVFZ1FVSWdLSEIxWW13cExHTTlVMFU9PC9uYW1lPjxub25jZT56UVcvWDhXdXVLazZOUmdLR20zUUJoS0N1ems9PC9ub25jZT48ZGlzcGxheU5hbWU+VkdWemRDQmhkaUJDWVc1clNVUT08L2Rpc3BsYXlOYW1lPjwvc3J2SW5mbz48Y2xpZW50SW5mbz48ZnVuY0lkPlNpZ25pbmc8L2Z1bmNJZD48dmVyc2lvbj5VR1Z5YzI5dVlXdzlOeTQxTGpBdU1qSW1RbUZ1YTBsRVgyVjRaVDAzTGpVdU1DNHlNaVpDU1ZOUVBUY3VOUzR3TGpJeUpuQnNZWFJtYjNKdFBYZHBialkwSm05elgzWmxjbk5wYjI0OWQybHVNVEFtZFdocFBXYzNWRFJoYW5STVNuSndlVm92UWxwTFpGRldiMm8yVjBwelFWa21iR1ZuWVdONWRXaHBQV2RzZVRGS1oyTlJiMjgzVURkbVVqWm9LM1pNYTBkQ05GVkxjMW9tWW1WemRGOWlaV1p2Y21VOU1UVXpPVFF6TkRRME5DWT08L3ZlcnNpb24+PGVudj48YWk+PHR5cGU+VjBsT1JFOVhVdz09PC90eXBlPjxkZXZpY2VJbmZvPmQybHVNVEE9PC9kZXZpY2VJbmZvPjx1aGk+ZzdUNGFqdExKcnB5Wi9CWktkUVZvajZXSnNBWTwvdWhpPjxmc2liPjE8L2ZzaWI+PHV0Yj5jczE8L3V0Yj48cmVxdWlyZW1lbnQ+PGNvbmRpdGlvbj48dHlwZT5DZXJ0aWZpY2F0ZVBvbGljaWVzPC90eXBlPjx2YWx1ZT4xLjIuMy40LjU8L3ZhbHVlPjwvY29uZGl0aW9uPjwvcmVxdWlyZW1lbnQ+PHVhdXRoPnB3PC91YXV0aD48L2FpPjwvZW52PjwvY2xpZW50SW5mbz48L2JhbmtJZFNpZ25lZERhdGE+PC9PYmplY3Q+PC9TaWduYXR1cmU+",
                certificate = ""
            });

            // Convert the object to a byte array and return it
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post));

        } // End of the CreateAnnytabDoxMeta method

        /// <summary>
        /// Create an quotation according to the Annytab Dox Trade v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxQuotation()
        {
            // Create an order
            AnnytabDoxTrade post = new AnnytabDoxTrade();
            post.id = Guid.NewGuid().ToString();
            post.document_type = "quotation";
            post.payment_reference = "D1005";
            post.issue_date = "2020-04-15";
            post.due_date = "2020-04-30";
            post.delivery_date = "2020-04-15";
            post.buyer_references = new Dictionary<string, string>();
            post.buyer_references.Add("customer_id", "105");
            post.terms_of_delivery = "EXW";
            post.terms_of_payment = "15";
            post.mode_of_delivery = "WEB";
            post.total_weight_kg = 0M;
            post.penalty_interest = 0.10M;
            post.currency_code = "SEK";
            post.vat_country_code = "SE";
            post.vat_state_code = null;
            post.comment = "Thank you for buying from us.";
            post.seller_information = new PartyInformation()
            {
                person_id = "556864-2747",
                person_name = "A Name Not Yet Taken AB",
                address_line_1 = "Klyvaregatan 1 lgh 1103",
                postcode = "30290",
                city_name = "Halmstad",
                country_name = "Sweden",
                country_code = "SE",
                contact_name = "Fredrik Stigsson",
                email = "info@annytab.se",
                vat_number = "SE556864274701"
            };
            post.buyer_information = new PartyInformation
            {
                person_id = "888888-9999",
                person_name = "Jan Jansson",
                address_line_1 = "St. Eriksgatan 15",
                address_line_2 = "Floor 1",
                postcode = "500505",
                city_name = "Stockholm",
                country_name = "Sweden",
                country_code = "SE",
                state_code = null,
                contact_name = "Jan Jansson",
                phone_number = "078008080",
                email = "info@demo.se",
                vat_number = "SE888888999901"
            };
            post.product_rows = new List<ProductRow>();
            post.product_rows.Add(new ProductRow
            {
                product_code = "GiB",
                manufacturer_code = "GiB",
                gtin = "",
                product_name = "Gibibytes",
                vat_rate = 0.25M,
                quantity = 1000M,
                unit_code = "pcs",
                unit_price = 0.5M,
                subrows = new List<ProductRow>()
            });
            post.product_rows.Add(new ProductRow
            {
                product_code = "File",
                manufacturer_code = "File",
                gtin = "",
                product_name = "Files",
                vat_rate = 0.12M,
                quantity = 100M,
                unit_code = "pcs",
                unit_price = 0.4M,
                subrows = null
            });
            post.product_rows.Add(new ProductRow
            {
                product_code = "Sign",
                manufacturer_code = "Sign",
                gtin = "",
                product_name = "Signatures",
                vat_rate = 0.06M,
                quantity = 13M,
                unit_code = "pcs",
                unit_price = 60M,
                subrows = null
            });
            post.vat_specification = new List<VatSpecification>();
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.25M,
                taxable_amount = 500M,
                tax_amount = 125M
            });
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.12M,
                taxable_amount = 40M,
                tax_amount = 4.80M
            });
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.06M,
                taxable_amount = 780M,
                tax_amount = 46.8M
            });
            post.subtotal = 1320M;
            post.vat_total = 176.60M;
            post.rounding = 0.4M;
            post.total = 1497M;
            post.paid_amount = 0M;
            post.balance_due = 1497M;

            // Convert the object to a byte array and return it
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post));

        } // End of the CreateAnnytabDoxQuotation method

        /// <summary>
        /// Create an order according to the Annytab Dox Trade v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxOrder()
        {
            // Create an order
            AnnytabDoxTrade post = new AnnytabDoxTrade();
            post.id = Guid.NewGuid().ToString();
            post.document_type = "order";
            post.payment_reference = "D1005";
            post.issue_date = "2020-04-15";
            post.due_date = "2020-04-30";
            post.delivery_date = "2020-04-15";
            post.buyer_references = new Dictionary<string, string>();
            post.buyer_references.Add("customer_id", "105");
            post.terms_of_delivery = "EXW";
            post.terms_of_payment = "15";
            post.mode_of_delivery = "WEB";
            post.total_weight_kg = 0M;
            post.penalty_interest = 0.10M;
            post.currency_code = "SEK";
            post.vat_country_code = "SE";
            post.vat_state_code = null;
            post.comment = "Thank you for buying from us.";
            post.seller_information = new PartyInformation()
            {
                person_id = "556864-2747",
                person_name = "A Name Not Yet Taken AB",
                address_line_1 = "Klyvaregatan 1 lgh 1103",
                postcode = "30290",
                city_name = "Halmstad",
                country_name = "Sweden",
                country_code = "SE",
                contact_name = "Fredrik Stigsson",
                email = "info@annytab.se",
                vat_number = "SE556864274701"
            };
            post.buyer_information = new PartyInformation
            {
                person_id = "888888-9999",
                person_name = "Jan Jansson",
                address_line_1 = "St. Eriksgatan 15",
                address_line_2 = "Floor 1",
                postcode = "500505",
                city_name = "Stockholm",
                country_name = "Sweden",
                country_code = "SE",
                state_code = null,
                contact_name = "Jan Jansson",
                phone_number = "078008080",
                email = "info@demo.se",
                vat_number = "SE888888999901"
            };
            post.product_rows = new List<ProductRow>();
            post.product_rows.Add(new ProductRow
            {
                product_code = "GiB",
                manufacturer_code = "GiB",
                gtin = "",
                product_name = "Gibibytes",
                vat_rate = 0.25M,
                quantity = 1000M,
                unit_code = "pcs",
                unit_price = 0.5M,
                subrows = new List<ProductRow>()
            });
            post.product_rows.Add(new ProductRow
            {
                product_code = "File",
                manufacturer_code = "File",
                gtin = "",
                product_name = "Files",
                vat_rate = 0.12M,
                quantity = 100M,
                unit_code = "pcs",
                unit_price = 0.4M,
                subrows = null
            });
            post.product_rows.Add(new ProductRow
            {
                product_code = "Sign",
                manufacturer_code = "Sign",
                gtin = "",
                product_name = "Signatures",
                vat_rate = 0.06M,
                quantity = 13M,
                unit_code = "pcs",
                unit_price = 60M,
                subrows =null
            });
            post.vat_specification = new List<VatSpecification>();
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.25M,
                taxable_amount = 500M,
                tax_amount = 125M
            });
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.12M,
                taxable_amount = 40M,
                tax_amount = 4.80M
            });
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.06M,
                taxable_amount = 780M,
                tax_amount = 46.8M
            });
            post.subtotal = 1320M;
            post.vat_total = 176.60M;
            post.rounding = 0.4M;
            post.total = 1497M;
            post.paid_amount = 0M;
            post.balance_due = 1497M;

            // Convert the object to a byte array and return it
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post));

        } // End of the CreateAnnytabDoxOrder method

        /// <summary>
        /// Create an invoice according to the Annytab Dox Trade v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxInvoice()
        {
            // Create an invoice
            AnnytabDoxTrade post = new AnnytabDoxTrade();
            post.id = Guid.NewGuid().ToString();
            post.document_type = "invoice";
            post.payment_reference = "D1005";
            post.issue_date = "2020-04-15";
            post.due_date = "2020-04-30";
            post.delivery_date = "2020-04-15";
            post.buyer_references = new Dictionary<string, string>();
            post.buyer_references.Add("customer_id", "105");
            post.terms_of_delivery = "EXW";
            post.terms_of_payment = "15";
            post.mode_of_delivery = "WEB";
            post.total_weight_kg = 0M;
            post.penalty_interest = 0.10M;
            post.currency_code = "SEK";
            post.vat_country_code = "SE";
            post.vat_state_code = null;
            post.comment = "Thank you for buying from us.";
            post.seller_information = new PartyInformation()
            {
                person_id = "556864-2747",
                person_name = "A Name Not Yet Taken AB",
                address_line_1 = "Klyvaregatan 1 lgh 1103",
                postcode = "30290",
                city_name = "Halmstad",
                country_name = "Sweden",
                country_code = "SE",
                contact_name = "Fredrik Stigsson",
                email = "info@annytab.se",
                vat_number = "SE556864274701"
            };
            post.buyer_information = new PartyInformation
            {
                person_id = "888888-9999",
                person_name = "Jan Jansson",
                address_line_1 = "St. Eriksgatan 15",
                address_line_2 = "Floor 1",
                postcode = "500505",
                city_name = "Stockholm",
                country_name = "Sweden",
                country_code = "SE",
                state_code = null,
                contact_name = "Jan Jansson",
                phone_number = "078008080",
                email = "info@demo.se",
                vat_number = "SE888888999901"
            };
            post.payment_options = new List<PaymentOption>
            {
                new PaymentOption
                {
                    name = "IBAN",
                    account_reference = "SE4680000816959239073274",
                    bank_identifier_code = "SWEDSESS",
                    bank_name = "Swedbank AB",
                    bank_country_code = "SE"
                },
                new PaymentOption
                {
                    name = "BG",
                    account_reference = "7893514",
                    bank_identifier_code = "BGABSESS",
                    bank_name = "Bankgirocentralen BGC AB",
                    bank_country_code = "SE"
                },
                new PaymentOption
                {
                    name = "SWISH",
                    account_reference = "1235370366",
                    bank_identifier_code = "SWEDSESS",
                    bank_name = "Swedbank AB",
                    bank_country_code = "SE"
                },
                new PaymentOption
                {
                    name = "PAYPAL.ME",
                    account_reference = "https://www.paypal.me/annytab",
                    bank_identifier_code = "",
                    bank_name = "PayPal",
                    bank_country_code = "US"
                }
            };
            post.product_rows = new List<ProductRow>();
            post.product_rows.Add(new ProductRow
            {
                product_code = "GiB",
                manufacturer_code = "GiB",
                gtin = "",
                product_name = "Gibibytes",
                vat_rate = 0.25M,
                quantity = 1000M,
                unit_code = "pcs",
                unit_price = 0.5M,
                subrows = new List<ProductRow>()
            });
            post.product_rows.Add(new ProductRow
            {
                product_code = "File",
                manufacturer_code = "File",
                gtin = "",
                product_name = "Files",
                vat_rate = 0.12M,
                quantity = 100M,
                unit_code = "pcs",
                unit_price = 0.4M,
                subrows = null
            });
            post.product_rows.Add(new ProductRow
            {
                product_code = "Sign",
                manufacturer_code = "Sign",
                gtin = "",
                product_name = "Signatures",
                vat_rate = 0.06M,
                quantity = 13M,
                unit_code = "pcs",
                unit_price = 60M,
                subrows = null
            });
            post.vat_specification = new List<VatSpecification>();
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.25M,
                taxable_amount = 500M,
                tax_amount = 125M
            });
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.12M,
                taxable_amount = 40M,
                tax_amount = 4.80M
            });
            post.vat_specification.Add(new VatSpecification
            {
                tax_rate = 0.06M,
                taxable_amount = 780M,
                tax_amount = 46.8M
            });
            post.subtotal = 1320M;
            post.vat_total = 176.60M;
            post.rounding = 0.4M;
            post.total = 1497M;
            post.paid_amount = 0M;
            post.balance_due = 1497M;

            // Convert the object to a byte array and return it
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post));

        } // End of the CreateAnnytabDoxInvoice method

        /// <summary>
        /// Create a contract according to the Annytab Dox Contract v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxContract()
        {
            // Create a contract
            AnnytabDoxContract post = new AnnytabDoxContract();
            post.id = Guid.NewGuid().ToString();
            post.title = "Example";
            post.issue_date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            post.parties = new List<PartyInformation>
            {
                new PartyInformation
                {
                    person_id = "888888-7777",
                    person_name = "Nils Nilsson",
                    address_line_1 = "Contractstreet",
                    address_line_2 = "",
                    postcode = "33333",
                    city_name = "City",
                    country_name = "Sweden",
                    country_code = "SE",
                    state_code = "",
                    contact_name = "Nils Nilsson",
                    phone_number = "",
                    email = "noemail@gmail.com",
                    vat_number = ""
                },
                new PartyInformation
                {
                    person_id = "43545354354",
                    person_name = "Glenn Testman",
                    address_line_1 = "address line 1",
                    address_line_2 = "address line 2",
                    postcode = "Postcode",
                    city_name = "City",
                    country_name = "USA",
                    country_code = "US",
                    state_code = "CA",
                    contact_name = "Contact name",
                    phone_number = "Phonenumber",
                    email = "email@email.com",
                    vat_number = ""
                }
            };
            post.articles = new List<ContractPoint>()
            {
                new ContractPoint
                {
                    id = "1.",
                    title = "Explanation",
                    text_html = "The <b>first</b> point in the contract.",
                    sections = new List<ContractPoint>
                    {
                        new ContractPoint
                        {
                            id = "a)",
                            text_html = "Point 1.a in the contract.",
                            sections = new List<ContractPoint>{}
                        },
                        new ContractPoint
                        {
                            id = "b)",
                            text_html = "Point 1.b in the contract.",
                            sections = new List<ContractPoint>{}
                        }
                    }
                },
                new ContractPoint
                {
                    id = "2.",
                    title = "Transfer Date",
                    text_html = "Point number 2 in the contract.",
                    sections = new List<ContractPoint>
                    {
                        new ContractPoint
                        {
                            id = "2.1.",
                            text_html = "Point 2.1 in the contract.",
                            sections = new List<ContractPoint>{}
                        },
                        new ContractPoint
                        {
                            id = "2.2.",
                            text_html = "Point 2.2 in the contract",
                            sections = new List<ContractPoint>{}
                        }
                    }
                }
            };

            // Convert the object to a byte array and return it
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post));

        } // End of the CreateAnnytabDoxContract method

        /// <summary>
        /// Create a travel expense claim according to the Annytab Dox Travel Expense Claim v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxTravelExpenseClaim()
        {
            // Create a travel expense claim
            AnnytabDoxTravelExpenseClaim post = new AnnytabDoxTravelExpenseClaim();
            post.personnel_id = "001";
            post.name = "Nils Nilsson";
            post.cost_center = "Marketing";
            post.currency_code = "SEK";
            post.trip_purpose = "Meeting with our largest customer";
            post.destination = "Stockholm";
            post.departure_date = "2018-08-01T08:00:00";
            post.return_date = "2018-08-02T16:00:00";

            // Add expense rows
            post.expense_rows = new List<TravelExpenseRow>();
            post.expense_rows.Add(new TravelExpenseRow
            {
                code = "ADT1016",
                description = "Private car fuel, tax free",
                quantity = 200,
                unit_code = "km",
                unit_price = 1.85M
            });
            post.expense_rows.Add(new TravelExpenseRow
            {
                code = "ADT1015",
                description = "Accomodation",
                quantity = 1,
                unit_code = "day",
                unit_price = 1495M
            });

            // Convert the object to a byte array and return it
            string json = JsonConvert.SerializeObject(post, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return Encoding.UTF8.GetBytes(json);

        } // End of the CreateAnnytabDoxTravelExpenseClaim method

        /// <summary>
        /// Create a drive log according to the Annytab Dox Drive Log v1 standard
        /// </summary>
        public static byte[] CreateAnnytabDoxDriveLog()
        {
            // Create a drive log
            AnnytabDoxDriveLog post = new AnnytabDoxDriveLog();
            post.personnel_id = "001";
            post.name = "Nils Nilsson";
            post.cost_center = "Marketing";
            post.registration_number = "SXL 837";
            post.unit_code = "km";
            post.start_date = "2018-08-01T00:00:00";
            post.end_date = "2018-08-31T23:59:59";
            post.opening_odometer = 5000M;
            post.ending_odometer = 5125M;

            // Add log rows
            post.log_rows = new List<DriveLogRow>();
            post.log_rows.Add(new DriveLogRow
            {
                start_odometer = 5000M,
                start_time = "2018-08-05T09:30:11",
                from = "Halmstad",
                end_odometer = 5065M,
                end_time = "2018-08-05T12:30:11",
                to = "Stockholm",
                description = "Meeting with Olle.",
                business_trip = true
            });
            post.log_rows.Add(new DriveLogRow
            {
                start_odometer = 5065M,
                start_time = "2018-08-05T15:10:34",
                from = "Stockholm",
                end_odometer = 5125M,
                end_time = "2018-08-05T20:15:55",
                to = "Halmstad",
                description = "Driving home from meeting with Olle.",
                business_trip = true
            });

            // Convert the object to a byte array and return it
            string json = JsonConvert.SerializeObject(post, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return Encoding.UTF8.GetBytes(json);

        } // End of the CreateAnnytabDoxDriveLog method

    } // End of the class

} // End of the namespace