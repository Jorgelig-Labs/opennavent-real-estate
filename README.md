# Open Navent Real Estate - Rest Client

Rest Client .Net para integrar avisos por medio del API OpenNavent:


## Requisitos
- Credenciales para sandbox: Se deben solicitar las credenciales de la API para Sandbox enviando un mail a integracion@navent.com
- Editar "appsettings.json" del proyecto de Test y cambiar los valores de "ClientId" y "ClientSecret" de acuerdo a los proporcionados por Navent.

```json
{
  "NaventAccount": {
    "ClientId": "XXXXXX",
    "ClientSecret": "XXXXXX"
  }
}
```

## Contribuyendo
Todos los Pull request son bienvenidos, para cambios de mayor impacto por favor abrir un issue antes para discutir los cambios.

Antes de hacer Pull request asegurese que todos los test estan actualizados y funcionan correctamente.

## Documentacion Oficial:
- [Primeros pasos](https://open.navent.com/primerospasos/apirestprimerospasos)
- [Swagger](http://api-rela.sandbox.open.navent.com/)

## License
[MIT](https://choosealicense.com/licenses/mit/)
