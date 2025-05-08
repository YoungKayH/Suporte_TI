-- Script PostgreSQL para criar usuário admin e configurar permissões

-- 1. Criar o usuário com senha forte
CREATE USER admin_chamados WITH PASSWORD 'S3nh4Sup3rS3gur@!2024';

-- 2. Conceder todos os privilégios no banco de dados "chamados"
GRANT ALL PRIVILEGES ON DATABASE chamados TO admin_chamados;

-- 3. Conceder privilégios em todas as tabelas (execute isto após conectar ao banco "chamados")
\c chamados
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO admin_chamados;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO admin_chamados;
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO admin_chamados;

-- 4. Opcional: Tornar o usuário superusuário (se necessário)
ALTER USER admin_chamados WITH SUPERUSER;

-- Connection string para uso em aplicações:
-- PostgreSQL: postgresql://admin_chamados:S3nh4Sup3rS3gur@!2024@localhost:5432/chamados
