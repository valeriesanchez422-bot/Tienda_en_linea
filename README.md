## Tienda en Línea (Sistema de Gestión de Envíos)

Este repositorio contiene una aplicación en **C#** para gestionar pedidos y calcular costos de envío según reglas de negocio.  
El proyecto está organizado de forma modular, separando la interfaz de usuario, la lógica de negocio y la orquestación del flujo.

---

## Integrantes

- **Valerie Sánchez Cossio**
- **Andrés Gonzalo Suárez Ríos**

---

## Descripción del Proyecto

La aplicación permite:

- Registrar pedidos ingresados por consola.
- Calcular el costo del envío según reglas de negocio.
- Aplicar condiciones como envío estándar, express o gratis.
- Mostrar el resumen del pedido.
- Utilizar programación modular con funciones bien separadas.

---

## Arquitectura del Proyecto

El código está organizado en módulos claros:

| Carpeta | Archivo | Descripción |
|--------|---------|-------------|
| `Models` | `Pedido.cs` | Modelo principal que contiene los datos del pedido ingresado por el usuario. |
| `Models` | `ResultadoPedido.cs` | Modelo que contiene el resultado final del cálculo (categoría, costo, descuentos si aplica). |
| `Services` | `CalculoService.cs` | Contiene la lógica de negocio para calcular la categoría del envío y el costo final. |
| `Services` | `PedidoController.cs` | Orquesta el procesamiento del pedido llamando los servicios de cálculo. |
| `UI` | `ConsolaUI.cs` | Maneja toda la interacción por consola (lectura de datos y presentación de resultados). |
| Raíz | `Program.cs` | Punto de entrada del programa. Solo coordina el flujo general. |

---

## Reglas de Negocio (Cálculo de Envío)

El sistema calcula la categoría del envío así:

- **Envío Gratis:** si el cliente es recurrente y el monto supera el umbral establecido.
- **Envío Express:** si el monto supera el umbral express o si la cantidad de items cumple la condición.
- **Envío Estándar:** si no se cumplen las reglas anteriores.

---

## Cómo Ejecutar la Aplicación

1. Clona o descarga este repositorio.
2. Abre el proyecto en Visual Studio o cualquier IDE compatible con C#.
3. Ejecuta el programa.
4. Ingresa los datos solicitados por consola.
5. El sistema mostrará el costo final y la categoría del envío.

---

## Flujo de Ejecución

1. El programa inicia en `Program.Main()`.
2. `Main()` solicita los datos al usuario usando `ConsolaUI`.
3. Se crea un objeto `Pedido`.
4. `PedidoController` recibe el pedido y coordina el proceso.
5. `CalculoService` realiza los cálculos del envío.
6. Se genera un objeto `ResultadoPedido`.
7. `ConsolaUI` imprime el resumen final en consola.

---

## Casos de Prueba

### Caso 1: Cliente recurrente con compra alta
Entrada:
- Cliente recurrente: Sí
- Total de compra: 200000
- Cantidad de items: 2

Salida esperada:
- Categoría: **Envío Gratis**
- Costo final: **0**

---

### Caso 2: Pedido con muchos items
Entrada:
- Cliente recurrente: No
- Total de compra: 80000
- Cantidad de items: 6

Salida esperada:
- Categoría: **Envío Express**
- Costo final: **Costo express según reglas del sistema**

---

### Caso 3: Pedido estándar
Entrada:
- Cliente recurrente: No
- Total de compra: 50000
- Cantidad de items: 2

Salida esperada:
- Categoría: **Envío Estándar**
- Costo final: **Costo estándar según reglas del sistema**

---

##  Notas Importantes

• El proyecto está desarrollado bajo el principio de **separación de responsabilidades**.  
• La lógica de cálculo está separada de la UI.  
• `Main()` solo coordina el flujo general.  
• Las funciones principales cuentan con documentación XML (`///`).  
• El proyecto es modular y cumple con los criterios de refactorización solicitados.

---

## Evidencia de Commits

Para cumplir con la rúbrica, ambos integrantes deben realizar commits en GitHub con avances reales.  
Esto se valida en la pestaña **Commits** del repositorio.

---
