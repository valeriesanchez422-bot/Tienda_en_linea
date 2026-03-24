## Sistema de Gestión de Logística - Tienda en Línea

**Integrantes:**
* Valerie Sanchez Cossio
* Andres Gonzalo Suarez Rios

---

### Descripción del problema
Una tienda en línea necesita un sistema robusto que clasifique los pedidos según reglas de negocio para determinar la categoría de despacho, el costo de envío y mantenga un registro histórico de las operaciones realizadas en la sesión.

**El sistema evalúa:**
* **Monto del pedido:** Define umbrales de costo y gratuidad.
* **Tipo de cliente:** Clasificado como Nuevo o Recurrente (implementado mediante `Enum`).
* **Cantidad de productos:** Influye en la asignación de envío Express.
* **Destino:** Determina recargos por envíos al Exterior (implementado mediante `Enum`).

---

### IPO — Diseño del Sistema (Actualizado)

| Entrada | Tipo | Descripción |
| :--- | :--- | :--- |
| `monto` | `decimal` | Valor total del pedido (Validado con TryParse). |
| `destino` | `Enum` | Selección entre Local (0) o Exterior (1). |
| `tipoCliente` | `Enum` | Selección entre Nuevo (0) o Recurrente (1). |
| `cantidadItems` | `int` | Número de productos (Validado con do-while). |

#### Proceso (Reglas de Negocio)
1. **Envío Gratis:** Si `monto` ≥ 150,000 y `tipoCliente` es Recurrente.
2. **Envío Express:** Si no es gratis y (`cantidadItems` ≥ 5 o `monto` ≥ 300,000).
3. **Envío Estándar:** En los demás casos.
4. **Recargo Exterior:** Si `destino` es Exterior, se suman 50,000 al costo base calculado.

#### Salidas
* **Categoría:** Tipo de despacho asignado (Gratis, Express o Estándar).
* **Costo Final:** Valor total incluyendo recargos por destino.
* **Historial:** Registro dinámico en una `List<T>` de todos los pedidos procesados.

---

### Tabla de Variables Técnicas
| Variable | Tipo | Propósito |
| :--- | :--- | :--- |
| `historial` | `List<RegistroPedido>` | Almacena los objetos de pedido en memoria. |
| `opcion` | `string` | Controla la navegación en el menú principal. |
| `categoria` | `string` | Guarda el nombre de la categoría de envío. |
| `costoFinal` | `decimal` | Almacena el resultado final del cálculo monetario. |

---

### Casos de Prueba Verificados

#### 1. Caso Normal (Local)
* **Entrada:** Monto: 200,000 | Tipo: Nuevo | Items: 3 | Destino: Local
* **Resultado:** Categoría: **ESTÁNDAR** | Costo: **10,000**

#### 2. Caso de Promoción (Exterior)
* **Entrada:** Monto: 150,000 | Tipo: Recurrente | Items: 1 | Destino: Exterior
* **Resultado:** Categoría: **ENVÍO GRATIS** | Costo: **50,000** (Base 0 + Recargo 50k)

#### 3. Caso de Volumen (Express)
* **Entrada:** Monto: 50,000 | Tipo: Nuevo | Items: 6 | Destino: Local
* **Resultado:** Categoría: **EXPRESS** | Costo: **20,000**

---

### Instrucciones para Compilar y Ejecutar

1. **Entorno:** Abra el proyecto en **Visual Studio**, **VS Code** (con SDK de .NET) o compiladores online como **.NET Fiddle**.
2. **Archivo:** Asegúrese de que el archivo contenga la estructura de clases y métodos de validación propuestos.
3. **Compilación:** Ejecute el programa (F5 o botón Run).
4. **Uso del Sistema:**
   * El programa presenta un **Menú Principal** interactivo.
   * Presione **1** para registrar un pedido. El sistema usará `TryParse` y `do-while` para asegurar que los datos ingresados sean válidos y positivos.
   * Presione **2** para listar el historial de todos los pedidos realizados durante la ejecución actual.
   * Presione **3** para cerrar la aplicación de forma segura.
   * 
