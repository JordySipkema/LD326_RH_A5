using System;

namespace Mallaca.Network
{
    public class Statuscode
    {
        public int Code { get; private set; }
        public string Description { get; private set; }

        public enum Status
        {
            Ok = 200,
            Unauthorized = 401,
            AccessDenied = 403,
            InvalidUsernameOrPassword = 430,
            CommandNotFound = 500,
            SyntaxError = 501,
            CommandNotImplemented = 502
        }
        public Statuscode(Status status)
        {
            switch (status)
            {
                case Status.Ok:
                    Code = 200;
                    Description = "OK!";
                    break;
                case Status.Unauthorized:
                    Code = 401;
                    Description = "UNAUTHORIZED";
                    break;
                case Status.AccessDenied:
                    Code = 403;
                    Description = "ACCESS DENIED";
                    break;
                case Status.InvalidUsernameOrPassword:
                    Code = 430;
                    Description = "INVALID USERNAME OR PASSWORD";
                    break;
                case Status.CommandNotFound:
                    Code = 500;
                    Description = "COMMAND NOT FOUND";
                    break;
                case Status.SyntaxError:
                    Code = 501;
                    Description = "SYNTAX ERROR";
                    break;
                case Status.CommandNotImplemented:
                    Code = 502;
                    Description = "COMMAND NOT IMPLEMENTED";
                    break;
            }
        }

        public static int GetCode(Status status)
        {
            switch (status)
            {
                case Status.Ok:
                    return 200;
                case Status.Unauthorized:
                    return 401;
                case Status.AccessDenied:
                    return 403;
                case Status.InvalidUsernameOrPassword:
                    return 430;
                case Status.CommandNotFound:
                    return 500;
                case Status.SyntaxError:
                    return 501;
                case Status.CommandNotImplemented:
                    return 502;
            }
            return 0;
        }


        public static string GetDescription(Status status)
        {
            switch (status)
            {
                case Status.Ok:
                    return "OK!";
                case Status.Unauthorized:
                    return "UNAUTHORIZED";
                case Status.AccessDenied:
                    return "ACCESS DENIED";
                case Status.InvalidUsernameOrPassword:
                    return "INVALID USERNAME OR PASSWORD";
                case Status.CommandNotFound:
                    return "COMMAND NOT FOUND";
                case Status.SyntaxError:
                    return "SYNTAX ERROR";
                case Status.CommandNotImplemented:
                    return "COMMAND NOT IMPLEMENTED";
            }
            return String.Empty;
        }

    }
}