# Tienda en Línea (Sistema de Gestión de Envíos)

Este repositorio contiene una aplicación en C# para gestionar pedidos y su logística de envío, organizada de manera modular para facilitar mantenimiento, pruebas y lectura.

---

## Integrantes
Valerie Sánchez Cossio 
Andrés Gonzalo Suárez Rios

---

## Descripción del proyecto

La aplicación permite:

- Registrar múltiples pedidos
- Calcular costos de envío según reglas de negocio
- Mostrar un historial de envíos
- Usar estructuras como listas, enums y un menú interactivo

---

## Arquitectura del Proyecto

El código está organizado en módulos claros:

| Carpeta | Archivo | Descripción |
|---------|---------|-------------|
| `Models` | `Enums.cs` | Define los tipos `TipoCliente` y `Destino`. |
| `Models` | `RegistroPedido.cs` | Modelo para almacenar pedidos en historial. |
| `Services` | `LogisticaService.cs` | Contiene lógica de cálculo (categoría y costo). |
| `Services` | `HistorialService.cs` | Controla el registro de pedidos en la lista historial. |
| `UI` | `ConsolaUI.cs` | Interacción con el usuario y menú principal. |
| *Raíz* | `Program.cs` | Punto de entrada que orquesta el flujo. |

---

## Cómo usar la Aplicación

1. Clona o descarga el repositorio.
2. Abre con un IDE compatible con C# (.NET).
3. Compila y ejecuta.
4. Usa el menú para:
   - Registrar nuevos pedidos.
   - Mostrar historial de envíos.
   - Salir de la aplicación.

---

## Flujo de Ejecución

1. El programa arranca en `Program.Main()`.
2. Se llama a `ConsolaUI.MostrarMenuPrincipal()` con historial.
3. El usuario elige entre registrar pedido o ver historial.
4. En registrar:
   - Se leen datos ingresados.
   - Se calcula la logística con `LogisticaService`.
   - Se registra el pedido con `HistorialService`.
   - Se muestra resumen al usuario.
5. En ver historial:
   - Se recorren los registros y se imprimen en consola.

---

## Casos de Prueba

### Caso 1

Entrada:
- Monto: 320000
- Tipo de cliente: Recurrente
- Items: 3
- Destino: Local

Resultado esperado:
- Categoría: Envío Gratis (por monto y cliente recurrente)
- Costo total: 0

### Caso 2

Entrada:
- Monto: 50000
- Tipo de cliente: Nuevo
- Items: 6
- Destino: Exterior

Resultado esperado:
- Categoría: Envío Express
- Costo total: (costo express + costo exterior)

---

## Notas Importantes

✔ El proyecto cumple con principios de **separación de responsabilidades**.  
✔ Las funciones tienen **firmas claras** sin input/output dentro de lógica.  
✔ Uso adecuado de estructuras como `List<T>` y `enum`.  
✔ Documentación XML añadida para funciones principales.  
✔ Historial adecuadamente almacenado y mostrado.
