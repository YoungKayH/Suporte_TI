-- Inserir tipos de usuário
INSERT INTO TIPO_USUARIO (TIPO_NOME) VALUES
('Administrador'),
('Usuário Comum');

-- Inserir usuários
INSERT INTO USUARIOS (USU_NOME, USU_SENHA, USU_EMAIL, USU_CPF, USU_TELEFONE, USU_ENDERECO, USU_DATANASC, USU_SEXO, USU_STATUS, TIPO_ID) VALUES
('João Silva', 'senha_hash_1', 'joao.silva@example.com', '12345678901', '21987654321', 'Rua Exemplo 123, Centro', '1990-05-10', 'M', 'S', 1),
('Maria Oliveira', 'senha_hash_2', 'maria.oliveira@example.com', '98765432109', '21912345678', 'Avenida Central 456, Bairro Novo', '1985-07-15', 'F', 'S', 2);

-- Inserir categorias de chamado
INSERT INTO CATEGORIAS_CHAMADO (CAT_NOME) VALUES
('Infraestrutura'),
('Software'),
('Hardware');

-- Inserir prioridades
INSERT INTO PRIORIDADES (PRI_NOME) VALUES
('Alta'),
('Média'),
('Baixa');

-- Inserir chamados
INSERT INTO CHAMADOS (CHAM_DATA, CHAM_DETALHE, CHAM_STATUS, USU_ID, CAT_ID, PRI_ID) VALUES
('2025-05-01', 'Problema com a conexão de rede no escritório.', 'ABERTO', 1, 1, 1),
('2025-05-02', 'Erro ao abrir o sistema de gestão.', 'ABERTO', 2, 2, 2);

-- Inserir interações de chamado
INSERT INTO INTERACOES_CHAMADO (CHAM_ID, USU_ID, INT_TEXTO) VALUES
(1, 1, 'Reiniciamos o roteador, mas o problema persiste.'),
(2, 2, 'Tentamos reinstalar o software, mas o erro continua.');

-- Inserir avaliações
INSERT INTO AVALIACOES (CHAM_ID, USU_ID, AVA_NOTA, AVA_COMENTARIO) VALUES
(1, 2, 5, 'Atendimento rápido e eficiente!'),
(2, 1, 4, 'Problema resolvido, mas demorou um pouco.');
