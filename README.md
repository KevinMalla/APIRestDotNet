# Chistes API

Este es un simple servicio web para obtener, almacenar, actualizar y eliminar chistes. Ofrece endpoints específicos para chistes aleatorios y operaciones de base de datos.

## Endpoint de Chistes

### Obtener un chiste aleatorio

- GET /jokes
  - Devuelve un chiste aleatorio.
  - Parámetros de consulta opcionales:
    - type (Chuck o Dad) - Define el origen del chiste.

### Guardar un chiste

- POST /jokes
  - Guarda un nuevo chiste en la base de datos.
  - Parámetros de solicitud:
    - text - Texto del chiste.

### Actualizar un chiste

- PUT /jokes
  - Actualiza un chiste existente en la base de datos.
    - Parámetros de solicitud:
      - number - Número identificador del chiste.

### Eliminar un chiste

- DELETE /jokes
  - Elimina un chiste de la base de datos.
  - Parámetros de solicitud:
    - number - Número identificador del chiste a eliminar.

## Endpoint Matemático

### Mínimo Común Múltiplo (MCM)

- GET /math/lcm
  - Calcula y devuelve el Mínimo Común Múltiplo de una lista de números enteros.
    - Parámetros de consulta:
    - numbers - Lista de números enteros separados por comas.

### Incremento por Uno

- GET /math/increment
  - Incrementa el número proporcionado en uno.
    - Parámetros de consulta:
    - number - Número entero a incrementar.
