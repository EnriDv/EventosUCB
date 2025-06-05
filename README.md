# EventosUCB

## Metodos HttpGet desde el navegador:

- https://localhost:(ruta en ejecucion)/api/eventos
- https://localhost:(ruta en ejecucion)/api/eventos/usuario/1234567/pagos
- https://localhost:(ruta en ejecucion)/api/eventos/usuario/1234567/inscripciones

## desde postman: 

- https://localhost:(ruta en ejecucion)/api/eventos/registrarse
    - Body:
    `
    {
    "eventoId": 101,
    "usuarioCi": "1234567" 
    }
    `

- https://localhost:(ruta en ejecucion)/api/eventos/pagar
    - Body:
    `
    {
    "inscripcionId": 2,
    "montoPagado": 100.00 
    }
    `
