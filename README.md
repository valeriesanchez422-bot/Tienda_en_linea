# Tienda_en_linea
Integrantes: Valerie Sanchez y Andres Suarez

Descripcion del problema: Una tienda en línea necesita un sistema que permita clasificar los pedidos según ciertas reglas de negocio para determinar la categoría de despacho y el costo de envío.
El sistema debe evaluar el monto del pedido, el tipo de cliente, la cantidad de productos y la ciudad destino.
Dependiendo de estas condiciones, el envío puede ser gratis, express o estándar, además de aplicar un recargo si el destino es al exterior.

Entradas:
Nombre
Tipo
Descripción
monto
decimal
Valor total del pedido
ciudad
string
Ciudad destino del pedido
tipoCliente
string
Tipo de cliente: "nuevo" o "recurrente"
cantidadItems
int
Número de productos comprados

Proceso:
Si el monto ≥ 150000 y el cliente es recurrente → Envío Gratis.
Si no se cumple lo anterior y:
cantidadItems ≥ 5 o monto ≥ 300000 → Envío Express.
En los demás casos → Envío Estándar.
Si la ciudad es "exterior" → Se suma un recargo adicional al costo de envío.

Salida:
Nombre
Tipo
Descripción
categoria
string
Tipo de envío asignado
costoEnvio
decimal
Valor final del envío
mensaje
string
Mensaje mostrado al cliente

Variables:
Variable
Tipo
Propósito
monto
decimal
Almacena el valor del pedido
ciudad
string
Guarda la ciudad destino
tipoCliente
string
Indica si el cliente es nuevo o recurrente
cantidadItems
int
Número de productos
categoria
string
Guarda la categoría de envío
costoEnvio
decimal
Guarda el costo final del envío

Casos de Prueba:

Caso Normal:
monto: 200000
tipoCliente: nuevo
cantidadItems: 3
ciudad: medellin
Resultado esperado:
Categoría: Envío Estándar
Costo: 10000

Caso Borde:
monto: 150000
tipoCliente: recurrente
cantidadItems: 1
ciudad: exterior
Resultado esperado:
Categoría: Envío Gratis
Costo: 50000 (recargo por exterior)

Instrucciones para compilar y ejecutar:
Abrir el proyecto en Visual Studio o VS Code.
Verificar que el archivo se llame Tienda_en_linea.cs.
Compilar el programa.
Ejecutar en consola.
Ingresar los datos solicitados.
