# PV_L4
Laboratorio no.4 Programación de videojuegos - Pickups 

[Video](https://youtu.be/AkHvf-OAfJk?si=7pShLj6DXwhW2f_O)

### 1. Monedas
- Al recoger una moneda, se suma al contador visible en la pantalla.  
- El contador se muestra en la UI con el formato `Monedas: X`.  
- Si el jugador tiene el ítem **Imán**, cada moneda recogida vale **el doble**.

### 2. Corazones
- Cada corazón recogido **aumenta la vida del jugador en +1**.  
- Si el jugador ya está en su **máximo de vidas**, no se añade más vida.  
- La UI se actualiza mostrando las vidas actuales tenga el jugador.

### 3. Llave
- La llave se recoge y se guarda en el inventario.  
- Mientras no se tenga, la puerta muestra un mensaje en pantalla:  
  *"Necesitas una llave para abrir la puerta"*.  
- Cuando el jugador obtiene la llave, la puerta puede abrirse y el mensaje desaparece.


### 4. Imán
- El ítem **Imán** modifica el comportamiento de las monedas.  
- Mientras el jugador tenga un Imán en el inventario, cada moneda recogida suma **2** en lugar de **1**.

### 5. Aid Kit
- El **Aid Kit** es un `ValuedItemData` con un valor de 3.  
- Al recogerlo, aparece en el inventario.  
- El jugador puede **usarlo en cualquier momento presionando la tecla `H`**.  
- Al usarse:
  - Se consume **una unidad del Aid Kit** del inventario.  
  - El jugador recupera la cantidad de vidas definida en el `value`, sin superar el máximo de vidas.  
  - La UI del inventario se actualiza automáticamente.
---

- Cada PickUp tiene su **modelo 3D** y su **ScriptableObject** con nombre, ícono, efecto de sonido y dependiendo de que tipo es su valor, si va al inventario y si se debe hacer un stack si hay varios de ellas en el inventario.  
- Al recogerlos se disparan **eventos**, que actualizan score, UI o habilitan acciones.  
- El **UI** muestra ícono y nombre de los ítems recogidos que vayan al inventario.  

