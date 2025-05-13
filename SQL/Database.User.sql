-- Script PostgreSQL para criar usu�rio admin e configurar permiss�es

-- 1. Criar o usu�rio com senha forte
CREATE USER admin_chamados WITH PASSWORD 'S3nh4Sup3rS3gur@!2024';

-- 2. Conceder todos os privil�gios no banco de dados "chamados"
GRANT ALL PRIVILEGES ON DATABASE chamados TO admin_chamados;

-- 3. Conceder privil�gios em todas as tabelas (execute isto ap�s conectar ao banco "chamados")
\c chamados
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO admin_chamados;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO admin_chamados;
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO admin_chamados;

-- 4. Opcional: Tornar o usu�rio superusu�rio (se necess�rio)
ALTER USER admin_chamados WITH SUPERUSER;

-- Connection string para uso em aplica��es:
-- PostgreSQL: postgresql://admin_chamados:S3nh4Sup3rS3gur@!2024@localhost:5432/chamados
