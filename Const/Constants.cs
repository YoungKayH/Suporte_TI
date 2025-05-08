using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suporte_TI.Const
{
    internal class Constants {
        public static class Database {  
            public const string DatabaseName    = "chamados";
            public const string Host            = "localhost";
            public const string Port            = "5432";
            public const string UserName        = "admin_chamados";
            public const string Password        = "S3nh4Sup3rS3gur@!2024";
            
            public static readonly string ConnectionUrl = $"Host={Host};Port={Port};Database={DatabaseName};Username={UserName};Password={Password}";
        }

    }
} 