# EventosUCB

## Requerimiento
La empresa EventosUCB desea modernizar la gestión de inscripciones a eventos académicos, culturales y deportivos. Para ello, está desarrollando un Módulo de Registro y Pago de Eventos, el cual forma parte de una aplicación web más amplia.

### Este módulo debe permitir a los usuarios:

- Ver el listado de eventos disponibles

- Registrarse en un evento (el registro requiere siempre un pago)

- Pagar la inscripción a un evento

- Ver los eventos en los que está inscrito

---

Diagrama de casos de Uso:
![Diagrama de casos de uso](<Screenshot 2025-06-04 211924.png>)

---

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
