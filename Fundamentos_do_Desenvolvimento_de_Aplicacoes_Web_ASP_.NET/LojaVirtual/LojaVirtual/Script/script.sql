﻿CREATE TABLE PESSOA
(ID INT PRIMARY KEY  NOT NULL,
NM_NOME VARCHAR(255),
NM_SOBRENOME VARCHAR(255),
DT_NASCIMENTO DATETIME
);




CREATE TABLE [dbo].[PRODUTO] (
    [ID]         INT   NOT NULL,
    [NM_NOME]       NCHAR (255)  NOT NULL,
    [NR_PRECO]      VARCHAR (255) NOT NULL,
    [NR_QUANTIDADE] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);