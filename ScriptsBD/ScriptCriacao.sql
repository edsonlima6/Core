SELECT TOP (1000) [idRazaoSocial]
      ,[sRazaoSocial]
      ,[dtCadastro]
      ,[nDiaCobranca]
      ,[sCnpjCpf]
      ,[sEndereco]
      ,[sCidade]
      ,[sEstado]
      ,[nContato]
      ,[sCep]
      ,[sCorrente]
      ,[nQtdeParcelas]
      ,[nValorAproximado]
  FROM [NetDocs].[dbo].[Empresa];


  INSERT into  [NetDocs].[dbo].[Empresa]   VALUES ('SABESP',GETDATE(), 10, '34555555', null, null, null, null, null, 0, 12, 10)
   INSERT into  [NetDocs].[dbo].[Empresa]   VALUES ('SABESP',GETDATE(), 10, '34555555', null, null, null, null, null, 0, 12, 10)
    INSERT into  [NetDocs].[dbo].[Empresa]   VALUES ('SABESP',GETDATE(), 10, '34555555', null, null, null, null, null, 0, 12, 10)
     INSERT into  [NetDocs].[dbo].[Empresa]   VALUES ('SABESP',GETDATE(), 10, '34555555', null, null, null, null, null, 0, 12, 10)