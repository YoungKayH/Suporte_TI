-- Inserir tipos de usuário
INSERT INTO TIPO_USUARIO (TIPO_NOME) VALUES
('Administrador'),
('Usuário');

-- Inserir usuários
INSERT INTO USUARIOS (USU_NOME, USU_SENHA, USU_EMAIL, USU_CPF, USU_TELEFONE, USU_ENDERECO, USU_DATANASC, USU_SEXO, USU_STATUS, TIPO_ID) VALUES
('admin', '04a7bd0ff0f69f704e4b84b6ee97374d5f461bca1884363c8d2d9192eda2f0e7', 'admin@ftrsolutech.com', '12345678901', '21987654321', 'Rua Exemplo 123, Centro', '1990-05-10', 'M', 'S', 1);

-- Inserir categorias de chamado
INSERT INTO CATEGORIAS_CHAMADO (CAT_NOME) VALUES
('Software'),
('Hardware'),
('Infraestrutura');

-- Inserir prioridades
INSERT INTO PRIORIDADES (PRI_NOME) VALUES
('Alta'),
('Média'),
('Baixa');
